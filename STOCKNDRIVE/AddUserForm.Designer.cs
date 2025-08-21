namespace STOCKNDRIVE
{
    partial class AddUserForm
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
            txtFullname = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(47, 35);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter Fullname:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(47, 64);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Enter Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(47, 93);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 2;
            label3.Text = "Enter Password:";
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(179, 27);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(223, 23);
            txtFullname.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(179, 56);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(223, 23);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(179, 85);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(223, 23);
            txtPassword.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(316, 186);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Add";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(211, 186);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(427, 233);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtFullname);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddUserForm";
            Load += AddUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFullname;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSave;
        private Button btnCancel;
    }
}