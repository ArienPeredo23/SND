namespace STOCKNDRIVE
{
    partial class LOGIN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            Picture1 = new PictureBox();
            loginPanel = new Panel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            Username = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Picture1).BeginInit();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Picture1
            // 
            Picture1.Image = (Image)resources.GetObject("Picture1.Image");
            Picture1.Location = new Point(42, 120);
            Picture1.Name = "Picture1";
            Picture1.Size = new Size(721, 480);
            Picture1.SizeMode = PictureBoxSizeMode.StretchImage;
            Picture1.TabIndex = 0;
            Picture1.TabStop = false;
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.FromArgb(45, 45, 45);
            loginPanel.Controls.Add(btnLogin);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(label2);
            loginPanel.Controls.Add(txtUsername);
            loginPanel.Controls.Add(Username);
            loginPanel.Controls.Add(label1);
            loginPanel.Location = new Point(760, 120);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(450, 480);
            loginPanel.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(217, 161, 41);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 350);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(350, 50);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 14F);
            txtPassword.Location = new Point(50, 250);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(350, 32);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(50, 220);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 14F);
            txtUsername.Location = new Point(50, 150);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(350, 32);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.BackColor = Color.Transparent;
            Username.Font = new Font("Segoe UI", 12F);
            Username.ForeColor = Color.White;
            Username.Location = new Point(50, 120);
            Username.Name = "Username";
            Username.Size = new Size(81, 21);
            Username.TabIndex = 1;
            Username.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(185, 40);
            label1.Name = "label1";
            label1.Size = new Size(99, 37);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // LOGIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 23);
            ClientSize = new Size(1280, 720);
            Controls.Add(loginPanel);
            Controls.Add(Picture1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LOGIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "S";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Picture1).EndInit();
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Picture1;
        private Panel loginPanel;
        private Label label1;
        private Label Username;
        private TextBox txtUsername;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label label2;
    }
}
