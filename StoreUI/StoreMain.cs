using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreUI
{
    public partial class StoreMain : Form
    {
        string OrderBy = ""; // Used to determine the Order By SQL clause

        public StoreMain()
        {
            InitializeComponent();
            //Starts the view off with Inventory
            lblTitle.Text = "Inventory";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
        }

        #region Event Handlers
        private void tsmiInventoryStore_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Inventory";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblSort.Visible = true;
            cmbbxSortBy.Visible = true;
            cmbbxSortBy.Items.Clear();
            cmbbxSortBy.Items.Add("Product");
            cmbbxSortBy.Items.Add("Supplier");
            btnAdd.Text = "Add Item";
            btnEdit.Text = "Edit Item";
        }

        private void tsmiInventoryAllProducts_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "All Products";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblSort.Visible = false;
            cmbbxSortBy.Visible = false;
            btnAdd.Text = "Add Product";
            btnEdit.Text = "Edit Product";
        }

        private void tsmiOrderCustomer_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Order Invoices";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = true;
            cmbbxSortBy.Visible = true;
            lblSort.Visible = true;
            cmbbxSortBy.Items.Clear();
            cmbbxSortBy.Items.Add("Order Invoice");
            cmbbxSortBy.Items.Add("Ordered Products");
            cmbbxSortBy.Items.Add("Date Ordered");
            btnAdd.Text = "Add Order";
            btnEdit.Text = "Edit Order";
        }

        private void tsmiInformationCustomer_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Customer Information";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblSort.Visible = false;
            cmbbxSortBy.Visible = false;
            btnAdd.Text = "Add Customer";
            btnEdit.Text = "Edit Customer";
        }

        private void tsmiInformationSupplier_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Supplier Information";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblSort.Visible = false;
            cmbbxSortBy.Visible = false;
            btnAdd.Text = "Add Supplier";
            btnEdit.Text = "Edit Supplier";
        }

        //Changes the order by string
       private void cmbbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderBy = cmbbxSortBy.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Inventory") 
            {
                PopupInventory popup = new PopupInventory("");
                popup.Show();
                SetListView();
            }
            else if (lblTitle.Text == "Order Invoices") 
            {
                PopupOrder popup = new PopupOrder("");
                popup.Show();
                SetListView();
            }
            else if (lblTitle.Text == "All Products")
            {
                PopupProduct popup = new PopupProduct("");
                popup.Show();
                SetListView();
            }
            else if (lblTitle.Text == "Customer Information") 
            {
                PopupInformation popup = new PopupInformation("Customer", "");
                popup.Show();
                SetListView();
            }
            else if (lblTitle.Text == "Supplier Information")
            {
                PopupInformation popup = new PopupInformation("Supplier", "");
                popup.Show();
                SetListView();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<OleDbParameter> sqlParameters = new List<OleDbParameter>();
            String SQL = "UPDATE OrderInvoice SET Completed=@orderComplete, DateCompleted=@dateComplete";
            sqlParameters.Add(new OleDbParameter("@orderComplete", true));
            sqlParameters.Add(new OleDbParameter("@dateComplete", DateTime.Now.ToOADate()));
            int numAffectedRows = DataAccess.Update(SQL, sqlParameters);
            if (numAffectedRows < 1)
            {
                MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
            }

            SetListView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Inventory") 
            {
                PopupInventory popup = new PopupInventory(lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
                SetListView();
            } 
            else if (lblTitle.Text == "Order Invoices")
            {
                PopupOrder popup = new PopupOrder(lstvwData.SelectedItems[0].SubItems[1].Text);
                popup.Show();
                SetListView();
            }
            else if (lblTitle.Text == "All Products")
            {
                PopupProduct popup = new PopupProduct(lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
                SetListView();
            }
            else if (lblTitle.Text == "Customer Information")
            {
                PopupInformation popup = new PopupInformation("Customer", lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
                SetListView();
            }
            else if (lblTitle.Text == "Supplier Information") 
            {
                PopupInformation popup = new PopupInformation("Supplier", lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
                SetListView();
            }
        }

        private void lstvwData_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Changes all records for an order to bold since submitting affects the entire order: better solution?
            if (lstvwData.SelectedItems.Count > 0 && lblTitle.Text == "Order Invoices")
            {
                String id = lstvwData.SelectedItems[0].SubItems[1].Text;
                foreach (ListViewItem item in lstvwData.Items)
                {
                    if (item.SubItems[1].Text == id)
                        item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold);
                    else
                        item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
                }
            }
        }
        #endregion

        #region Functions
        //Adds headers to the Listview (these are necessary to populate it)
        public void SetListViewHeaders()
        {
            if (lblTitle.Text == "Inventory") 
            {
                AddHeader("InventoryItemID", 200);
                AddHeader("SupplierID", 100); //Need a Join to retrieve this
                AddHeader("Supplier Name", 200);
                AddHeader("ProductID", 100);
                AddHeader("Product Name", 200); //Need a Join to retrieve this
                AddHeader("Cost", 100);
                AddHeader("Discount", 100);
                AddHeader("Quantity", 100); //QuantityInInventory
            }
            else if (lblTitle.Text == "All Products") 
            {
                AddHeader("ProductID", 100);
                AddHeader("Product Name", 200);
                AddHeader("Description", 400);
                AddHeader("Price", 100);
            }
            else if (lblTitle.Text == "Order Invoices") 
            {
                AddHeader("OrderPartID", 100);
                AddHeader("OrderID", 100);
                AddHeader("CustomerID", 100);
                AddHeader("Customer Name", 150);
                AddHeader("Date Ordered", 300);
                AddHeader("Shipping Preference", 100);
                AddHeader("Shipping Cost", 150);
                AddHeader("Tracking Number", 150);
                AddHeader("InventoryItemID", 50);
                AddHeader("Product Name", 150);
                AddHeader("Quantity", 150);
            }
            else if (lblTitle.Text == "Customer Information") 
            {
                AddHeader("CustomerID", 100);
                AddHeader("Name", 200);
                AddHeader("Address", 400);
                AddHeader("City", 150);
                AddHeader("State", 50);
                AddHeader("Postal Code", 100);
                AddHeader("Phone", 150);
                AddHeader("Email", 200);
            }
            else if (lblTitle.Text == "Supplier Information") 
            {
                AddHeader("SupplierID", 100);
                AddHeader("Name", 200);
                AddHeader("Address", 400);
                AddHeader("City", 150);
                AddHeader("State", 50);
                AddHeader("Postal Code", 100);
                AddHeader("Phone", 150);
                AddHeader("Email", 200);
                AddHeader("Active", 100);
            }
        }

        //Helper function to add a header to the first ListView
        private void AddHeader(String field, int width)
        {
            ColumnHeader header = new ColumnHeader();
            header.Text = field;
            header.Width = width;
            header.TextAlign = HorizontalAlignment.Center;
            lstvwData.Columns.Add(header);
        }

        public void SetListView()
        {
            DataTable dt = new DataTable();
            string SQL = ""; 

            if (lstvwData.Columns.Count != 0)
            {
                lstvwData.Clear();
                SetListViewHeaders();
            }
            
            if (lblTitle.Text == "Inventory")
            {
                switch(OrderBy)
                {
                    case "Product":
                        SQL = "SELECT * FROM SupplierProducts ORDERBY ProductID";
                        break;
                    case "Supplier":
                        SQL = "SELECT * FROM SupplierProducts ORDERBY SupplierID";
                        break;
                    default:
                        SQL = "SELECT * FROM SupplierProducts";
                        break;
                }
                dt = DataAccess.Read(SQL, null);

                DataTable productnamedt = new DataTable();
                DataTable suppliernamedt = new DataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["InventoryItemID"].ToString());
                    item.SubItems.Add(dr["SupplierID"].ToString());

                    //Retrieve Supplier Name
                    SQL = "SELECT SupplierName FROM Suppliers WHERE SupplierID=" + dr["SupplierID"].ToString();
                    suppliernamedt = DataAccess.Read(SQL, null);
                    if (suppliernamedt == null || suppliernamedt.Rows.Count <= 0)
                        item.SubItems.Add("Supplier Not Found"); // Will cause an error upon edit
                    else
                        item.SubItems.Add(suppliernamedt.Rows[0]["SupplierName"].ToString());

                    item.SubItems.Add(dr["ProductID"].ToString());

                    // Retrieve Product Name
                    SQL = "SELECT ProductName FROM Products WHERE ProductID=" + dr["ProductID"].ToString();
                    productnamedt = DataAccess.Read(SQL, null);
                    item.SubItems.Add(productnamedt.Rows[0]["ProductName"].ToString());

                    item.SubItems.Add(dr["Cost"].ToString());
                    item.SubItems.Add(dr["Discount"].ToString());
                    item.SubItems.Add(dr["QuantityInInventory"].ToString());
                    lstvwData.Items.Add(item);
                }
            }
            else if (lblTitle.Text == "All Products")
            {
                SQL = "SELECT * FROM Products ORDER BY ProductName";
                dt = DataAccess.Read(SQL, null);
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductID"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Description"].ToString());
                    item.SubItems.Add(dr["Price"].ToString());
                    lstvwData.Items.Add(item);
                }
            }
            else if (lblTitle.Text == "Order Invoices")
            {
                switch (OrderBy)
                {
                    case "Order Invoice":
                        SQL = "SELECT * FROM OrderInvoice INNER JOIN OrderProduct ON OrderInvoice.OrderID = OrderProduct.OrderID WHERE " 
                            + "OrderInvoice.Completed=false ORDER BY OrderInvoice.OrderID";
                        break;
                    case "Ordered Products":
                        SQL = "SELECT * FROM OrderInvoice INNER JOIN OrderProduct ON OrderInvoice.OrderID = OrderProduct.OrderID WHERE "
                            + "OrderInvoice.Completed=false ORDER BY OrderPartID";
                        break;
                    case "Date Ordered":
                        SQL = "SELECT * FROM OrderInvoice INNER JOIN OrderProduct ON OrderInvoice.OrderID = OrderProduct.OrderID WHERE " 
                            + "OrderInvoice.Completed=false ORDER BY DateOrdered";
                        break;
                    default:
                        SQL = "SELECT * FROM OrderInvoice INNER JOIN OrderProduct ON OrderInvoice.OrderID = OrderProduct.OrderID WHERE "
                            + "OrderInvoice.Completed=false";
                        break;
                }
                dt = DataAccess.Read(SQL, null);

                DataTable customernamedt = new DataTable(); //Customer Name
                DataTable productnamedt = new DataTable(); //Product Name
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["OrderPartID"].ToString());
                    item.SubItems.Add(dr["OrderInvoice.OrderID"].ToString());
                    item.SubItems.Add(dr["CustomerID"].ToString());

                    // Retrieve Customer Name
                    SQL = "SELECT LastName, FirstName FROM Customers WHERE CustomerID=" + dr["CustomerID"].ToString();
                    customernamedt = DataAccess.Read(SQL, null);
                    item.SubItems.Add(customernamedt.Rows[0]["FirstName"].ToString() + " " + customernamedt.Rows[0]["LastName"].ToString());

                    item.SubItems.Add(dr["DateOrdered"].ToString());
                    item.SubItems.Add(dr["ShippingPreference"].ToString());
                    item.SubItems.Add(dr["ShippingCost"].ToString());
                    item.SubItems.Add(dr["TrackingID"].ToString());
                    item.SubItems.Add(dr["InventoryItemID"].ToString());

                    // Retrieve Product Name
                    SQL = "SELECT ProductName FROM Products WHERE ProductID = (SELECT ProductID FROM SupplierProducts WHERE InventoryItemID = "
                        + dr["InventoryItemID"].ToString() + ")";
                    productnamedt = DataAccess.Read(SQL, null);
                    item.SubItems.Add(productnamedt.Rows[0]["ProductName"].ToString());

                    item.SubItems.Add(dr["Quantity"].ToString());
                    lstvwData.Items.Add(item);
                }
            }
            else if (lblTitle.Text == "Customer Information")
            {
                SQL = "SELECT * FROM Customers ORDER BY LastName";
                dt = DataAccess.Read(SQL, null);

                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                    item.SubItems.Add(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                    item.SubItems.Add(dr["Address"].ToString());
                    item.SubItems.Add(dr["City"].ToString());
                    item.SubItems.Add(dr["State"].ToString());
                    item.SubItems.Add(dr["PostalCode"].ToString());
                    item.SubItems.Add(dr["Phone"].ToString());
                    item.SubItems.Add(dr["Email"].ToString());
                    lstvwData.Items.Add(item);
                }
            }
            else if (lblTitle.Text == "Supplier Information")
            {
                SQL = "SELECT * FROM Suppliers ORDER BY SupplierName";
                dt = DataAccess.Read(SQL, null);

                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["SupplierID"].ToString());
                    item.SubItems.Add(dr["SupplierName"].ToString());
                    item.SubItems.Add(dr["Address"].ToString());
                    item.SubItems.Add(dr["City"].ToString());
                    item.SubItems.Add(dr["State"].ToString());
                    item.SubItems.Add(dr["PostalCode"].ToString());
                    item.SubItems.Add(dr["Phone"].ToString());
                    item.SubItems.Add(dr["Email"].ToString());
                    item.SubItems.Add(dr["Active"].ToString());
                    lstvwData.Items.Add(item);
                }
            }
        }
        #endregion
    }
}
