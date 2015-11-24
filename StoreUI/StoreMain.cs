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
            //Use below method to populate listview with store inventory (SupplierProducts Table)
            //Make btnSubmit and lblOrderedProductsTitle invisible
        }

        private void tsmiInventoryAllProducts_Click(object sender, EventArgs e)
        {
            //Change Title to "All Products"
            //Use below method to populate listview with store inventory (Products Table)
            //Make btnSubmit and lblOrderedProductsTitle invisible
        }

        private void tsmiOrderCustomer_Click(object sender, EventArgs e)
        {
            //Change Title to "Order Invoices"
            //Use below method to populate listview with order invoices
            //Make first order selected
            //Create another ListView (maybe this should be permanent with toggle visible/invisible) and populate with order parts for the first order
            //Set Listview location and size
            //Make btnSubmit and lblOrderedProductsTitle VISIBLE
        }

        private void tsmiInformationCustomer_Click(object sender, EventArgs e)
        {
            //Change Title to "Customer Information"
            //Use below method to populate listview with customer information
            //Make btnSubmit and lblOrderedProductsTitle invisible
        }

        private void tsmiInformationSupplier_Click(object sender, EventArgs e)
        {
            //Change title to "Supplier Information"
            //Use below method to populate listview with supplier information
            //Make btnSubmit and lblOrderedProductsTitle invisible
        }

        private void cmbbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change an orderby string (used for SQL building)
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //If Title = "Inventory"
                // Open PopupProduct
            //If Title = "Order Invoices"
                // Open PopupOrder
            //If Title = "Customer Information"
                // Open PopupInformation
            //If Title = "Supplier Information"
                // Open PopupInformation
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Change the field that indicates if the order has been fulfilled
            //"Refresh" the listview
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //If Title = "Inventory"
                // Open PopupProduct
                // Populate the textboxes in the form with the selected product's information
            //If Title = "Order Invoices"
                // Open PopupOrder
                // Populate the textboxes in the form with the selected customer's order's information (THIS MAY NOT CURRENTLY WORK?)
                // Find a way to handle the products that are part of an order...
            //If Title = "Customer Information"
                // Open PopupInformation
                // Populate the textboxes in the form with the selected customer's information
            //If Title = "Supplier Information"
                // Open PopupInformation
                // Populate the textboxes in the form with the selected supplier's information
        }

        private void lstvwData_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Needed for order invoices to display the products that belong to that order
            //If Title = "Order Invoices"
                //Use that selection to determine the order and display its parts...
        }
        #endregion

        #region Functions
        //Add Headers to the Listview (these are necessary to populate it)
        public void SetListViewHeaders()
        {
            //If Title = "Inventory"
                //Create headers: Product Name, Description, Quantity, Price
            //If Title = "Order Invoices"
                //Create headers: Customer ID, customer name, shipping preference, tracking number, shipping cost
            //If Title = "Customer Information"
                //Create headers: Name, Address, City, State, PostalCode, Phone, Email
            //If Title = "Supplier Information"
                //Create headers: Name, Address, City, State, PostalCode, Phone, Email, Active

            //Example header:
                //ColumnHeader header = new ColumnHeader();
                //header.Text = "Product Name";
                //header.Width = 90;
                //header.TextAlign = HorizontalAlignment.Center;
                //lstvwData.Columns.Add(header);
        }

        //CREATE METHOD TO SET LIST VIEW HEADERS FOR ORDERED PRODUCTS (Second Listview)

        //Populate the Listview
        public void SetListView()
        {
            //If the listview contains items, clear it
                //If you clear it, reset the headers (SetListViewHeaders())
            //Else
                //If Title = "Inventory"
                    //Populate with the Products table?
                //If Title = "Customer Orders"
                    //Populate with the Customer Orders Table?
                //If Title = "Supplier Orders"
                    //Populate with the Supplier Orders Table?
                //If Title = "Customer Information"
                    //Populate with the Customer Information Table?
                //If Title = "Supplier Information"
                    //Populate with the Supplier Information Table?

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
