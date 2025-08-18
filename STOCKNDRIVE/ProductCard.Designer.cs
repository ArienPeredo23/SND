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
            picProductImage = new PictureBox();
            lblProductName = new Label();
            php = new Label();
            lblQuantity = new Label();
            btnAddToCart = new Button();
            lblBrand = new Label();
            lblManufacturer = new Label();
            lblPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            SuspendLayout();
            // 
            // picProductImage
            // 
            picProductImage.Location = new Point(20, 10);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(200, 120);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 0;
            picProductImage.TabStop = false;
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
            // php
            // 
            php.AutoSize = true;
            php.BackColor = Color.Transparent;
            php.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            php.ForeColor = Color.FromArgb(204, 141, 26);
            php.Location = new Point(15, 215);
            php.Name = "php";
            php.Size = new Size(34, 17);
            php.TabIndex = 4;
            php.Text = "PHP";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BorderStyle = BorderStyle.FixedSingle;
            lblQuantity.Font = new Font("Segoe UI", 9F);
            lblQuantity.ForeColor = Color.White;
            lblQuantity.Location = new Point(167, 217);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(15, 17);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "0";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
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
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrand.ForeColor = Color.LightGray;
            lblBrand.Location = new Point(15, 166);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(41, 15);
            lblBrand.TabIndex = 9;
            lblBrand.Text = "Brand:";
            // 
            // lblManufacturer
            // 
            lblManufacturer.AutoSize = true;
            lblManufacturer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManufacturer.ForeColor = Color.LightGray;
            lblManufacturer.Location = new Point(15, 190);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(82, 15);
            lblManufacturer.TabIndex = 10;
            lblManufacturer.Text = "Manufacturer:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(55, 215);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(45, 17);
            lblPrice.TabIndex = 11;
            lblPrice.Text = "label1";
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(lblPrice);
            Controls.Add(lblManufacturer);
            Controls.Add(lblBrand);
            Controls.Add(btnAddToCart);
            Controls.Add(lblQuantity);
            Controls.Add(php);
            Controls.Add(lblProductName);
            Controls.Add(picProductImage);
            Name = "ProductCard";
            Size = new Size(240, 280);
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picProductImage;
        private Label lblProductName;
        private Label php;
        private Label lblQuantity;
        private Button btnAddToCart;
        private Label lblBrand;
        private Label lblManufacturer;
        private Label lblPrice;
    }
}
