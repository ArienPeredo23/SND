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

        public int Quantity
        {
            get { return _quantity; }
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
            }
            else
            {
                MessageBox.Show("Maximum stock reached for this item.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateDisplay()
        {
            lblQuantity.Text = _quantity.ToString();
            decimal totalPrice = _basePrice * _quantity;
            lblPrice.Text = totalPrice.ToString("0.00");
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
            }
            else
            {
                this.Parent.Controls.Remove(this);
            }
        }

        private void CartItem_Load(object sender, EventArgs e)
        {

        }
    }
}