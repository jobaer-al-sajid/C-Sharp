using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class salesreport : Form
    {
        private readonly string _conn =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // ✅ Reference to the parent (Admin or Employee dashboard)
        private readonly Form _parent;

        public salesreport()
        {
            InitializeComponent();

            // Wire up events (if not connected in designer)
            button1.Click += button1_Click_Generate;  // "Generate Report" button
            button2.Click += button2_Click;           // ← Back button
            this.Load += salesreport_Load;
        }

        // ✅ Overloaded constructor to accept the parent form
        public salesreport(Form parent) : this()
        {
            _parent = parent;
        }

        // ===================== FORM LOAD =====================
        private void salesreport_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today.AddDays(-7);
        }

        // ===================== GENERATE REPORT =====================
        private void button1_Click_Generate(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value.Date;
            DateTime to = dateTimePicker2.Value.Date;

            if (from > to)
            {
                MessageBox.Show("Start Date cannot be after End Date.");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(_conn))
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT [Date], [CustomerName], [Payment], [Quantity], [Price]
                    FROM dbo.sales
                    WHERE CONVERT(date, [Date]) BETWEEN @f AND @t
                    ORDER BY [Date];", cn))
                {
                    cmd.Parameters.Add("@f", SqlDbType.Date).Value = from;
                    cmd.Parameters.Add("@t", SqlDbType.Date).Value = to;

                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL error: " + ex.Message);
            }
        }

        // ===================== BACK BUTTON =====================
        private void button2_Click(object sender, EventArgs e)
        {
            // ✅ If this form was opened from a parent dashboard, go back there
            if (_parent != null && !_parent.IsDisposed)
            {
                _parent.Show();
                this.Close();
            }
            else
            {
                // ✅ Fallback (if opened directly) → return to Admin Dashboard
                admindashboard ad = new admindashboard();
                ad.Show();
                this.Close();
            }
        }

        // ✅ If closed using [X], show parent again
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_parent != null && !_parent.IsDisposed)
                _parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
