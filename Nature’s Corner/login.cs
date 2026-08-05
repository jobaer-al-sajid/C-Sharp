using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            passwordtextbox.PasswordChar = '*';
        }

        private void passhidebox_CheckedChanged(object sender, EventArgs e)
        {
            passwordtextbox.PasswordChar = passhidebox.Checked ? '\0' : '*';
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            string connectionString =
                @"Data Source=DESKTOP-SAJID\SQLEXPRESS1;Initial Catalog=login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string username = usernametextbox.Text.Trim();
            string password = passwordtextbox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT Role FROM dbo.login WHERE UserName=@username AND Password=@password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object roleObj = cmd.ExecuteScalar();

                        if (roleObj != null)
                        {
                            string role = roleObj.ToString().Trim();

                            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {

                                AppSession.UserName = username;
                                AppSession.Role = "Admin";

                                MessageBox.Show($"Welcome Admin {username}!", "Login Successful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                admindashboard ad = new admindashboard();
                                ad.Show();
                                this.Hide();
                            }
                            else if (role.Equals("Employee", StringComparison.OrdinalIgnoreCase))
                            {

                                AppSession.UserName = username;
                                AppSession.Role = "Employee";

                                MessageBox.Show($"Welcome Employee {username}!", "Login Successful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                var ed = new employeedashboard();
                                ed.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Unknown Role detected!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password!", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usernametextbox_TextChanged(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }

        private void usernametextbox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
