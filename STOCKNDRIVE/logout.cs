using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace STOCKNDRIVE
{
    public partial class logout : Form
    {
        public logout()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logout_Load(object sender, EventArgs e)
        {

        }
        private void LogActivity(int userId, string fullname)
        {
            if (userId == 0) return; // Don't log if no user was in session

            try
            {
                string query = "INSERT INTO AuditTrail (UserID, ActionType, ActionDetails, Timestamp) VALUES (@UserID, @ActionType, @ActionDetails, @Timestamp)";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ActionType", "User Logout");
                        cmd.Parameters.AddWithValue("@ActionDetails", $"{fullname} logged out of the system.");
                        cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to log logout activity: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to log out?",
                                                         "Confirm Logout",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                int userIdToLog = UserSession.UserId;
                string fullnameToLog = UserSession.Fullname;

                LogActivity(userIdToLog, fullnameToLog);
                UserSession.Clear();
                this.Hide();

                LOGIN loginForm = Application.OpenForms.OfType<LOGIN>().FirstOrDefault();

                if (loginForm != null)
                {
                    loginForm.ClearCredentials();
                    loginForm.Show();
                }
                else
                {
                    loginForm = new LOGIN();
                    loginForm.Show();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
