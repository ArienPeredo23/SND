namespace STOCKNDRIVE
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            leftNavPanel = new Panel();
            settingsPanel = new Panel();
            btnaudittrail = new Button();
            btnusermanagement = new Button();
            btnlogout = new Button();
            btnSettings = new Button();
            btnSales = new Button();
            btnInventory = new Button();
            btnPOS = new Button();
            btnDashboard = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            revenueCard = new Panel();
            label4 = new Label();
            label2 = new Label();
            ordersCard = new Panel();
            label5 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            slideTimer = new System.Windows.Forms.Timer(components);
            panel4 = new Panel();
            lblwelcome = new Label();
            panel2 = new Panel();
            btnWeekly = new Button();
            btnMonthly = new Button();
            salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label7 = new Label();
            LowStockWarning = new Button();
            Outofstockwarning = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            leftNavPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            revenueCard.SuspendLayout();
            ordersCard.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)salesChart).BeginInit();
            SuspendLayout();
            // 
            // leftNavPanel
            // 
            leftNavPanel.BackColor = Color.FromArgb(30, 30, 30);
            leftNavPanel.Controls.Add(settingsPanel);
            leftNavPanel.Controls.Add(btnSettings);
            leftNavPanel.Controls.Add(btnSales);
            leftNavPanel.Controls.Add(btnInventory);
            leftNavPanel.Controls.Add(btnPOS);
            leftNavPanel.Controls.Add(btnDashboard);
            leftNavPanel.Controls.Add(pictureBox1);
            leftNavPanel.Dock = DockStyle.Left;
            leftNavPanel.Location = new Point(0, 0);
            leftNavPanel.Name = "leftNavPanel";
            leftNavPanel.Size = new Size(240, 920);
            leftNavPanel.TabIndex = 0;
            leftNavPanel.Paint += leftNavPanel_Paint;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(btnaudittrail);
            settingsPanel.Controls.Add(btnusermanagement);
            settingsPanel.Controls.Add(btnlogout);
            settingsPanel.Location = new Point(12, 650);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(198, 189);
            settingsPanel.TabIndex = 13;
            settingsPanel.Visible = false;
            // 
            // btnaudittrail
            // 
            btnaudittrail.BackColor = Color.FromArgb(30, 30, 30);
            btnaudittrail.FlatAppearance.BorderSize = 0;
            btnaudittrail.FlatStyle = FlatStyle.Flat;
            btnaudittrail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnaudittrail.ForeColor = Color.White;
            btnaudittrail.Image = (Image)resources.GetObject("btnaudittrail.Image");
            btnaudittrail.ImageAlign = ContentAlignment.MiddleLeft;
            btnaudittrail.Location = new Point(18, 73);
            btnaudittrail.Name = "btnaudittrail";
            btnaudittrail.Size = new Size(163, 30);
            btnaudittrail.TabIndex = 2;
            btnaudittrail.Text = " Audit Trail";
            btnaudittrail.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnaudittrail.UseVisualStyleBackColor = false;
            btnaudittrail.Click += btnaudittrail_Click;
            // 
            // btnusermanagement
            // 
            btnusermanagement.BackColor = Color.FromArgb(30, 30, 30);
            btnusermanagement.FlatAppearance.BorderSize = 0;
            btnusermanagement.FlatStyle = FlatStyle.Flat;
            btnusermanagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnusermanagement.ForeColor = Color.White;
            btnusermanagement.Image = (Image)resources.GetObject("btnusermanagement.Image");
            btnusermanagement.ImageAlign = ContentAlignment.MiddleLeft;
            btnusermanagement.Location = new Point(18, 109);
            btnusermanagement.Name = "btnusermanagement";
            btnusermanagement.Size = new Size(163, 30);
            btnusermanagement.TabIndex = 1;
            btnusermanagement.Text = " User Management";
            btnusermanagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnusermanagement.UseVisualStyleBackColor = false;
            btnusermanagement.Click += btnusermanagement_Click;
            // 
            // btnlogout
            // 
            btnlogout.BackColor = Color.FromArgb(30, 30, 30);
            btnlogout.FlatAppearance.BorderSize = 0;
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnlogout.ForeColor = Color.White;
            btnlogout.Image = (Image)resources.GetObject("btnlogout.Image");
            btnlogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnlogout.Location = new Point(18, 147);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(97, 30);
            btnlogout.TabIndex = 0;
            btnlogout.Text = " Logout";
            btnlogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlogout.UseVisualStyleBackColor = false;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSettings.ForeColor = Color.White;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(30, 845);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(180, 45);
            btnSettings.TabIndex = 5;
            btnSettings.Text = " Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSales
            // 
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSales.ForeColor = Color.White;
            btnSales.Image = (Image)resources.GetObject("btnSales.Image");
            btnSales.ImageAlign = ContentAlignment.MiddleLeft;
            btnSales.Location = new Point(30, 319);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(180, 45);
            btnSales.TabIndex = 4;
            btnSales.Text = " Sales";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnInventory
            // 
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInventory.ForeColor = Color.White;
            btnInventory.Image = (Image)resources.GetObject("btnInventory.Image");
            btnInventory.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventory.Location = new Point(30, 264);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(180, 45);
            btnInventory.TabIndex = 3;
            btnInventory.Text = " Inventory";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnPOS
            // 
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPOS.ForeColor = Color.White;
            btnPOS.Image = (Image)resources.GetObject("btnPOS.Image");
            btnPOS.ImageAlign = ContentAlignment.MiddleLeft;
            btnPOS.Location = new Point(30, 209);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(180, 45);
            btnPOS.TabIndex = 2;
            btnPOS.Text = " POS";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPOS.UseVisualStyleBackColor = true;
            btnPOS.Click += btnPOS_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = SystemColors.ActiveCaptionText;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Image = (Image)resources.GetObject("btnDashboard.Image");
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(30, 154);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(180, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = " Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(260, 30);
            label1.Name = "label1";
            label1.Size = new Size(184, 45);
            label1.TabIndex = 1;
            label1.Text = "Dashboard";
            // 
            // revenueCard
            // 
            revenueCard.BackColor = Color.FromArgb(45, 45, 45);
            revenueCard.Controls.Add(label4);
            revenueCard.Controls.Add(label2);
            revenueCard.Location = new Point(1110, 107);
            revenueCard.Name = "revenueCard";
            revenueCard.Size = new Size(340, 230);
            revenueCard.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(11, 166);
            label4.Name = "label4";
            label4.Size = new Size(197, 34);
            label4.TabIndex = 7;
            label4.Text = "The total cash revenue recorded\r\n for the day";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(11, 23);
            label2.Name = "label2";
            label2.Size = new Size(203, 32);
            label2.TabIndex = 6;
            label2.Text = "Today's Revenue";
            // 
            // ordersCard
            // 
            ordersCard.BackColor = Color.FromArgb(45, 45, 45);
            ordersCard.Controls.Add(label5);
            ordersCard.Controls.Add(label3);
            ordersCard.Location = new Point(1470, 107);
            ordersCard.Name = "ordersCard";
            ordersCard.Size = new Size(340, 230);
            ordersCard.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(11, 166);
            label5.Name = "label5";
            label5.Size = new Size(212, 34);
            label5.TabIndex = 8;
            label5.Text = "The total number of customer \r\npurchases recorded within the day.";
            label5.Click += label5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(11, 23);
            label3.Name = "label3";
            label3.Size = new Size(172, 32);
            label3.TabIndex = 7;
            label3.Text = "Today's Order";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(1110, 353);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 538);
            panel1.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(11, 26);
            label6.Name = "label6";
            label6.Size = new Size(246, 32);
            label6.TabIndex = 8;
            label6.Text = "Best-Selling Product";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(3, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(675, 458);
            dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(45, 45, 45);
            panel3.Location = new Point(280, 574);
            panel3.Name = "panel3";
            panel3.Size = new Size(813, 317);
            panel3.TabIndex = 4;
            // 
            // slideTimer
            // 
            slideTimer.Interval = 15;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.Location = new Point(260, 79);
            panel4.Name = "panel4";
            panel4.Size = new Size(1550, 2);
            panel4.TabIndex = 5;
            // 
            // lblwelcome
            // 
            lblwelcome.AutoSize = true;
            lblwelcome.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblwelcome.ForeColor = Color.FromArgb(204, 141, 26);
            lblwelcome.Location = new Point(700, 43);
            lblwelcome.Name = "lblwelcome";
            lblwelcome.Size = new Size(20, 28);
            lblwelcome.TabIndex = 6;
            lblwelcome.Text = "-";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnWeekly);
            panel2.Controls.Add(btnMonthly);
            panel2.Controls.Add(salesChart);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(280, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(813, 450);
            panel2.TabIndex = 3;
            // 
            // btnWeekly
            // 
            btnWeekly.BackColor = Color.Transparent;
            btnWeekly.BackgroundImageLayout = ImageLayout.Stretch;
            btnWeekly.FlatAppearance.BorderSize = 0;
            btnWeekly.FlatStyle = FlatStyle.Flat;
            btnWeekly.ForeColor = Color.White;
            btnWeekly.Image = (Image)resources.GetObject("btnWeekly.Image");
            btnWeekly.Location = new Point(649, 23);
            btnWeekly.Name = "btnWeekly";
            btnWeekly.Size = new Size(71, 32);
            btnWeekly.TabIndex = 12;
            btnWeekly.Text = "Weekly";
            btnWeekly.UseVisualStyleBackColor = false;
            btnWeekly.Click += btnWeekly_Click;
            // 
            // btnMonthly
            // 
            btnMonthly.BackColor = Color.Transparent;
            btnMonthly.BackgroundImageLayout = ImageLayout.Stretch;
            btnMonthly.FlatAppearance.BorderSize = 0;
            btnMonthly.FlatStyle = FlatStyle.Flat;
            btnMonthly.ForeColor = Color.FromArgb(0, 0, 0, 1);
            btnMonthly.Image = (Image)resources.GetObject("btnMonthly.Image");
            btnMonthly.Location = new Point(717, 23);
            btnMonthly.Name = "btnMonthly";
            btnMonthly.Size = new Size(71, 32);
            btnMonthly.TabIndex = 11;
            btnMonthly.Text = "Monthly";
            btnMonthly.UseVisualStyleBackColor = false;
            btnMonthly.Click += btnMonthly_Click;
            // 
            // salesChart
            // 
            chartArea1.Name = "ChartArea1";
            salesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            salesChart.Legends.Add(legend1);
            salesChart.Location = new Point(20, 80);
            salesChart.Name = "salesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            salesChart.Series.Add(series1);
            salesChart.Size = new Size(768, 355);
            salesChart.TabIndex = 10;
            salesChart.Text = "chart1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(20, 23);
            label7.Name = "label7";
            label7.Size = new Size(185, 32);
            label7.TabIndex = 9;
            label7.Text = "Sales Overview";
            // 
            // LowStockWarning
            // 
            LowStockWarning.BackgroundImageLayout = ImageLayout.Stretch;
            LowStockWarning.FlatAppearance.BorderSize = 0;
            LowStockWarning.FlatStyle = FlatStyle.Flat;
            LowStockWarning.Font = new Font("Segoe UI", 12F);
            LowStockWarning.ForeColor = Color.Yellow;
            LowStockWarning.Image = (Image)resources.GetObject("LowStockWarning.Image");
            LowStockWarning.ImageAlign = ContentAlignment.MiddleLeft;
            LowStockWarning.Location = new Point(1589, 15);
            LowStockWarning.Name = "LowStockWarning";
            LowStockWarning.Size = new Size(221, 58);
            LowStockWarning.TabIndex = 13;
            LowStockWarning.Text = "Low Stocks Warning!";
            LowStockWarning.TextAlign = ContentAlignment.MiddleRight;
            LowStockWarning.TextImageRelation = TextImageRelation.ImageBeforeText;
            LowStockWarning.UseVisualStyleBackColor = true;
            LowStockWarning.Visible = false;
            LowStockWarning.Click += LowStockWarning_Click;
            // 
            // Outofstockwarning
            // 
            Outofstockwarning.BackgroundImageLayout = ImageLayout.Stretch;
            Outofstockwarning.FlatAppearance.BorderSize = 0;
            Outofstockwarning.FlatStyle = FlatStyle.Flat;
            Outofstockwarning.Font = new Font("Segoe UI", 12F);
            Outofstockwarning.ForeColor = Color.Red;
            Outofstockwarning.Image = (Image)resources.GetObject("Outofstockwarning.Image");
            Outofstockwarning.ImageAlign = ContentAlignment.MiddleLeft;
            Outofstockwarning.Location = new Point(1342, 15);
            Outofstockwarning.Name = "Outofstockwarning";
            Outofstockwarning.Size = new Size(231, 58);
            Outofstockwarning.TabIndex = 14;
            Outofstockwarning.Text = "Out of Stocks Warning!";
            Outofstockwarning.TextAlign = ContentAlignment.MiddleRight;
            Outofstockwarning.TextImageRelation = TextImageRelation.ImageBeforeText;
            Outofstockwarning.UseVisualStyleBackColor = true;
            Outofstockwarning.Visible = false;
            Outofstockwarning.Click += Outofstockwarning_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 23);
            ClientSize = new Size(1850, 920);
            Controls.Add(Outofstockwarning);
            Controls.Add(LowStockWarning);
            Controls.Add(lblwelcome);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(ordersCard);
            Controls.Add(revenueCard);
            Controls.Add(label1);
            Controls.Add(leftNavPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Dashboard_Load;
            leftNavPanel.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            revenueCard.ResumeLayout(false);
            revenueCard.PerformLayout();
            ordersCard.ResumeLayout(false);
            ordersCard.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)salesChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel leftNavPanel;
        private PictureBox pictureBox1;
        private Button btnPOS;
        private Button btnDashboard;
        private Button btnSettings;
        private Button btnSales;
        private Button btnInventory;
        private Label label1;
        private Panel revenueCard;
        private Panel ordersCard;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Panel panel3;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label3;
        private Label label6;
        private Panel settingsPanel;
        private Button btnaudittrail;
        private Button btnusermanagement;
        private Button btnlogout;
        private System.Windows.Forms.Timer slideTimer;
        private Panel panel4;
        private Label lblwelcome;
        private Panel panel2;
        private Label label7;
        private Button LowStockWarning;
        private Button Outofstockwarning;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnWeekly;
        private Button btnMonthly;
    }
}