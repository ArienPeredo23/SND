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
    public partial class Bulkupload : Form
    {
        public Bulkupload()
        {
            InitializeComponent();
        }

        private void Bulkupload_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            dgvBulkUpload.EditingControlShowing += dgvBulkUpload_EditingControlShowing;
        }

        private void SetupDataGridView()
        {
            dgvBulkUpload.CellClick += dgvBulkUpload_CellClick;
            dgvBulkUpload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBulkUpload.AllowUserToResizeColumns = false;
            dgvBulkUpload.AllowUserToResizeRows = true; // Allow rows to resize for multiline text
            dgvBulkUpload.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvBulkUpload.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvBulkUpload.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Product Name" });
            dgvBulkUpload.Columns.Add(new DataGridViewTextBoxColumn { Name = "Brand", HeaderText = "Brand" });
            dgvBulkUpload.Columns.Add(new DataGridViewTextBoxColumn { Name = "Manufacturer", HeaderText = "Manufacturer" });

            var categoryColumn = new DataGridViewComboBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataSource = new List<string> {
                    "Engine & Performance Parts", "Electrical & Lighting", "Tires & Wheels",
                    "Brakes & Suspension", "Body & Frame Parts", "Transmission & Drivetrain",
                    "Tools & Maintenance", "Riding Gear & Accessories", "Fluids & Consumables",
                    "Customization & Decorative Items"
                }
            };
            dgvBulkUpload.Columns.Add(categoryColumn);

            dgvBulkUpload.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price" });
            dgvBulkUpload.Columns.Add(new DataGridViewTextBoxColumn { Name = "QuantityInStock", HeaderText = "Quantity" });
            dgvBulkUpload.Columns.Add(new DataGridViewTextBoxColumn { Name = "NoteText", HeaderText = "Note" });

            var imageColumn = new DataGridViewImageColumn
            {
                Name = "ProductImage",
                HeaderText = "Image (Drag & Drop)",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 150
            };
            dgvBulkUpload.Columns.Add(imageColumn);
            dgvBulkUpload.RowTemplate.Height = 80;
        }

        private void dgvBulkUpload_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= NumericOnly_KeyPress;
            e.Control.KeyPress -= DecimalOnly_KeyPress;

            if (dgvBulkUpload.CurrentCell.OwningColumn.Name == "QuantityInStock")
            {
                e.Control.KeyPress += NumericOnly_KeyPress;
            }
            else if (dgvBulkUpload.CurrentCell.OwningColumn.Name == "Price")
            {
                e.Control.KeyPress += DecimalOnly_KeyPress;
            }
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void DecimalOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void dgvBulkUpload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row and in the "ProductImage" column
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBulkUpload.Columns["ProductImage"].Index)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Select a Product Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
      
                        Image img = Image.FromFile(openFileDialog.FileName);


                        byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);

                        var cell = dgvBulkUpload.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        cell.Value = img;

  
                        cell.Tag = imageData;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save all items in the grid?", "Confirm Bulk Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            SqlConnection conn = DBConnection.GetConnection();
            SqlTransaction transaction = null;
            int itemsAdded = 0;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();
                foreach (DataGridViewRow row in dgvBulkUpload.Rows)
                {
                    if (row.IsNewRow) continue;


                    string productName = Convert.ToString(row.Cells["ProductName"].Value);
                    string priceStr = Convert.ToString(row.Cells["Price"].Value);
                    string quantityStr = Convert.ToString(row.Cells["QuantityInStock"].Value);
                    string category = Convert.ToString(row.Cells["Category"].Value);

  
                    if (string.IsNullOrWhiteSpace(productName) &&
                        string.IsNullOrWhiteSpace(priceStr) &&
                        string.IsNullOrWhiteSpace(quantityStr) &&
                        string.IsNullOrWhiteSpace(category))
                    {
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(productName))
                    {
                        MessageBox.Show($"Row {row.Index + 1}: Product Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!decimal.TryParse(priceStr, out decimal price) || price <= 0)
                    {
                        MessageBox.Show($"Row {row.Index + 1}: A valid Price greater than zero is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(quantityStr, out int qty) || qty < 0)
                    {
                        MessageBox.Show($"Row {row.Index + 1}: A valid Quantity (0 or more) is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(category))
                    {
                        MessageBox.Show($"Row {row.Index + 1}: Category is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    string insertQuery = @"INSERT INTO Products (ProductName, Brand, Manufacturer, Category, Price, QuantityInStock, NoteText, ProductImage) 
                                   VALUES (@ProductName, @Brand, @Manufacturer, @Category, @Price, @QuantityInStock, @NoteText, @ProductImage)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                    {                  cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Brand", Convert.ToString(row.Cells["Brand"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@Manufacturer", Convert.ToString(row.Cells["Manufacturer"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@QuantityInStock", qty);
                        cmd.Parameters.AddWithValue("@NoteText", Convert.ToString(row.Cells["NoteText"].Value) ?? "");

                        byte[] imageData = row.Cells["ProductImage"].Tag as byte[];
                        if (imageData != null)
                        {
                            cmd.Parameters.AddWithValue("@ProductImage", imageData);
                        }
                        else
                        {
                            SqlParameter imageParam = new SqlParameter("@ProductImage", SqlDbType.VarBinary, -1);
                            imageParam.Value = DBNull.Value;
                            cmd.Parameters.Add(imageParam);
                        }

                        cmd.ExecuteNonQuery();
                        itemsAdded++;

                        string details = $"{UserSession.Fullname} added a product ('{productName}') via bulk upload.";
                        LogActivity(conn, transaction, "Add Product", details);
                    }
                }

                transaction.Commit();
                string bulkDetails = $"{UserSession.Fullname} performed a bulk upload, adding {itemsAdded} item(s).";
                LogActivity(conn, null, "Bulk Upload", bulkDetails);
                string successMessage = $"{itemsAdded} item(s) added successfully!";
                new AutoClosingMessageBox(successMessage, "Success", 3000).ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("An error occurred during bulk upload. No items were saved.\nError: " + ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LogActivity(SqlConnection conn, SqlTransaction trans, string actionType, string actionDetails)
        {
            try
            {
                string query = "INSERT INTO AuditTrail (UserID, ActionType, ActionDetails, Timestamp) VALUES (@UserID, @ActionType, @ActionDetails, @Timestamp)";
                using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserId);
                    cmd.Parameters.AddWithValue("@ActionType", actionType);
                    cmd.Parameters.AddWithValue("@ActionDetails", actionDetails);
                    cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit Log Failed during bulk upload: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}