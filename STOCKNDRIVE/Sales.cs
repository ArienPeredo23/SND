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
        private bool isPanelExpanded = false;
        private int settingsPanelStartHeight;
        private int settingsPanelTargetHeight;
        public Sales()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(UserSession.Fullname))
            {
                lblwelcome.Text = $"Welcome back, {UserSession.Fullname}!";
            }
            InitializeSettingsPanel();
        }

        private void InitializeSettingsPanel()
        {
            // This positions the panel right above the settings button
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
            settingsPanelTargetHeight = settingsPanel.Height; // Store the original height
            settingsPanel.Height = 0; // Start with the panel collapsed
            slideTimer.Tick += SlideTimer_Tick; // Subscribe to the timer's tick event
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            int step = 20; // Controls the speed of the animation

            if (!isPanelExpanded)
            {
                // Expanding the panel
                settingsPanel.Visible = true;
                if (settingsPanel.Height + step < settingsPanelTargetHeight)
                {
                    settingsPanel.Height += step;
                }
                else
                {
                    settingsPanel.Height = settingsPanelTargetHeight;
                    isPanelExpanded = true;
                    slideTimer.Stop();
                }
            }
            else
            {
                // Collapsing the panel
                if (settingsPanel.Height - step > 0)
                {
                    settingsPanel.Height -= step;
                }
                else
                {
                    settingsPanel.Height = 0;
                    settingsPanel.Visible = false;
                    isPanelExpanded = false;
                    slideTimer.Stop();
                }
            }
            // Ensure panel stays correctly positioned as it resizes
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
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
                btnusermanagement.Visible = false;
                btnaudittrail.Visible = false;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            slideTimer.Start();
        }

        private void btnaudittrail_Click(object sender, EventArgs e)
        {
            audittrail audittrail = new audittrail();
            audittrail.ShowDialog();
            isPanelExpanded = false;
            settingsPanel.Visible = false;
        }

        private void btnusermanagement_Click(object sender, EventArgs e)
        {
            usermanagement usermanagement = new usermanagement();
            usermanagement.ShowDialog();
            isPanelExpanded = false;
            settingsPanel.Visible = false;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            using (logout logoutForm = new logout())
            {
                isPanelExpanded = false;
                settingsPanel.Height = 0;
                settingsPanel.Visible = false;

                if (logoutForm.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
