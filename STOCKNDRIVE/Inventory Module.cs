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
using Microsoft.Data;

namespace STOCKNDRIVE
{
    public partial class Inventory_Module : Form
    {
        private DataTable inventoryDataTable;
        public Inventory_Module()
        {
            InitializeComponent();
            // This line connects your event handler method to the actual event
            inventoryGrid.DataBindingComplete += inventoryGrid_DataBindingComplete;
        }
        private void Inventory_Module_Load(object sender, EventArgs e)
        {
            StyleInventoryGrid();
            LoadInventoryData();
            lblClearSearch.Visible = false;
        }
        private void LoadInventoryData()
        {
            string query = "SELECT ProductID, ProductName, Brand, Manufacturer, Price, QuantityInStock, Category FROM Products ORDER BY ProductName";

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load inventory data.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleInventoryGrid()
        {
            inventoryGrid.BorderStyle = BorderStyle.None;
            inventoryGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            inventoryGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            inventoryGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 210, 210);
            inventoryGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            inventoryGrid.BackgroundColor = Color.White;
            inventoryGrid.RowHeadersVisible = false;

            // This line will center the content of ALL cells
            inventoryGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Also center the headers
            inventoryGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            inventoryGrid.EnableHeadersVisualStyles = false;
            inventoryGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            inventoryGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 232, 232);
            inventoryGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
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

            foreach (DataGridViewRow row in inventoryGrid.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    DataGridViewCellStyle style = new DataGridViewCellStyle(row.Cells["Status"].Style); // Clone existing style

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
            AddItem addItem = new AddItem();

            // Show the form as a dialog and check the result it returns when it closes
            if (addItem.ShowDialog() == DialogResult.OK)
            {
                // If the result was OK, it means the user clicked "Done" and the item was saved.
                // Therefore, we should refresh the inventory data.
                LoadInventoryData();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            var categories = new List<string>
    {
        "Show All", // Option to clear the filter
        "---",      // A separator line
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
                    menuItem.Click += FilterMenuItem_Click; // Assign the same click event to all items
                    contextMenu.Items.Add(menuItem);
                }
            }

            // Show the menu just below the filter button
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
                    // Apply the filter. Note the single quotes around the category name.
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
