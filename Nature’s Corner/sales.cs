using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class sales : Form
    {
        // SQL connection
        private readonly string _connStr =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Who opened this form (admin/employee)? Used for Back.
        private readonly Form _parent;

        public sales()
        {
            InitializeComponent();
            WireEvents();
        }

        // Use this from Admin/Employee dashboards: new sales(this)
        public sales(Form parent) : this()
        {
            _parent = parent;
        }

        private void WireEvents()
        {
            btnsave.Click += btnsave_Click;
            btndownload.Click += btndownload_Click;
            button1.Click += button1_Click; // Back button on this form
        }

        // ========================= SAVE =========================
        private void btnsave_Click(object sender, EventArgs e)
        {
            // Quantity
            if (!int.TryParse(txtquantity.Text.Trim(), out int quantity))
            {
                MessageBox.Show("Please enter a valid Quantity (integer).");
                txtquantity.Focus();
                return;
            }

            // Price
            if (!decimal.TryParse(txtprice.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price))
            {
                MessageBox.Show("Please enter a valid Price (number).");
                txtprice.Focus();
                return;
            }

            string customerName = txtcname.Text.Trim();
            string number = txtnumber.Text.Trim();
            string payment = comboBox1.Text?.Trim();

            if (string.IsNullOrWhiteSpace(customerName) ||
                string.IsNullOrWhiteSpace(number) ||
                string.IsNullOrWhiteSpace(payment))
            {
                MessageBox.Show("Customer Name, Number and Payment are required.");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(_connStr))
                using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.sales ([Date], [Quantity], [CustomerName], [Number], [Payment], [Price])
                    VALUES (@Date, @Quantity, @CustomerName, @Number, @Payment, @Price);", conn))
                {
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                    cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar, 200).Value = customerName;
                    cmd.Parameters.Add("@Number", SqlDbType.NVarChar, 50).Value = number;
                    cmd.Parameters.Add("@Payment", SqlDbType.NVarChar, 50).Value = payment;

                    var p = cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    p.Precision = 18; p.Scale = 2; p.Value = price;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Sale saved successfully!");

                // Clear fields
                txtquantity.Clear();
                txtcname.Clear();
                txtnumber.Clear();
                txtprice.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;

                // (txtdiscount থাকলে UI-তে রেখে দিলেও আর ব্যবহার হচ্ছে না)
                // txtdiscount.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ========================= DOWNLOAD CSV =========================
        private void btndownload_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(_connStr))
                using (var cmd = new SqlCommand(@"
                    SELECT [Date], [Quantity], [CustomerName], [Number], [Payment], [Price]
                    FROM dbo.sales
                    ORDER BY [Date] DESC;", conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    using (var sfd = new SaveFileDialog
                    {
                        Filter = "CSV files (*.csv)|*.csv",
                        FileName = "SalesHistory.csv"
                    })
                    {
                        if (sfd.ShowDialog() != DialogResult.OK) return;

                        using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            // header (no Discount)
                            sw.WriteLine("Date,Quantity,CustomerName,Number,Payment,Price");

                            while (rdr.Read())
                            {
                                string dateStr = Convert.ToDateTime(rdr["Date"])
                                    .ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                                string Esc(string s)
                                {
                                    if (s == null) return "";
                                    bool needQuotes = s.Contains(",") || s.Contains("\"") || s.Contains("\n");
                                    return needQuotes ? "\"" + s.Replace("\"", "\"\"") + "\"" : s;
                                }

                                string line = string.Join(",",
                                    Esc(dateStr),
                                    rdr["Quantity"].ToString(),
                                    Esc(rdr["CustomerName"]?.ToString() ?? ""),
                                    Esc(rdr["Number"]?.ToString() ?? ""),
                                    Esc(rdr["Payment"]?.ToString() ?? ""),
                                    Convert.ToDecimal(rdr["Price"]).ToString(CultureInfo.InvariantCulture)
                                );

                                sw.WriteLine(line);
                            }
                        }

                        MessageBox.Show("Download complete.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ========================= BACK =========================
        private void button1_Click(object sender, EventArgs e)
        {
            if (_parent != null && !_parent.IsDisposed)
            {
                _parent.Show();
                this.Close();
            }
            else
            {
                new admindashboard().Show();
                this.Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_parent != null && !_parent.IsDisposed) _parent.Show();
        }

        // Optional existing handlers
        private void lblprice_Click(object sender, EventArgs e) { }
        private void txtprice_TextChanged(object sender, EventArgs e) { }
        private void txtquantity_TextChanged(object sender, EventArgs e) { }
    }
}
