namespace STOCKNDRIVE
{
    partial class ProductCard
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
            picProduct = new PictureBox();
            lblProductName = new Label();
            label1 = new Label();
            label2 = new Label();
            lblPrice = new Label();
            btnMinus = new Button();
            lblQuantity = new Label();
            btnPlus = new Button();
            btnAddToCart = new Button();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();
            // 
            // picProduct
            // 
            picProduct.Location = new Point(20, 10);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(200, 120);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 0;
            picProduct.TabStop = false;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.ForeColor = Color.White;
            lblProductName.Location = new Point(15, 140);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(45, 17);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(20, 163);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 2;
            label1.Text = "Brand:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(20, 180);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 3;
            label2.Text = "Manufacturer:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.FromArgb(204, 141, 26);
            lblPrice.Location = new Point(15, 215);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(34, 17);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "PHP";
            // 
            // btnMinus
            // 
            btnMinus.FlatAppearance.BorderColor = Color.Gray;
            btnMinus.FlatAppearance.BorderSize = 0;
            btnMinus.FlatStyle = FlatStyle.Flat;
            btnMinus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMinus.ForeColor = Color.White;
            btnMinus.Location = new Point(132, 211);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(30, 25);
            btnMinus.TabIndex = 5;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BorderStyle = BorderStyle.FixedSingle;
            lblQuantity.Font = new Font("Segoe UI", 10F);
            lblQuantity.ForeColor = Color.White;
            lblQuantity.Location = new Point(166, 216);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(19, 21);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "0";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPlus
            // 
            btnPlus.FlatAppearance.BorderColor = Color.Gray;
            btnPlus.FlatAppearance.BorderSize = 0;
            btnPlus.FlatStyle = FlatStyle.Flat;
            btnPlus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPlus.ForeColor = Color.White;
            btnPlus.Location = new Point(191, 211);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(30, 25);
            btnPlus.TabIndex = 7;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(204, 141, 26);
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToCart.ForeColor = Color.Black;
            btnAddToCart.Location = new Point(0, 250);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(240, 30);
            btnAddToCart.TabIndex = 8;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(btnAddToCart);
            Controls.Add(btnPlus);
            Controls.Add(lblQuantity);
            Controls.Add(btnMinus);
            Controls.Add(lblPrice);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblProductName);
            Controls.Add(picProduct);
            Name = "ProductCard";
            Size = new Size(240, 280);
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picProduct;
        private Label lblProductName;
        private Label label1;
        private Label label2;
        private Label lblPrice;
        private Button btnMinus;
        private Label lblQuantity;
        private Button btnPlus;
        private Button btnAddToCart;
    }
}
