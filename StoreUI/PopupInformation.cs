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
    public partial class PopupInformation : Form
    {
        private string CustomerSupplierID = "";
        private string CustomerSupplier = "";
        private string SQL = "";
        private List<OleDbParameter> sqlParameters = new List<OleDbParameter>();
        private int numAffectedRows = 0;

        public PopupInformation(string who, string ID)
        {
            InitializeComponent();

            CustomerSupplier = who;
            if (CustomerSupplier == "Customer")
            {
                chkbxActive.Visible = false;
                if (ID == "")
                {
                    this.Text = "Add New Customer Information";
                    btnAdd.Text = "Add Customer";
                }
                else
                {
                    this.Text = "Edit Customer Information";
                    CustomerSupplierID = ID;
                    btnAdd.Text = "Edit Info";
                    SQL = "SELECT * FROM Customers WHERE CustomerID=" + CustomerSupplierID;
                    DataTable dt = DataAccess.Read(SQL, null);
                    txtbxName.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    txtbxAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtbxCity.Text = dt.Rows[0]["City"].ToString();
                    txtbxEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtbxPhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    txtbxPostalCode.Text = dt.Rows[0]["PostalCode"].ToString();
                    cmbbxState.SelectedIndex = cmbbxState.FindStringExact(dt.Rows[0]["State"].ToString());
                }
            }
            else // CustomerSupplier == "Supplier"
            {
                chkbxActive.Visible = true;
                if (ID == "")
                {
                    this.Text = "Add New Supplier Information";
                    btnAdd.Text = "Add Supplier";
                    chkbxActive.Checked = true;
                }
                else
                {
                    this.Text = "Edit Supplier Information";
                    CustomerSupplierID = ID;
                    btnAdd.Text = "Edit Info";
                    SQL = "SELECT * FROM Suppliers WHERE SupplierID=" + CustomerSupplierID;
                    DataTable dt = DataAccess.Read(SQL, null);
                    txtbxName.Text = dt.Rows[0]["SupplierName"].ToString();
                    txtbxAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtbxCity.Text = dt.Rows[0]["City"].ToString();
                    txtbxEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtbxPhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    txtbxPostalCode.Text = dt.Rows[0]["PostalCode"].ToString();
                    cmbbxState.SelectedIndex = cmbbxState.FindStringExact(dt.Rows[0]["State"].ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtbxAddress.Text == "" || txtbxCity.Text == "" || txtbxEmail.Text == "" || txtbxName.Text == "" || txtbxPhoneNumber.Text == ""
                || txtbxPostalCode.Text == "" || cmbbxState.Text == "")
            {
                MessageBox.Show("A field is empty. Please fill out all textboxes and make selections in all comboboxes.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (CustomerSupplier == "Customer" && btnAdd.Text == "Add Customer")
                {
                    SQL = "INSERT INTO Customers (LastName, FirstName, Address, City, State, PostalCode, Phone, Email) VALUES "
                        + "(@lastname, @firstname, @address, @city, @state, @postalcode, @phone, @email)";
                    sqlParameters.Clear();
                    sqlParameters.Add(new OleDbParameter("@lastname", txtbxName.Text.Split(' ')[1]));
                    sqlParameters.Add(new OleDbParameter("@firstname", txtbxName.Text.Split(' ')[0]));
                    sqlParameters.Add(new OleDbParameter("@address", txtbxAddress.Text));
                    sqlParameters.Add(new OleDbParameter("@city", txtbxCity.Text));
                    sqlParameters.Add(new OleDbParameter("@state", cmbbxState.Text));
                    sqlParameters.Add(new OleDbParameter("@postalcode", txtbxPostalCode.Text));
                    sqlParameters.Add(new OleDbParameter("@phone", txtbxPhoneNumber.Text));
                    sqlParameters.Add(new OleDbParameter("@email", txtbxEmail.Text));

                    numAffectedRows = DataAccess.Create(SQL, sqlParameters);
                    if (numAffectedRows < 1)
                    {
                        MessageBox.Show("An error occured. " + txtbxName.Text + " was not added to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (CustomerSupplier == "Customer" && btnAdd.Text == "Edit Info")
                {
                    SQL = "UPDATE Customers SET LastName=@lastname, FirstName=@firstname, Address=@address, City=@city, State=@state, "
                        + "PostalCode=@postalcode, Phone=@phone, Email=@email WHERE CustomerID=" + CustomerSupplierID;
                    sqlParameters.Clear();
                    sqlParameters.Add(new OleDbParameter("@lastname", txtbxName.Text.Split(' ')[1]));
                    sqlParameters.Add(new OleDbParameter("@firstname", txtbxName.Text.Split(' ')[0]));
                    sqlParameters.Add(new OleDbParameter("@address", txtbxAddress.Text));
                    sqlParameters.Add(new OleDbParameter("@city", txtbxCity.Text));
                    sqlParameters.Add(new OleDbParameter("@state", cmbbxState.Text));
                    sqlParameters.Add(new OleDbParameter("@postalcode", txtbxPostalCode.Text));
                    sqlParameters.Add(new OleDbParameter("@phone", txtbxPhoneNumber.Text));
                    sqlParameters.Add(new OleDbParameter("@email", txtbxEmail.Text));
                    numAffectedRows = DataAccess.Update(SQL, sqlParameters);
                    if (numAffectedRows < 1)
                    {
                        MessageBox.Show("An error occured. " + txtbxName.Text + " was not edited in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (CustomerSupplier == "Supplier" && btnAdd.Text == "Add Supplier")
                {
                    SQL = "INSERT INTO Suppliers (SupplierName, Address, City, State, PostalCode, Phone, Email, Active) VALUES "
                        + "(@suppliername, @address, @city, @state, @postalcode, @phone, @email, @active)";
                    sqlParameters.Clear();
                    sqlParameters.Add(new OleDbParameter("@suppliername", txtbxName.Text));
                    sqlParameters.Add(new OleDbParameter("@address", txtbxAddress.Text));
                    sqlParameters.Add(new OleDbParameter("@city", txtbxCity.Text));
                    sqlParameters.Add(new OleDbParameter("@state", cmbbxState.Text));
                    sqlParameters.Add(new OleDbParameter("@postalcode", txtbxPostalCode.Text));
                    sqlParameters.Add(new OleDbParameter("@phone", txtbxPhoneNumber.Text));
                    sqlParameters.Add(new OleDbParameter("@email", txtbxEmail.Text));
                    sqlParameters.Add(new OleDbParameter("@active", chkbxActive.Checked));

                    numAffectedRows = DataAccess.Create(SQL, sqlParameters);
                    if (numAffectedRows < 1)
                    {
                        MessageBox.Show("An error occured. " + txtbxName.Text + " was not added to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (CustomerSupplier == "Supplier" && btnAdd.Text == "Edit Info")
                {
                    SQL = "UPDATE Suppliers SET SupplierName=@suppliername, Address=@address, City=@city, State=@state, "
                        + "PostalCode=@postalcode, Phone=@phone, Email=@email, Active=@active WHERE SupplierID=" + CustomerSupplierID;
                    sqlParameters.Clear();
                    sqlParameters.Add(new OleDbParameter("@suppliername", txtbxName.Text));
                    sqlParameters.Add(new OleDbParameter("@address", txtbxAddress.Text));
                    sqlParameters.Add(new OleDbParameter("@city", txtbxCity.Text));
                    sqlParameters.Add(new OleDbParameter("@state", cmbbxState.Text));
                    sqlParameters.Add(new OleDbParameter("@postalcode", txtbxPostalCode.Text));
                    sqlParameters.Add(new OleDbParameter("@phone", txtbxPhoneNumber.Text));
                    sqlParameters.Add(new OleDbParameter("@email", txtbxEmail.Text));
                    sqlParameters.Add(new OleDbParameter("@active", chkbxActive.Checked));

                    numAffectedRows = DataAccess.Update(SQL, sqlParameters);
                    if (numAffectedRows < 1)
                    {
                        MessageBox.Show("An error occured. " + txtbxName.Text + " was not edited in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
