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
            adddiscountbtn = new Button();
            button5 = new Button();
            rightOrderPanel = new Panel();
            lbldiscount = new Label();
            label6 = new Label();
            php = new Label();
            lbltotalamount = new Label();
            lblsubtotal = new Label();
            lblnumberofitem = new Label();
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
            // adddiscountbtn
            // 
            adddiscountbtn.BackColor = Color.FromArgb(30, 30, 30);
            adddiscountbtn.FlatStyle = FlatStyle.Flat;
            adddiscountbtn.ForeColor = Color.FromArgb(255, 255, 128);
            adddiscountbtn.Location = new Point(384, 603);
            adddiscountbtn.Name = "adddiscountbtn";
            adddiscountbtn.Size = new Size(115, 23);
            adddiscountbtn.TabIndex = 7;
            adddiscountbtn.Text = "Add Discount";
            adddiscountbtn.UseVisualStyleBackColor = false;
            adddiscountbtn.Click += adddiscountbtn_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(204, 141, 26);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button5.Location = new Point(20, 776);
            button5.Name = "button5";
            button5.Size = new Size(490, 34);
            button5.TabIndex = 8;
            button5.Text = "Proceed Transaction";
            button5.UseVisualStyleBackColor = false;
            // 
            // rightOrderPanel
            // 
            rightOrderPanel.Controls.Add(adddiscountbtn);
            rightOrderPanel.Controls.Add(lbldiscount);
            rightOrderPanel.Controls.Add(label6);
            rightOrderPanel.Controls.Add(php);
            rightOrderPanel.Controls.Add(lbltotalamount);
            rightOrderPanel.Controls.Add(lblsubtotal);
            rightOrderPanel.Controls.Add(lblnumberofitem);
            rightOrderPanel.Controls.Add(panel1);
            rightOrderPanel.Controls.Add(Orderlistpanel);
            rightOrderPanel.Controls.Add(button5);
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
            // lbldiscount
            // 
            lbldiscount.AutoSize = true;
            lbldiscount.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbldiscount.ForeColor = Color.White;
            lbldiscount.Location = new Point(430, 564);
            lbldiscount.Name = "lbldiscount";
            lbldiscount.Size = new Size(20, 25);
            lbldiscount.TabIndex = 21;
            lbldiscount.Text = "-";
            lbldiscount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(35, 570);
            label6.Name = "label6";
            label6.Size = new Size(64, 17);
            label6.TabIndex = 20;
            label6.Text = "Discount:";
            // 
            // php
            // 
            php.AutoSize = true;
            php.BackColor = Color.Transparent;
            php.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            php.ForeColor = Color.FromArgb(204, 141, 26);
            php.Location = new Point(312, 679);
            php.Name = "php";
            php.Size = new Size(34, 17);
            php.TabIndex = 19;
            php.Text = "PHP";
            // 
            // lbltotalamount
            // 
            lbltotalamount.AutoSize = true;
            lbltotalamount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbltotalamount.ForeColor = Color.White;
            lbltotalamount.Location = new Point(430, 670);
            lbltotalamount.Name = "lbltotalamount";
            lbltotalamount.Size = new Size(20, 28);
            lbltotalamount.TabIndex = 18;
            lbltotalamount.Text = "-";
            lbltotalamount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblsubtotal
            // 
            lblsubtotal.AutoSize = true;
            lblsubtotal.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblsubtotal.ForeColor = Color.White;
            lblsubtotal.Location = new Point(430, 539);
            lblsubtotal.Name = "lblsubtotal";
            lblsubtotal.Size = new Size(20, 25);
            lblsubtotal.TabIndex = 17;
            lblsubtotal.Text = "-";
            lblsubtotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblnumberofitem
            // 
            lblnumberofitem.AutoSize = true;
            lblnumberofitem.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblnumberofitem.ForeColor = Color.White;
            lblnumberofitem.Location = new Point(430, 514);
            lblnumberofitem.Name = "lblnumberofitem";
            lblnumberofitem.Size = new Size(20, 25);
            lblnumberofitem.TabIndex = 16;
            lblnumberofitem.Text = "-";
            lblnumberofitem.TextAlign = ContentAlignment.MiddleCenter;
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
            label5.Location = new Point(25, 679);
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
        private Button adddiscountbtn;
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
        private Label lblnumberofitem;
        private Label lbltotalamount;
        private Label lblsubtotal;
        private Label php;
        private Label lbldiscount;
        private Label label6;
    }
}