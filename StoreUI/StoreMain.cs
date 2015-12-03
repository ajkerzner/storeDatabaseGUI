using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void tsmiInventoryAllProducts_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "All Products";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblSort.Visible = false;
            cmbbxSortBy.Visible = false;
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
        }

        private void tsmiInformationCustomer_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Customer Information";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblSort.Visible = false;
            cmbbxSortBy.Visible = false;
        }

        private void tsmiInformationSupplier_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Supplier Information";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblSort.Visible = false;
            cmbbxSortBy.Visible = false;
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
                PopupProduct popup = new PopupProduct("");
                popup.Show();
            }
            else if (lblTitle.Text == "Order Invoices") 
            {
                PopupOrder popup = new PopupOrder("");
                popup.Show();
            }
            else if (lblTitle.Text == "All Products")
            {
                PopupProduct popup = new PopupProduct("");
                popup.Show();
            }
            else if (lblTitle.Text == "Customer Information") 
            {
                PopupInformation popup = new PopupInformation("Customer", "");
                popup.Show();
            }
            else if (lblTitle.Text == "Supplier Information")
            {
                PopupInformation popup = new PopupInformation("Supplier", "");
                popup.Show();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Change the field that indicates if the order has been fulfilled
            //"Refresh" the listview
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Inventory") 
            {
                PopupProduct popup = new PopupProduct(lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
            } 
            else if (lblTitle.Text == "Order Invoices")
            {
                PopupOrder popup = new PopupOrder(lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
            }
            else if (lblTitle.Text == "All Products")
            {
                PopupProduct popup = new PopupProduct(lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
            }
            else if (lblTitle.Text == "Customer Information")
            {
                PopupInformation popup = new PopupInformation("Customer", lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
            }
            else if (lblTitle.Text == "Supplier Information") 
            {
                PopupInformation popup = new PopupInformation("Supplier", lstvwData.SelectedItems[0].SubItems[0].Text);
                popup.Show();
            }
        }

        private void lstvwData_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Needed for order invoices to display the products that belong to that order
            //If Title = "Order Invoices"
                //Use that selection to determine the order and display its parts...
        }
        #endregion

        #region Functions
        //Adds headers to the Listview (these are necessary to populate it)
        public void SetListViewHeaders()
        {
            if (lblTitle.Text == "Inventory") 
            {
                AddHeader("InventoryItemID", 200);
                AddHeader("SupplierID", 400);
                AddHeader("ProductID", 100);
                AddHeader("Product Name", 200); //Need a Join to retrieve this
                AddHeader("Cost", 100);
                AddHeader("Discount", 100);
                AddHeader("Quantity", 100); //QuantityInInventory
            }
            //Need to check if there are more fields for this table
            else if (lblTitle.Text == "All Products") 
            {
                AddHeader("Product Name", 200);
                AddHeader("Description", 400);
                AddHeader("Price", 100);
            }
            else if (lblTitle.Text == "Order Invoices") 
            {
                AddHeader("Customer ID", 150);
                AddHeader("Customer Name", 200);
                AddHeader("Date Ordered", 150);
                AddHeader("Shipping Preference", 300);
                AddHeader("Shipping Cost", 100);
                AddHeader("Tracking Number", 150);                
            }
            else if (lblTitle.Text == "Customer Information") 
            {
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
                AddHeader("Name", 200);
                AddHeader("Address", 400);
                AddHeader("City", 150);
                AddHeader("State", 50);
                AddHeader("Postal Code", 100);
                AddHeader("Phone", 150);
                AddHeader("Email", 200);
                AddHeader("Active", 50);
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

        //CREATE METHOD TO SET LIST VIEW HEADERS FOR ORDERED PRODUCTS (Second Listview)

        //Needs to actually handle populating
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
                //Populate with the Products table?
                switch(OrderBy)
                {
                    case "Product":
                        SQL = "SELECT * FROM SupplierProducts ORDERBY ProductID";
                        break;
                    case "Supplier":
                        SQL = "SELECT * FROM SupplierProducts ORDERBY ProductID";
                        break;
                    default:
                        SQL = "SELECT * FROM SupplierProducts";
                        break;
                }
                dt = DataAccess.Read(SQL, null);

                DataTable productnamedt = new DataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["InventoryItemID"].ToString());
                    item.SubItems.Add(dr["SupplierID"].ToString());
                    item.SubItems.Add(dr["ProductID"].ToString());
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
                //Populate with the Customer Orders Table?
            }
            else if (lblTitle.Text == "Customer Orders")
            {
                //Populate with the Supplier Orders Table?
            }
            else if (lblTitle.Text == "Customer Information")
            {
                //Populate with the Customer Information Table?
            }
            else if (lblTitle.Text == "Supplier Information")
            {
                //Populate with the Supplier Information Table?
            }
            

            //For each row in the datatable returned from the database, add an item to the listview. Example:
                //foreach (DataRow dr in recipeResults.Rows)
                //{
                //    ListViewItem item = new ListViewItem("Recipes");
                //    item.SubItems.Add(dr["RecipeName"].ToString());
                //    item.SubItems.Add(dr["RecipeName"].ToString());
                //    lstvwSearchResults.Items.Add(item);
                //}
            //Remember that the item should correlate to the first column header, and each subitem to each consecutive header

            //EXAMPLE OF HOW TO READ A TABLE FROM A DATABASE:
            //string SQL = "SELECT * FROM Products ORDER BY ProductName"; //<-- Replace Product Name with whatever the sort by string is
            //DataTable dt = DataAccess.Read(SQL, null);
        }
        #endregion
    }
}
