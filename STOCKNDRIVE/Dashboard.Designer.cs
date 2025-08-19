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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            leftNavPanel = new Panel();
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
            panel2 = new Panel();
            label7 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            lblwelcome = new Label();
            leftNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            revenueCard.SuspendLayout();
            ordersCard.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // leftNavPanel
            // 
            leftNavPanel.BackColor = Color.FromArgb(30, 30, 30);
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
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label7);
            panel2.Location = new Point(280, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(813, 450);
            panel2.TabIndex = 3;
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(45, 45, 45);
            panel3.Location = new Point(280, 574);
            panel3.Name = "panel3";
            panel3.Size = new Size(813, 317);
            panel3.TabIndex = 4;
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
            lblwelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblwelcome.ForeColor = Color.FromArgb(204, 141, 26);
            lblwelcome.Location = new Point(271, 12);
            lblwelcome.Name = "lblwelcome";
            lblwelcome.Size = new Size(16, 21);
            lblwelcome.TabIndex = 6;
            lblwelcome.Text = "-";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 23);
            ClientSize = new Size(1850, 920);
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
            Text = "Dashboard";
            Load += Dashboard_Load;
            leftNavPanel.ResumeLayout(false);
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
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label lblwelcome;
    }
}