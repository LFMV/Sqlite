using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;

namespace SqliteDB.HelperClass
{
    public class dbConnectionSqlite
    {
        private SQLiteDataAdapter mySQLiteAdapter;
        private SQLiteConnection SQLiteconn;

        #region SQLite Connections

        public dbConnectionSqlite()
        {
            mySQLiteAdapter = new SQLiteDataAdapter();
            string SQliteconnection = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString.ToString();
            SQLiteconn = new SQLiteConnection(SQliteconnection);
        }

        private SQLiteConnection openSQLiteConnection()
        {
            if (SQLiteconn.State == ConnectionState.Closed || SQLiteconn.State == ConnectionState.Broken)
            {
                SQLiteconn.Open();
            }
            return SQLiteconn;
        }

        #endregion

        #region Methods

        public bool executeSQLiteSelectQuery(String _query, SQLiteParameter[] sqliteParameter)
        {
            SQLiteCommand mySQLiteCommand = new SQLiteCommand();
            bool respuesta = true;

            try
            {
                mySQLiteCommand.Connection = openSQLiteConnection();
                mySQLiteCommand.CommandText = _query;
                mySQLiteCommand.Parameters.AddRange(sqliteParameter); 

                if(mySQLiteCommand.ExecuteNonQuery() < 1)
                {
                    return false;
                }

            }
            catch (SQLiteException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
                SQLiteconn.Close();
                mySQLiteCommand.Dispose();
            }
            return respuesta;
        }

        public DataTable executeSPDT(string _query, SQLiteParameter[] sqliteParameter)
        {
            SQLiteCommand mySQLiteCommand = new SQLiteCommand();
            DataTable dt = new DataTable();
            DataTable dtResult = new DataTable();
            try
            {
                mySQLiteCommand.Connection = openSQLiteConnection();
                mySQLiteCommand.CommandText = _query;
                mySQLiteCommand.Parameters.AddRange(sqliteParameter);
                SQLiteDataReader dr = mySQLiteCommand.ExecuteReader();
                dt.Load(dr);
            }
            catch (SQLiteException e)
            {
                Console.Write("Error - Connection.executeSQLSP - SP: " + _query + " \nException: " + e.StackTrace.ToString());
            }
            finally
            {
                SQLiteconn.Close();
                mySQLiteCommand.Dispose();
            }
            return dt;
        }



        #endregion
    }
}
