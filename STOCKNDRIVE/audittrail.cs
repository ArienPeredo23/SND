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
    public partial class audittrail : Form
    {
        public audittrail()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void audittrail_Load(object sender, EventArgs e)
        {
            LoadAuditData();
            StyleGrid();
        }

        private void LoadAuditData()
        {
            try
            {
                // Join with the user table to get the Fullname instead of just the UserID
                string query = @"SELECT T2.Fullname, T1.ActionType, T1.ActionDetails, T1.Timestamp 
                                 FROM AuditTrail AS T1
                                 LEFT JOIN [user] AS T2 ON T1.UserID = T2.UserID
                                 ORDER BY T1.Timestamp DESC";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load audit trail data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            dataGridView1.Size = new Size(820, 385);

            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0) return;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

            dataGridView1.Columns["Fullname"].HeaderText = "User";
            dataGridView1.Columns["ActionType"].HeaderText = "Action Type";
            dataGridView1.Columns["ActionDetails"].HeaderText = "Details";
            dataGridView1.Columns["Timestamp"].HeaderText = "Date & Time";

            dataGridView1.Columns["Timestamp"].DefaultCellStyle.Format = "MMMM dd, yyyy h:mm tt";

            dataGridView1.Columns["ActionDetails"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.Columns["Fullname"].Width = 120;
            dataGridView1.Columns["ActionType"].Width = 120;
            dataGridView1.Columns["Timestamp"].Width = 180;
            dataGridView1.Columns["ActionDetails"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}