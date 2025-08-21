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
    public partial class usermanagement : Form
    {
        private DataTable userDataTable;
        private bool isEditing = false;
        private int currentlyEditingRowIndex = -1;
        private bool isBlinkOn = false;

        public usermanagement()
        {
            InitializeComponent();
            editBlinkTimer.Tick += new System.EventHandler(this.editBlinkTimer_Tick);
        }

        private void usermanagement_Load(object sender, EventArgs e)
        {
            LoadAndStyleData();
        }

        private void LoadAndStyleData()
        {
            LoadUserData();
            StyleGrid();
        }

        private void editBlinkTimer_Tick(object sender, EventArgs e)
        {
            if (currentlyEditingRowIndex >= 0 && currentlyEditingRowIndex < dataGridView1.Rows.Count)
            {
                isBlinkOn = !isBlinkOn;
                DataGridViewRow row = dataGridView1.Rows[currentlyEditingRowIndex];
                Color backColor = isBlinkOn ? Color.Yellow : SystemColors.Window;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = backColor;
                }
            }
        }

        private void LogActivity(string actionType, string actionDetails)
        {
            try
            {
                string query = "INSERT INTO AuditTrail (UserID, ActionType, ActionDetails, Timestamp) VALUES (@UserID, @ActionType, @ActionDetails, @Timestamp)";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserId);
                        cmd.Parameters.AddWithValue("@ActionType", actionType);
                        cmd.Parameters.AddWithValue("@ActionDetails", actionDetails);
                        cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit Log Failed: " + ex.Message);
            }
        }

        private void LoadUserData()
        {
            try
            {
                string query = "SELECT UserId, Fullname, Username, Password FROM [user]";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    userDataTable = new DataTable();
                    adapter.Fill(userDataTable);
                    dataGridView1.DataSource = userDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            if (dataGridView1.Columns.Contains("EditCol"))
                dataGridView1.Columns.Remove("EditCol");
            if (dataGridView1.Columns.Contains("DeleteCol"))
                dataGridView1.Columns.Remove("DeleteCol");

            if (dataGridView1.Columns.Contains("UserId"))
            {
                dataGridView1.Columns["UserId"].Visible = false;
            }

            dataGridView1.ReadOnly = false;
            dataGridView1.Columns["Fullname"].ReadOnly = true;
            dataGridView1.Columns["Username"].ReadOnly = true;
            dataGridView1.Columns["Password"].ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditCol";
            editButtonColumn.HeaderText = "";
            editButtonColumn.UseColumnTextForButtonValue = false;
            dataGridView1.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteCol";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["EditCol"].Value = "Edit";
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value);
            if (userId == 1 && (e.ColumnIndex == dataGridView1.Columns["EditCol"].Index || e.ColumnIndex == dataGridView1.Columns["DeleteCol"].Index))
            {
                MessageBox.Show("The admin user cannot be edited or deleted.", "Operation Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.ColumnIndex == dataGridView1.Columns["EditCol"].Index)
            {
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridView1.Rows[e.RowIndex].Cells["EditCol"];
                if (buttonCell.Value.ToString() == "Edit")
                {
                    HandleEditClick(e.RowIndex);
                }
                else
                {
                    HandleUpdateClick(e.RowIndex);
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteCol"].Index)
            {
                HandleDeleteClick(e.RowIndex);
            }
        }

        private void HandleEditClick(int rowIndex)
        {
            isEditing = true;
            SetEditingState(true, rowIndex);
        }

        private void HandleUpdateClick(int rowIndex)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                int userId = Convert.ToInt32(row.Cells["UserId"].Value);
                string fullname = row.Cells["Fullname"].Value.ToString();
                string username = row.Cells["Username"].Value.ToString();
                string password = row.Cells["Password"].Value.ToString();

                if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "UPDATE [user] SET Fullname = @Fullname, Username = @Username, Password = @Password WHERE UserId = @UserId";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fullname", fullname);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                LogActivity("Update User", $"{UserSession.Fullname} updated the user account for '{fullname}'.");
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetEditingState(false, -1);
                LoadAndStyleData();
            }
        }

        private void HandleDeleteClick(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string userToDeleteName = dataGridView1.Rows[rowIndex].Cells["Fullname"].Value.ToString();
                try
                {
                    int userId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["UserId"].Value);
                    string query = "DELETE FROM [user] WHERE UserId = @UserId";
                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LogActivity("Delete User", $"{UserSession.Fullname} deleted the user account for '{userToDeleteName}'.");
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAndStyleData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetEditingState(bool isEditing, int editingRowIndex)
        {
            this.isEditing = isEditing;
            btnAddUser.Enabled = !isEditing;
            button4.Enabled = !isEditing;

            editBlinkTimer.Stop();
            if (currentlyEditingRowIndex >= 0 && currentlyEditingRowIndex < dataGridView1.Rows.Count)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[currentlyEditingRowIndex].Cells)
                {
                    cell.Style.BackColor = SystemColors.Window;
                }
            }
            currentlyEditingRowIndex = editingRowIndex;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (isEditing)
                {
                    if (i == editingRowIndex)
                    {
                        row.Cells["Fullname"].ReadOnly = false;
                        row.Cells["Username"].ReadOnly = false;
                        row.Cells["Password"].ReadOnly = false;
                        row.Cells["EditCol"].Value = "Update";
                        row.Cells["DeleteCol"].Style.BackColor = Color.Gray;
                    }
                    else
                    {
                        row.Cells["EditCol"].Style.BackColor = Color.Gray;
                        row.Cells["DeleteCol"].Style.BackColor = Color.Gray;
                    }
                }
                else
                {
                    row.Cells["Fullname"].ReadOnly = true;
                    row.Cells["Username"].ReadOnly = true;
                    row.Cells["Password"].ReadOnly = true;
                    row.Cells["EditCol"].Value = "Edit";
                    row.Cells["EditCol"].Style.BackColor = SystemColors.Window;
                    row.Cells["DeleteCol"].Style.BackColor = SystemColors.Window;
                }
            }
            if (isEditing)
            {
                isBlinkOn = false;
                editBlinkTimer.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (AddUserForm addUserForm = new AddUserForm())
            {
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string query = "INSERT INTO [user] (Fullname, Username, Password) VALUES (@Fullname, @Username, @Password)";
                        using (SqlConnection conn = DBConnection.GetConnection())
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Fullname", addUserForm.Fullname);
                                cmd.Parameters.AddWithValue("@Username", addUserForm.Username);
                                cmd.Parameters.AddWithValue("@Password", addUserForm.Password);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        LogActivity("Add User", $"{UserSession.Fullname} added a new user: '{addUserForm.Fullname}'.");
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAndStyleData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to add user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}