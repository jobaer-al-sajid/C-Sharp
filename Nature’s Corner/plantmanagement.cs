using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class plantmanagement : Form
    {
        private readonly string _conn = @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        private DataTable _inventoryTable;
        private DataView _inventoryView;

        public plantmanagement()
        {
            InitializeComponent();

            this.guna2Button2.Click += guna2Button2_PlantView_Click;   // event handler attach
            this.guna2Button1.Click += guna2Button1_PlantAdd_Click;    
            this.guna2Button3.Click += guna2Button3_PlantDelete_Click; 
            this.guna2Button4.Click += guna2Button4_Back_Click;        

   
            this.guna2TextBox1.TextChanged += guna2TextBox1_TextChanged; 
            this.guna2TextBox2.TextChanged += guna2TextBox2_TextChanged; 

            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dataGridView1.AutoGenerateColumns = true; // auto generate grid dhekabe 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // table e jaite sob valo vabe dit hoiye jai
            dataGridView1.ReadOnly = true; // only read only kono edit kora jabe na 
            dataGridView1.AllowUserToAddRows = false; // nicher fhaka nicher row hide kore dei 
            dataGridView1.RowHeadersVisible = false; // row header invisible kore 
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // click korle pura row select hoiye jai 
            dataGridView1.MultiSelect = false; // ekabre ektai row select hobe 
        }


        private void guna2Button2_PlantView_Click(object sender, EventArgs e)
        {
            LoadInventory(); // just method call kora hoyeche 
        }

        private void LoadInventory()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_conn))
                using (SqlCommand cmd = new SqlCommand(@"
                        SELECT [Name], [Category], [Quantity], [Price]
                        FROM dbo.inventory
                        ORDER BY [Name];", cn))
                {
                    _inventoryTable = new DataTable();
                    new SqlDataAdapter(cmd).Fill(_inventoryTable);

 
                    _inventoryView = new DataView(_inventoryTable);
                    dataGridView1.DataSource = _inventoryView;

                    ApplyFilter(); 
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL error (View): " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error (View): " + ex.Message);
            }
        }


        private void guna2Button1_PlantAdd_Click(object sender, EventArgs e)
        {
            plantadd f = new plantadd();
            f.FormClosed += (s, args) => LoadInventory(); // refresh after add
            f.Show();
        }

        // ============== DELETE ==============
        private void guna2Button3_PlantDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to delete. Click Plant view first.");
                return;
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string name = row.Cells["Name"]?.Value?.ToString();
            string category = row.Cells["Category"]?.Value?.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Selected row is missing Name/Category.");
                return;
            }

            var confirm = MessageBox.Show($"Delete '{name}' ({category}) from the list?",
                                          "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cn = new SqlConnection(_conn))
                using (SqlCommand cmd = new SqlCommand(@"
                        DELETE FROM dbo.inventory
                        WHERE [Name] = @n AND [Category] = @c;", cn))
                {
                    cmd.Parameters.Add("@n", SqlDbType.NVarChar, 100).Value = name;
                    cmd.Parameters.Add("@c", SqlDbType.NVarChar, 100).Value = category;

                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Deleted successfully.");
                        LoadInventory(); // reload to reflect delete
                    }
                    else
                    {
                        MessageBox.Show("No matching row found (it may have been deleted).");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL error (Delete): " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error (Delete): " + ex.Message);
            }
        }

        // ============== BACK ==============
        private void guna2Button4_Back_Click(object sender, EventArgs e)
        {
            admindashboard ad = new admindashboard();
            ad.Show();
            this.Hide();
        }

        // ============== SEARCH (live) ==============
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) => ApplyFilter(); // Name search
        private void guna2TextBox2_TextChanged(object sender, EventArgs e) => ApplyFilter(); // Category search

        private void ApplyFilter()
        {
            if (_inventoryView == null) return;

            string name = EscapeLike(guna2TextBox1.Text.Trim());
            string cat = EscapeLike(guna2TextBox2.Text.Trim());

            // Build DataView RowFilter (case-insensitive by default for NVARCHAR)
            // Use LIKE and wildcard % for contains match
            var parts = new System.Collections.Generic.List<string>();
            if (!string.IsNullOrEmpty(name))
                parts.Add($"Convert([Name], 'System.String') LIKE '%{name}%'");
            if (!string.IsNullOrEmpty(cat))
                parts.Add($"Convert([Category], 'System.String') LIKE '%{cat}%'");

            _inventoryView.RowFilter = parts.Count > 0 ? string.Join(" AND ", parts) : string.Empty;
        }

        // Escape characters that have meaning in DataView filters: ', %, [, ]
        private string EscapeLike(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return input
                .Replace("[", "[[]")
                .Replace("%", "[%]")
                .Replace("'", "''")
                .Replace("]", "[]]");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
