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
    public partial class PopupProduct : Form
    {
        string SQL = "";
        List<OleDbParameter> sqlParameters = new List<OleDbParameter>();
        int numAffectedRows = 0;
        string ID = "";

        //If editing a preexisting product, hand the popup the ID, otherwise assume that a new product is being added
        public PopupProduct(string ID)
        {
            InitializeComponent();

            if(ID == "")
            {
                this.Text = "Add Product";
                btnAdd.Text = "Add";
            }
            else
            {
                this.Text = "Edit Product";
                btnAdd.Text = "Edit";
                this.ID = ID;
                SQL = "SELECT * FROM Products WHERE ProductID=" + ID;
                DataTable dt = DataAccess.Read(SQL, null);
                txtbxProductName.Text = dt.Rows[0]["ProductName"].ToString();
                txtbxPrice.Text = dt.Rows[0]["Price"].ToString();
                txtbxProductDescription.Text = dt.Rows[0]["Description"].ToString();
            }
        }

        //Button can be either Add or Edit and execute either SQL function?
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text == "Add")
            {
                SQL = "INSERT INTO Products (ProductName, Description, Price) VALUES (@productname, @description, @price)";
                sqlParameters.Clear();
                sqlParameters.Add(new OleDbParameter("@productname", txtbxProductName.Text));
                sqlParameters.Add(new OleDbParameter("@description", txtbxProductDescription.Text));
                sqlParameters.Add(new OleDbParameter("@price", Double.Parse(txtbxPrice.Text)));
                numAffectedRows = DataAccess.Create(SQL, sqlParameters);
                if(numAffectedRows < 1)
                {
                    MessageBox.Show("An error occured. " + txtbxProductName.Text + " was not added to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                // Exemplar for UPDATE
                SQL = "UPDATE Products SET ProductName=@productname, Description=@description, Price=@price WHERE ProductID=@ID";
                sqlParameters.Clear();
                sqlParameters.Add(new OleDbParameter("@productname", txtbxProductName.Text));
                sqlParameters.Add(new OleDbParameter("@description", txtbxProductDescription.Text));
                sqlParameters.Add(new OleDbParameter("@price", Double.Parse(txtbxPrice.Text)));
                sqlParameters.Add(new OleDbParameter("@ID", ID)); //Integer cast?
                numAffectedRows = DataAccess.Update(SQL, sqlParameters);
                if (numAffectedRows < 1)
                {
                    MessageBox.Show("An error occured. " + txtbxProductName.Text + " was not edited in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
