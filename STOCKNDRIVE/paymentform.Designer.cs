namespace STOCKNDRIVE
{
    partial class paymentform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(paymentform));
            button1 = new Button();
            lbldiscount = new Label();
            label6 = new Label();
            php = new Label();
            lbltotalamount = new Label();
            lblsubtotal = new Label();
            lblnumberofitem = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            summarygrid = new DataGridView();
            label2 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblchange = new Label();
            panel1 = new Panel();
            label9 = new Label();
            label10 = new Label();
            lblSaleID = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            notetb = new TextBox();
            button2 = new Button();
            Proceed = new Button();
            amountpaid = new NumericUpDown();
            tbname = new TextBox();
            ((System.ComponentModel.ISupportInitialize)summarygrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountpaid).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(30, 30, 30);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(30, 30, 30);
            button1.Location = new Point(495, 12);
            button1.Name = "button1";
            button1.Size = new Size(20, 20);
            button1.TabIndex = 18;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lbldiscount
            // 
            lbldiscount.AutoSize = true;
            lbldiscount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbldiscount.ForeColor = Color.DarkGray;
            lbldiscount.Location = new Point(422, 461);
            lbldiscount.Name = "lbldiscount";
            lbldiscount.Size = new Size(76, 21);
            lbldiscount.TabIndex = 32;
            lbldiscount.Text = "-----------";
            lbldiscount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.DarkGray;
            label6.Location = new Point(42, 467);
            label6.Name = "label6";
            label6.Size = new Size(64, 17);
            label6.TabIndex = 31;
            label6.Text = "Discount:";
            // 
            // php
            // 
            php.AutoSize = true;
            php.BackColor = Color.Transparent;
            php.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            php.ForeColor = Color.FromArgb(204, 141, 26);
            php.Location = new Point(331, 501);
            php.Name = "php";
            php.Size = new Size(34, 17);
            php.TabIndex = 30;
            php.Text = "PHP";
            // 
            // lbltotalamount
            // 
            lbltotalamount.AutoSize = true;
            lbltotalamount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbltotalamount.ForeColor = Color.FromArgb(204, 141, 26);
            lbltotalamount.Location = new Point(419, 495);
            lbltotalamount.Name = "lbltotalamount";
            lbltotalamount.Size = new Size(76, 25);
            lbltotalamount.TabIndex = 29;
            lbltotalamount.Text = "--------";
            lbltotalamount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblsubtotal
            // 
            lblsubtotal.AutoSize = true;
            lblsubtotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblsubtotal.ForeColor = Color.DarkGray;
            lblsubtotal.Location = new Point(422, 429);
            lblsubtotal.Name = "lblsubtotal";
            lblsubtotal.Size = new Size(76, 21);
            lblsubtotal.TabIndex = 28;
            lblsubtotal.Text = "-----------";
            lblsubtotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblnumberofitem
            // 
            lblnumberofitem.AutoSize = true;
            lblnumberofitem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblnumberofitem.ForeColor = Color.DarkGray;
            lblnumberofitem.Location = new Point(422, 398);
            lblnumberofitem.Name = "lblnumberofitem";
            lblnumberofitem.Size = new Size(76, 21);
            lblnumberofitem.TabIndex = 27;
            lblnumberofitem.Text = "-----------";
            lblnumberofitem.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(32, 504);
            label5.Name = "label5";
            label5.Size = new Size(114, 17);
            label5.TabIndex = 26;
            label5.Text = "TOTAL AMOUNT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.DarkGray;
            label4.Location = new Point(42, 435);
            label4.Name = "label4";
            label4.Size = new Size(62, 17);
            label4.TabIndex = 25;
            label4.Text = "Subtotal:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(260, 37);
            label1.TabIndex = 23;
            label1.Text = "Payment Summary";
            // 
            // summarygrid
            // 
            summarygrid.AllowUserToAddRows = false;
            summarygrid.AllowUserToDeleteRows = false;
            summarygrid.AllowUserToResizeColumns = false;
            summarygrid.AllowUserToResizeRows = false;
            summarygrid.BackgroundColor = Color.FromArgb(30, 30, 30);
            summarygrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            summarygrid.Enabled = false;
            summarygrid.Location = new Point(12, 129);
            summarygrid.MultiSelect = false;
            summarygrid.Name = "summarygrid";
            summarygrid.ReadOnly = true;
            summarygrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            summarygrid.Size = new Size(503, 246);
            summarygrid.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkGray;
            label2.Location = new Point(32, 546);
            label2.Name = "label2";
            label2.Size = new Size(111, 17);
            label2.TabIndex = 35;
            label2.Text = "Customer Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(32, 588);
            label7.Name = "label7";
            label7.Size = new Size(93, 17);
            label7.TabIndex = 36;
            label7.Text = "Amount Paid:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label8.ForeColor = Color.DarkGray;
            label8.Location = new Point(42, 617);
            label8.Name = "label8";
            label8.Size = new Size(54, 17);
            label8.TabIndex = 37;
            label8.Text = "Change";
            // 
            // lblchange
            // 
            lblchange.AutoSize = true;
            lblchange.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblchange.ForeColor = Color.FromArgb(204, 141, 26);
            lblchange.Location = new Point(422, 617);
            lblchange.Name = "lblchange";
            lblchange.Size = new Size(13, 17);
            lblchange.TabIndex = 40;
            lblchange.Text = "-";
            lblchange.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 50, 50);
            panel1.Location = new Point(19, 381);
            panel1.Name = "panel1";
            panel1.Size = new Size(490, 2);
            panel1.TabIndex = 41;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label9.ForeColor = Color.DarkGray;
            label9.Location = new Point(209, 644);
            label9.Name = "label9";
            label9.Size = new Size(110, 17);
            label9.TabIndex = 42;
            label9.Text = "NOTES (optional)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.DarkGray;
            label10.Location = new Point(32, 402);
            label10.Name = "label10";
            label10.Size = new Size(122, 17);
            label10.TabIndex = 43;
            label10.Text = "NUMBER OF ITEM:";
            // 
            // lblSaleID
            // 
            lblSaleID.AutoSize = true;
            lblSaleID.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSaleID.ForeColor = Color.FromArgb(204, 141, 26);
            lblSaleID.Location = new Point(32, 98);
            lblSaleID.Name = "lblSaleID";
            lblSaleID.RightToLeft = RightToLeft.Yes;
            lblSaleID.Size = new Size(20, 28);
            lblSaleID.TabIndex = 45;
            lblSaleID.Text = "-";
            lblSaleID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 50, 50);
            panel2.Location = new Point(-2, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(529, 10);
            panel2.TabIndex = 42;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(50, 50, 50);
            panel3.Location = new Point(-2, 765);
            panel3.Name = "panel3";
            panel3.Size = new Size(529, 10);
            panel3.TabIndex = 43;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(50, 50, 50);
            panel4.Location = new Point(-2, 8);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 758);
            panel4.TabIndex = 44;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(50, 50, 50);
            panel5.Location = new Point(519, 8);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 758);
            panel5.TabIndex = 45;
            // 
            // notetb
            // 
            notetb.BackColor = Color.DimGray;
            notetb.BorderStyle = BorderStyle.None;
            notetb.Location = new Point(32, 664);
            notetb.Multiline = true;
            notetb.Name = "notetb";
            notetb.Size = new Size(462, 58);
            notetb.TabIndex = 44;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.Location = new Point(12, 728);
            button2.Name = "button2";
            button2.Size = new Size(231, 34);
            button2.TabIndex = 33;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Proceed
            // 
            Proceed.BackColor = Color.FromArgb(204, 141, 26);
            Proceed.FlatStyle = FlatStyle.Flat;
            Proceed.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Proceed.Location = new Point(284, 728);
            Proceed.Name = "Proceed";
            Proceed.Size = new Size(231, 34);
            Proceed.TabIndex = 22;
            Proceed.Text = "Paid";
            Proceed.UseVisualStyleBackColor = false;
            Proceed.Click += Proceed_Click;
            // 
            // amountpaid
            // 
            amountpaid.BackColor = Color.FromArgb(30, 30, 30);
            amountpaid.BorderStyle = BorderStyle.FixedSingle;
            amountpaid.Font = new Font("Segoe UI", 12F);
            amountpaid.ForeColor = Color.White;
            amountpaid.Location = new Point(377, 576);
            amountpaid.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            amountpaid.Name = "amountpaid";
            amountpaid.Size = new Size(117, 29);
            amountpaid.TabIndex = 39;
            amountpaid.TextAlign = HorizontalAlignment.Center;
            // 
            // tbname
            // 
            tbname.BackColor = Color.FromArgb(30, 30, 30);
            tbname.BorderStyle = BorderStyle.FixedSingle;
            tbname.Font = new Font("Segoe UI", 12F);
            tbname.ForeColor = Color.White;
            tbname.Location = new Point(263, 545);
            tbname.Name = "tbname";
            tbname.Size = new Size(231, 29);
            tbname.TabIndex = 38;
            // 
            // paymentform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(527, 774);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(lblSaleID);
            Controls.Add(notetb);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(panel1);
            Controls.Add(lblchange);
            Controls.Add(amountpaid);
            Controls.Add(tbname);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(summarygrid);
            Controls.Add(button2);
            Controls.Add(lbldiscount);
            Controls.Add(label6);
            Controls.Add(php);
            Controls.Add(lbltotalamount);
            Controls.Add(lblsubtotal);
            Controls.Add(lblnumberofitem);
            Controls.Add(Proceed);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "paymentform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "paymentform";
            Load += paymentform_Load;
            ((System.ComponentModel.ISupportInitialize)summarygrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountpaid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lbldiscount;
        private Label label6;
        private Label php;
        private Label lbltotalamount;
        private Label lblsubtotal;
        private Label lblnumberofitem;
        private Label label5;
        private Label label4;
        private Label label1;
        private DataGridView summarygrid;
        private Label label2;
        private Label label7;
        private Label label8;
        private Label lblchange;
        private Panel panel1;
        private Label label9;
        private Label label10;
        private Label lblSaleID;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private TextBox notetb;
        private Button button2;
        private Button Proceed;
        private NumericUpDown amountpaid;
        private TextBox tbname;
    }
}