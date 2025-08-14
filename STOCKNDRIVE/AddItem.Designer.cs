namespace STOCKNDRIVE
{
    partial class AddItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItem));
            picItemImage = new PictureBox();
            lblProductName_Title = new Label();
            lblBrand_Title = new Label();
            lblManufacturer_Title = new Label();
            lblPrice_Title = new Label();
            lblNumItems_Title = new Label();
            lblDescription_Title = new Label();
            lblCategory_Title = new Label();
            txtProductName = new TextBox();
            txtBrand = new TextBox();
            txtManufacturer = new TextBox();
            numPrice = new NumericUpDown();
            numItemCount = new NumericUpDown();
            cmbCategory = new ComboBox();
            txtDescription = new TextBox();
            btnCancel = new Button();
            btnDone = new Button();
            ((System.ComponentModel.ISupportInitialize)picItemImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numItemCount).BeginInit();
            SuspendLayout();
            // 
            // picItemImage
            // 
            picItemImage.BackColor = Color.FromArgb(224, 224, 224);
            picItemImage.BorderStyle = BorderStyle.FixedSingle;
            picItemImage.Image = (Image)resources.GetObject("picItemImage.Image");
            picItemImage.Location = new Point(40, 60);
            picItemImage.Name = "picItemImage";
            picItemImage.Size = new Size(250, 250);
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom;
            picItemImage.TabIndex = 0;
            picItemImage.TabStop = false;
            // 
            // lblProductName_Title
            // 
            lblProductName_Title.AutoSize = true;
            lblProductName_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductName_Title.Location = new Point(330, 60);
            lblProductName_Title.Name = "lblProductName_Title";
            lblProductName_Title.Size = new Size(87, 15);
            lblProductName_Title.TabIndex = 1;
            lblProductName_Title.Text = "Product Name";
            // 
            // lblBrand_Title
            // 
            lblBrand_Title.AutoSize = true;
            lblBrand_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBrand_Title.Location = new Point(330, 130);
            lblBrand_Title.Name = "lblBrand_Title";
            lblBrand_Title.Size = new Size(40, 15);
            lblBrand_Title.TabIndex = 2;
            lblBrand_Title.Text = "Brand";
            // 
            // lblManufacturer_Title
            // 
            lblManufacturer_Title.AutoSize = true;
            lblManufacturer_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblManufacturer_Title.Location = new Point(590, 130);
            lblManufacturer_Title.Name = "lblManufacturer_Title";
            lblManufacturer_Title.Size = new Size(84, 15);
            lblManufacturer_Title.TabIndex = 3;
            lblManufacturer_Title.Text = "Manufacturer";
            // 
            // lblPrice_Title
            // 
            lblPrice_Title.AutoSize = true;
            lblPrice_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice_Title.Location = new Point(330, 200);
            lblPrice_Title.Name = "lblPrice_Title";
            lblPrice_Title.Size = new Size(35, 15);
            lblPrice_Title.TabIndex = 4;
            lblPrice_Title.Text = "Price";
            // 
            // lblNumItems_Title
            // 
            lblNumItems_Title.AutoSize = true;
            lblNumItems_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumItems_Title.Location = new Point(590, 200);
            lblNumItems_Title.Name = "lblNumItems_Title";
            lblNumItems_Title.Size = new Size(98, 15);
            lblNumItems_Title.TabIndex = 5;
            lblNumItems_Title.Text = "Number of Item";
            // 
            // lblDescription_Title
            // 
            lblDescription_Title.AutoSize = true;
            lblDescription_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription_Title.Location = new Point(330, 340);
            lblDescription_Title.Name = "lblDescription_Title";
            lblDescription_Title.Size = new Size(71, 15);
            lblDescription_Title.TabIndex = 7;
            lblDescription_Title.Text = "Description";
            // 
            // lblCategory_Title
            // 
            lblCategory_Title.AutoSize = true;
            lblCategory_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory_Title.Location = new Point(330, 270);
            lblCategory_Title.Name = "lblCategory_Title";
            lblCategory_Title.Size = new Size(57, 15);
            lblCategory_Title.TabIndex = 6;
            lblCategory_Title.Text = "Category";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 10F);
            txtProductName.Location = new Point(330, 85);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(480, 25);
            txtProductName.TabIndex = 8;
            // 
            // txtBrand
            // 
            txtBrand.Font = new Font("Segoe UI", 10F);
            txtBrand.Location = new Point(330, 155);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(220, 25);
            txtBrand.TabIndex = 9;
            // 
            // txtManufacturer
            // 
            txtManufacturer.Font = new Font("Segoe UI", 10F);
            txtManufacturer.Location = new Point(590, 155);
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.Size = new Size(220, 25);
            txtManufacturer.TabIndex = 10;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Font = new Font("Segoe UI", 10F);
            numPrice.Location = new Point(330, 225);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(220, 25);
            numPrice.TabIndex = 11;
            // 
            // numItemCount
            // 
            numItemCount.DecimalPlaces = 2;
            numItemCount.Font = new Font("Segoe UI", 10F);
            numItemCount.Location = new Point(590, 225);
            numItemCount.Name = "numItemCount";
            numItemCount.Size = new Size(220, 25);
            numItemCount.TabIndex = 12;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(330, 295);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(480, 25);
            cmbCategory.TabIndex = 13;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(330, 365);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(480, 60);
            txtDescription.TabIndex = 14;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(550, 440);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnDone
            // 
            btnDone.BackColor = Color.FromArgb(204, 141, 26);
            btnDone.FlatAppearance.BorderSize = 0;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDone.ForeColor = Color.White;
            btnDone.Location = new Point(690, 440);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(120, 40);
            btnDone.TabIndex = 16;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = false;
            // 
            // AddItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 500);
            Controls.Add(btnDone);
            Controls.Add(btnCancel);
            Controls.Add(txtDescription);
            Controls.Add(cmbCategory);
            Controls.Add(numItemCount);
            Controls.Add(numPrice);
            Controls.Add(txtManufacturer);
            Controls.Add(txtBrand);
            Controls.Add(txtProductName);
            Controls.Add(lblDescription_Title);
            Controls.Add(lblCategory_Title);
            Controls.Add(lblNumItems_Title);
            Controls.Add(lblPrice_Title);
            Controls.Add(lblManufacturer_Title);
            Controls.Add(lblBrand_Title);
            Controls.Add(lblProductName_Title);
            Controls.Add(picItemImage);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddItem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Item";
            ((System.ComponentModel.ISupportInitialize)picItemImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numItemCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picItemImage;
        private Label lblProductName_Title;
        private Label lblBrand_Title;
        private Label lblManufacturer_Title;
        private Label lblPrice_Title;
        private Label lblNumItems_Title;
        private Label lblDescription_Title;
        private Label lblCategory_Title;
        private TextBox txtProductName;
        private TextBox txtBrand;
        private TextBox txtManufacturer;
        private NumericUpDown numPrice;
        private NumericUpDown numItemCount;
        private ComboBox cmbCategory;
        private TextBox txtDescription;
        private Button btnCancel;
        private Button btnDone;
    }
}