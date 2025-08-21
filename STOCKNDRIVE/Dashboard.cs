using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace STOCKNDRIVE
{
    public partial class Dashboard : Form
    {
        private bool isPanelExpanded = false;
        private int settingsPanelStartHeight;
        private int settingsPanelTargetHeight;

        public Dashboard()
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
        private void CheckForLowStock()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Products WHERE QuantityInStock <= 5";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        int lowStockCount = (int)cmd.ExecuteScalar();
                        LowStockWarning.Visible = (lowStockCount > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to check for low stock: " + ex.Message);
            }
        }

        private void CheckForOutOfStock()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Products WHERE QuantityInStock = 0";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        int outOfStockCount = (int)cmd.ExecuteScalar();
                        Outofstockwarning.Visible = (outOfStockCount > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to check for out of stock items: " + ex.Message);
            }
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
        private void Dashboard_Load(object sender, EventArgs e)
        {
            CheckForLowStock();
            CheckForOutOfStock();
        }
        private void LowStockWarning_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory = new Inventory_Module(true);
            inventory.Show();
            this.Close();
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

        private void leftNavPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void Outofstockwarning_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory = new Inventory_Module(true);
            inventory.Show();
            this.Close();
        }
    }

}
