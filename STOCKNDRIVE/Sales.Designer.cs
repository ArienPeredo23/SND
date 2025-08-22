namespace STOCKNDRIVE
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btnSales = new Button();
            btnInventory = new Button();
            btnPOS = new Button();
            btnDashboard = new Button();
            leftNavPanel = new Panel();
            settingsPanel = new Panel();
            btnaudittrail = new Button();
            btnusermanagement = new Button();
            btnlogout = new Button();
            pictureBox1 = new PictureBox();
            btnSettings = new Button();
            label1 = new Label();
            panel4 = new Panel();
            reportPanel = new Panel();
            dgvSalesReport = new DataGridView();
            NameSearchtb = new TextBox();
            btnFilter = new Button();
            label2 = new Label();
            btnExport = new Button();
            lblwelcome = new Label();
            slideTimer = new System.Windows.Forms.Timer(components);
            panelDateFilter = new Panel();
            lblDateRange = new Label();
            btnClearFilter = new Button();
            monthCalendar1 = new MonthCalendar();
            leftNavPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            reportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            panelDateFilter.SuspendLayout();
            SuspendLayout();
            // 
            // btnSales
            // 
            btnSales.BackColor = SystemColors.ActiveCaptionText;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSales.ForeColor = Color.White;
            btnSales.Image = (Image)resources.GetObject("btnSales.Image");
            btnSales.ImageAlign = ContentAlignment.MiddleLeft;
            btnSales.Location = new Point(30, 312);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(180, 45);
            btnSales.TabIndex = 4;
            btnSales.Text = " Sales";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSales.UseVisualStyleBackColor = false;
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
            btnInventory.Location = new Point(30, 257);
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
            btnPOS.Location = new Point(30, 202);
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
            btnDashboard.BackColor = Color.FromArgb(30, 30, 30);
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
            // leftNavPanel
            // 
            leftNavPanel.BackColor = Color.FromArgb(30, 30, 30);
            leftNavPanel.Controls.Add(settingsPanel);
            leftNavPanel.Controls.Add(pictureBox1);
            leftNavPanel.Controls.Add(btnSettings);
            leftNavPanel.Controls.Add(btnSales);
            leftNavPanel.Controls.Add(btnInventory);
            leftNavPanel.Controls.Add(btnPOS);
            leftNavPanel.Controls.Add(btnDashboard);
            leftNavPanel.Dock = DockStyle.Left;
            leftNavPanel.Location = new Point(0, 0);
            leftNavPanel.Name = "leftNavPanel";
            leftNavPanel.Size = new Size(240, 920);
            leftNavPanel.TabIndex = 1;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(btnaudittrail);
            settingsPanel.Controls.Add(btnusermanagement);
            settingsPanel.Controls.Add(btnlogout);
            settingsPanel.Location = new Point(12, 650);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(198, 189);
            settingsPanel.TabIndex = 14;
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(260, 30);
            label1.Name = "label1";
            label1.Size = new Size(302, 45);
            label1.TabIndex = 7;
            label1.Text = "Sales Management";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.Location = new Point(260, 79);
            panel4.Name = "panel4";
            panel4.Size = new Size(1550, 2);
            panel4.TabIndex = 8;
            // 
            // reportPanel
            // 
            reportPanel.BackColor = Color.White;
            reportPanel.Controls.Add(dgvSalesReport);
            reportPanel.Controls.Add(NameSearchtb);
            reportPanel.Controls.Add(btnFilter);
            reportPanel.Controls.Add(label2);
            reportPanel.Location = new Point(260, 98);
            reportPanel.Name = "reportPanel";
            reportPanel.Size = new Size(1255, 793);
            reportPanel.TabIndex = 9;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AllowUserToDeleteRows = false;
            dgvSalesReport.BackgroundColor = Color.White;
            dgvSalesReport.BorderStyle = BorderStyle.None;
            dgvSalesReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSalesReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSalesReport.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSalesReport.GridColor = SystemColors.ButtonFace;
            dgvSalesReport.Location = new Point(25, 80);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.RowHeadersVisible = false;
            dgvSalesReport.Size = new Size(1206, 485);
            dgvSalesReport.TabIndex = 4;
            // 
            // NameSearchtb
            // 
            NameSearchtb.Font = new Font("Segoe UI", 12F);
            NameSearchtb.Location = new Point(765, 36);
            NameSearchtb.Name = "NameSearchtb";
            NameSearchtb.Size = new Size(356, 29);
            NameSearchtb.TabIndex = 3;
            NameSearchtb.TextChanged += NameSearchtb_TextChanged;
            NameSearchtb.Enter += NameSearchtb_Enter;
            NameSearchtb.Leave += NameSearchtb_Leave;
            // 
            // btnFilter
            // 
            btnFilter.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.Location = new Point(1127, 36);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(104, 30);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "Date Filter";
            btnFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(25, 36);
            label2.Name = "label2";
            label2.Size = new Size(162, 32);
            label2.TabIndex = 0;
            label2.Text = "Sales History";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(233, 95, 95);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1745, 860);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(90, 30);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // lblwelcome
            // 
            lblwelcome.AutoSize = true;
            lblwelcome.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblwelcome.ForeColor = Color.FromArgb(204, 141, 26);
            lblwelcome.Location = new Point(700, 43);
            lblwelcome.Name = "lblwelcome";
            lblwelcome.Size = new Size(20, 28);
            lblwelcome.TabIndex = 10;
            lblwelcome.Text = "-";
            // 
            // slideTimer
            // 
            slideTimer.Interval = 15;
            // 
            // panelDateFilter
            // 
            panelDateFilter.Controls.Add(lblDateRange);
            panelDateFilter.Controls.Add(btnClearFilter);
            panelDateFilter.Controls.Add(monthCalendar1);
            panelDateFilter.Location = new Point(1531, 98);
            panelDateFilter.Name = "panelDateFilter";
            panelDateFilter.Size = new Size(307, 396);
            panelDateFilter.TabIndex = 11;
            panelDateFilter.Visible = false;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new Font("Segoe UI", 14F);
            lblDateRange.ForeColor = Color.Yellow;
            lblDateRange.Location = new Point(74, 8);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(161, 25);
            lblDateRange.TabIndex = 4;
            lblDateRange.Text = "Select a start date";
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.Gray;
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(214, 363);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(90, 30);
            btnClearFilter.TabIndex = 3;
            btnClearFilter.Text = "Clear";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(1, 2);
            monthCalendar1.Location = new Point(41, 42);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 2;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 23);
            ClientSize = new Size(1850, 920);
            Controls.Add(panelDateFilter);
            Controls.Add(lblwelcome);
            Controls.Add(reportPanel);
            Controls.Add(btnExport);
            Controls.Add(panel4);
            Controls.Add(label1);
            Controls.Add(leftNavPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Sales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory";
            Load += Sales_Load;
            leftNavPanel.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            reportPanel.ResumeLayout(false);
            reportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            panelDateFilter.ResumeLayout(false);
            panelDateFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSales;
        private Button btnInventory;
        private Button btnPOS;
        private Button btnDashboard;
        private Panel leftNavPanel;
        private Button btnSettings;
        private Label label1;
        private Panel panel4;
        private Panel reportPanel;
        private Button btnExport;
        private Label label2;
        private TextBox NameSearchtb;
        private Button btnFilter;
        private DataGridView dgvSalesReport;
        private PictureBox pictureBox1;
        private Label lblwelcome;
        private Panel settingsPanel;
        private Button btnaudittrail;
        private Button btnusermanagement;
        private Button btnlogout;
        private System.Windows.Forms.Timer slideTimer;
        private Panel panelDateFilter;
        private Label lblDateRange;
        private Button btnClearFilter;
        private MonthCalendar monthCalendar1;
    }
}