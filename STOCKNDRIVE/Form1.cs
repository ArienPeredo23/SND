using Microsoft.Data.SqlClient;

namespace STOCKNDRIVE
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Opacity = 0;

            for (double i = 0.0; i <= 1.0; i += 0.1)
            {
                this.Opacity = i;
                await Task.Delay(50);
            }
        }
        public void ClearCredentials()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogActivity(int userId, string fullname)
        {
            try
            {
                string query = "INSERT INTO AuditTrail (UserID, ActionType, ActionDetails, Timestamp) VALUES (@UserID, @ActionType, @ActionDetails, @Timestamp)";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ActionType", "User Login");
                        cmd.Parameters.AddWithValue("@ActionDetails", $"{fullname} logged in to the system.");
                        cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally, handle or log the error if the audit trail fails.
                // For a login screen, it's often best to not show a blocking error message here.
                Console.WriteLine("Failed to log activity: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT UserId, Fullname FROM [user] WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["UserId"]);
                            string fullname = reader["Fullname"].ToString();

                         
                            UserSession.SetCurrentUser(userId, fullname);
                            LogActivity(userId, fullname);

                            string successMessage = "";
                            if (userId == 1)
                            {
                                successMessage = "Admin Login Authorized!";
                            }
                            else
                            {
                                successMessage = "Staff Login Authorized!";
                            }
                            new AutoClosingMessageBox(successMessage, "Success", 1500).ShowDialog();

                            if (userId == 1)
                            {
                                Dashboard dashboardForm = new Dashboard();
                                dashboardForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                pos posForm = new pos();
                                posForm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
