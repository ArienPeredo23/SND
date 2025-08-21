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
    public partial class DiscountInputForm : Form
    {
        public string DiscountDescription { get; private set; }
        public decimal DiscountAmount { get; private set; }

        public DiscountInputForm()
        {
            InitializeComponent();
            this.numAmount.Click += new System.EventHandler(this.numAmount_Click);
            this.numAmount.Enter += new System.EventHandler(this.numAmount_Enter);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Discount Description is a required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Discount Amount must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DiscountDescription = txtDescription.Text;
            this.DiscountAmount = numAmount.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numAmount_Click(object sender, EventArgs e)
        {
            numAmount.Select(0, numAmount.Text.Length);
        }

        private void numAmount_Enter(object sender, EventArgs e)
        {
            numAmount.Select(0, numAmount.Text.Length);
        }
    }
}