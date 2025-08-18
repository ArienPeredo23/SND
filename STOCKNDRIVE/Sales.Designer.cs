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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnSales = new Button();
            btnInventory = new Button();
            btnPOS = new Button();
            btnDashboard = new Button();
            leftNavPanel = new Panel();
            pictureBox1 = new PictureBox();
            btnSettings = new Button();
            label1 = new Label();
            panel4 = new Panel();
            reportPanel = new Panel();
            dgvSalesReport = new DataGridView();
            txtSearch = new TextBox();
            btnFilter = new Button();
            btnExport = new Button();
            label2 = new Label();
            leftNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            reportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
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
            panel4.Size = new Size(980, 2);
            panel4.TabIndex = 8;
            // 
            // reportPanel
            // 
            reportPanel.BackColor = Color.White;
            reportPanel.Controls.Add(dgvSalesReport);
            reportPanel.Controls.Add(txtSearch);
            reportPanel.Controls.Add(btnFilter);
            reportPanel.Controls.Add(btnExport);
            reportPanel.Controls.Add(label2);
            reportPanel.Location = new Point(260, 98);
            reportPanel.Name = "reportPanel";
            reportPanel.Size = new Size(1550, 793);
            reportPanel.TabIndex = 9;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AllowUserToDeleteRows = false;
            dgvSalesReport.BackgroundColor = Color.White;
            dgvSalesReport.BorderStyle = BorderStyle.None;
            dgvSalesReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSalesReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSalesReport.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSalesReport.GridColor = SystemColors.ButtonFace;
            dgvSalesReport.Location = new Point(25, 80);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.RowHeadersVisible = false;
            dgvSalesReport.Size = new Size(925, 485);
            dgvSalesReport.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(507, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 3;
            // 
            // btnFilter
            // 
            btnFilter.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.Location = new Point(774, 20);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(70, 30);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "Filter";
            btnFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(233, 95, 95);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(858, 20);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(90, 30);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 20);
            label2.Name = "label2";
            label2.Size = new Size(135, 30);
            label2.TabIndex = 0;
            label2.Text = "Sales Report";
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 23);
            ClientSize = new Size(1850, 920);
            Controls.Add(reportPanel);
            Controls.Add(panel4);
            Controls.Add(label1);
            Controls.Add(leftNavPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Sales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory";
            leftNavPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            reportPanel.ResumeLayout(false);
            reportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
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
        private TextBox txtSearch;
        private Button btnFilter;
        private DataGridView dgvSalesReport;
        private PictureBox pictureBox1;
    }
}