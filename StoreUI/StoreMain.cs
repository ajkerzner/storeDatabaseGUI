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
        }

        #region Event Handlers
        private void tsmiInventoryStore_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Inventory";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblOrderedProductsTitle.Visible = false;
        }

        private void tsmiInventoryAllProducts_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "All Products";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblOrderedProductsTitle.Visible = false;
        }

        private void tsmiOrderCustomer_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Order Invoices";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = true;
            lblOrderedProductsTitle.Visible = true;
        }

        private void tsmiInformationCustomer_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Customer Information";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblOrderedProductsTitle.Visible = false;
        }

        private void tsmiInformationSupplier_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Supplier Information";
            SetListViewHeaders();
            SetListView();
            btnSubmit.Visible = false;
            lblOrderedProductsTitle.Visible = false;
        }

        //Changes the order by string
       private void cmbbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxSortBy.Text == "Product Name")
            {
                OrderBy = "Product Name";
            } 
            else if (cmbbxSortBy.Text == "Supplier Name")
            {
                OrderBy = "Supplier Name";
            }
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
                //Parameters will be ("Customer", "")
                PopupInformation popup = new PopupInformation();
                popup.Show();
            }
            else if (lblTitle.Text == "Supplier Information")
            {
                //Parameters will be ("Supplier", "")
                PopupInformation popup = new PopupInformation();
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
                //Parameters will be ("Customer", lstvwData.SelectedItems[0].SubItems[0].Text)
                PopupInformation popup = new PopupInformation();
                popup.Show();
            }
            else if (lblTitle.Text == "Supplier Information") 
            {
                //Parameters will be ("Supplier", lstvwData.SelectedItems[0].SubItems[0].Text)
                PopupInformation popup = new PopupInformation();
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
                AddHeader("Product Name", 200);
                AddHeader("Description", 400);
                AddHeader("Quantity", 100);
                AddHeader("Price", 100);
            }
            //Need to check if there are more fields for this table
            else if (lblTitle.Text == "All Products") 
            {
                AddHeader("Product Name", 200);
                AddHeader("Description", 400);
                AddHeader("Quantity", 100);
                AddHeader("Price", 100);
            }
            else if (lblTitle.Text == "Order Invoices") 
            {
                AddHeader("Customer ID", 150);
                AddHeader("Customer Name", 200);
                AddHeader("Shipping Preference", 300);
                AddHeader("Tracking Number", 150);
                AddHeader("Shipping Cost", 100);
                
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
            if (lstvwData.Items.Count != 0)
            {
                lstvwData.Clear();
                SetListViewHeaders();
            }
            else
            {
                if (lblTitle.Text == "Inventory")
                {
                    //Populate with the Products table?
                }
                else if (lblTitle.Text == "Customer Orders")
                {
                    //Populate with the Customer Orders Table?
                }
                else if (lblTitle.Text == "Supplier Orders")
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
            string SQL = "SELECT * FROM Products ORDER BY ProductName"; //<-- Replace Product Name with whatever the sort by string is
            DataTable dt = DataAccess.Read(SQL, null);
        }
        #endregion
    }
}
