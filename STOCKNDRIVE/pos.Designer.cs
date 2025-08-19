namespace STOCKNDRIVE
{
    partial class pos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pos));
            leftNavPanel = new Panel();
            pictureBox1 = new PictureBox();
            productFlowPanel = new FlowLayoutPanel();
            btnSettings = new Button();
            btnSales = new Button();
            btnInventory = new Button();
            btnPOS = new Button();
            btnDashboard = new Button();
            topActionPanel = new Panel();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            rightOrderPanel = new Panel();
            panel1 = new Panel();
            Orderlistpanel = new FlowLayoutPanel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            separatorPanel = new Panel();
            label2 = new Label();
            panel2 = new FlowLayoutPanel();
            leftNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            topActionPanel.SuspendLayout();
            rightOrderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftNavPanel
            // 
            leftNavPanel.BackColor = Color.FromArgb(30, 30, 30);
            leftNavPanel.Controls.Add(pictureBox1);
            leftNavPanel.Controls.Add(productFlowPanel);
            leftNavPanel.Controls.Add(btnSettings);
            leftNavPanel.Controls.Add(btnSales);
            leftNavPanel.Controls.Add(btnInventory);
            leftNavPanel.Controls.Add(btnPOS);
            leftNavPanel.Controls.Add(btnDashboard);
            leftNavPanel.Dock = DockStyle.Left;
            leftNavPanel.Location = new Point(0, 0);
            leftNavPanel.Name = "leftNavPanel";
            leftNavPanel.Size = new Size(240, 920);
            leftNavPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // productFlowPanel
            // 
            productFlowPanel.AutoScroll = true;
            productFlowPanel.Location = new Point(240, 144);
            productFlowPanel.Name = "productFlowPanel";
            productFlowPanel.Size = new Size(690, 576);
            productFlowPanel.TabIndex = 10;
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
            btnSales.Location = new Point(30, 317);
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
            btnInventory.Location = new Point(30, 262);
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
            btnPOS.BackColor = SystemColors.ActiveCaptionText;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPOS.ForeColor = Color.White;
            btnPOS.Image = (Image)resources.GetObject("btnPOS.Image");
            btnPOS.ImageAlign = ContentAlignment.MiddleLeft;
            btnPOS.Location = new Point(30, 207);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(180, 45);
            btnPOS.TabIndex = 2;
            btnPOS.Text = " POS";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPOS.UseVisualStyleBackColor = false;
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
            // topActionPanel
            // 
            topActionPanel.Controls.Add(textBox1);
            topActionPanel.Dock = DockStyle.Top;
            topActionPanel.Location = new Point(240, 0);
            topActionPanel.Name = "topActionPanel";
            topActionPanel.Size = new Size(1610, 80);
            topActionPanel.TabIndex = 3;
            topActionPanel.Paint += topActionPanel_Paint;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(350, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 23);
            textBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(325, 104);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(427, 104);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(523, 104);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(620, 104);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 7;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(715, 104);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 8;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // rightOrderPanel
            // 
            rightOrderPanel.Controls.Add(panel1);
            rightOrderPanel.Controls.Add(Orderlistpanel);
            rightOrderPanel.Controls.Add(label5);
            rightOrderPanel.Controls.Add(label4);
            rightOrderPanel.Controls.Add(label3);
            rightOrderPanel.Controls.Add(label1);
            rightOrderPanel.Controls.Add(separatorPanel);
            rightOrderPanel.Controls.Add(label2);
            rightOrderPanel.Dock = DockStyle.Right;
            rightOrderPanel.Location = new Point(1319, 80);
            rightOrderPanel.Name = "rightOrderPanel";
            rightOrderPanel.Size = new Size(531, 840);
            rightOrderPanel.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 50, 50);
            panel1.Location = new Point(20, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(490, 2);
            panel1.TabIndex = 12;
            // 
            // Orderlistpanel
            // 
            Orderlistpanel.AutoScroll = true;
            Orderlistpanel.FlowDirection = FlowDirection.TopDown;
            Orderlistpanel.Location = new Point(3, 81);
            Orderlistpanel.Name = "Orderlistpanel";
            Orderlistpanel.Size = new Size(525, 363);
            Orderlistpanel.TabIndex = 10;
            Orderlistpanel.WrapContents = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(25, 600);
            label5.Name = "label5";
            label5.Size = new Size(114, 17);
            label5.TabIndex = 15;
            label5.Text = "TOTAL AMOUNT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(35, 545);
            label4.Name = "label4";
            label4.Size = new Size(62, 17);
            label4.TabIndex = 14;
            label4.Text = "Subtotal:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(35, 520);
            label3.Name = "label3";
            label3.Size = new Size(115, 17);
            label3.TabIndex = 13;
            label3.Text = "Number of Items:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 480);
            label1.Name = "label1";
            label1.Size = new Size(156, 21);
            label1.TabIndex = 12;
            label1.Text = "Payment Summary";
            // 
            // separatorPanel
            // 
            separatorPanel.BackColor = Color.FromArgb(50, 50, 50);
            separatorPanel.Location = new Point(20, 450);
            separatorPanel.Name = "separatorPanel";
            separatorPanel.Size = new Size(490, 2);
            separatorPanel.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 40);
            label2.Name = "label2";
            label2.Size = new Size(83, 21);
            label2.TabIndex = 10;
            label2.Text = "Order List";
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Location = new Point(279, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(1034, 729);
            panel2.TabIndex = 11;
            panel2.Visible = false;
            // 
            // pos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 23);
            ClientSize = new Size(1850, 920);
            Controls.Add(panel2);
            Controls.Add(rightOrderPanel);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(topActionPanel);
            Controls.Add(leftNavPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "pos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "pos";
            Load += pos_Load;
            leftNavPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            topActionPanel.ResumeLayout(false);
            topActionPanel.PerformLayout();
            rightOrderPanel.ResumeLayout(false);
            rightOrderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel leftNavPanel;
        private Button btnSettings;
        private Button btnSales;
        private Button btnInventory;
        private Button btnPOS;
        private Button btnDashboard;
        private Panel topActionPanel;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Panel rightOrderPanel;
        private Label label3;
        private Label label1;
        private Panel separatorPanel;
        private Label label2;
        private FlowLayoutPanel productFlowPanel;
        private Label label5;
        private Label label4;
        private FlowLayoutPanel Orderlistpanel;
        private Panel panel1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel panel2;
    }
}