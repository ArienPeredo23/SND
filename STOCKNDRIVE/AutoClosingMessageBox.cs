using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace STOCKNDRIVE
{
    public partial class AutoClosingMessageBox : Form
    {
        public AutoClosingMessageBox(string message, string title, int duration)
        {
            InitializeComponent();
            this.Text = title;
            lblMessage.Text = message;
            closeTimer.Interval = duration;
            closeTimer.Tick += CloseTimer_Tick;
            closeTimer.Start();
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.Close();
        }
    }
}
