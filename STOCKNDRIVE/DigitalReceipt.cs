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

namespace STOCKNDRIVE
{
    public partial class DigitalReceipt : Form
    {
        // Private fields to store all the transaction data
        private readonly long _saleId;
        private readonly List<CartItem> _cartItems;
        private readonly string _customerName;
        private readonly decimal _amountPaid;
        private readonly decimal _change;
        private readonly string _note;
        private readonly string _numberOfItems;
        private readonly string _subtotal;
        private readonly string _discount;
        private readonly string _totalAmount;
        private string _status;

        // New constructor to accept all the data from the payment form
        public DigitalReceipt(long saleId, List<CartItem> cartItems, string customerName, decimal amountPaid, decimal change, string note, string numberOfItems, string subtotal, string discount, string totalAmount)
        {
            InitializeComponent();
            _saleId = saleId;
            _cartItems = cartItems;
            _customerName = customerName;
            _amountPaid = amountPaid;
            _change = change;
            _note = note;
            _numberOfItems = numberOfItems;
            _subtotal = subtotal;
            _discount = discount;
            _totalAmount = totalAmount;
        }

        private void DigitalReceipt_Load(object sender, EventArgs e)
        {
            FetchSaleStatus();
            PopulateAllFields();
            StyleSummaryGrid();
        }

        private void PopulateAllFields()
        {
            // Populate all labels
            lblSaleID.Text = "Transaction ID: " + _saleId.ToString("D6");
            lblcustomername.Text = _customerName;
            lblamountpaid.Text = _amountPaid.ToString("N2");
            lblchange.Text = _change.ToString("N2");
            lblnote.Text = _note;
            lblnumberofitem.Text = _numberOfItems;
            lblsubtotal.Text = _subtotal;
            lbldiscount.Text = _discount;
            lbltotalamount.Text = _totalAmount;
            Statuslbl.Text = _status;

            if (_status == "Returned")
            {
                btnreturn.Visible = false;
            }
            else
            {
                btnreturn.Visible = true;
            }

            // Populate the items grid
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

        private void FetchSaleStatus()
        {
            try
            {
                string query = "SELECT Status FROM Sales WHERE SaleID = @SaleID";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", _saleId);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        _status = result?.ToString() ?? "Completed"; // Default to "Completed" if null
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve sale status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _status = "Error";
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

        private void btnreturn_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to mark this entire sale as returned? This action cannot be undone.",
                                                "Confirm Return",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE Sales SET Status = 'Returned' WHERE SaleID = @SaleID";
                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@SaleID", _saleId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    string details = $"{UserSession.Fullname} marked Sale ID {_saleId.ToString("D6")} as 'Returned'.";
                    LogActivity("Return Sale", details);

                    MessageBox.Show("Sale has been successfully marked as returned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _status = "Returned";
                    PopulateAllFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update the sale status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}