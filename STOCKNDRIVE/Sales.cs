using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOCKNDRIVE
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(UserSession.Fullname))
            {
                lblwelcome.Text = $"Welcome back, {UserSession.Fullname}!";
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard newDashboard = new Dashboard();
            newDashboard.Show();
            this.Close();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            pos newpos = new pos();
            newpos.Show();
            this.Close();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory = new Inventory_Module();
            inventory.Show();
            this.Close();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Close();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            if (UserSession.UserId >= 2)
            {
                Point dashboardLocation = btnDashboard.Location;
                Point posLocation = btnPOS.Location;

                btnDashboard.Visible = false;
                btnInventory.Visible = false;

                btnPOS.Location = dashboardLocation;
                btnSales.Location = posLocation;
            }
        }
    }
}
