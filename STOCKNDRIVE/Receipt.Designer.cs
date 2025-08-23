namespace STOCKNDRIVE
{
    partial class Receipt
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            datelbl = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(71, 6);
            label1.Name = "label1";
            label1.Size = new Size(261, 19);
            label1.TabIndex = 0;
            label1.Text = "VENDETA MOTORCYCLE PARTS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(93, 25);
            label2.Name = "label2";
            label2.Size = new Size(215, 19);
            label2.TabIndex = 1;
            label2.Text = "AND ACCESSORIES SHOP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(98, 43);
            label3.Name = "label3";
            label3.Size = new Size(206, 14);
            label3.TabIndex = 2;
            label3.Text = "BUENAVENTURA A. DECHAVEZ - Prop. ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 8.25F);
            label4.Location = new Point(116, 57);
            label4.Name = "label4";
            label4.Size = new Size(171, 15);
            label4.TabIndex = 3;
            label4.Text = "Non-VAT Reg. TIN: 294-881-508-00000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 8.25F);
            label5.Location = new Point(99, 72);
            label5.Name = "label5";
            label5.Size = new Size(198, 15);
            label5.TabIndex = 4;
            label5.Text = "Enverga Cor. Allarey Street Barangay 3, 4301";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Narrow", 8.25F);
            label6.Location = new Point(122, 87);
            label6.Name = "label6";
            label6.Size = new Size(155, 15);
            label6.TabIndex = 5;
            label6.Text = "City of Lucena, Quezon, Philippines";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(243, 119);
            label7.Name = "label7";
            label7.Size = new Size(44, 18);
            label7.TabIndex = 6;
            label7.Text = "Date: ";
            // 
            // datelbl
            // 
            datelbl.AutoSize = true;
            datelbl.BorderStyle = BorderStyle.FixedSingle;
            datelbl.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datelbl.ForeColor = SystemColors.ControlText;
            datelbl.Location = new Point(281, 119);
            datelbl.Name = "datelbl";
            datelbl.Size = new Size(13, 18);
            datelbl.TabIndex = 7;
            datelbl.Text = "-";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(46, 121);
            label8.Name = "label8";
            label8.Size = new Size(90, 16);
            label8.TabIndex = 8;
            label8.Text = "CASH SALES";
            // 
            // Receipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(404, 681);
            Controls.Add(label8);
            Controls.Add(datelbl);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Receipt";
            Text = "Receipt";
            Load += Receipt_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label datelbl;
        private Label label8;
    }
}