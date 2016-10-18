using GlobalDevelopment.Databases.Microsoft_SqlServer;
using GlobalDevelopment.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GlobalDevelopment.Databases.MicrosoftSqlServer
{
    public class MicrosoftSqlServer
    {
        /// <summary>
        /// The databases available on the currrent SQL Server Instance.
        /// </summary>
        public List<SqlDatabase> Databases { get; set; }
        /// <summary>
        /// The connected server's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is current instance connected to a SQL Server
        /// </summary>
        public bool Connected { get; set; }
        /// <summary>
        /// Available server names.
        /// </summary>
        public List<string> ServerNames { get; set; }
        /// <summary>
        /// Names of databases in current server.
        /// </summary>
        public List<string> DatabaseNames { get; set; }
        /// <summary>
        /// The current connection. IF isn't connected, will return 'NULL'.
        /// </summary>
        public SqlConnection Connection { get; set; }
        /// <summary>
        /// List of errors which can be handled accordingly.
        /// </summary>
        public List<SqlException> Errors { get; set; }
        /// <summary>
        /// The current version of Microsoft SQL Server.
        /// </summary>
        public string SqlServerVersion { get; set; }
        /// <summary>
        /// Add SQL Server Database functionality easily into any application.
        /// </summary>
        public MicrosoftSqlServer()
        {
            Connected = false;
            ServerNames = new List<string>();
            Errors = new List<SqlException>();
            DatabaseNames = new List<string>();
        }
        /// <summary>
        /// Returns a list of available server names. If list is empty, there is no available server.
        /// </summary>
        /// <returns></returns>
        public List<string> AvailableServers()
        {
            List<string> ServerNames = new List<string>();
            SqlDataSourceEnumerator Enumerator = SqlDataSourceEnumerator.Instance;
            foreach(DataRow row in Enumerator.GetDataSources().Rows)
            {
                ServerNames.AddUniqueItem(row["ServerName"].ToString());
            }
            return ServerNames;
        }
        /// <summary>
        /// Connect to any available server.
        /// </summary>
        /// <param name="serverName">Name of server you want to connect to.</param>
        /// <param name="databaseName">Name of database on server you want to connect to.</param>
        public void Connect(string serverName, string databaseName, string username, string password)
        {
            if (Connected)
            {
                Disconnect();
            }
            Connection = new SqlConnection();
            Connection.ConnectionString = SqlServerHelper.StandardConnectionString(serverName, databaseName, username, password);
            try
            {
                Connection.Open();
                Connected = true;
                SqlServerVersion = Connection.ServerVersion;
            }
            catch (SqlException se)
            {
                Errors.Add(se);
            }
        }
        /// <summary>
        /// Disconnect from server if connected.
        /// </summary>
        public void Disconnect()
        {
            if (Connected)
            {
                try
                {
                    Connection.Close();
                    Connected = false;
                }
                catch (SqlException se)
                {
                    Errors.Add(se);
                }
            }
        }
        /// <summary>
        /// Get available databases.
        /// </summary>
        public void GetDatabases()
        {
            if(Connected)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM master.sys.databases", Connection))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while(dr.Read())
                            {
                                DatabaseNames.Add(dr[0].ToString());
                            }
                        }
                    }
                }
                catch(SqlException se)
                {
                    Errors.AddUniqueItem(se);
                }
            }
        }
        /// <summary>
        /// Check if database exists or is available.
        /// </summary>
        /// <param name="databaseName">Database name used.</param>
        /// <returns></returns>
        public bool DatabaseExist(string databaseName)
        {
            bool exist = false;
            if(Connected)
            {
                if (DatabaseNames.Count == 0)
                    GetDatabases();
                if (DatabaseNames.IndexOf(databaseName) != -1)
                    exist = true;
            }
            return exist;
        }
        public bool TableExist(string databaseName, string tableName)
        {
            bool exist = false;
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    List<string> tableNames = GetTables(databaseName);
                    if (tableNames.IndexOf(tableName) != -1)
                        exist = true;
                }
            }
            return exist;
        }
        public bool ColumnExist(string databaseName, string tableName, string columnName)
        {
            bool exists = false;
            List<string> columnNames = new List<string>();
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    if(TableExist(databaseName, tableName))
                    {
                        columnNames = GetColumns(databaseName, tableName);
                        if (columnNames.IndexOf(columnName) != -1)
                            exists = true;
                    }
                }
            }
            return exists;
        }
        public bool HasPermissions(string databaseName, string permissions)
        {
            bool allowed = false;
            if (Connected)
            {
                if (DatabaseExist(databaseName))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlHelper.CheckPermissions(databaseName, permissions), Connection))
                        {
                            cmd.ExecuteNonQuery();
                            allowed = true;
                        }
                    }
                    catch(SqlException se)
                    {
                        Errors.Add(se);
                    }
                }
            }
            return allowed;
        }
        public List<string> GetTables(string databaseName)
        {
            List<string> tableNames = new List<string>();
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    string oldDbname = Connection.Database;
                    Connection.ChangeDatabase(databaseName);
                    DataTable schema = Connection.GetSchema("Tables");
                    foreach(DataRow row in schema.Rows)
                    {
                        tableNames.Add(row[2].ToString());
                    }
                    Connection.ChangeDatabase(oldDbname);
                }
            }
            return tableNames;
        }
        public List<string> GetColumns(string databaseName, string tableName)
        {
            List<string> columnNames = new List<string>();
            if (Connected)
            {
                if (DatabaseExist(databaseName))
                {
                    if (TableExist(databaseName, tableName))
                    {
                        string oldDbname = Connection.Database;
                        Connection.ChangeDatabase(databaseName);
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM " + tableName, Connection))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                            {
                                DataTable stable = reader.GetSchemaTable();
                                foreach (DataRow row in stable.Rows)
                                {
                                    columnNames.AddUniqueItem(row["ColumnName"].ToString());
                                }
                            }
                        }
                        Connection.ChangeDatabase(oldDbname);
                    }
                }
            }
            return columnNames;
        }
        public void CreateDatabase(string databaseName)
        {
            if(Connected)
            {
                if (!DatabaseExist(databaseName))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlHelper.CreateDatabase(databaseName), Connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException se)
                    {
                        Errors.Add(se);
                    }
                }
            }
        }
        public void DeleteDatabase(string databaseName)
        {
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlHelper.DeleteDatabase(databaseName), Connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch(SqlException se)
                    {
                        Errors.Add(se);
                    }
                }
            }
        }
        public void CreateTable(string databaseName, string tableName, Dictionary<string,string> Properties)
        {
            if(Connected)
            {
                if (DatabaseExist(databaseName))
                {
                    if(!TableExist(databaseName, tableName))
                    {
                        try
                        {
                            string oldDbname = Connection.Database;
                            Connection.ChangeDatabase(databaseName);
                            using (SqlCommand cmd = new SqlCommand(SqlHelper.CreateTable(tableName, Properties), Connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            Connection.ChangeDatabase(oldDbname);
                        }
                        catch (SqlException se)
                        {
                            Errors.Add(se);
                        }
                    }
                }
            }
        }
        public void CreateTable(string databaseName, string tableName, string sqlQuery)
        {
            if (Connected)
            {
                if (DatabaseExist(databaseName))
                {
                    if (!TableExist(databaseName, tableName))
                    {
                        try
                        {
                            string oldDbname = Connection.Database;
                            Connection.ChangeDatabase(databaseName);
                            using (SqlCommand cmd = new SqlCommand(sqlQuery, Connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            Connection.ChangeDatabase(oldDbname);
                        }
                        catch (SqlException se)
                        {
                            Errors.Add(se);
                        }
                    }
                }
            }
        }
        public void DeleteTable(string databaseName, string tableName)
        {
            if (Connected)
            {
                if (DatabaseExist(databaseName))
                {
                    if(TableExist(databaseName, tableName))
                    {
                        try
                        {
                            string oldDbname = Connection.Database;
                            Connection.ChangeDatabase(databaseName);
                            using (SqlCommand cmd = new SqlCommand(SqlHelper.DeleteTable(tableName), Connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            Connection.ChangeDatabase(oldDbname);
                        }
                        catch (SqlException se)
                        {
                            Errors.Add(se);
                        }
                    }
                }
            }
        }
        public void AddColumn(string databaseName, string tableName, KeyValuePair<string,string> column)
        {
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    if(TableExist(databaseName, tableName))
                    {
                        if(!ColumnExist(databaseName, tableName, column.Key))
                        {
                            try
                            {
                                string oldDbname = Connection.Database;
                                Connection.ChangeDatabase(databaseName);
                                using (SqlCommand cmd = new SqlCommand(SqlHelper.AddColumn(tableName, column), Connection))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                Connection.ChangeDatabase(oldDbname);
                            }
                            catch (SqlException se)
                            {
                                Errors.Add(se);
                            }
                        }
                    }
                }
            }
        }
        public void AddColumn(string databaseName, string tableName, string columnName, string sqlQuery)
        {
            if (Connected)
            {
                if (DatabaseExist(databaseName))
                {
                    if (TableExist(databaseName, tableName))
                    {
                        if (!ColumnExist(databaseName, tableName, columnName))
                        {
                            try
                            {
                                string oldDbname = Connection.Database;
                                Connection.ChangeDatabase(databaseName);
                                using (SqlCommand cmd = new SqlCommand(sqlQuery, Connection))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                Connection.ChangeDatabase(oldDbname);
                            }
                            catch (SqlException se)
                            {
                                Errors.Add(se);
                            }
                        }
                    }
                }
            }
        }
        public void RemoveColumn(string databaseName, string tableName, string column)
        {
            if (Connected)
            {
                if (DatabaseExist(databaseName))
                {
                    if (TableExist(databaseName, tableName))
                    {
                        if (ColumnExist(databaseName, tableName, column))
                        {
                            try
                            {
                                string oldDbname = Connection.Database;
                                Connection.ChangeDatabase(databaseName);
                                using (SqlCommand cmd = new SqlCommand(SqlHelper.RemoveColumn(tableName, column), Connection))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                Connection.ChangeDatabase(oldDbname);
                            }
                            catch (SqlException se)
                            {
                                Errors.Add(se);
                            }
                        }
                    }
                }
            }
        }
        public void SetIncrement(string databaseName, string tableName, string columnName, int seed, int incrementBy)
        {
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    if(TableExist(databaseName, tableName))
                    {
                        string oldDbName = Connection.Database;
                        Connection.ChangeDatabase(databaseName);
                        using (SqlCommand cmd = new SqlCommand(SqlHelper.AutoIncrement(tableName, columnName, seed, incrementBy), Connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Connection.ChangeDatabase(oldDbName);
                    }
                }
            }
        }
        public void AddValues(string databaseName, string tableName, KeyValuePair<string,List<string>> queryString)
        {
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    if(TableExist(databaseName, tableName))
                    {
                        string oldDbName = Connection.Database;
                        Connection.ChangeDatabase(databaseName);
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = queryString.Key;
                            int a = 0;
                            foreach(string val in queryString.Value)
                            {
                                cmd.Parameters.AddWithValue("@val" + a, val);
                                a++;
                            }
                            cmd.Connection = Connection;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch(SqlException se)
                            {
                                Errors.Add(se);
                            }
                        }
                        Connection.ChangeDatabase(oldDbName);
                    }
                }
            }
        }
        public void DeleteValue(string databaseName, string tableName, string columnName, string value)
        {
            if(Connected)
            {
                if(DatabaseExist(databaseName))
                {
                    if(TableExist(databaseName, tableName))
                    {
                        if (ColumnExist(databaseName, tableName, columnName))
                        {
                            string olddbName = Connection.Database;
                            Connection.ChangeDatabase(databaseName);
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM " + tableName + " WHERE " + columnName + " = '" + value + "'", Connection))
                            {
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch(SqlException se)
                                {
                                    Errors.Add(se);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}