using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace STOCKNDRIVE
{
    public partial class Inventory_Module : Form
    {
        private DataTable inventoryDataTable;

        public Inventory_Module()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(UserSession.Fullname))
            {
                lblwelcome.Text = $"Welcome back, {UserSession.Fullname}!";
            }
            inventoryGrid.DataBindingComplete += inventoryGrid_DataBindingComplete;
            inventoryGrid.SelectionChanged += inventoryGrid_SelectionChanged;
            inventoryGrid.CellMouseEnter += inventoryGrid_CellMouseEnter;
            inventoryGrid.MouseLeave += inventoryGrid_MouseLeave;
        }

        private void Inventory_Module_Load(object sender, EventArgs e)
        {
            StyleInventoryGrid();
            LoadInventoryData();
            lblClearSearch.Visible = false;
        }
        private int hoveredRowIndex = -1;
        private void inventoryGrid_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in inventoryGrid.SelectedCells)
            {
                cell.Style.SelectionBackColor = cell.Style.BackColor;
                cell.Style.SelectionForeColor = cell.Style.ForeColor;
            }
        }
        private void inventoryGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != this.hoveredRowIndex)
            {
                if (this.hoveredRowIndex >= 0)
                {
                    RestoreRowStyle(this.hoveredRowIndex);
                }
                this.hoveredRowIndex = e.RowIndex;
                inventoryGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 223, 0); 
            }
        }

        private void inventoryGrid_MouseLeave(object sender, EventArgs e)
        {
            if (this.hoveredRowIndex >= 0)
            {
                RestoreRowStyle(this.hoveredRowIndex);
                this.hoveredRowIndex = -1;
            }
        }

        private void RestoreRowStyle(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < inventoryGrid.Rows.Count)
            {
                DataGridViewRow row = inventoryGrid.Rows[rowIndex];

                if (rowIndex % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = inventoryGrid.DefaultCellStyle.BackColor;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = inventoryGrid.AlternatingRowsDefaultCellStyle.BackColor;
                }

                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    DataGridViewCellStyle style = row.Cells["Status"].Style; 

                    switch (status)
                    {
                        case "Good":
                            style.BackColor = Color.FromArgb(223, 240, 216);
                            break;
                        case "Low Stock":
                            style.BackColor = Color.FromArgb(252, 248, 227);
                            break;
                        case "Out of Stock":
                            style.BackColor = Color.FromArgb(242, 222, 222);
                            break;
                    }
                }
            }
        }

        private void LoadInventoryData()
        {
            string query = "SELECT ProductID, ProductName, Brand, Manufacturer, Price, QuantityInStock, Category, LastUpdated FROM Products ORDER BY ProductName";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    this.inventoryDataTable = new DataTable();
                    adapter.Fill(this.inventoryDataTable);

                    this.inventoryDataTable.Columns.Add("Status", typeof(string));

                    foreach (DataRow row in this.inventoryDataTable.Rows)
                    {
                        int quantity = Convert.ToInt32(row["QuantityInStock"]);
                        if (quantity == 0)
                        {
                            row["Status"] = "Out of Stock";
                        }
                        else if (quantity <= 5)
                        {
                            row["Status"] = "Low Stock";
                        }
                        else
                        {
                            row["Status"] = "Good";
                        }
                    }

                    inventoryGrid.DataSource = this.inventoryDataTable;
                    UpdateStatusCounts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load inventory data.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusCounts()
        {
            if (inventoryDataTable == null) return;

            int totalItems = 0;
            int lowStockItems = 0;
            int outOfStockItems = 0;

            foreach (DataRow row in inventoryDataTable.Rows)
            {
                int quantity = Convert.ToInt32(row["QuantityInStock"]);
                totalItems++;

                if (quantity == 0)
                {
                    outOfStockItems++;
                }
                else if (quantity <= 5)
                {
                    lowStockItems++;
                }
            }

            totaltxt.Text = totalItems.ToString();
            lowstocktxt.Text = lowStockItems.ToString();
            outofstocktxt.Text = outOfStockItems.ToString();
        }

        private void StyleInventoryGrid()
        {
            inventoryGrid.BorderStyle = BorderStyle.FixedSingle;
            inventoryGrid.GridColor = Color.Black;
            inventoryGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            inventoryGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            inventoryGrid.BackgroundColor = Color.White;
            inventoryGrid.RowHeadersVisible = false;
            inventoryGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            inventoryGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            inventoryGrid.EnableHeadersVisualStyles = false;
            inventoryGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            inventoryGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 232, 232);
            inventoryGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            inventoryGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 232, 232);
            inventoryGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            inventoryGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 10, 0, 10);
            inventoryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inventoryGrid.AllowUserToAddRows = false;
            inventoryGrid.AllowUserToDeleteRows = false;
            inventoryGrid.AllowUserToResizeRows = false;
            inventoryGrid.ReadOnly = true;
        }

        private void inventoryGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            inventoryGrid.ClearSelection();
            if (inventoryGrid.Columns.Count == 0) return;

            inventoryGrid.Columns["Category"].Visible = false;
            inventoryGrid.Columns["ProductID"].Visible = false;

            inventoryGrid.Columns["ProductName"].HeaderText = "Product Name";
            inventoryGrid.Columns["QuantityInStock"].HeaderText = "Quantity";
            inventoryGrid.Columns["Price"].HeaderText = "Price (₱)";
            inventoryGrid.Columns["Price"].DefaultCellStyle.Format = "N2";

            inventoryGrid.Columns["LastUpdated"].HeaderText = "Date Updated";
            inventoryGrid.Columns["LastUpdated"].DefaultCellStyle.Format = "MMMM dd, yyyy h:mm tt";

            foreach (DataGridViewRow row in inventoryGrid.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    DataGridViewCellStyle style = new DataGridViewCellStyle(row.Cells["Status"].Style);

                    style.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
                    style.Padding = new Padding(5, 2, 5, 2);

                    switch (status)
                    {
                        case "Good":
                            style.BackColor = Color.FromArgb(223, 240, 216);
                            style.ForeColor = Color.FromArgb(60, 118, 61);
                            break;
                        case "Low Stock":
                            style.BackColor = Color.FromArgb(252, 248, 227);
                            style.ForeColor = Color.FromArgb(138, 109, 59);
                            break;
                        case "Out of Stock":
                            style.BackColor = Color.FromArgb(242, 222, 222);
                            style.ForeColor = Color.FromArgb(169, 68, 66);
                            break;
                    }
                    row.Cells["Status"].Style = style;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblClearSearch.Visible = !string.IsNullOrEmpty(textBox1.Text);

            if (this.inventoryDataTable != null)
            {
                try
                {
                    string searchText = textBox1.Text.Trim().Replace("'", "''");
                    this.inventoryDataTable.DefaultView.RowFilter = $"ProductName LIKE '%{searchText}%'";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Filter Error: " + ex.Message);
                }
            }
        }

        private void lblClearSearch_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard newDashboard = new Dashboard();
            newDashboard.Show();
            this.Close();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            pos newpos = new pos();
            newpos.Show();
            this.Close();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory_Module inventory = new Inventory_Module();
            inventory.Show();
            this.Close();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (AddItem addItem = new AddItem())
            {
                if (addItem.ShowDialog() == DialogResult.OK)
                {
                    LoadInventoryData();
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            var categories = new List<string>
            {
                "Show All",
                "---",
                "Engine & Performance Parts",
                "Electrical & Lighting",
                "Tires & Wheels",
                "Brakes & Suspension",
                "Body & Frame Parts",
                "Transmission & Drivetrain",
                "Tools & Maintenance",
                "Riding Gear & Accessories",
                "Fluids & Consumables",
                "Customization & Decorative Items"
            };

            foreach (string category in categories)
            {
                if (category == "---")
                {
                    contextMenu.Items.Add(new ToolStripSeparator());
                }
                else
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(category);
                    menuItem.Click += FilterMenuItem_Click;
                    contextMenu.Items.Add(menuItem);
                }
            }
            Point screenPoint = btnFilter.PointToScreen(new Point(0, btnFilter.Height));
            contextMenu.Show(screenPoint);
        }

        private void FilterMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string selectedCategory = clickedItem.Text;

            if (this.inventoryDataTable != null)
            {
                if (selectedCategory == "Show All")
                {
                    this.inventoryDataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    this.inventoryDataTable.DefaultView.RowFilter = $"Category = '{selectedCategory}'";
                }
            }
        }

        private void inventoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int productId = Convert.ToInt32(inventoryGrid.Rows[e.RowIndex].Cells["ProductID"].Value);

            using (AddItem editItemForm = new AddItem(productId))
            {
                if (editItemForm.ShowDialog() == DialogResult.OK)
                {
                    LoadInventoryData();
                }
            }
        }
    }
}