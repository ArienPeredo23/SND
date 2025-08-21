namespace STOCKNDRIVE
{
    partial class CartItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblProductName = new Label();
            php = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            minus = new Button();
            add = new Button();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.ForeColor = Color.White;
            lblProductName.Location = new Point(15, 3);
            lblProductName.Margin = new Padding(4, 0, 4, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(45, 17);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "label1";
            // 
            // php
            // 
            php.AutoSize = true;
            php.BackColor = Color.Transparent;
            php.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            php.ForeColor = Color.FromArgb(204, 141, 26);
            php.Location = new Point(14, 28);
            php.Margin = new Padding(4, 0, 4, 0);
            php.Name = "php";
            php.Size = new Size(34, 17);
            php.TabIndex = 5;
            php.Text = "PHP";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(59, 28);
            lblPrice.Margin = new Padding(4, 0, 4, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(45, 17);
            lblPrice.TabIndex = 12;
            lblPrice.Text = "label1";
            // 
            // lblQuantity
            // 
            lblQuantity.BorderStyle = BorderStyle.FixedSingle;
            lblQuantity.Font = new Font("Segoe UI", 9F);
            lblQuantity.ForeColor = Color.White;
            lblQuantity.Location = new Point(371, 8);
            lblQuantity.Margin = new Padding(4, 0, 4, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(35, 34);
            lblQuantity.TabIndex = 13;
            lblQuantity.Text = "0";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minus
            // 
            minus.BackColor = Color.FromArgb(30, 30, 30);
            minus.FlatStyle = FlatStyle.Flat;
            minus.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            minus.ForeColor = Color.White;
            minus.Location = new Point(311, 8);
            minus.Margin = new Padding(4, 3, 4, 3);
            minus.Name = "minus";
            minus.Size = new Size(52, 35);
            minus.TabIndex = 14;
            minus.Text = "-";
            minus.UseVisualStyleBackColor = false;
            minus.Click += minus_Click;
            // 
            // add
            // 
            add.BackColor = Color.FromArgb(30, 30, 30);
            add.FlatStyle = FlatStyle.Flat;
            add.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            add.ForeColor = Color.White;
            add.Location = new Point(413, 8);
            add.Margin = new Padding(4, 3, 4, 3);
            add.Name = "add";
            add.Size = new Size(52, 35);
            add.TabIndex = 15;
            add.Text = "+";
            add.UseVisualStyleBackColor = false;
            add.Click += add_Click;
            // 
            // CartItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(add);
            Controls.Add(minus);
            Controls.Add(lblQuantity);
            Controls.Add(lblPrice);
            Controls.Add(php);
            Controls.Add(lblProductName);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CartItem";
            Size = new Size(500, 52);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label php;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button add;
    }
}