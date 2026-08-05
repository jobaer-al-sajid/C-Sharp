using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class plantadd : Form
    {

        private readonly string connectionString =@"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True";

        public plantadd()
        {
            InitializeComponent();


            this.guna2Button1.Click += guna2Button1_Click;
            this.guna2Button2.Click += guna2Button2_Click;
            this.guna2Button3.Click += guna2Button3_Click;
            this.guna2Button4.Click += guna2Button4_Click;

            ConfigureGrid();
            LoadPlants();
        }

        private void ConfigureGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        // ekahne loadplants hocche mehtod . 
        private void LoadPlants()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // databse string call korlam
                using (SqlCommand cmd = new SqlCommand(@"
                        SELECT [Name], [Category], [Quantity], [Price] 
                        FROM dbo.inventory
                        ORDER BY [Name];", conn))  // select diye coloumn ke select korbo .then 2nd line inventory table name .name ghulo orderby thakbe like a a,b,c,d...
                {
                    DataTable dt = new DataTable(); // ekhane upore sql r kaj korlam eita r maddome datatable e save hobe 
                    new SqlDataAdapter(cmd).Fill(dt); // eita ekta bridge .database e datatable add kore
                    dataGridView1.DataSource = dt; // eita just view dhekabe 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plants: " + ex.Message);
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = guna2TextBox1.Text.Trim();      
            string category = guna2TextBox2.Text.Trim();  

            if (!int.TryParse(guna2TextBox3.Text.Trim(), out int qty))
            {
                MessageBox.Show("Quantity must be a whole number.");
                return;
            }

            if (!decimal.TryParse(guna2TextBox4.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Price must be a number.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please enter Name and Category.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO dbo.inventory ([Name], [Category], [Quantity], [Price])
                        VALUES (@n, @c, @q, @p);", conn))
                {
                    cmd.Parameters.Add("@n", SqlDbType.NVarChar, 100).Value = name;
                    cmd.Parameters.Add("@c", SqlDbType.NVarChar, 100).Value = category;
                    cmd.Parameters.Add("@q", SqlDbType.Int).Value = qty;
                    cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = price;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Plant added successfully!");
                LoadPlants();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding plant: " + ex.Message);
            }
        }

        private void ClearInputs()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to delete. Click Plant view first.");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string name = row.Cells["Name"]?.Value?.ToString();
            string category = row.Cells["Category"]?.Value?.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Selected row missing Name/Category.");
                return;
            }

            var confirm = MessageBox.Show($"Delete '{name}' ({category})?", "Confirm",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                        DELETE FROM dbo.inventory
                        WHERE [Name] = @n AND [Category] = @c;", conn))
                {
                    cmd.Parameters.Add("@n", SqlDbType.NVarChar, 100).Value = name;
                    cmd.Parameters.Add("@c", SqlDbType.NVarChar, 100).Value = category;

                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("🗑 Deleted successfully.");
                        LoadPlants();
                    }
                    else
                    {
                        MessageBox.Show("No matching row found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting plant: " + ex.Message);
            }
        }

        // ===== View button =====
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadPlants();
        }

        // ===== Back =====
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // If you want to go back to admin dashboard:
            // var ad = new admindashboard();
            // ad.Show();
            // this.Hide();

            // Or just close this form:
            this.Close();
        }

        // (Designer wired this accidentally – keep empty or remove)
        private void guna2Button2_Click_1(object sender, EventArgs e) { }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
