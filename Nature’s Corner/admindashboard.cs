using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class admindashboard : Form
    {
        private readonly string connectionString =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public admindashboard()
        {
            InitializeComponent();
            SetButtonTexts();

            ConfigureGridAsTotal(gridplants);
            ConfigureGridAsTotal(gridsales);
            ConfigureGridAsTotal(gridemployees);

            this.Load += admindashboard_Load;


            dashboardbutton.Click += dashboardbutton_Click;
            plantmanagementbutton.Click += plantmanagementbutton_Click;
            categorymanagementbutton.Click += categorymanagementbutton_Click;
            salesandbillingbutton.Click += salesandbillingbutton_Click;
            inventorybutton.Click += inventorybutton_Click;
            salesreportsbutton.Click += salesreportsbutton_Click;
            employeemanagmentbutton.Click += employeemanagmentbutton_Click;
            logoutbutton.Click += logoutbutton_Click;


            CenterHeaderLabel(totalplantlabel, "total plants");
            CenterHeaderLabel(todaysaleslabel, "today's sales");
            CenterHeaderLabel(totalemployeelabel, "total employees");
        }

        private void admindashboard_Load(object sender, EventArgs e)
        {
            LoadPlantsTotal();
            LoadTodaySalesTotal();
            LoadEmployeesTotal();
        }

        private void SetButtonTexts()
        {
            dashboardbutton.Text = "Dashboard";
            plantmanagementbutton.Text = "Plant Management";
            categorymanagementbutton.Text = "Category Management";
            salesandbillingbutton.Text = "Sales";
            inventorybutton.Text = "Inventory";
            salesreportsbutton.Text = "Sales Report";
            employeemanagmentbutton.Text = "Employee Management";
            settingbutton.Text = "Setting";
            logoutbutton.Text = "Log Out";
        }

        private void CenterHeaderLabel(Guna.UI2.WinForms.Guna2HtmlLabel lbl, string text)
        {
            lbl.Text = text;
            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Top;
            lbl.Height = 32;
            lbl.TextAlignment = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(0, 64, 0);
        }


        private void ConfigureGridAsTotal(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;              
            gv.Columns.Clear();

            var col = new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total",
                DataPropertyName = "Total",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            gv.Columns.Add(col);

            gv.ReadOnly = true;
            gv.AllowUserToAddRows = false;
            gv.AllowUserToDeleteRows = false;
            gv.RowHeadersVisible = false;
            gv.ColumnHeadersVisible = true;

            gv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            gv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);


            gv.Height = 90;
        }

        private DataTable OneNumberTable(int value)
        {
            var dt = new DataTable();
            dt.Columns.Add("Total", typeof(int));
            dt.Rows.Add(value);
            return dt;
        }


        private void LoadPlantsTotal()
        {
            try
            {
                int total;
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.inventory;", con))
                {
                    con.Open();
                    total = (int)cmd.ExecuteScalar();
                }
                gridplants.DataSource = OneNumberTable(total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total plants: " + ex.Message);
            }
        }

        private void LoadTodaySalesTotal()
        {
            try
            {
                int totalToday;
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM dbo.sales
                        WHERE CONVERT(date, [Date]) = CONVERT(date, GETDATE());", con))
                {
                    con.Open();
                    totalToday = (int)cmd.ExecuteScalar();
                }
                gridsales.DataSource = OneNumberTable(totalToday);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's sales: " + ex.Message);
            }
        }

        private void LoadEmployeesTotal()
        {
            try
            {
                int totalEmp;
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.employeemanagement;", con))
                {
                    con.Open();
                    totalEmp = (int)cmd.ExecuteScalar();
                }
                gridemployees.DataSource = OneNumberTable(totalEmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total employees: " + ex.Message);
            }
        }


        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            LoadPlantsTotal();
            LoadTodaySalesTotal();
            LoadEmployeesTotal();
        }

        private void plantmanagementbutton_Click(object sender, EventArgs e)
        {
            var pm = new plantmanagement();
            pm.Show();
            this.Close();
        }

        private void categorymanagementbutton_Click(object sender, EventArgs e)
        {
            var c = new category();
            c.Show();
            this.Hide();
        }

        private void salesandbillingbutton_Click(object sender, EventArgs e)
        {
            var s = new sales();
            s.Show();
            this.Hide();
        }

        private void inventorybutton_Click(object sender, EventArgs e)
        {
            inventory i = new inventory(this);
            i.Show();
            this.Hide();
        }

        private void salesreportsbutton_Click(object sender, EventArgs e)
        {
            salesreport sr = new salesreport(this);
            sr.Show();
            this.Hide();
        }

        private void employeemanagmentbutton_Click(object sender, EventArgs e)
        {
            var em = new employeemanagement();
            em.Show();
            this.Hide();
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            var l = new login();
            l.Show();
            this.Close();
        }

        private void gridplants_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void gridsales_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void gridemployees_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void settingbutton_Click(object sender, EventArgs e)
        {
            var s = new setting(this);
            s.Show();
            this.Hide();
        }
    }
}
