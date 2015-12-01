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
    public partial class PopupInventory : Form
    {
        private string InventoryItemID = "";
        private string ProductID = "";
        private string SupplierID = "";
        private string SQL = "";
        private List<OleDbParameter> sqlParameters = new List<OleDbParameter>();

        //If editing a preexisting item, initialize the popup with the ID, otherwise assume that a new item is being added
        public PopupInventory(string ID)
        {
            InitializeComponent();

            SQL = "SELECT SupplierID, SupplierName FROM Suppliers";
            DataTable dt = DataAccess.Read(SQL, null);
            foreach(DataRow dr in dt.Rows)
            {
                cmbbxSupplier.Items.Add(dr["SupplierID"].ToString() + " " + dr["SupplierName"].ToString());
            }
            SQL = "SELECT ProductID, ProductName FROM Products";
            dt = DataAccess.Read(SQL, null);
            foreach (DataRow dr in dt.Rows)
            {
                cmbbxSupplier.Items.Add(dr["ProductID"].ToString() + " " + dr["ProductName"].ToString());
            }

            // Initialize Add or Edit functionality
            if (ID == "")
            {
                this.Text = "Add Item to Inventory";
                btnAdd.Text = "Add Item";
                cmbbxSupplier.SelectedIndex = 1;
                cmbbxProduct.SelectedIndex = 1;
            }
            else
            {
                InventoryItemID = ID;
                this.Text = "Edit Item Information";
                btnAdd.Text = "Edit Item";

                SQL = "SELECT * FROM SupplierProducts WHERE InventoryItemID=" + InventoryItemID;
                dt = DataAccess.Read(SQL, null);
                txtbxCost.Text = dt.Rows[0]["Cost"].ToString();
                txtbxDiscount.Text = dt.Rows[0]["Discount"].ToString();
                txtbxQuantity.Text = dt.Rows[0]["QuantityInInventory"].ToString();

                SQL = "SELECT SupplierName FROM Suppliers WHERE SupplierID=" + dt.Rows[0]["SupplierID"].ToString();
                DataTable IDdt = DataAccess.Read(SQL, null);
                cmbbxSupplier.SelectedIndex = cmbbxSupplier.FindStringExact(dt.Rows[0]["SupplierID"].ToString() + " "
                    + IDdt.Rows[0]["SupplierName"].ToString());
                SQL = "SELECT ProductName FROM Products WHERE ProductID=" + dt.Rows[0]["ProductID"].ToString();
                IDdt = DataAccess.Read(SQL, null);
                cmbbxSupplier.SelectedIndex = cmbbxSupplier.FindStringExact(dt.Rows[0]["ProductID"].ToString() + " "
                    + IDdt.Rows[0]["SupplierName"].ToString());
            }
        }

        private void cmbbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxProduct.Text != "") // Selected Count > 0 doesn't work for combobox, test this check
                this.ProductID = cmbbxProduct.Text.Split(' ')[0];
        }

        private void cmbbxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxSupplier.Text != "") // Selected Count > 0 doesn't work for combobox, test this check
                this.SupplierID = cmbbxSupplier.Text.Split(' ')[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add Item")
            {
                SQL = "INSERT INTO SupplierProducts (SupplierID, ProductID, Cost, Discount, QuantityInInventory) VALUES (@supplierid, @productid, @cost, @discount, @quantityininventory)";
                sqlParameters.Clear();
                sqlParameters.Add(new OleDbParameter("@supplierid", SupplierID));
                sqlParameters.Add(new OleDbParameter("@productid", ProductID));
                if (txtbxCost.Text == "")
                    sqlParameters.Add(new OleDbParameter("@cost", "0.00"));
                else
                    sqlParameters.Add(new OleDbParameter("@cost", txtbxCost.Text));
                if (txtbxDiscount.Text == "")
                    sqlParameters.Add(new OleDbParameter("@discount", "0.00"));
                else
                    sqlParameters.Add(new OleDbParameter("@discount", txtbxDiscount.Text));
                if (txtbxQuantity.Text == "")
                    sqlParameters.Add(new OleDbParameter("@quantityininventory", "0.00"));
                else
                    sqlParameters.Add(new OleDbParameter("@quantityininventory", txtbxQuantity.Text));
                int numAffectedRows = DataAccess.Create(SQL, sqlParameters);
                if (numAffectedRows < 1)
                {
                    MessageBox.Show("An error occured. The item was not added to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
