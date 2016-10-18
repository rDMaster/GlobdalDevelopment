using GlobalDevelopment.Databases.MicrosoftSqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Databases.Microsoft_SqlServer
{
    public class SqlDatabase
    {
        public string Name { get; set; }
        public short ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SqlException> Errors { get; set; }
        public List<SqlTable> Tables { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlDatabase(DataRow database, SqlConnection connection)
        {
            Connection = connection;
            Errors = new List<SqlException>();
            try
            {
                Name = database.Field<string>("database_name");
                ID = database.Field<short>("dbid");
                Tables = new List<SqlTable>();
                CreatedDate = database.Field<DateTime>("create_date");
                GetTables();
            }
            catch(SqlException se)
            {
                Errors.Add(se);
            }
        }
        private void GetTables()
        {
            try
            {
                string oldDbname = Connection.Database;
                Connection.ChangeDatabase(Name);
                DataTable tables = Connection.GetSchema("Tables");
                foreach (DataRow table in tables.Rows)
                {
                    SqlTable tb = new SqlTable(table, Connection, Name);
                    Tables.Add(tb);
                }
                Connection.ChangeDatabase(oldDbname);
            }
            catch(SqlException se)
            {
                Errors.Add(se);
            }
        }
        public string CreateDatabaseQuery(string databaseName)
        {
            return "CREATE DATABASE " + databaseName + ";";
        }
    }
}