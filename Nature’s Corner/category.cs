using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class category : Form
    {
        private readonly string _conn =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;TrustServerCertificate=True";

        private bool _editMode = false;   // toggles Edit <-> Save

        public category()
        {
            InitializeComponent();

            // --- DataGridView setup (read-only to start) ---
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;

            // Fill সেট করার সময় resize exception এড়াতে None, data bind শেষে Fill
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.DataBindingComplete += (s, e) =>
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            };

            // প্রথমে সব ডেটা
            LoadAll();

            // ComboBox: "All, Indoor, Succulents, Flowering, Foliage, Medicinal" ইত্যাদি
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // Edit বাটনের লেখা সুধু “Edit” রাখি শুরুতে
            button1.Text = "Edit";
        }

        // ================== LOAD HELPERS ==================
        private void LoadAll()
        {
            BindGrid(@"SELECT Name, Category, Quantity, Price
                       FROM dbo.inventory
                       ORDER BY Name;");
        }

        private void LoadByCategoryKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword) ||
                keyword.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                LoadAll();
                return;
            }

            BindGrid(@"
                SELECT Name, Category, Quantity, Price
                FROM dbo.inventory
                WHERE LOWER(Category) LIKE '%' + LOWER(@kw) + '%'
                ORDER BY Name;", ("@kw", keyword.Trim()));
        }

        private void BindGrid(string sql, params (string name, object val)[] p)
        {
            try
            {
                using (var con = new SqlConnection(_conn))
                using (var da = new SqlDataAdapter(sql, con))
                {
                    foreach (var (name, val) in p)
                        da.SelectCommand.Parameters.AddWithValue(name, val ?? DBNull.Value);

                    var dt = new DataTable();
                    da.Fill(dt);

                    // bind করার সময় None রাখি; event-এ Fill হবে
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dataGridView1.DataSource = dt;

                    // Name কলামটা সবসময় read-only রাখবো (key হিসেবে ব্যবহার করবো)
                    if (dataGridView1.Columns["Name"] != null)
                        dataGridView1.Columns["Name"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================== EDIT / SAVE TOGGLE ==================
        private void SetGridEditable(bool editable)
        {
            _editMode = editable;

            // গ্রিড এডিটিং মোড
            dataGridView1.ReadOnly = !editable;
            dataGridView1.EditMode = editable
                ? DataGridViewEditMode.EditOnKeystrokeOrF2
                : DataGridViewEditMode.EditProgrammatically;

            // কোন কোন কলাম এডিটেবল হবে
            if (dataGridView1.Columns["Category"] != null)
                dataGridView1.Columns["Category"].ReadOnly = !editable;

            if (dataGridView1.Columns["Quantity"] != null)
                dataGridView1.Columns["Quantity"].ReadOnly = !editable;

            if (dataGridView1.Columns["Price"] != null)
                dataGridView1.Columns["Price"].ReadOnly = !editable;

            if (dataGridView1.Columns["Name"] != null)
                dataGridView1.Columns["Name"].ReadOnly = true; // কখনোই না

            // বাটনের লেখা
            button1.Text = editable ? "Save" : "Edit";

            // এডিট শুরু করতে কার্সর বসিয়ে দিই
            if (editable && dataGridView1.CurrentCell == null && dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["Category"];
        }

        // Edit/Save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (!_editMode)
            {
                // Edit mode ON
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No data to edit.");
                    return;
                }
                SetGridEditable(true);
                return;
            }

            // Save mode: নির্বাচিত রো DB-তে আপডেট করি
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to save.");
                return;
            }

            // গ্রিডের এডিট শেষ করে দিই যাতে সর্বশেষ টাইপও ধরা পড়ে
            dataGridView1.EndEdit();

            try
            {
                var row = dataGridView1.SelectedRows[0];

                string name = row.Cells["Name"]?.Value?.ToString();           // key (read-only)
                string cat = row.Cells["Category"]?.Value?.ToString();
                int quantity = Convert.ToInt32(row.Cells["Quantity"]?.Value ?? 0);
                decimal price = Convert.ToDecimal(row.Cells["Price"]?.Value ?? 0m);

                using (var con = new SqlConnection(_conn))
                using (var cmd = new SqlCommand(
                    @"UPDATE dbo.inventory
                      SET Category=@c, Quantity=@q, Price=@p
                      WHERE Name=@n;", con))
                {
                    cmd.Parameters.AddWithValue("@n", name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@c", (object)cat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@q", quantity);
                    cmd.Parameters.AddWithValue("@p", price);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Row saved successfully!" : "Nothing changed.");
                }

                // Save হওয়ার পর আবার read-only মোড
                SetGridEditable(false);

                // বর্তমান ফিল্টার বজায় রেখে রিলোড
                var current = comboBox1.SelectedItem?.ToString() ?? "All";
                LoadByCategoryKeyword(current);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }

        // ================== DELETE ==================
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            try
            {
                string name = dataGridView1.SelectedRows[0].Cells["Name"]?.Value?.ToString();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Selected row has no Name.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this row?",
                                    "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                using (var con = new SqlConnection(_conn))
                using (var cmd = new SqlCommand("DELETE FROM dbo.inventory WHERE Name=@n", con))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Row deleted successfully!");

                var current = comboBox1.SelectedItem?.ToString() ?? "All";
                LoadByCategoryKeyword(current);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting: " + ex.Message);
            }
        }

        // ================== FILTER (ComboBox) ==================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedItem?.ToString() ?? "All";
            LoadByCategoryKeyword(selected);
        }

        // ================== BACK ==================
        private void button2_Click(object sender, EventArgs e)
        {
            var ad = new admindashboard();
            ad.Show();
            this.Close();
        }

        // (designer stubs)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
