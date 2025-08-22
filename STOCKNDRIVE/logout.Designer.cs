namespace STOCKNDRIVE
{
    partial class logout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logout));
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(204, 141, 26);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(137, 298);
            button1.Name = "button1";
            button1.Size = new Size(169, 35);
            button1.TabIndex = 14;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(81, 235);
            label4.Name = "label4";
            label4.Size = new Size(339, 30);
            label4.TabIndex = 13;
            label4.Text = "Are you sure you want to Logout?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(81, 178);
            label3.Name = "label3";
            label3.Size = new Size(236, 45);
            label3.TabIndex = 12;
            label3.Text = "You're Leaving";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(81, 123);
            label2.Name = "label2";
            label2.Size = new Size(160, 45);
            label2.TabIndex = 11;
            label2.Text = "Ohh no!!!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(388, 94);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(373, 373);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 33);
            label1.Name = "label1";
            label1.Size = new Size(138, 32);
            label1.TabIndex = 9;
            label1.Text = "Dashboard";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Location = new Point(20, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(820, 2);
            panel1.TabIndex = 8;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(50, 50, 50);
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(814, 12);
            button2.Name = "button2";
            button2.Size = new Size(34, 34);
            button2.TabIndex = 18;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // logout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(860, 500);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "logout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "logout";
            Load += logout_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Button button2;
    }
}