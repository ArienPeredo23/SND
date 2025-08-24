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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
        private int hoveredRowIndex = -1;
        public Sales()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(UserSession.Fullname))
            {
                lblwelcome.Text = $"Welcome back, {UserSession.Fullname}!";
            }
            InitializeSettingsPanel();
            dgvSalesReport.CellMouseEnter += dgvSalesReport_CellMouseEnter;
            dgvSalesReport.MouseLeave += dgvSalesReport_MouseLeave;
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
                backupbtn.Visible = false;
            }
        }
        private void dgvSalesReport_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != this.hoveredRowIndex)
            {
                if (this.hoveredRowIndex >= 0)
                {
                    RestoreRowStyle(this.hoveredRowIndex);
                }

                this.hoveredRowIndex = e.RowIndex;
                dgvSalesReport.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                dgvSalesReport.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgvSalesReport_MouseLeave(object sender, EventArgs e)
        {
            if (this.hoveredRowIndex >= 0)
            {
                RestoreRowStyle(this.hoveredRowIndex);
                this.hoveredRowIndex = -1;
            }
        }

        private void RestoreRowStyle(int rowIndex)
        {

            if (rowIndex >= 0 && rowIndex < dgvSalesReport.Rows.Count)
            {
                DataGridViewRow row = dgvSalesReport.Rows[rowIndex];
                row.DefaultCellStyle.BackColor = dgvSalesReport.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvSalesReport.DefaultCellStyle.ForeColor;
            }
        }

        private void LoadSalesData()
        {
            try
            {
                string query = @"
            SELECT 
                s.SaleID, 
                s.TransactionDate, 
                'Processed by ' + u.Fullname AS ProcessedBy, 
                (
                    SELECT p.ProductName + ' (x' + CAST(si.QuantitySold AS VARCHAR) + ' @ ' + FORMAT(si.PriceAtSale, 'N2') + ')' + CHAR(13)+CHAR(10)
                    FROM SaleItems si
                    JOIN Products p ON si.ProductID = p.ProductID
                    WHERE si.SaleID = s.SaleID
                    FOR XML PATH('')
                ) AS ItemsList,
                s.Subtotal, 
                s.Discount, 
                s.DiscountDescription, 
                s.TotalAmount, 
                s.AmountPaid, 
                s.ChangeGiven, 
                s.CustomerName,
                s.NoteText, 
                s.Status 
            FROM Sales s
            LEFT JOIN [user] u ON s.UserID = u.UserID
            ORDER BY s.TransactionDate DESC";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    this.salesDataTable = new DataTable();
                    adapter.Fill(this.salesDataTable);

                    this.salesDataTable.Columns.Add("FormattedSaleID", typeof(string));
                    this.salesDataTable.Columns.Add("CombinedDiscount", typeof(string));
                    this.salesDataTable.Columns.Add("CombinedCustomerInfo", typeof(string));

                    foreach (DataRow row in this.salesDataTable.Rows)
                    {
                        long originalSaleId = Convert.ToInt64(row["SaleID"]);
                        row["FormattedSaleID"] = originalSaleId.ToString("D6");

                        string discountDesc = row["DiscountDescription"].ToString();
                        decimal discountAmount = Convert.ToDecimal(row["Discount"]);
                        row["CombinedDiscount"] = string.IsNullOrEmpty(discountDesc) ? discountAmount.ToString("N2") : $"{discountDesc} ({discountAmount:N2})";

                        string customer = row["CustomerName"].ToString();
                        string note = row["NoteText"].ToString();
                        row["CombinedCustomerInfo"] = string.IsNullOrEmpty(note) ? customer : $"{customer}\nNote: {note}";

                        // Clean the XML encoded newline characters from the ItemsList
                        if (row["ItemsList"] != DBNull.Value)
                        {
                            string items = row["ItemsList"].ToString();
                            row["ItemsList"] = items.Replace("&#x0D;", "").Trim();
                        }
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
            if (dgvSalesReport.DataSource == null || dgvSalesReport.Rows.Count == 0) return;
            dgvSalesReport.RowTemplate.Height = 35;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSalesReport.ColumnHeadersHeight = 50;
            dgvSalesReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvSalesReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSalesReport.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvSalesReport.BorderStyle = BorderStyle.None;
            dgvSalesReport.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvSalesReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvSalesReport.GridColor = Color.White;
            dgvSalesReport.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, GraphicsUnit.Pixel);
            dgvSalesReport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesReport.DefaultCellStyle.Padding = new Padding(5);
            dgvSalesReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
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
            dgvSalesReport.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvSalesReport.DefaultCellStyle.ForeColor = Color.White;
            dgvSalesReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 40, 40);
            dgvSalesReport.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvSalesReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 40, 40);

            dgvSalesReport.Columns["SaleID"].Visible = false;
            dgvSalesReport.Columns["Discount"].Visible = false;
            dgvSalesReport.Columns["DiscountDescription"].Visible = false;
            dgvSalesReport.Columns["CustomerName"].Visible = false;
            dgvSalesReport.Columns["NoteText"].Visible = false;

            dgvSalesReport.Columns["FormattedSaleID"].HeaderText = "Transaction ID";
            dgvSalesReport.Columns["TransactionDate"].HeaderText = "Date";
            dgvSalesReport.Columns["ProcessedBy"].HeaderText = "Processed By";
            dgvSalesReport.Columns["ItemsList"].HeaderText = "Items Purchased";
            dgvSalesReport.Columns["Subtotal"].HeaderText = "Subtotal";
            dgvSalesReport.Columns["CombinedDiscount"].HeaderText = "Discount";
            dgvSalesReport.Columns["TotalAmount"].HeaderText = "Total Amount";
            dgvSalesReport.Columns["AmountPaid"].HeaderText = "Amount Paid";
            dgvSalesReport.Columns["ChangeGiven"].HeaderText = "Change";
            dgvSalesReport.Columns["CombinedCustomerInfo"].HeaderText = "Customer & Notes";
            dgvSalesReport.Columns["Status"].HeaderText = "Status";

            dgvSalesReport.Columns["TransactionDate"].DefaultCellStyle.Format = "MMMM dd, yyyy";
            dgvSalesReport.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["AmountPaid"].DefaultCellStyle.Format = "N2";
            dgvSalesReport.Columns["ChangeGiven"].DefaultCellStyle.Format = "N2";

            dgvSalesReport.Columns["ItemsList"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvSalesReport.Columns["CombinedCustomerInfo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

        private void dgvSalesReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long saleId = Convert.ToInt64(dgvSalesReport.Rows[e.RowIndex].Cells["SaleID"].Value);


            ShowReceiptForSale(saleId);
        }
        private void ShowReceiptForSale(long saleId)
        {
            try
            {
                DataRow saleDetailsRow = null;
                List<CartItem> saleItemsList = new List<CartItem>();
                int totalNumberOfItems = 0;

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();


                    string saleQuery = "SELECT * FROM Sales WHERE SaleID = @SaleID";
                    using (SqlCommand cmd = new SqlCommand(saleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            saleDetailsRow = dt.Rows[0];
                        }
                    }

                    if (saleDetailsRow == null)
                    {
                        throw new Exception("Sale record could not be found.");
                    }

                    string itemsQuery = @"
                SELECT 
                    p.ProductName,
                    (si.PriceAtSale / si.QuantitySold) as UnitPrice,
                    si.QuantitySold
                FROM SaleItems si
                JOIN Products p ON si.ProductID = p.ProductID
                WHERE si.SaleID = @SaleID";

                    using (SqlCommand cmd = new SqlCommand(itemsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["ProductName"].ToString();
                                decimal unitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                                int quantity = Convert.ToInt32(reader["QuantitySold"]);

                                saleItemsList.Add(new CartItem(name, unitPrice, quantity));
                                totalNumberOfItems += quantity;
                            }
                        }
                    }
                }

                using (DigitalReceipt receiptForm = new DigitalReceipt(
                    saleId,
                    saleItemsList,
                    saleDetailsRow["CustomerName"].ToString(),
                    Convert.ToDecimal(saleDetailsRow["AmountPaid"]),
                    Convert.ToDecimal(saleDetailsRow["ChangeGiven"]),
                    saleDetailsRow["NoteText"].ToString(),
                    totalNumberOfItems.ToString(),
                    Convert.ToDecimal(saleDetailsRow["Subtotal"]).ToString("N2"),
                    Convert.ToDecimal(saleDetailsRow["Discount"]).ToString("N2"),
                    Convert.ToDecimal(saleDetailsRow["TotalAmount"]).ToString("N2")
                ))
                {
                    receiptForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve full receipt details.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogSystemActivity(string actionType, string actionDetails)
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
                Console.WriteLine("System Audit Log Failed: " + ex.Message);
            }
        }
        private void backupbtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to back up the database?",
                                                         "Confirm Backup",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQL Backup file (*.bak)|*.bak";
            saveFileDialog.Title = "Save Database Backup";
            saveFileDialog.FileName = $"stockndrive_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupPath = saveFileDialog.FileName;

                try
                {
                    string dbName = "stockndrive";
                    string query = $"BACKUP DATABASE [{dbName}] TO DISK = @BackupPath";

                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@BackupPath", backupPath);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    string details = $"{UserSession.Fullname} created a database backup at '{backupPath}'.";
                    LogSystemActivity("Database Backup", details);

                    MessageBox.Show("Database backup completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database backup failed.\n\n" +
                                    "Please ensure the SQL Server service has write permissions to the selected folder.\n\n" +
                                    "Error: " + ex.Message,
                                    "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvSalesReport.Rows.Count == 0)
            {
                MessageBox.Show("There is no data to export.", "Cannot Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
            saveFileDialog.Title = "Export Sales Report to PDF";
            saveFileDialog.FileName = $"SalesReport_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.LETTER.Rotate(), 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    doc.Open();

                    iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font filterFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.ITALIC);
                    iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font cellFont = FontFactory.GetFont("Arial", 8);

                    doc.Add(new Paragraph("Sales Report", titleFont));

                    if (!string.IsNullOrEmpty(salesDataTable.DefaultView.RowFilter) && salesDataTable.DefaultView.RowFilter.Contains("TransactionDate"))
                    {
                        if (startDate.HasValue && endDate.HasValue)
                        {
                            doc.Add(new Paragraph($"Filtered from: {startDate.Value:MMMM dd, yyyy} to {endDate.Value:MMMM dd, yyyy}", filterFont));
                        }
                        else
                        {
                            doc.Add(new Paragraph($"Filtered by a selected date range", filterFont));
                        }
                    }
                    doc.Add(new Paragraph(" "));

                    PdfPTable pdfTable = new PdfPTable(dgvSalesReport.Columns.GetColumnCount(DataGridViewElementStates.Visible));
                    pdfTable.WidthPercentage = 100;

                    foreach (DataGridViewColumn column in dgvSalesReport.Columns)
                    {
                        if (column.Visible)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                            cell.BackgroundColor = new BaseColor(240, 240, 240);
                            pdfTable.AddCell(cell);
                        }
                    }

                    foreach (DataGridViewRow row in dgvSalesReport.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Visible)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(cell.FormattedValue.ToString(), cellFont));
                                pdfTable.AddCell(dataCell);
                            }
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();

                    MessageBox.Show("Report exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while exporting the report.\nError: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}