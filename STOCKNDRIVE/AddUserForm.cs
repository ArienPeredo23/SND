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
    public partial class AddUserForm : Form
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Fullname = txtFullname.Text;
            this.Username = txtUsername.Text;
            this.Password = txtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text) ||
           string.IsNullOrWhiteSpace(txtUsername.Text) ||
           string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Fullname = txtFullname.Text;
            this.Username = txtUsername.Text;
            this.Password = txtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
