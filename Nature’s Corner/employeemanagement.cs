using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class employeemanagement : Form
    {
        // Connection string
        private readonly string connectionString =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;TrustServerCertificate=True";

        public employeemanagement()
        {
            InitializeComponent();

            // Nice defaults for the grid
            employeeview.ReadOnly = true;
            employeeview.AllowUserToAddRows = false;
            employeeview.MultiSelect = false;
            employeeview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeeview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Wire events (in case Designer didn’t)
            this.Load += employeemanagement_Load;
            Addbutton.Click += Addbutton_Click;
            searchbutton.Click += searchbutton_Click;
            dltbutton.Click += dltbutton_Click;          // <<< delete button
            button1.Click += button1_Click;               // back to admin
        }

        private void employeemanagement_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        // Load employees (optional search by name)
        private void LoadEmployees(string searchName = "")
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string sql = "SELECT FullName, Phone, Email, Position FROM dbo.employeemanagement";
                    if (!string.IsNullOrWhiteSpace(searchName))
                        sql += " WHERE FullName LIKE @FullName";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        if (!string.IsNullOrWhiteSpace(searchName))
                            cmd.Parameters.AddWithValue("@FullName", "%" + searchName + "%");

                        var dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        employeeview.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        // Add new employee
        private void Addbutton_Click(object sender, EventArgs e)
        {
            string fullname = txtfullname.Text.Trim();
            string phone = txtphone.Text.Trim();
            string email = txtemail.Text.Trim();
            string position = txtposition.Text.Trim();

            if (fullname == "" || phone == "" || email == "" || position == "")
            {
                MessageBox.Show("Please fill all fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(
                    @"INSERT INTO dbo.employeemanagement (FullName, Phone, Email, Position)
                      VALUES (@FullName, @Phone, @Email, @Position);", con))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullname);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Position", position);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Employee added successfully!", "Success");
                        txtfullname.Clear(); txtphone.Clear(); txtemail.Clear(); txtposition.Clear();
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add employee.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Search
        private void searchbutton_Click(object sender, EventArgs e)
        {
            LoadEmployees(employeesearchbox.Text.Trim());
        }

        // ===== DELETE SELECTED ROW (dltbutton) =====
        private void dltbutton_Click(object sender, EventArgs e)
        {
            if (employeeview.DataSource == null || employeeview.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing to delete.");
                return;
            }

            if (employeeview.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            var row = employeeview.SelectedRows[0];

            // Since there’s no Id column, delete by the full row values
            string fullname = row.Cells["FullName"]?.Value?.ToString();
            string phone = row.Cells["Phone"]?.Value?.ToString();
            string email = row.Cells["Email"]?.Value?.ToString();
            string position = row.Cells["Position"]?.Value?.ToString();

            if (string.IsNullOrWhiteSpace(fullname) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Selected row is missing data.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete employee:\n\nName: {fullname}\nPhone: {phone}\nEmail: {email}\nPosition: {position}\n\nAre you sure?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(
                    // Delete a single matching row
                    @"DELETE TOP(1) FROM dbo.employeemanagement
                      WHERE FullName=@FullName AND Phone=@Phone AND Email=@Email AND Position=@Position;", con))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullname);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Position", position);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Employee deleted successfully.");
                        LoadEmployees(); // refresh
                    }
                    else
                    {
                        MessageBox.Show("No matching row was found (it may already be deleted).");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee: " + ex.Message);
            }
        }

        // Back to admin dashboard
        private void button1_Click(object sender, EventArgs e)
        {
            var ad = new admindashboard();
            ad.Show();
            this.Close();
        }

        // Designer-generated empty handlers (safe to keep)
        private void fullnamelabel_Click(object sender, EventArgs e) { }
        private void fullnametextbox_TextChanged(object sender, EventArgs e) { }
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void employeeview_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
    }
}
