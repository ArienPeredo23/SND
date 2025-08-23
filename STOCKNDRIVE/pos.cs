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
using System.IO;

namespace STOCKNDRIVE
{
    public partial class pos : Form
    {
        private decimal currentDiscount = 0;
        private string currentDiscountDescription = "";
        private bool isPanelExpanded = false;
        private int settingsPanelStartHeight;
        private int settingsPanelTargetHeight;

        public pos()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(UserSession.Fullname))
            {
                lblwelcome.Text = $"Welcome back, {UserSession.Fullname}!";
            }
            Orderlistpanel.ControlRemoved += (s, e) => UpdatePaymentSummary();

            InitializeSettingsPanel();
        }

        private void InitializeSettingsPanel()
        {
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
            settingsPanelTargetHeight = settingsPanel.Height;
            settingsPanel.Height = 0;
            slideTimer.Tick += SlideTimer_Tick;
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            int step = 20;

            if (!isPanelExpanded)
            {
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
            settingsPanel.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - settingsPanel.Height);
        }

        private void UpdatePaymentSummary()
        {
            int totalItems = 0;
            decimal subtotal = 0;

            foreach (Control control in Orderlistpanel.Controls)
            {
                if (control is CartItem cartItem)
                {
                    totalItems += cartItem.Quantity;
                    subtotal += cartItem.TotalPrice;
                }
            }

            decimal totalAmount = subtotal - currentDiscount;

            lblnumberofitem.Text = totalItems.ToString();
            lblsubtotal.Text = subtotal.ToString("0.00");
            lbldiscount.Text = currentDiscount.ToString("0.00");
            lbltotalamount.Text = totalAmount.ToString("0.00");
            lbldiscountdescription.Text = currentDiscountDescription;

            if (Orderlistpanel.Controls.Count > 0)
            {
                Proceed.Enabled = true;
                Proceed.BackColor = Color.FromArgb(204, 141, 26);
                adddiscountbtn.Enabled = true;
                adddiscountbtn.BackColor = Color.FromArgb(30, 30, 30);
                clearpanellbl.Visible = true;
            }
            else
            {
                Proceed.Enabled = false;
                Proceed.BackColor = Color.Gray;
                adddiscountbtn.Enabled = false;
                adddiscountbtn.BackColor = Color.Gray;
                clearpanellbl.Visible = false;
            }

            bool hasDiscount = currentDiscount > 0;
            cleardiscount.Visible = hasDiscount;
            lbldiscountdescription.Visible = hasDiscount;
        }

        private void clearpanellbl_Click(object sender, EventArgs e)
        {
            Orderlistpanel.Controls.Clear();
            currentDiscount = 0;
            currentDiscountDescription = "";
            UpdatePaymentSummary();
        }

        private void cleardiscount_Click(object sender, EventArgs e)
        {
            currentDiscount = 0;
            currentDiscountDescription = "";
            UpdatePaymentSummary();
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

        private void topActionPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pos_Load(object sender, EventArgs e)
        {
            LoadProductCards();
            UpdatePaymentSummary();
            lblclear.Visible = false;
            searchtb.Text = "Search for Product Name";
            searchtb.ForeColor = Color.Black;

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
                backupbtn.Visible = false;
            }
        }

        private void LoadProductCards()
        {
            panel2.Visible = true;
            panel2.Controls.Clear();

            string query = "SELECT ProductID, ProductName, Brand, Manufacturer, Price, ProductImage, QuantityInStock, Category, NoteText FROM Products";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ProductCard card = new ProductCard();
                            Image productImage = null;

                            card.ProductId = Convert.ToInt32(reader["ProductID"]); // Add this line
                            card.ProductName = reader["ProductName"].ToString();
                            card.BrandText = reader["Brand"].ToString();
                            card.ManufacturerText = reader["Manufacturer"].ToString();
                            card.ProductPrice = Convert.ToDecimal(reader["Price"]).ToString("0.00");
                            card.Category = reader["Category"].ToString();
                            card.NoteText = reader["NoteText"].ToString();

                            int stockQuantity = Convert.ToInt32(reader["QuantityInStock"]);
                            card.StockQuantityText = stockQuantity.ToString();
                            card.StockQuantity = stockQuantity;

                            if (reader["ProductImage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["ProductImage"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    productImage = Image.FromStream(ms);
                                }
                            }

                            if (stockQuantity == 0)
                            {
                                card.AddToCartButton.Enabled = false;
                                card.AddToCartButton.BackColor = Color.Gray;

                                if (productImage != null)
                                {
                                    card.ProductImage = CreateOutOfStockOverlay(productImage);
                                }
                            }
                            else
                            {
                                card.ProductImage = productImage;
                                card.AddToCartClicked += Card_AddToCartClicked;
                            }

                            panel2.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Card_AddToCartClicked(object sender, EventArgs e)
        {
            ProductCard card = sender as ProductCard;
            int productId = card.ProductId;
            string name = card.ProductName;
            string price = card.ProductPrice;
            int maxStock = card.StockQuantity;

            foreach (Control control in Orderlistpanel.Controls)
            {
                if (control is CartItem existingCartItem && existingCartItem.ProductId == productId)
                {
                    existingCartItem.IncrementQuantity();
                    return;
                }
            }

            CartItem newCartItem = new CartItem();
            newCartItem.ProductId = productId;
            newCartItem.ProductName = name;
            newCartItem.SetPriceAndStock(Convert.ToDecimal(price), maxStock);
            newCartItem.CartItemChanged += (s, ev) => UpdatePaymentSummary();

            Orderlistpanel.Controls.Add(newCartItem);
            UpdatePaymentSummary();
        }
        private Image CreateOutOfStockOverlay(Image originalImage)
        {
            Bitmap bitmap = new Bitmap(originalImage);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font font = new Font("Arial", 60, FontStyle.Bold);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                RectangleF rect = new RectangleF(0, 0, bitmap.Width, bitmap.Height);

                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddString("Out of Stock", font.FontFamily, (int)font.Style, font.Size, rect, stringFormat);

                    using (Pen pen = new Pen(Color.Black, 3))
                    {
                        graphics.DrawPath(pen, path);
                    }

                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        graphics.FillPath(brush, path);
                    }
                }
            }
            return bitmap;
        }

        private void adddiscountbtn_Click(object sender, EventArgs e)
        {
            using (DiscountInputForm discountForm = new DiscountInputForm())
            {
                if (discountForm.ShowDialog() == DialogResult.OK)
                {
                    currentDiscount = discountForm.DiscountAmount;
                    currentDiscountDescription = discountForm.DiscountDescription;
                    UpdatePaymentSummary();
                }
            }
        }

        private void searchtb_TextChanged(object sender, EventArgs e)
        {
            lblclear.Visible = !string.IsNullOrEmpty(searchtb.Text) && searchtb.Text != "Search for Product Name";

            if (searchtb.Text != "Search for Product Name" && panel2.Controls.Count > 0)
            {
                string searchText = searchtb.Text.Trim().ToLower();

                foreach (Control control in panel2.Controls)
                {
                    if (control is ProductCard card)
                    {
                        string productName = card.ProductName.ToLower();
                        card.Visible = productName.Contains(searchText);
                    }
                }
            }
            else if (searchtb.Text == "Search for Product Name")
            {
                foreach (Control control in panel2.Controls)
                {
                    if (control is ProductCard card)
                    {
                        card.Visible = true;
                    }
                }
            }
        }

        private void lblclear_Click(object sender, EventArgs e)
        {
            searchtb.Clear();
            searchtb.Focus();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            var categories = new List<string>
            {
                "Show All",
                "---",
                "Engine & Performance Parts",
                "Electrical & Lighting",
                "Tires & Wheels",
                "Brakes & Suspension",
                "Body & Frame Parts",
                "Transmission & Drivetrain",
                "Tools & Maintenance",
                "Riding Gear & Accessories",
                "Fluids & Consumables",
                "Customization & Decorative Items"
            };

            foreach (string category in categories)
            {
                if (category == "---")
                {
                    contextMenu.Items.Add(new ToolStripSeparator());
                }
                else
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(category);
                    menuItem.Click += FilterMenuItem_Click;
                    contextMenu.Items.Add(menuItem);
                }
            }
            Point screenPoint = btnFilter.PointToScreen(new Point(0, btnFilter.Height));
            contextMenu.Show(screenPoint);

        }

        private void FilterMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string selectedCategory = clickedItem.Text;

            foreach (Control control in panel2.Controls)
            {
                if (control is ProductCard card)
                {
                    if (selectedCategory == "Show All")
                    {
                        card.Visible = true;
                    }
                    else
                    {
                        card.Visible = (card.Category == selectedCategory);
                    }
                }
            }
        }


        private void Proceed_Click(object sender, EventArgs e)
        {
            if (Orderlistpanel.Controls.Count > 0)
            {
                List<CartItem> cartItems = new List<CartItem>();
                foreach (Control control in Orderlistpanel.Controls)
                {
                    if (control is CartItem item)
                    {
                        cartItems.Add(item);
                    }
                }

                string numberOfItems = lblnumberofitem.Text;
                string subtotal = lblsubtotal.Text;
                string discount = lbldiscount.Text;
                string totalAmount = lbltotalamount.Text;
                string discountDescription = currentDiscountDescription;

                using (paymentform paymentForm = new paymentform(cartItems, numberOfItems, subtotal, discount, totalAmount, discountDescription))
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        Orderlistpanel.Controls.Clear();
                        LoadProductCards();
                    }
                }
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

        private void searchtb_Enter(object sender, EventArgs e)
        {
            if (searchtb.Text == "Search for Product Name")
            {
                searchtb.Text = "";
                searchtb.ForeColor = Color.Black; // Or your normal text color
            }
        }

        private void searchtb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchtb.Text))
            {
                searchtb.Text = "Search for Product Name";
                searchtb.ForeColor = Color.Gray;
            }
        }
        private void LogSystemActivity(string actionType, string actionDetails)
        {
            try
            {
                string query = "INSERT INTO AuditTrail (UserID, ActionType, ActionDetails, Timestamp) VALUES (@UserID, @ActionType, @ActionDetails, @Timestamp)";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserId); // Log who initiated the backup
                        cmd.Parameters.AddWithValue("@ActionType", actionType);
                        cmd.Parameters.AddWithValue("@ActionDetails", actionDetails);
                        cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("System Audit Log Failed: " + ex.Message);
            }
        }

        private void backupbtn_Click(object sender, EventArgs e)
        {
            // 1. Ask for confirmation from the user
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to back up the database?",
                                                         "Confirm Backup",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            // 2. Open a Save File Dialog to let the user choose the location and name
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQL Backup file (*.bak)|*.bak";
            saveFileDialog.Title = "Save Database Backup";
            saveFileDialog.FileName = $"stockndrive_{DateTime.Now:yyyyMMdd_HHmmss}.bak"; // Default file name

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupPath = saveFileDialog.FileName;

                try
                {
                    // 3. Execute the database backup command
                    // IMPORTANT: The SQL Server service account MUST have write permissions to the folder you choose.
                    // This often fails if you try to save to "C:\Program Files" or other protected system locations.
                    // Saving to "Documents" or a dedicated "Backups" folder on the C: drive is usually safest.
                    string dbName = "stockndrive";
                    string query = $"BACKUP DATABASE [{dbName}] TO DISK = @BackupPath";

                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@BackupPath", backupPath);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 4. Log the successful backup
                    string details = $"{UserSession.Fullname} created a database backup at '{backupPath}'.";
                    LogSystemActivity("Database Backup", details); // Assuming you have this method

                    MessageBox.Show("Database backup completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database backup failed.\n\n" +
                                    "Please ensure the SQL Server service has write permissions to the selected folder.\n\n" +
                                    "Error: " + ex.Message,
                                    "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}