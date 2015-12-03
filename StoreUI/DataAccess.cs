using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreUI
{
    public static class DataAccess
    {
        // Change the connection string's Data Source to use the path to the correct database file
        // If the database file is in the folder containing the EXE then a path is not necessary
        private const string CONNECTION_STRING = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=JennsDatabase.accdb";
        private const CommandType COMMAND_TYPE_TEXT = CommandType.Text;

        // Executes a SQL SELECT statement against the connection and returns ONE DataTable of results.
        public static DataTable Read(String commandText, List<OleDbParameter> parameters)
        {
            try
            {
                if (!commandText.ToUpper().StartsWith("SELECT")) return new DataTable(); // correct data type but no content

                using (OleDbConnection cnxn = new OleDbConnection(CONNECTION_STRING))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    using (OleDbCommand cmd = cnxn.CreateCommand())
                    {

                        cmd.CommandType = COMMAND_TYPE_TEXT;
                        cmd.CommandText = commandText;
                        if (parameters != null)
                            foreach (OleDbParameter p in parameters)
                                cmd.Parameters.Add(p);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();

                        cnxn.Open();
                        da.Fill(ds);
                        cnxn.Close();
                        if (ds.Tables.Count >= 1)
                            return ds.Tables[0]; // use only first table, ignore others (should never be others)
                        else
                            return new DataTable(); // correct data type but no content
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception thrown in DataAccess Read: " + e.Message);
                return null;
            }
        }

        // Executes a SQL SELECT statement against the connection and returns ONE DataTable of results.
        public static OleDbDataReader ReadStoredQuery(String commandText, List<OleDbParameter> parameters)
        {
            try
            {
                OleDbConnection cnxn = new OleDbConnection(CONNECTION_STRING);

                using (OleDbCommand cmd = new OleDbCommand(commandText, cnxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        foreach (OleDbParameter p in parameters)
                            cmd.Parameters.Add(p);

                    cnxn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    return reader;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception thrown in DataAccess ExecuteReader: " + e.Message);
                return null;
            }
        }

        // Executes a SQL INSERT statement against the connection and return the number of affected rows.
        public static Int32 Create(String commandText, List<OleDbParameter> parameters)
        {
            if (commandText.ToUpper().StartsWith("INSERT")) return ExecuteNonQuery(commandText, parameters);
            else return 0;
        }

        // Executes a SQL UPDATE statement against the connection and return the number of affected rows.
        public static Int32 Update(String commandText, List<OleDbParameter> parameters)
        {
            if (commandText.ToUpper().StartsWith("UPDATE")) return ExecuteNonQuery(commandText, parameters);
            else return 0;
        }

        // Executes a SQL DELETE statement against the connection and return the number of affected rows.
        public static Int32 Delete(String commandText, List<OleDbParameter> parameters)
        {
            if (commandText.ToUpper().StartsWith("DELETE")) return ExecuteNonQuery(commandText, parameters);
            else return 0;
        }

        // Executes a SQL statement against the connection and returns the number of rows affected.
        public static Int32 ExecuteNonQuery(String commandText, List<OleDbParameter> parameters)
        {
            try
            {
                using (OleDbConnection cnxn = new OleDbConnection(CONNECTION_STRING))
                {
                    using (OleDbCommand cmd = new OleDbCommand(commandText, cnxn))
                    {
                        cmd.CommandType = COMMAND_TYPE_TEXT;
                        if (parameters != null)
                            foreach (OleDbParameter p in parameters)
                                cmd.Parameters.Add(p);

                        cnxn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        cnxn.Close();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception thrown in DataAccess ExecuteNonQuery: " + e.Message);
                return 0;
            }          
        }

        // Executes the query, and returns the first column of the first row in the result set returned by the query. Returns a maximum of 2033 characters.
        public static Object ExecuteScalar(String commandText, List<OleDbParameter> parameters)
        {
            try
            {
                using (OleDbConnection cnxn = new OleDbConnection(CONNECTION_STRING))
                {
                    using (OleDbCommand cmd = new OleDbCommand(commandText, cnxn))
                    {
                        cmd.CommandType = COMMAND_TYPE_TEXT;
                        if (parameters != null)
                            foreach (OleDbParameter p in parameters)
                                cmd.Parameters.Add(p);

                        cnxn.Open();
                        Object obj = cmd.ExecuteScalar();
                        cnxn.Close();
                        return obj;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception thrown in DataAccess ExecuteScalar: " + e.Message);
                return null;
            }
        }

        // Set the connection, command, and then execute the command with query and return the reader.
        public static OleDbDataReader ExecuteReader(String commandText, List<OleDbParameter> parameters)
        {
            try
            {
                OleDbConnection cnxn = new OleDbConnection(CONNECTION_STRING);

                using (OleDbCommand cmd = new OleDbCommand(commandText, cnxn))
                {
                    cmd.CommandType = COMMAND_TYPE_TEXT;
                    if (parameters != null)
                        foreach (OleDbParameter p in parameters)
                            cmd.Parameters.Add(p);

                    cnxn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    return reader;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception thrown in DataAccess ExecuteReader: " + e.Message);
                return null;
            }
        }
	}
}
