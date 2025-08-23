using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace STOCKNDRIVE
{
    public partial class Dashboard : Form
    {
        private bool isPanelExpanded = false;
        private int settingsPanelStartHeight;
        private int settingsPanelTargetHeight;

        private Font activeFont;
        private Font inactiveFont;

        public Dashboard()
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
            // This positions the panel right above the settings button
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
            settingsPanelTargetHeight = settingsPanel.Height; // Store the original height
            settingsPanel.Height = 0; // Start with the panel collapsed
            slideTimer.Tick += SlideTimer_Tick; // Subscribe to the timer's tick event
        }
        private void CheckForLowStock()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Products WHERE QuantityInStock <= 5";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        int lowStockCount = (int)cmd.ExecuteScalar();
                        LowStockWarning.Visible = (lowStockCount > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to check for low stock: " + ex.Message);
            }
        }

        private void CheckForOutOfStock()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Products WHERE QuantityInStock = 0";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        int outOfStockCount = (int)cmd.ExecuteScalar();
                        Outofstockwarning.Visible = (outOfStockCount > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to check for out of stock items: " + ex.Message);
            }
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            int step = 20; // Controls the speed of the animation

            if (!isPanelExpanded)
            {
                // Expanding the panel
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
                // Collapsing the panel
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
            // Ensure panel stays correctly positioned as it resizes
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadTodaysStats();
            CheckForLowStock();
            LoadRecentSales(); // Add this line
            StyleRecentSalesGrid();
            CheckForOutOfStock();
            StyleSalesChart();
            LoadBestsellingProducts();
            inactiveFont = new Font("Segoe UI", 9F, FontStyle.Regular);

            activeFont = new Font("Arial Black", 9F, FontStyle.Bold);

            btnMonthly_Click(null, null);
        }

        private void LoadRecentSales()
        {
            try
            {
                // This query gets the 5 most recent sales by ordering by date in descending order.
                string query = @"
            SELECT TOP 5
                s.SaleID, 
                s.TransactionDate, 
                s.CustomerName, 
                s.TotalAmount,
                u.Fullname
            FROM Sales s
            LEFT JOIN [user] u ON s.UserID = u.UserID
            ORDER BY s.TransactionDate DESC";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns.Add("FormattedSaleID", typeof(string));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        long originalSaleId = Convert.ToInt64(row["SaleID"]);
                        row["FormattedSaleID"] = originalSaleId.ToString("D6");
                    }

                    dgvSalesReport.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load recent sales: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleRecentSalesGrid()
        {
            if (dgvSalesReport.DataSource == null || dgvSalesReport.Rows.Count == 0) return;

            // --- Interaction and Sizing ---
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AllowUserToDeleteRows = false;
            dgvSalesReport.AllowUserToOrderColumns = false;
            dgvSalesReport.AllowUserToResizeColumns = false;
            dgvSalesReport.AllowUserToResizeRows = false;
            dgvSalesReport.RowHeadersVisible = false;
            dgvSalesReport.MultiSelect = false;
            dgvSalesReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // --- Visual Style & Colors ---
            dgvSalesReport.BackgroundColor = Color.FromArgb(45, 45, 48); // Dark background
            dgvSalesReport.BorderStyle = BorderStyle.None;
            dgvSalesReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSalesReport.GridColor = Color.White; // White grid lines
            dgvSalesReport.EnableHeadersVisualStyles = false;

            // --- Cell Style (for all data rows) ---
            dgvSalesReport.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvSalesReport.DefaultCellStyle.ForeColor = Color.White;
            dgvSalesReport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dgvSalesReport.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSalesReport.RowTemplate.Height = 30; // Add some padding

            // --- Header Style ---
            dgvSalesReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvSalesReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dgvSalesReport.ColumnHeadersHeight = 40;

            // To disable header click for sorting
            foreach (DataGridViewColumn column in dgvSalesReport.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // --- Column Specific Settings ---
            dgvSalesReport.Columns["SaleID"].Visible = false;
            dgvSalesReport.Columns["FormattedSaleID"].HeaderText = "Transaction ID";
            dgvSalesReport.Columns["TransactionDate"].HeaderText = "Date";
            dgvSalesReport.Columns["CustomerName"].HeaderText = "Customer";
            dgvSalesReport.Columns["TotalAmount"].HeaderText = "Amount";
            dgvSalesReport.Columns["Fullname"].HeaderText = "Processed By";

            dgvSalesReport.Columns["TransactionDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dgvSalesReport.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";

            dgvSalesReport.Columns["FormattedSaleID"].DisplayIndex = 0;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadTodaysStats()
        {
            try
            {
                decimal todayRevenue = 0;
                int todaySalesCount = 0;

                string revenueQuery = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Sales WHERE CAST(TransactionDate AS DATE) = CAST(GETDATE() AS DATE)";

                string salesCountQuery = "SELECT COUNT(*) FROM Sales WHERE CAST(TransactionDate AS DATE) = CAST(GETDATE() AS DATE)";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(revenueQuery, conn))
                    {
                        todayRevenue = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    using (SqlCommand cmd = new SqlCommand(salesCountQuery, conn))
                    {
                        todaySalesCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                Revenuelbl.Text = todayRevenue.ToString("₱ #,##0.00");
                totalsaletodaylbl.Text = todaySalesCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load today's statistics: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Revenuelbl.Text = "Error";
                totalsaletodaylbl.Text = "Error";
            }
        }

        private void LoadWeeklySalesChart()
        {
            try
            {
                var series = salesChart.Series["SalesData"];
                series.Points.Clear();

                // --- START OF CHANGES ---

                // This query now only gets sales data that actually exists within the last 7 days.
                string query = @"
            SELECT 
                CAST(TransactionDate AS DATE) as SalesDate,
                SUM(TotalAmount) as TotalSales
            FROM Sales
            WHERE TransactionDate >= DATEADD(day, -6, CAST(GETDATE() AS DATE))
            GROUP BY CAST(TransactionDate AS DATE)";

                // 1. Create a dictionary to hold the results from the database.
                var salesDataFromDb = new Dictionary<DateTime, decimal>();

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DateTime date = Convert.ToDateTime(reader["SalesDate"]);
                            decimal total = Convert.ToDecimal(reader["TotalSales"]);
                            salesDataFromDb[date] = total;
                        }
                    }
                }

                // 2. Create the final, complete list of the last 7 days.
                var completeWeeklyData = new Dictionary<DateTime, decimal>();
                for (int i = 6; i >= 0; i--)
                {
                    DateTime day = DateTime.Today.AddDays(-i);
                    completeWeeklyData[day] = 0; // Initialize each day with 0 sales
                }

                // 3. Populate the complete list with data from the database where it exists.
                foreach (var dbData in salesDataFromDb)
                {
                    if (completeWeeklyData.ContainsKey(dbData.Key))
                    {
                        completeWeeklyData[dbData.Key] = dbData.Value;
                    }
                }

                // 4. Add the final, complete data to the chart.
                foreach (var dayData in completeWeeklyData)
                {
                    series.Points.AddXY(dayData.Key.ToString("ddd"), dayData.Value); // "ddd" gives "Mon", "Tue", etc.
                }
                decimal maxSales = completeWeeklyData.Values.Max();
                if (maxSales == 0) maxSales = 100; // Set a default height if there are no sales
                salesChart.ChartAreas["SalesArea"].AxisY.Maximum = (double)maxSales * 1.2;
                // --- END OF CHANGES ---
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load weekly sales chart data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleSalesChart()
        {
            var chart = salesChart;
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();

            ChartArea chartArea = new ChartArea("SalesArea");
            chart.ChartAreas.Add(chartArea);

            chartArea.BackColor = Color.White;
            chartArea.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            chartArea.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisX.LineColor = Color.Transparent;
            chartArea.AxisY.LineColor = Color.Transparent;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisX.MajorTickMark.Enabled = false;
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = true;

            chartArea.AxisX.Interval = 1;

            Series series = new Series("SalesData");

            series.IsXValueIndexed = true;

            chart.Series.Add(series);
            chart.Series["SalesData"].ChartType = SeriesChartType.SplineArea;

            series.Color = Color.FromArgb(150, 237, 213, 159);
            series.BorderColor = Color.FromArgb(217, 177, 108);
            series.BorderWidth = 3;
        }

        private void LoadMonthlySalesChart()
        {
            try
            {
                var series = salesChart.Series["SalesData"];
                series.Points.Clear();

                string query = @"
                    SELECT 
                        MONTH(TransactionDate) as SalesMonth, 
                        SUM(TotalAmount) as TotalSales
                    FROM Sales
                    WHERE YEAR(TransactionDate) = YEAR(GETDATE())
                    GROUP BY MONTH(TransactionDate)
                    ORDER BY SalesMonth ASC";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        var monthlySales = new Dictionary<int, decimal>();
                        for (int i = 1; i <= 12; i++)
                        {
                            monthlySales[i] = 0;
                        }

                        while (reader.Read())
                        {
                            int month = Convert.ToInt32(reader["SalesMonth"]);
                            decimal total = Convert.ToDecimal(reader["TotalSales"]);
                            monthlySales[month] = total;
                        }

                        foreach (var monthData in monthlySales)
                        {
                            string monthName = new DateTime(DateTime.Now.Year, monthData.Key, 1).ToString("MMM");

                            series.Points.AddXY(monthName, monthData.Value);
                        }

                        decimal maxSales = monthlySales.Values.Max();
                        if (maxSales == 0) maxSales = 100;
                        salesChart.ChartAreas["SalesArea"].AxisY.Maximum = (double)maxSales * 1.2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load sales chart data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBestsellingProducts()
        {
            bestsellingpanel.Controls.Clear();
            bestsellingpanel.RowStyles.Clear();

            try
            {
                // --- THIS IS THE ONLY CHANGE ---
                // Change TOP 16 to TOP 4 to fill a 2x2 grid
                string query = @"
            SELECT TOP 4
                p.ProductID, p.ProductName, p.Brand, p.Manufacturer, p.Price, p.ProductImage,
                SUM(si.QuantitySold) AS TotalSold
            FROM SaleItems si
            JOIN Products p ON si.ProductID = p.ProductID
            GROUP BY p.ProductID, p.ProductName, p.Brand, p.Manufacturer, p.Price, p.ProductImage
            ORDER BY TotalSold DESC";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        int column = 0;
                        int row = 0;

                        while (reader.Read())
                        {
                            if (column == 0)
                            {
                                bestsellingpanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            }

                            ProductCard card = new ProductCard();
                            Image productImage = null;

                            card.ProductName = reader["ProductName"].ToString();
                            card.BrandText = reader["Brand"].ToString();
                            card.ManufacturerText = reader["Manufacturer"].ToString();
                            card.ProductPrice = Convert.ToDecimal(reader["Price"]).ToString("0.00");
                            card.TotalSoldText = reader["TotalSold"].ToString();

                            if (reader["ProductImage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["ProductImage"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    productImage = Image.FromStream(ms);
                                }
                            }
                            card.ProductImage = productImage;
                            card.AddToCartButton.Visible = false;
                            card.Dock = DockStyle.Fill;
                            card.Anchor = AnchorStyles.None;
                            bestsellingpanel.Controls.Add(card, column, row);

                            column++;
                            if (column >= bestsellingpanel.ColumnCount)
                            {
                                column = 0;
                                row++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load best-selling products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LowStockWarning_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory = new Inventory_Module(true);
            inventory.Show();
            this.Close();
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

        private void leftNavPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void Outofstockwarning_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory = new Inventory_Module(true);
            inventory.Show();
            this.Close();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            LoadWeeklySalesChart();
            btnWeekly.Font = activeFont;
            btnMonthly.Font = inactiveFont;
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            LoadMonthlySalesChart();
            btnMonthly.Font = activeFont;
            btnWeekly.Font = inactiveFont;
        }

        private void Salesbtn_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Close();
        }

        private void posbtn_Click(object sender, EventArgs e)
        {
            pos pos = new pos();
            pos.Show();
            this.Close();
        }

        private void invbtn_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory_Module = new Inventory_Module(true);
            inventory_Module.Show();
            this.Close();
        }
    }

}
