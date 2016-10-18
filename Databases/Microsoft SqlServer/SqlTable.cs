using GlobalDevelopment.Databases.Microsoft_SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Databases.MicrosoftSqlServer
{
    public class SqlTable
    {
        public string Name { get; set; }
        public SqlConnection Connection { get; set; }
        public List<SqlException> Errors { get; set; }
        public int PropertyCount { get; set; }
        public string DatabaseName { get; set; }
        public List<string> Properties { get; set; }
        public SqlTable(string name, int propertyCount, string databaseName)
        {
            Name = name;
            PropertyCount = propertyCount;
            DatabaseName = databaseName;
            Properties = new List<string>();
        }
        public SqlTable(DataRow table, SqlConnection connection, string databaseName)
        {
            Connection = connection;
            Name = table.ItemArray[2].ToString();
            Errors = new List<SqlException>();
            DatabaseName = databaseName;
        }
        public void AddProperty(string property, string dataType, bool primaryKey, bool Null, bool Increment)
        {
            string prop = property + " " + dataType;
            if (Increment)
                prop += " IDENTITY";
            if (!Null)
                prop += " NOT NULL";
            if (primaryKey)
                prop += " PRIMARY KEY";
            Properties.AddUniqueItem(prop);
        }
        public string AddColumnQuery(string columnName, string dataType, bool primaryKey, bool Null, bool Increment)
        {
            string prop = "ALTER TABLE " + Name + " ADD " + columnName + " " + dataType;
            if (Increment)
                prop += " IDENTITY";
            if (!Null)
                prop += " NOT NULL";
            if (primaryKey)
                prop += " PRIMARY KEY";
            prop = prop + ";";
            return prop;
        }
        public string CreateTableQuery()
        {
            string query = "CREATE TABLE \"" + Name + "\"(";
            foreach(string prop in Properties)
            {
                query += " " + prop + ",";
            }
            return query = query.Substring(0, query.LastIndexOf(',')) + ");";
        }
        public KeyValuePair<string, List<string>> AddValueQuery(int[] propertyIndexes, string[] values)
        {
            List<string> vals = new List<string>();
            string query = "INSERT INTO " + Name + "(";
            foreach(int index in propertyIndexes)
            {
                query += Properties[index].Substring(0, Properties[index].IndexOf(' ')) + ",";
            }
            query = query.Substring(0, query.LastIndexOf(',')) + ") VALUES (";
            int c = 0;
            foreach (string val in values)
            {
                query += "@val" + c + ",";
                c++;
                vals.Add(val);
            }
            query = query.Substring(0, query.LastIndexOf(',')) + ");";
            KeyValuePair<string, List<string>> valQuery = new KeyValuePair<string, List<string>>(query, vals);
            return valQuery;
        }
    }
}