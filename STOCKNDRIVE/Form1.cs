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

                            // Set the global user session
                            UserSession.SetCurrentUser(userId, fullname);

                            if (userId == 1) // Admin user
                            {
                                Dashboard dashboardForm = new Dashboard();
                                dashboardForm.Show();
                                this.Hide();
                            }
                            else // Any other user (ID >= 2)
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
