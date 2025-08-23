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
    public partial class CartItem : UserControl
    {
        private int _quantity = 1;
        private decimal _basePrice = 0;
        private int _maxQuantity = 0;
        public event EventHandler CartItemChanged;

        public decimal TotalPrice { get; private set; }
        public int ProductId { get; set; }

        public CartItem()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        public string ProductName
        {
            get { return lblProductName.Text; }
            set { lblProductName.Text = value; }
        }
        public int MaxQuantity
        {
            get { return _maxQuantity; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public decimal BasePrice
        {
            get { return _basePrice; }
        }

        public void SetPriceAndStock(decimal basePrice, int maxStock)
        {
            _basePrice = basePrice;
            _maxQuantity = maxStock;
            UpdateDisplay();
        }

        public void IncrementQuantity()
        {
            if (_quantity < _maxQuantity)
            {
                _quantity++;
                UpdateDisplay();
                CartItemChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Maximum stock reached for this item.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateDisplay()
        {
            lblQuantity.Text = _quantity.ToString();
            this.TotalPrice = _basePrice * _quantity;
            lblPrice.Text = this.TotalPrice.ToString("0.00");
        }

        private void add_Click(object sender, EventArgs e)
        {
            IncrementQuantity();
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (_quantity > 1)
            {
                _quantity--;
                UpdateDisplay();
                CartItemChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                this.Parent.Controls.Remove(this);
            }
        }
        public CartItem(string productName, decimal basePrice, int quantity)
        {
            InitializeComponent();

            // Set internal state
            _basePrice = basePrice;
            _quantity = quantity;
            this.TotalPrice = _basePrice * _quantity;

            // Update the visual display
            lblProductName.Text = productName;
            lblQuantity.Text = _quantity.ToString();
            lblPrice.Text = this.TotalPrice.ToString("0.00");

            // Hide interactive controls for receipt view
            add.Visible = false;
            minus.Visible = false;
        }

    }
}