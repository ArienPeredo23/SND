namespace STOCKNDRIVE
{
    partial class AutoClosingMessageBox
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
            lblMessage = new Label();
            closeTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Franklin Gothic Medium", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(30, 22);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(220, 100);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "aaaaaaaaaaaaa";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeTimer
            // 
            closeTimer.Interval = 1500;
            // 
            // AutoClosingMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(133, 92, 17);
            ClientSize = new Size(281, 144);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AutoClosingMessageBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AutoClosingMessageBox";
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
        private System.Windows.Forms.Timer closeTimer;
    }
}