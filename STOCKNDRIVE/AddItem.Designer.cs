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
            button1 = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            bulkupload = new Button();
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
            picItemImage.Click += picItemImage_Click_1;
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
            lblDescription_Title.Size = new Size(35, 15);
            lblDescription_Title.TabIndex = 7;
            lblDescription_Title.Text = "Note";
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
            numPrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(220, 25);
            numPrice.TabIndex = 11;
            // 
            // numItemCount
            // 
            numItemCount.DecimalPlaces = 2;
            numItemCount.Font = new Font("Segoe UI", 10F);
            numItemCount.Location = new Point(590, 225);
            numItemCount.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numItemCount.Name = "numItemCount";
            numItemCount.Size = new Size(220, 25);
            numItemCount.TabIndex = 12;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Engine & Performance Parts", "Electrical & Lighting", "Tires & Wheels", "Brakes & Suspension", "Body & Frame Parts", "Transmission & Drivetrain", "Tools & Maintenance", "Riding Gear & Accessories", "Fluids & Consumables", "Customization & Decorative Items" });
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
            btnCancel.Click += btnCancel_Click_1;
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
            btnDone.Click += btnDone_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(814, 12);
            button1.Name = "button1";
            button1.Size = new Size(34, 34);
            button1.TabIndex = 17;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(204, 141, 26);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(690, 440);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 40);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Maroon;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(40, 440);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // bulkupload
            // 
            bulkupload.BackColor = SystemColors.Control;
            bulkupload.FlatAppearance.BorderSize = 0;
            bulkupload.FlatStyle = FlatStyle.Flat;
            bulkupload.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            bulkupload.Location = new Point(40, 14);
            bulkupload.Name = "bulkupload";
            bulkupload.Size = new Size(171, 28);
            bulkupload.TabIndex = 20;
            bulkupload.Text = "Switch to Bulk Upload";
            bulkupload.UseVisualStyleBackColor = false;
            bulkupload.Click += bulkupload_Click;
            // 
            // AddItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 500);
            Controls.Add(bulkupload);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(button1);
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
            Load += AddItem_Load;
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
        private Button button1;
        private Button btnUpdate;
        private Button btnDelete;
        private Button bulkupload;
    }
}