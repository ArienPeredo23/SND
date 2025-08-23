using Microsoft.Data.SqlClient;
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
    public partial class paymentform : Form
    {
        private List<CartItem> _cartItems;
        private string _numberOfItems;
        private string _subtotal;
        private string _discount;
        private string _totalAmount;
        private string _discountDescription;

        public paymentform(List<CartItem> cartItems, string numberOfItems, string subtotal, string discount, string totalAmount, string discountDescription)
        {
            InitializeComponent();
            _cartItems = cartItems;
            _numberOfItems = numberOfItems;
            _subtotal = subtotal;
            _discount = discount;
            _totalAmount = totalAmount;
            _discountDescription = discountDescription;
            amountpaid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.amountpaid_UpdateChange);
            amountpaid.Click += new System.EventHandler(this.amountpaid_SelectAll);
            amountpaid.Enter += new System.EventHandler(this.amountpaid_SelectAll);
        }
        private void paymentform_Load(object sender, EventArgs e)
        {
            LoadNextSaleId();
            PopulateSummaryGrid();
            StyleSummaryGrid();
            UpdateSummaryLabels();
        }
        private void LoadNextSaleId()
        {
            try
            {
                // This query gets the last identity value generated for the 'Sales' table.
                // ISNULL handles the case where the table is empty, starting the count at 1.
                string query = "SELECT ISNULL(IDENT_CURRENT('Sales'), 0) + 1;";
                long nextId;

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        nextId = Convert.ToInt64(cmd.ExecuteScalar());
                    }
                }

                // Format the ID with 6 digits and leading zeros, then display it.
                lblSaleID.Text = "Transaction ID: " + nextId.ToString("D6");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve the next Sale ID.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblSaleID.Text = "Transaction ID: Error";
            }
        }

        private void amountpaid_UpdateChange(object sender, EventArgs e)
        {
            decimal totalAmount = 0;
            decimal amountPaidValue = amountpaid.Value;

            if (Decimal.TryParse(lbltotalamount.Text, out totalAmount))
            {
                decimal change = amountPaidValue - totalAmount;
                lblchange.Text = change.ToString("0.00");
            }
        }
        private void amountpaid_SelectAll(object sender, EventArgs e)
        {
            amountpaid.Select(0, amountpaid.Text.Length);
        }
        private void UpdateSummaryLabels()
        {
            lblnumberofitem.Text = _numberOfItems;
            lblsubtotal.Text = _subtotal;
            lbldiscount.Text = _discount;
            lbltotalamount.Text = _totalAmount;
        }


        private void PopulateSummaryGrid()
        {
            summarygrid.Rows.Clear();
            summarygrid.Columns.Clear();

            summarygrid.Columns.Add("ProductName", "Product Name");
            summarygrid.Columns.Add("UnitPrice", "Unit Price");
            summarygrid.Columns.Add("Quantity", "Quantity");
            summarygrid.Columns.Add("Total", "Total");

            summarygrid.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (var item in _cartItems)
            {
                summarygrid.Rows.Add(item.ProductName, item.BasePrice.ToString("0.00"), item.Quantity, item.TotalPrice.ToString("0.00"));
            }
        }

        private void StyleSummaryGrid()
        {
            summarygrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            summarygrid.ColumnHeadersHeight = 50;
            summarygrid.ReadOnly = true;
            summarygrid.AllowUserToAddRows = false;
            summarygrid.AllowUserToDeleteRows = false;
            summarygrid.AllowUserToResizeRows = false;
            summarygrid.RowHeadersVisible = false;
            summarygrid.EnableHeadersVisualStyles = false;

            summarygrid.BackgroundColor = Color.FromArgb(30, 30, 30);
            summarygrid.BorderStyle = BorderStyle.None;
            summarygrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            summarygrid.GridColor = Color.Gray;

            summarygrid.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            summarygrid.DefaultCellStyle.ForeColor = Color.White;
            summarygrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            summarygrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            summarygrid.DefaultCellStyle.Padding = new Padding(5);
            summarygrid.DefaultCellStyle.SelectionForeColor = Color.White;

            summarygrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            summarygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            summarygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            summarygrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            summarygrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            summarygrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogActivity(string actionType, string actionDetails)
        {
            try
            {
                string query = "INSERT INTO AuditTrail (UserID, ActionType, ActionDetails, Timestamp) VALUES (@UserID, @ActionType, @ActionDetails, @Timestamp)";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserId);
                        cmd.Parameters.AddWithValue("@ActionType", actionType);
                        cmd.Parameters.AddWithValue("@ActionDetails", actionDetails);
                        cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit Log Failed: " + ex.Message);
            }
        }
        private void Proceed_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbname.Text))
            {
                MessageBox.Show("Customer Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalAmount = decimal.Parse(_totalAmount);
            if (amountpaid.Value < totalAmount)
            {
                MessageBox.Show("Amount paid is less than the total amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool showLowStockWarning = false;
            foreach (var item in _cartItems)
            {
                int remainingStock = item.MaxQuantity - item.Quantity;
                if (remainingStock <= 5)
                {
                    showLowStockWarning = true;
                    break;
                }
            }

            if (showLowStockWarning)
            {
                DialogResult confirmResult = MessageBox.Show("One or more items will be at or below 5 stock after this sale. Are you sure you want to complete this transaction?",
                                                             "Low Stock Warning & Confirmation",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.No)
                {
                    return;
                }
            }
            SqlConnection conn = DBConnection.GetConnection();
            SqlTransaction transaction = null;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                long saleId;
                string salesQuery = @"INSERT INTO Sales (TransactionDate, UserID, TotalAmount, AmountPaid, ChangeGiven, Subtotal, DiscountDescription, Discount, CustomerName, NoteText)
                              VALUES (@TransactionDate, @UserID, @TotalAmount, @AmountPaid, @ChangeGiven, @Subtotal, @DiscountDescription, @Discount, @CustomerName, @NoteText);
                              SELECT SCOPE_IDENTITY();";


                using (SqlCommand cmd = new SqlCommand(salesQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserId);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@AmountPaid", amountpaid.Value);
                    cmd.Parameters.AddWithValue("@ChangeGiven", decimal.Parse(lblchange.Text));
                    cmd.Parameters.AddWithValue("@Subtotal", decimal.Parse(_subtotal));
                    cmd.Parameters.AddWithValue("@DiscountDescription", _discountDescription);
                    cmd.Parameters.AddWithValue("@Discount", decimal.Parse(_discount));
                    cmd.Parameters.AddWithValue("@CustomerName", tbname.Text);
                    cmd.Parameters.AddWithValue("@NoteText", notetb.Text);

                    saleId = Convert.ToInt64(cmd.ExecuteScalar());
                }

                // Step 2 & 3: Insert into SaleItems and Update Product Stock
                foreach (var item in _cartItems)
                {
                    // Insert Sale Item
                    string saleItemQuery = @"INSERT INTO SaleItems (SaleID, ProductID, QuantitySold, PriceAtSale)
                                     VALUES (@SaleID, @ProductID, @QuantitySold, @PriceAtSale)";
                    using (SqlCommand cmd = new SqlCommand(saleItemQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        cmd.Parameters.AddWithValue("@ProductID", item.ProductId);
                        cmd.Parameters.AddWithValue("@QuantitySold", item.Quantity);
                        cmd.Parameters.AddWithValue("@PriceAtSale", item.TotalPrice);
                        cmd.ExecuteNonQuery();
                    }

                    // Update Stock
                    string updateStockQuery = "UPDATE Products SET QuantityInStock = QuantityInStock - @QuantitySold WHERE ProductID = @ProductID";
                    using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@QuantitySold", item.Quantity);
                        cmd.Parameters.AddWithValue("@ProductID", item.ProductId);
                        cmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                string details = $"{UserSession.Fullname} processed a sale (ID: {saleId}) for customer '{tbname.Text}' with a total amount of {totalAmount:0.00}.";
                LogActivity("Process Sale", details);
                using (DigitalReceipt receiptForm = new DigitalReceipt(
                       saleId, _cartItems, tbname.Text, amountpaid.Value, decimal.Parse(lblchange.Text),
                       notetb.Text, _numberOfItems, _subtotal, _discount, _totalAmount))
                            {
                                receiptForm.ShowDialog();
                            }

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("An error occurred during the transaction. The sale was not completed.\nError: " + ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}