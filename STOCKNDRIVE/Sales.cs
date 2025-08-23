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
    public partial class Sales : Form
    {
        private bool isPanelExpanded = false;
        private int settingsPanelStartHeight;
        private int settingsPanelTargetHeight;

        private DataTable salesDataTable;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        public Sales()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(UserSession.Fullname))
            {
                lblwelcome.Text = $"Welcome back, {UserSession.Fullname}!";
            }
            InitializeSettingsPanel();
        }

        private void InitializeSettingsPanel()
        {
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
            settingsPanelTargetHeight = settingsPanel.Height;
            settingsPanel.Height = 0;
            slideTimer.Tick += SlideTimer_Tick;
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            int step = 20;
            if (!isPanelExpanded)
            {
                settingsPanel.Visible = true;
                if (settingsPanel.Height + step < settingsPanelTargetHeight)
                {
                    settingsPanel.Height += step;
                }
                else
                {
                    settingsPanel.Height = settingsPanelTargetHeight;
                    isPanelExpanded = true;
                    slideTimer.Stop();
                }
            }
            else
            {
                if (settingsPanel.Height - step > 0)
                {
                    settingsPanel.Height -= step;
                }
                else
                {
                    settingsPanel.Height = 0;
                    settingsPanel.Visible = false;
                    isPanelExpanded = false;
                    slideTimer.Stop();
                }
            }
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard newDashboard = new Dashboard();
            newDashboard.Show();
            this.Close();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            pos newpos = new pos();
            newpos.Show();
            this.Close();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory = new Inventory_Module();
            inventory.Show();
            this.Close();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Close();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            LoadSalesData();
            StyleSalesGrid();
            NameSearchtb_Leave(null, null);
            searchtransactionid_Leave(null, null);
            lblClearSearchforname.Visible = false;
            lblClearSearchforID.Visible = false;

            if (UserSession.UserId >= 2)
            {
                Point dashboardLocation = btnDashboard.Location;
                Point posLocation = btnPOS.Location;
                btnDashboard.Visible = false;
                btnInventory.Visible = false;
                btnPOS.Location = dashboardLocation;
                btnSales.Location = posLocation;
                btnusermanagement.Visible = false;
                btnaudittrail.Visible = false;
            }
        }

        private void LoadSalesData()
        {
            try
            {
                string query = @"
                    SELECT 
                        s.SaleID, s.TransactionDate, 'Processed by ' + u.Fullname AS ProcessedBy, 
                        s.Subtotal, s.Discount, s.DiscountDescription, s.TotalAmount, 
                        s.AmountPaid, s.ChangeGiven, s.CustomerName, s.NoteText
                    FROM Sales s
                    LEFT JOIN [user] u ON s.UserID = u.UserID
                    ORDER BY s.TransactionDate DESC";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    this.salesDataTable = new DataTable();
                    adapter.Fill(this.salesDataTable);
                    this.salesDataTable.Columns.Add("FormattedSaleID", typeof(string));
                    foreach (DataRow row in this.salesDataTable.Rows)
                    {
                        long originalSaleId = Convert.ToInt64(row["SaleID"]);
                        row["FormattedSaleID"] = originalSaleId.ToString("D6");
                    }
                    dgvSalesReport.DataSource = this.salesDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load sales report data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleSalesGrid()
        {
            if (dgvSalesReport.DataSource == null) return;
            dgvSalesReport.RowTemplate.Height = 35;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSalesReport.ColumnHeadersHeight = 50;
            dgvSalesReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvSalesReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSalesReport.BackgroundColor = Color.White;
            dgvSalesReport.BorderStyle = BorderStyle.None;
            dgvSalesReport.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvSalesReport.GridColor = Color.LightGray;
            dgvSalesReport.DefaultCellStyle.Font = new Font("Segoe UI", 12F, GraphicsUnit.Pixel);
            dgvSalesReport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSalesReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AllowUserToDeleteRows = false;
            dgvSalesReport.AllowUserToOrderColumns = false;
            dgvSalesReport.AllowUserToResizeColumns = true;
            dgvSalesReport.AllowUserToResizeRows = false;
            dgvSalesReport.RowHeadersVisible = false;
            dgvSalesReport.MultiSelect = false;
            dgvSalesReport.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn column in dgvSalesReport.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvSalesReport.DefaultCellStyle.BackColor = Color.White;
            dgvSalesReport.DefaultCellStyle.ForeColor = Color.Black;
            dgvSalesReport.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvSalesReport.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvSalesReport.Columns["SaleID"].Visible = false;
            dgvSalesReport.Columns["FormattedSaleID"].HeaderText = "Transaction ID";
            dgvSalesReport.Columns["TransactionDate"].HeaderText = "Date";
            dgvSalesReport.Columns["ProcessedBy"].HeaderText = "Processed By";
            dgvSalesReport.Columns["Subtotal"].HeaderText = "Subtotal";
            dgvSalesReport.Columns["Discount"].HeaderText = "Discount";
            dgvSalesReport.Columns["DiscountDescription"].HeaderText = "Discount Details";
            dgvSalesReport.Columns["TotalAmount"].HeaderText = "Total Amount";
            dgvSalesReport.Columns["AmountPaid"].HeaderText = "Amount Paid";
            dgvSalesReport.Columns["ChangeGiven"].HeaderText = "Change";
            dgvSalesReport.Columns["CustomerName"].HeaderText = "Customer";
            dgvSalesReport.Columns["NoteText"].HeaderText = "Note";
            dgvSalesReport.Columns["TransactionDate"].DefaultCellStyle.Format = "MMMM dd, yyyy";
            dgvSalesReport.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["Discount"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["AmountPaid"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["ChangeGiven"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["FormattedSaleID"].DisplayIndex = 0;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            slideTimer.Start();
        }

        private void btnaudittrail_Click(object sender, EventArgs e)
        {
            audittrail audittrail = new audittrail();
            audittrail.ShowDialog();
            isPanelExpanded = false;
            settingsPanel.Visible = false;
        }

        private void btnusermanagement_Click(object sender, EventArgs e)
        {
            usermanagement usermanagement = new usermanagement();
            usermanagement.ShowDialog();
            isPanelExpanded = false;
            settingsPanel.Visible = false;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            using (logout logoutForm = new logout())
            {
                isPanelExpanded = false;
                settingsPanel.Height = 0;
                settingsPanel.Visible = false;
                if (logoutForm.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (startDate == null)
            {
                startDate = e.Start;
                endDate = null;
                lblDateRange.Text = "Select an end date...";
                monthCalendar1.SelectionRange = new SelectionRange(startDate.Value, startDate.Value);
            }
            else
            {
                endDate = e.Start;
                if (endDate < startDate)
                {
                    var temp = startDate;
                    startDate = endDate;
                    endDate = temp;
                }
                monthCalendar1.SelectionRange = new SelectionRange(startDate.Value, endDate.Value);
                string filterExpression = $"TransactionDate >= #{startDate.Value:MM/dd/yyyy}# AND TransactionDate < #{endDate.Value.AddDays(1):MM/dd/yyyy}#";
                this.salesDataTable.DefaultView.RowFilter = filterExpression;
                lblDateRange.Text = $"Range: {startDate:d} - {endDate:d}";
                Task.Delay(500).ContinueWith(t => this.Invoke((MethodInvoker)delegate
                {
                    panelDateFilter.Visible = false;
                }));
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            if (this.salesDataTable != null)
            {
                this.salesDataTable.DefaultView.RowFilter = string.Empty;
            }
            startDate = null;
            endDate = null;
            lblDateRange.Text = "Select a start date...";


            if (monthCalendar1 != null)
            {
                return;
            }
            panelDateFilter.Visible = false;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            panelDateFilter.Visible = !panelDateFilter.Visible;
            startDate = null;
            endDate = null;
            lblDateRange.Text = "Select a start date...";
        }

        private void NameSearchtb_Enter(object sender, EventArgs e)
        {
            if (NameSearchtb.Text == "Search for Customer Name")
            {
                NameSearchtb.Text = "";
                NameSearchtb.ForeColor = Color.Black;
            }
        }

        private void NameSearchtb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameSearchtb.Text))
            {
                NameSearchtb.Text = "Search for Customer Name";
                NameSearchtb.ForeColor = Color.Gray;
            }
        }

        private void NameSearchtb_TextChanged(object sender, EventArgs e)
        {
            lblClearSearchforname.Visible = !string.IsNullOrEmpty(NameSearchtb.Text) && NameSearchtb.Text != "Search for Customer Name";
            if (salesDataTable == null) return;
            if (NameSearchtb.Text != "Search for Customer Name")
            {
                string searchText = NameSearchtb.Text.Trim().Replace("'", "''");
                salesDataTable.DefaultView.RowFilter = $"CustomerName LIKE '%{searchText}%'";
            }
            else if (salesDataTable.DefaultView.RowFilter != string.Empty)
            {
                salesDataTable.DefaultView.RowFilter = string.Empty;
            }
        }

        private void searchtransactionid_TextChanged(object sender, EventArgs e)
        {
            lblClearSearchforID.Visible = !string.IsNullOrEmpty(searchtransactionid.Text) && searchtransactionid.Text != "Search Transaction ID";
            if (salesDataTable == null) return;
            if (searchtransactionid.Text != "Search Transaction ID")
            {
                string searchText = searchtransactionid.Text.Trim().Replace("'", "''");
                salesDataTable.DefaultView.RowFilter = $"FormattedSaleID LIKE '%{searchText}%'";
            }
            else if (salesDataTable.DefaultView.RowFilter != string.Empty)
            {
                salesDataTable.DefaultView.RowFilter = string.Empty;
            }
        }

        private void lblClearSearchforID_Click(object sender, EventArgs e)
        {
            searchtransactionid.Clear();
            searchtransactionid.Focus();
        }

        private void lblClearSearchforname_Click(object sender, EventArgs e)
        {
            NameSearchtb.Clear();
            NameSearchtb.Focus();
        }

        private void searchtransactionid_Enter(object sender, EventArgs e)
        {
            if (searchtransactionid.Text == "Search Transaction ID")
            {
                searchtransactionid.Text = "";
                searchtransactionid.ForeColor = Color.Black;
            }
        }

        private void searchtransactionid_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchtransactionid.Text))
            {
                searchtransactionid.Text = "Search Transaction ID";
                searchtransactionid.ForeColor = Color.Gray;
            }
        }
    }
}