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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pos));
            leftNavPanel = new Panel();
            settingsPanel = new Panel();
            btnaudittrail = new Button();
            btnusermanagement = new Button();
            btnlogout = new Button();
            pictureBox1 = new PictureBox();
            productFlowPanel = new FlowLayoutPanel();
            btnSettings = new Button();
            btnSales = new Button();
            btnInventory = new Button();
            btnPOS = new Button();
            btnDashboard = new Button();
            topActionPanel = new Panel();
            panel4 = new Panel();
            label7 = new Label();
            lblwelcome = new Label();
            adddiscountbtn = new Button();
            Proceed = new Button();
            rightOrderPanel = new Panel();
            lbldiscountdescription = new Label();
            cleardiscount = new Label();
            clearpanellbl = new Label();
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
            lblclear = new Label();
            searchtb = new TextBox();
            btnFilter = new Button();
            slideTimer = new System.Windows.Forms.Timer(components);
            leftNavPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            topActionPanel.SuspendLayout();
            rightOrderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftNavPanel
            // 
            leftNavPanel.BackColor = Color.FromArgb(30, 30, 30);
            leftNavPanel.Controls.Add(settingsPanel);
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
            // settingsPanel
            // 
            settingsPanel.Controls.Add(btnaudittrail);
            settingsPanel.Controls.Add(btnusermanagement);
            settingsPanel.Controls.Add(btnlogout);
            settingsPanel.Location = new Point(12, 650);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(198, 189);
            settingsPanel.TabIndex = 12;
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
            topActionPanel.Controls.Add(panel4);
            topActionPanel.Controls.Add(label7);
            topActionPanel.Controls.Add(lblwelcome);
            topActionPanel.Dock = DockStyle.Top;
            topActionPanel.Location = new Point(240, 0);
            topActionPanel.Name = "topActionPanel";
            topActionPanel.Size = new Size(1610, 80);
            topActionPanel.TabIndex = 3;
            topActionPanel.Paint += topActionPanel_Paint;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.Location = new Point(20, 77);
            panel4.Name = "panel4";
            panel4.Size = new Size(1550, 2);
            panel4.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(20, 30);
            label7.Name = "label7";
            label7.Size = new Size(224, 45);
            label7.TabIndex = 12;
            label7.Text = "Point of Sales";
            // 
            // lblwelcome
            // 
            lblwelcome.AutoSize = true;
            lblwelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblwelcome.ForeColor = Color.FromArgb(204, 141, 26);
            lblwelcome.Location = new Point(31, 12);
            lblwelcome.Name = "lblwelcome";
            lblwelcome.Size = new Size(16, 21);
            lblwelcome.TabIndex = 0;
            lblwelcome.Text = "-";
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
            // Proceed
            // 
            Proceed.BackColor = Color.FromArgb(204, 141, 26);
            Proceed.FlatStyle = FlatStyle.Flat;
            Proceed.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Proceed.Location = new Point(20, 776);
            Proceed.Name = "Proceed";
            Proceed.Size = new Size(490, 34);
            Proceed.TabIndex = 8;
            Proceed.Text = "Proceed Transaction";
            Proceed.UseVisualStyleBackColor = false;
            Proceed.Click += Proceed_Click;
            // 
            // rightOrderPanel
            // 
            rightOrderPanel.Controls.Add(lbldiscountdescription);
            rightOrderPanel.Controls.Add(cleardiscount);
            rightOrderPanel.Controls.Add(clearpanellbl);
            rightOrderPanel.Controls.Add(adddiscountbtn);
            rightOrderPanel.Controls.Add(lbldiscount);
            rightOrderPanel.Controls.Add(label6);
            rightOrderPanel.Controls.Add(php);
            rightOrderPanel.Controls.Add(lbltotalamount);
            rightOrderPanel.Controls.Add(lblsubtotal);
            rightOrderPanel.Controls.Add(lblnumberofitem);
            rightOrderPanel.Controls.Add(panel1);
            rightOrderPanel.Controls.Add(Orderlistpanel);
            rightOrderPanel.Controls.Add(Proceed);
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
            // lbldiscountdescription
            // 
            lbldiscountdescription.AutoSize = true;
            lbldiscountdescription.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lbldiscountdescription.ForeColor = Color.White;
            lbldiscountdescription.Location = new Point(105, 564);
            lbldiscountdescription.Name = "lbldiscountdescription";
            lbldiscountdescription.Size = new Size(20, 25);
            lbldiscountdescription.TabIndex = 23;
            lbldiscountdescription.Text = "-";
            lbldiscountdescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cleardiscount
            // 
            cleardiscount.AutoSize = true;
            cleardiscount.BackColor = Color.Transparent;
            cleardiscount.Cursor = Cursors.Hand;
            cleardiscount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cleardiscount.ForeColor = Color.White;
            cleardiscount.Location = new Point(311, 605);
            cleardiscount.Name = "cleardiscount";
            cleardiscount.Size = new Size(46, 21);
            cleardiscount.TabIndex = 22;
            cleardiscount.Text = "Clear";
            cleardiscount.Visible = false;
            cleardiscount.Click += cleardiscount_Click;
            // 
            // clearpanellbl
            // 
            clearpanellbl.AutoSize = true;
            clearpanellbl.BackColor = Color.Transparent;
            clearpanellbl.Cursor = Cursors.Hand;
            clearpanellbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearpanellbl.ForeColor = Color.White;
            clearpanellbl.Location = new Point(464, 40);
            clearpanellbl.Name = "clearpanellbl";
            clearpanellbl.Size = new Size(46, 21);
            clearpanellbl.TabIndex = 15;
            clearpanellbl.Text = "Clear";
            clearpanellbl.Visible = false;
            clearpanellbl.Click += clearpanellbl_Click;
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
            // lblclear
            // 
            lblclear.AutoSize = true;
            lblclear.BackColor = Color.White;
            lblclear.Cursor = Cursors.Hand;
            lblclear.Font = new Font("Segoe UI", 9F);
            lblclear.Location = new Point(1139, 110);
            lblclear.Name = "lblclear";
            lblclear.Size = new Size(14, 15);
            lblclear.TabIndex = 13;
            lblclear.Text = "X";
            lblclear.Visible = false;
            lblclear.Click += lblclear_Click;
            // 
            // searchtb
            // 
            searchtb.Location = new Point(880, 106);
            searchtb.Name = "searchtb";
            searchtb.Size = new Size(282, 23);
            searchtb.TabIndex = 12;
            searchtb.TextChanged += searchtb_TextChanged;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.White;
            btnFilter.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.Location = new Point(1182, 106);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(70, 30);
            btnFilter.TabIndex = 14;
            btnFilter.Text = "Filter";
            btnFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // slideTimer
            // 
            slideTimer.Interval = 15;
            // 
            // pos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 23);
            ClientSize = new Size(1850, 920);
            Controls.Add(btnFilter);
            Controls.Add(lblclear);
            Controls.Add(searchtb);
            Controls.Add(panel2);
            Controls.Add(rightOrderPanel);
            Controls.Add(topActionPanel);
            Controls.Add(leftNavPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "pos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "pos";
            Load += pos_Load;
            leftNavPanel.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            topActionPanel.ResumeLayout(false);
            topActionPanel.PerformLayout();
            rightOrderPanel.ResumeLayout(false);
            rightOrderPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel leftNavPanel;
        private Button btnSettings;
        private Button btnSales;
        private Button btnInventory;
        private Button btnPOS;
        private Button btnDashboard;
        private Panel topActionPanel;
        private Button adddiscountbtn;
        private Button Proceed;
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
        private Label lblwelcome;
        private Label label7;
        private Label lblclear;
        private TextBox searchtb;
        private Button btnFilter;
        private Label clearpanellbl;
        private Label cleardiscount;
        private Label lbldiscountdescription;
        private Panel settingsPanel;
        private Button btnlogout;
        private System.Windows.Forms.Timer slideTimer;
        private Button btnusermanagement;
        private Button btnaudittrail;
        private Panel panel4;
    }
}