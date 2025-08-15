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
    public partial class AddItem : Form
    {
        // Code to make a borderless form movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // This code runs when the user clicks the PictureBox
        private void picItemImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picItemImage.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        // This closes the form when cancel is clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public AddItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product Name is a required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] imageData = null;
            if (picItemImage.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save as PNG to support transparency, or use Jpeg for smaller file sizes.
                    picItemImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imageData = ms.ToArray();
                }
            }

            string query = @"
        INSERT INTO Products 
            (ProductName, Brand, Manufacturer, Category, Price, QuantityInStock, NoteText, ProductImage) 
        VALUES 
            (@ProductName, @Brand, @Manufacturer, @Category, @Price, @QuantityInStock, @NoteText, @ProductImage)";

            try
            {
                // FIX: Use your working DBConnection class, just like in your login code.
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Brand", txtBrand.Text);
                        cmd.Parameters.AddWithValue("@Manufacturer", txtManufacturer.Text);
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("@Price", numPrice.Value);
                        cmd.Parameters.AddWithValue("@QuantityInStock", numItemCount.Value);
                        cmd.Parameters.AddWithValue("@NoteText", txtDescription.Text);

                        if (imageData != null)
                        {
                            cmd.Parameters.AddWithValue("@ProductImage", imageData);
                        }
                        else
                        {
                            // If no image is selected, save NULL to the database.
                            cmd.Parameters.Add(new SqlParameter("@ProductImage", SqlDbType.VarBinary, -1)).Value = DBNull.Value;
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Set result for the parent form
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add item to the database.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picItemImage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Select a Product Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picItemImage.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
