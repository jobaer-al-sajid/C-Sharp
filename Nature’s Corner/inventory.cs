using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class inventory : Form
    {
        // ✅ Connection string
        private readonly string _conn =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // ✅ Store parent form (admin or employee)
        private readonly Form _parent;

        // Default constructor
        public inventory()
        {
            InitializeComponent();
            this.Load += inventory_Load;
            button1.Click += button1_Click;  // ← Back button
        }

        // Overloaded constructor for parent form
        public inventory(Form parent) : this()
        {
            _parent = parent;
        }

        // ===================== FORM LOAD =====================
        private void inventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        // ===================== LOAD INVENTORY =====================
        private void LoadInventory(string searchName = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conn))
                {
                    con.Open();

                    string query = string.IsNullOrWhiteSpace(searchName)
                        ? "SELECT * FROM dbo.inventory"
                        : "SELECT * FROM dbo.inventory WHERE [Name] LIKE @n";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrWhiteSpace(searchName))
                            cmd.Parameters.AddWithValue("@n", "%" + searchName + "%");

                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        dataGridView1.DataSource = dt;

                        // Adjust GridView appearance
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message);
            }
        }

        // ===================== SEARCH BOX =====================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadInventory(txtsearch.Text.Trim());
        }

        // ===================== BACK BUTTON =====================
        private void button1_Click(object sender, EventArgs e)
        {
            if (_parent != null && !_parent.IsDisposed)
            {
                // ✅ Return to the form that opened this (Admin or Employee)
                _parent.Show();
                this.Close();
            }
            else
            {
                // ✅ Fallback: if no parent found → open Admin Dashboard
                admindashboard ad = new admindashboard();
                ad.Show();
                this.Close();
            }
        }

        // If form is closed using [X] button
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_parent != null && !_parent.IsDisposed)
                _parent.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
