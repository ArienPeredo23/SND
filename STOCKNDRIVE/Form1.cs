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
            // 1. Get username and password from the textboxes
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // 2. Check if the textboxes are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop the method here
            }

            // 3. Prepare the SQL query
            // This query selects the UserId if the username and password match.
            // Using @parameters is VERY IMPORTANT to prevent SQL Injection attacks.
            string query = "SELECT UserId FROM [user] WHERE Username = @Username AND Password = @Password";

            // 4. Connect to the database and run the query
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the values from your textboxes as parameters
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password); // Note: See security warning below

                        connection.Open();

                        // ExecuteScalar is good for getting a single value (like one UserId)
                        object result = command.ExecuteScalar();

                        // 5. Check the result
                        if (result != null) // This means a user was found
                        {
                            int userId = Convert.ToInt32(result);

                            if (userId == 1) // Check if the user is the admin/main user
                            {
                                // Open the Dashboard form
                                Dashboard dashboardForm = new Dashboard();
                                dashboardForm.Show();

                                // Hide the current login form
                                this.Hide();
                            }
                            else
                            {
                                // Handle other users if needed, or show a generic success message
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else // This means no user was found with that combination
                        {
                            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Clear the username and password fields
                            txtUsername.Clear();
                            txtPassword.Clear();

                            // Set the focus back to the username field for convenience
                            txtUsername.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show a general error message if something goes wrong with the database
                MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
