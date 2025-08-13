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
    public partial class pos : Form
    {
        private void productCard1_AddToCartClicked(object sender, EventArgs e)
        {
            // 1. Get the card that was clicked
            ProductCard card = sender as ProductCard;

            // 2. Get the product info from the card
            string name = card.ProductName;
            string price = card.ProductPrice;
            int qty = card.Quantity;

            // 3. Create a new label to display the item in the order details
            Label orderItemLabel = new Label();
            orderItemLabel.Text = $"x{qty}  {name}          {price}";
            orderItemLabel.ForeColor = Color.White;
            orderItemLabel.AutoSize = true;

            // 4. Add the new label to the order details panel
            //    (You will need a FlowLayoutPanel inside your rightOrderPanel for this to work best)
            //    Let's assume you added a FlowLayoutPanel named 'orderedItemsFlowPanel'
            //    orderedItemsFlowPanel.Controls.Add(orderItemLabel);

            MessageBox.Show($"{qty} x {name} added to cart!"); // For testing
        }
        public pos()
        {
            InitializeComponent();
        }
    }

}
