namespace STOCKNDRIVE
{
    partial class usermanagement
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usermanagement));
            btnAddUser = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            button4 = new Button();
            editBlinkTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(204, 141, 26);
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(765, 82);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(75, 23);
            btnAddUser.TabIndex = 14;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(820, 359);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Location = new Point(20, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(820, 2);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 28);
            label1.Name = "label1";
            label1.Size = new Size(223, 32);
            label1.TabIndex = 10;
            label1.Text = "User Management";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(50, 50, 50);
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(50, 50, 50);
            button4.Location = new Point(828, 12);
            button4.Name = "button4";
            button4.Size = new Size(20, 20);
            button4.TabIndex = 19;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // editBlinkTimer
            // 
            editBlinkTimer.Interval = 500;
            // 
            // usermanagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(860, 500);
            Controls.Add(button4);
            Controls.Add(btnAddUser);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "usermanagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "usermanagement";
            Load += usermanagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAddUser;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label1;
        private Button button4;
        private System.Windows.Forms.Timer editBlinkTimer;
    }
}