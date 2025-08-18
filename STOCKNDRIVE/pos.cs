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
        private void Card_AddToCartClicked(object sender, EventArgs e)
        {
            ProductCard card = sender as ProductCard;
            string name = card.ProductName;
            string price = card.ProductPrice;
            int qty = card.Quantity;

            Label orderItemLabel = new Label();
            orderItemLabel.Text = $"x{qty}  {name}          {price}";
            orderItemLabel.ForeColor = Color.White;
            orderItemLabel.AutoSize = true;
            MessageBox.Show($"{qty} x {name} added to cart!");
        }

        public pos()
        {
            InitializeComponent();
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
        }

        private void LoadProductCards()
        {
            panel2.Visible = true;
            panel2.Controls.Clear();

            string query = "SELECT ProductName, Brand, Manufacturer, Price, ProductImage, QuantityInStock FROM Products";

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

                            int stockQuantity = Convert.ToInt32(reader["QuantityInStock"]);
                            card.StockQuantityText = stockQuantity.ToString();

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

    }
}