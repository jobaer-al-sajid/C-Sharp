using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class setting : Form
    {
        // DB connection
        private readonly string _conn =
            @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // (optional) who opened this form — so Back can return there
        private readonly Form parent;

        public setting()
        {
            InitializeComponent();
            WireUi();
        }

        public setting(Form parent) : this()
        {
            parent = parent;
        }

        private void WireUi()
        {
            // You can prefill current username to help user
            if (!string.IsNullOrWhiteSpace(AppSession.UserName))
                textBox1.Text = AppSession.UserName;

            // Mask password boxes
            textBox2.UseSystemPasswordChar = true; // new password
            textBox3.UseSystemPasswordChar = true; // confirm

            // Hook buttons (if designer didn’t already)
            button1.Click += button1_Click; // Save
            button2.Click += button2_Click; // Back
        }

        // -------- SAVE ----------
        private void button1_Click(object sender, EventArgs e)
        {
            string newUser = textBox1.Text.Trim();
            string newPass = textBox2.Text.Trim();
            string confirm = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(newUser) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Please fill all fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Optional: simple length rule
            if (newPass.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Who am I?
            var currentUser = AppSession.UserName?.Trim();
            if (string.IsNullOrEmpty(currentUser))
            {
                MessageBox.Show("Current user not detected. Please log in again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();

                    // 1) Prevent duplicate usernames (other than current)
                    using (var check = new SqlCommand(
                        @"SELECT COUNT(*) FROM dbo.login 
                          WHERE UserName = @u AND UserName <> @me;", cn))
                    {
                        check.Parameters.Add("@u", SqlDbType.NVarChar, 200).Value = newUser;
                        check.Parameters.Add("@me", SqlDbType.NVarChar, 200).Value = currentUser;

                        int exists = Convert.ToInt32(check.ExecuteScalar());
                        if (exists > 0)
                        {
                            MessageBox.Show("That username is already in use. Choose another.",
                                "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2) Update this user’s row
                    using (var cmd = new SqlCommand(
                        @"UPDATE dbo.login
                          SET UserName = @newUser, [Password] = @newPass
                          WHERE UserName = @me;", cn))
                    {
                        cmd.Parameters.Add("@newUser", SqlDbType.NVarChar, 200).Value = newUser;
                        cmd.Parameters.Add("@newPass", SqlDbType.NVarChar, 200).Value = newPass;
                        cmd.Parameters.Add("@me", SqlDbType.NVarChar, 200).Value = currentUser;

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            // keep session in sync (username may have changed)
                            AppSession.UserName = newUser;

                            MessageBox.Show("Updated successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            textBox2.Clear();
                            textBox3.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No matching user found to update.",
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------- BACK ----------
        private void button2_Click(object sender, EventArgs e)
        {
            if (parent != null && !parent.IsDisposed)
            {
                parent.Show();
                this.Close();
                return;
            }

            // Fallback if parent wasn’t passed: go by role
            if (AppSession.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                new admindashboard().Show();
            }
            else
            {
                new employeedashboard().Show();
            }
            this.Close();
        }

        // (Designer auto-generated empty handlers – safe to leave)
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void setting_Load(object sender, EventArgs e)
        {

        }
    }
}
