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

        public pos()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(UserSession.Fullname))
            {
                lblwelcome.Text = $"Welcome back, {UserSession.Fullname}!";
            }
            Orderlistpanel.ControlRemoved += (s, e) => UpdatePaymentSummary();
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

        private void LoadProductCards()
        {
            panel2.Visible = true;
            panel2.Controls.Clear();

            string query = "SELECT ProductName, Brand, Manufacturer, Price, ProductImage, QuantityInStock, Category FROM Products";

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

                            card.ProductName = reader["ProductName"].ToString();
                            card.BrandText = reader["Brand"].ToString();
                            card.ManufacturerText = reader["Manufacturer"].ToString();
                            card.ProductPrice = Convert.ToDecimal(reader["Price"]).ToString("0.00");
                            card.Category = reader["Category"].ToString(); // Add this line

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
            string name = card.ProductName;
            string price = card.ProductPrice;
            int maxStock = card.StockQuantity;

            foreach (Control control in Orderlistpanel.Controls)
            {
                if (control is CartItem existingCartItem && existingCartItem.ProductName == name)
                {
                    existingCartItem.IncrementQuantity();
                    return;
                }
            }

            CartItem newCartItem = new CartItem();
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
                    UpdatePaymentSummary();
                }
            }
        }

        private void searchtb_TextChanged(object sender, EventArgs e)
        {
            lblclear.Visible = !string.IsNullOrEmpty(searchtb.Text);
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
    }
}