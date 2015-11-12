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

        public PopupProduct(string AddEdit)
        {
            InitializeComponent();

            if(AddEdit == "Add")
            {
                this.Text = "Add Product";
                btnAdd.Text = "Add";
            }
            else if(AddEdit == "Edit")
            {
                this.Text = "Edit Product";
                btnAdd.Text = "Edit";
            }
        }

        //Button can be either Add or Edit and execute either SQL function?
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Exemplar for CREATE
            SQL = "INSERT INTO FamilyTable (firstName, lastName, hometown, relationship, age) " +
                  "VALUES (@firstName, @lastName, @hometown, @relationship, @age)";
            sqlParameters.Clear();
            sqlParameters.Add(new OleDbParameter("@firstName", "Jenn"));
            sqlParameters.Add(new OleDbParameter("@lastName", "Neal"));
            sqlParameters.Add(new OleDbParameter("@hometown", "Great Mills"));
            sqlParameters.Add(new OleDbParameter("@relationship", "Tyrant"));
            sqlParameters.Add(new OleDbParameter("@age", 21));
            numAffectedRows = DataAccess.Create(SQL, sqlParameters);

            // Exemplar for UPDATE
            SQL = "UPDATE FamilyTable SET hometown=@hometown, relationship=@relationship WHERE lastName=@lastName";
            sqlParameters.Clear();
            sqlParameters.Add(new OleDbParameter("@hometown", "NONE"));
            sqlParameters.Add(new OleDbParameter("@relationship", "Hobo"));
            sqlParameters.Add(new OleDbParameter("@lastName", "Neal"));
            numAffectedRows = DataAccess.Update(SQL, sqlParameters);

            //if btnAdd text == add
                //add the record
            //else if it == edit
                //edit the record
        }
    }
}
