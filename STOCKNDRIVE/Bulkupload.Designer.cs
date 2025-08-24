namespace STOCKNDRIVE
{
    partial class Bulkupload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bulkupload));
            button1 = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvBulkUpload = new DataGridView();
            btnSaveAll = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBulkUpload).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(968, 12);
            button1.Name = "button1";
            button1.Size = new Size(20, 20);
            button1.TabIndex = 18;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgvBulkUpload
            // 
            dgvBulkUpload.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBulkUpload.Location = new Point(0, 68);
            dgvBulkUpload.Name = "dgvBulkUpload";
            dgvBulkUpload.Size = new Size(1001, 388);
            dgvBulkUpload.TabIndex = 19;
            // 
            // btnSaveAll
            // 
            btnSaveAll.Location = new Point(901, 465);
            btnSaveAll.Name = "btnSaveAll";
            btnSaveAll.Size = new Size(87, 23);
            btnSaveAll.TabIndex = 20;
            btnSaveAll.Text = "Add All";
            btnSaveAll.UseVisualStyleBackColor = true;
            btnSaveAll.Click += btnSaveAll_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(205, 25);
            label1.TabIndex = 21;
            label1.Text = "Add Multiple Product";
            // 
            // Bulkupload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(label1);
            Controls.Add(btnSaveAll);
            Controls.Add(dgvBulkUpload);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Bulkupload";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bulkupload";
            Load += Bulkupload_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBulkUpload).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView dgvBulkUpload;
        private Button btnSaveAll;
        private Label label1;
    }
}