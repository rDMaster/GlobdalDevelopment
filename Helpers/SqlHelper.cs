using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Helpers
{
    public static class SqlHelper
    {
        public static string CreateDatabase(string name)
        {
            return "CREATE DATABASE \"" + name + "\";";
        }
        public static string CreateTable(string tableName, Dictionary<string, string> properties)
        {
            string sqlString = "CREATE TABLE \"" + tableName + "\"(";
            foreach(KeyValuePair<string,string> prop in properties)
            {
                sqlString += prop.Key + " " + prop.Value + ",";
            }
            sqlString = sqlString.Substring(0, sqlString.LastIndexOf(','));
            return sqlString + ");";
        }
        public static string CheckPermissions(string databaseName, string permissions)
        {
            return "SELECT HAS_PERMS_BY_NAME(db_name(), \"" + databaseName + "\", " + permissions + ");";
        }
        public static string DeleteDatabase(string name)
        {
            return "DROP DATABASE \"" + name + "\";";
        }
        public static string DeleteTable(string name)
        {
            return "DROP TABLE \"" + name + "\";";
        }
        public static string AddColumn(string tableName, KeyValuePair<string,string> column)
        {
            return "ALTER TABLE " + tableName + " ADD " + column.Key + " " + column.Value + ";";
        }
        public static string RemoveColumn(string tableName, string column)
        {
            return "ALTER TABLE " + tableName + " DROP COLUMN " + column + ";";
        }
        public static string AutoIncrement(string tableName, string columnName, int seed, int incrementBy)
        {
            return "ALTER TABLE " + tableName + " ALTER COLUMN " + columnName + " IDENTITY(" + seed + ", " + incrementBy + ");";
        }
        public static string PrimaryKey(string propertyName)
        {
            return "PRIMARY KEY (" + propertyName + ");";
        }
    }
}
