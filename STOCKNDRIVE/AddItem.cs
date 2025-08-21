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
        private int currentProductId = 0;

        public AddItem()
        {
            InitializeComponent();
            SetupFormForAdd();
            SetupEventHandlers(); 
        }

        public AddItem(int productId)
        {
            InitializeComponent();
            this.currentProductId = productId;
            SetupFormForEdit();
            LoadProductData();
            SetupEventHandlers(); 
        }

        private void SetupFormForAdd()
        {
            this.Text = "Add New Item";
            btnDone.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private void SetupFormForEdit()
        {
            this.Text = "Edit Item";
            btnDone.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }

        private void SetupEventHandlers()
        {
            this.numPrice.Click += new System.EventHandler(this.NumericUpDown_SelectAll);
            this.numPrice.Enter += new System.EventHandler(this.NumericUpDown_SelectAll);
            this.numItemCount.Click += new System.EventHandler(this.NumericUpDown_SelectAll);
            this.numItemCount.Enter += new System.EventHandler(this.NumericUpDown_SelectAll);
        }

        private void NumericUpDown_SelectAll(object sender, EventArgs e)
        {
            NumericUpDown control = sender as NumericUpDown;
            if (control != null)
            {
                control.Select(0, control.Text.Length);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product Name is a required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numItemCount.Value < 0)
            {
                MessageBox.Show("Item Count cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Category is a required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void LoadProductData()
        {
            string query = "SELECT * FROM Products WHERE ProductID = @ProductID";
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", this.currentProductId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtProductName.Text = reader["ProductName"].ToString();
                            txtBrand.Text = reader["Brand"].ToString();
                            txtManufacturer.Text = reader["Manufacturer"].ToString();
                            cmbCategory.Text = reader["Category"].ToString();
                            numPrice.Value = Convert.ToDecimal(reader["Price"]);
                            numItemCount.Value = Convert.ToDecimal(reader["QuantityInStock"]);
                            txtDescription.Text = reader["NoteText"].ToString();

                            if (reader["ProductImage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["ProductImage"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    picItemImage.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load item data.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) // Add this block
            {
                return;
            }

            byte[] imageData = GetImageData();
            string query = @"INSERT INTO Products (ProductName, Brand, Manufacturer, Category, Price, QuantityInStock, NoteText, ProductImage) 
                             VALUES (@ProductName, @Brand, @Manufacturer, @Category, @Price, @QuantityInStock, @NoteText, @ProductImage)";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        AddParametersToCommand(cmd, imageData);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add item.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            byte[] imageData = GetImageData();
            string query = @"UPDATE Products SET 
                                ProductName = @ProductName, 
                                Brand = @Brand, 
                                Manufacturer = @Manufacturer, 
                                Category = @Category, 
                                Price = @Price, 
                                QuantityInStock = @QuantityInStock, 
                                NoteText = @NoteText, 
                                ProductImage = @ProductImage,
                                LastUpdated = GETDATE()
                             WHERE ProductID = @ProductID";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        AddParametersToCommand(cmd, imageData);
                        cmd.Parameters.AddWithValue("@ProductID", this.currentProductId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update item.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                try
                {
                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", this.currentProductId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete item.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddParametersToCommand(SqlCommand cmd, byte[] imageData)
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
                cmd.Parameters.Add(new SqlParameter("@ProductImage", SqlDbType.VarBinary, -1)).Value = DBNull.Value;
            }
        }

        private byte[] GetImageData()
        {
            if (picItemImage.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picItemImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            return null;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Code for Movable Borderless Form ---
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
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
                    picItemImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imageData = ms.ToArray();
                }
            }

            string query = @"UPDATE Products SET 
                        ProductName = @ProductName, 
                        Brand = @Brand, 
                        Manufacturer = @Manufacturer, 
                        Category = @Category, 
                        Price = @Price, 
                        QuantityInStock = @QuantityInStock, 
                        NoteText = @NoteText, 
                        ProductImage = @ProductImage,
                        LastUpdated = GETDATE()
                     WHERE ProductID = @ProductID";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", this.currentProductId);
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
                            cmd.Parameters.Add(new SqlParameter("@ProductImage", SqlDbType.VarBinary, -1)).Value = DBNull.Value;
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Item updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update item.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";

                try
                {
                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", this.currentProductId);
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete item.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddItem_Load(object sender, EventArgs e)
        {

        }
    }
}