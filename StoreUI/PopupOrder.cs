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
    public partial class PopupOrder : Form
    {
        string SQL = "";
        List<OleDbParameter> sqlParameters = new List<OleDbParameter>();
        int numAffectedRows = 0;
        string OrderID = "";

        //If editing a preexisting order, initialize the popup the ID, otherwise assume that a new order is being added
        public PopupOrder(string ID)
        {
            InitializeComponent();

            ColumnHeader header1 = new ColumnHeader();
            header1.Text = "InventoryItemID";
            header1.Width = 20;
            header1.TextAlign = HorizontalAlignment.Center;
            lstvwOrderedProducts.Columns.Add(header1);
            ColumnHeader header2 = new ColumnHeader();
            header2.Text = "SupplierID";
            header2.Width = 15;
            header2.TextAlign = HorizontalAlignment.Center;
            lstvwOrderedProducts.Columns.Add(header2);
            ColumnHeader header3 = new ColumnHeader();
            header3.Text = "ProductID";
            header3.Width = 15;
            header3.TextAlign = HorizontalAlignment.Center;
            lstvwOrderedProducts.Columns.Add(header3);
            ColumnHeader header4 = new ColumnHeader();
            header4.Text = "Price";
            header4.Width = 10;
            header4.TextAlign = HorizontalAlignment.Center;
            lstvwOrderedProducts.Columns.Add(header4);
            ColumnHeader header5 = new ColumnHeader();
            header5.Text = "Quantity";
            header5.Width = 10;
            header5.TextAlign = HorizontalAlignment.Center;
            lstvwOrderedProducts.Columns.Add(header5);

            if(ID == "")
            {
                btnAdd.Text = "Add Order";

                //Set the customer order box to all customers
                SQL = "SELECT CustomerID, LastName, FirstName FROM Customers";
                DataTable customersdt = DataAccess.Read(SQL, null);
                foreach(DataRow dr in customersdt.Rows)
                {
                    cmbbxCustomers.Items.Add(dr["CustomerID"].ToString() + " " + dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                }

                //Populate listview with store inventory
                SQL = "SELECT InventoryItemID, SupplierID, ProductID, QuantityInInventory FROM Products";
                DataTable dt = DataAccess.Read(SQL, null);
                foreach(DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["InventoryItemID"].ToString());
                    item.SubItems.Add(dr["SupplierID"].ToString());
                    item.SubItems.Add(dr["ProductID"].ToString());

                    SQL = "SELECT Price FROM Products WHERE ProductID=" + dr["ProductID"].ToString();
                    DataTable pricedt = DataAccess.Read(SQL, null);
                    if (pricedt != null)
                        item.SubItems.Add(pricedt.Rows[0]["Price"].ToString());
                    else
                        item.SubItems.Add("0.00");
                    item.SubItems.Add(dr["QuantityInInventory"].ToString());
                    item.SubItems.Add("0");
                    item.Checked = false;
                    lstvwOrderedProducts.Items.Add(item);
                }
            }
            else
            {
                btnAdd.Text = "Edit Order";
                OrderID = ID;
                
                // Set the customer combobox to the customer whose order is being edited
                SQL = "SELECT CustomerID FROM OrderInvoice WHERE OrderID=" + OrderID;
                DataTable customersdt = DataAccess.Read(SQL, null);
                SQL = "SELECT CustomerID, LastName, FirstName FROM Customers WHERE CustomerID=" + customersdt.Rows[0]["CustomerID"];
                customersdt = DataAccess.Read(SQL, null);
                cmbbxCustomers.Items.Add(customersdt.Rows[0]["CustomerID"].ToString() + " " + customersdt.Rows[0]["FirstName"].ToString() + " " + customersdt.Rows[0]["LastName"].ToString());
                cmbbxCustomers.SelectedIndex = 1;

                SQL = "SELECT InventoryItemID, Quantity FROM OrderProduct WHERE OrderID=" + ID;
                DataTable dt = DataAccess.Read(SQL, null);
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["InventoryItemID"].ToString());

                    SQL = "SELECT SupplierID, ProductID, QuantityInInventory FROM SupplierProducts WHERE InventoryItemID="
                        + dr["InventoryItemID"].ToString();
                    DataTable productdt = DataAccess.Read(SQL, null);
                    SQL = "SELECT Price FROM Products WHERE ProductID=" + productdt.Rows[0]["ProductID"].ToString();
                    DataTable pricedt = DataAccess.Read(SQL, null);

                    item.SubItems.Add(productdt.Rows[0]["SupplierID"].ToString());
                    item.SubItems.Add(productdt.Rows[0]["ProductID"].ToString());
                    if (pricedt != null)
                        item.SubItems.Add(pricedt.Rows[0]["Price"].ToString());
                    else
                        item.SubItems.Add("0.00");
                    item.SubItems.Add(productdt.Rows[0]["QuantityInInventory"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.Checked = false;
                    lstvwOrderedProducts.Items.Add(item);                    
                }
            }
        }

        private void lstvwOrderedProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvwOrderedProducts.SelectedItems.Count > 0)
            {
                foreach(ListViewItem item in lstvwOrderedProducts.SelectedItems)
                {
                    item.Checked = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text == "Add Order")
            {
                SQL = "INSERT INTO OrderInvoice (ProductName, Description, Price) VALUES (@productname, @description, @price)";
                //sqlParameters.Clear();
                //sqlParameters.Add(new OleDbParameter("@productname", txtbxProductName.Text));
                //sqlParameters.Add(new OleDbParameter("@description", txtbxProductDescription.Text));
                //sqlParameters.Add(new OleDbParameter("@price", txtbxPrice.Text));
                //numAffectedRows = DataAccess.Create(SQL, sqlParameters);
                //if (numAffectedRows < 1)
                //{
                //    MessageBox.Show("An error occured. " + txtbxProductName.Text + " was not added to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    this.Close();
                //}
            }
            else //Edit
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
