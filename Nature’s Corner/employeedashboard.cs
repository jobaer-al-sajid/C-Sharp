using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class employeedashboard : Form
    {
        // ✅ Connection string
        private readonly string _conn =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;TrustServerCertificate=True";

        public employeedashboard()
        {
            InitializeComponent();

            // Header
            dashboardlabel.Text = "Dashboard";
            dashboardlabel.TextAlignment = ContentAlignment.MiddleCenter;

            // Grid setup (numbers only)
            ConfigureGrid(dataGridView1);
            ConfigureGrid(dataGridView2);

            // Wire button clicks
            dashboardbutton.Click += dashboardbutton_Click;
            salesandbillingbutton.Click += salesandbillingbutton_Click;
            inventorybutton.Click += inventorybutton_Click;
            salesreportbutton.Click += salesreportbutton_Click;
            settingbutton.Click += settingbutton_Click;   // ← open settings now
            logoutbutton.Click += logoutbutton_Click;

            // Load on form load
            this.Load += employeedashboard_Load;
        }

        private void ConfigureGrid(DataGridView gv)
        {
            gv.AutoGenerateColumns = true;
            gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gv.ReadOnly = true;
            gv.AllowUserToAddRows = false;
            gv.RowHeadersVisible = false;
            gv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void employeedashboard_Load(object sender, EventArgs e)
        {
            LoadTotalPlants();
            LoadTodaySalesTotals();
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            LoadTotalPlants();
            LoadTodaySalesTotals();
        }

        // ===================== DATA LOADERS =====================

        // total plants (count of rows in inventory)
        private void LoadTotalPlants()
        {
            try
            {
                using (var cn = new SqlConnection(_conn))
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.inventory;", cn))
                {
                    cn.Open();
                    int totalPlants = Convert.ToInt32(cmd.ExecuteScalar());

                    totalplantlabel.Text = $"total plants: {totalPlants}";
                    totalplantlabel.TextAlignment = ContentAlignment.MiddleCenter;

                    var dt = new DataTable();
                    dt.Columns.Add("total_plants", typeof(int));
                    dt.Rows.Add(totalPlants);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total plants: " + ex.Message);
            }
        }

        // today's sales: orders count + total amount (Price sum)
        private void LoadTodaySalesTotals()
        {
            try
            {
                using (var cn = new SqlConnection(_conn))
                using (var cmd = new SqlCommand(@"
                    SELECT 
                        COUNT(*) AS orders_today,
                        COALESCE(SUM(TRY_CONVERT(decimal(18,2), Price)), 0) AS total_today
                    FROM dbo.sales
                    WHERE CONVERT(date, [Date]) = CONVERT(date, GETDATE());", cn))
                {
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    int orders = 0;
                    decimal total = 0m;

                    if (dt.Rows.Count > 0)
                    {
                        orders = Convert.ToInt32(dt.Rows[0]["orders_today"]);
                        total = Convert.ToDecimal(dt.Rows[0]["total_today"]);
                    }

                    todaysaleslabel.Text = $"today's sales: {orders}   total: {total:0.##} tk";
                    todaysaleslabel.TextAlignment = ContentAlignment.MiddleCenter;

                    var onlyNums = new DataTable();
                    onlyNums.Columns.Add("orders_today", typeof(int));
                    onlyNums.Columns.Add("total_today", typeof(decimal));
                    onlyNums.Rows.Add(orders, total);
                    dataGridView2.DataSource = onlyNums;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's sales: " + ex.Message);
            }
        }

        // ===================== NAVIGATION =====================

        // Sales (pass parent so Back returns here)
        private void salesandbillingbutton_Click(object sender, EventArgs e)
        {
            var s = new sales(this);   // sales form should have (Form parent) ctor
            this.Hide();
            s.Show();
        }

        // Inventory (pass parent so Back returns here)
        private void inventorybutton_Click(object sender, EventArgs e)
        {
            var i = new inventory(this); // inventory form with (Form parent) ctor
            this.Hide();
            i.Show();
        }

        // Sales Report (pass parent so Back returns here)
        private void salesreportbutton_Click(object sender, EventArgs e)
        {
            var sr = new salesreport(this); // salesreport with (Form parent) ctor
            this.Hide();
            sr.Show();
        }

        // Settings — open settings and return back here on Back/Close
        private void settingbutton_Click(object sender, EventArgs e)
        {
            var s = new setting(this); // make sure setting has a ctor: public setting(Form parent)
            this.Hide();
            s.Show();
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            var l = new login();
            l.Show();
            this.Close();
        }

        // Designer stubs
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e) { }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            // If you still have a second settings button, keep it consistent
            var s = new setting(this);
            this.Hide();
            s.Show();
        }
    }
}
