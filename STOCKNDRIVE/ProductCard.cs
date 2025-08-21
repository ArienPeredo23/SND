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
        public ProductCard()
        {
            InitializeComponent();
        }

        public int ProductId { get; set; }

        public event EventHandler AddToCartClicked;

        public int StockQuantity { get; set; }
        private void ProductCard_Load(object sender, EventArgs e)
        {
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            AddToCartClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ProductCard_Load_1(object sender, EventArgs e)
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

        public string StockQuantityText
        {
            set { lblQuantity.Text = "Stock: " + value; }
        }

        public Button AddToCartButton
        {
            get { return btnAddToCart; }
        }

        public int Quantity
        {
            get { return 1; }
        }

        public string Category { get; set; }
    }
}