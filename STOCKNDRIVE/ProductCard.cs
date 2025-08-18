using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace STOCKNDRIVE
{
    public partial class ProductCard : UserControl
    {
        private int quantity = 1;

        public ProductCard()
        {
            InitializeComponent();
            lblQuantity.Text = quantity.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            quantity++;
            lblQuantity.Text = quantity.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                lblQuantity.Text = quantity.ToString();
            }
        }

        public event EventHandler AddToCartClicked;

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            AddToCartClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ProductCard_Load(object sender, EventArgs e)
        {
        }

        public string ProductName
        {
            get { return lblProductName.Text; }
            set { lblProductName.Text = value; }
        }

        public string ProductPrice
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }

        public string BrandText
        {
            set { lblBrand.Text = "Brand: " + value; }
        }

        public string ManufacturerText
        {
            set { lblManufacturer.Text = "Manufacturer: " + value; }
        }

        public Image ProductImage
        {
            set { picProductImage.Image = value; }
        }

        public int Quantity
        {
            get { return quantity; }
        }
    }
}