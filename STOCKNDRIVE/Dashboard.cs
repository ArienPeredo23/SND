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
            CheckForLowStock();
            CheckForOutOfStock();
            StyleSalesChart();
            inactiveFont = new Font("Segoe UI", 9F, FontStyle.Regular);

            activeFont = new Font("Arial Black", 9F, FontStyle.Bold);

            btnMonthly_Click(null, null);
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
    }

}
