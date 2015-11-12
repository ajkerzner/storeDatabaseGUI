using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreUI
{
    class DbManagement
    {
        string SQL = "";
        List<OleDbParameter> sqlParameters = new List<OleDbParameter>();
        int numAffectedRows = 0;

        public void AddProduct()
        {
            // Exemplar for READ (Note: Should use parameter instead of leteral value)
            SQL = "SELECT * FROM FamilyTable WHERE age >= 21 ORDER BY lastName, firstName";
            DataTable dt = DataAccess.Read(SQL, null);
        }
    }
}
