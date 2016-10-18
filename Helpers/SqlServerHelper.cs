using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Helpers
{
    public static class SqlServerHelper
    {
        // For information about the different type of connection strings visit https://www.connectionstrings.com/sql-server-2012/
        public static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch(SqlException)
                {
                    return false;
                }
            }
        }
        public static string StandardConnectionString(string serverName, string databaseName, string username, string password)
        {
            return "Server=" + serverName + "; Database=" + databaseName + "; User Id=" + username + "; Password=" + password + "; ";
        }
        public static string TrustedConnectionString(string serverName, string databaseName)
        {
            return "Server=" + serverName + "; Database=" + databaseName + "; Trusted_Connection=True;";
        }
        public static string SqlInstanceConnectionString(string serverName, string databaseName, string username, string password)
        {
            return "Server=" + serverName + "; Database" + databaseName + "; User Id=" + username + "; Password=" + password + ";";
        }
        public static string TrustedDeviceConnectionString(string serverName, string databaseName, string username, string password)
        {
            return "Data Source=" + serverName + "; Initial Catalog=" + databaseName + "; Integrated Secuirty=SSPI; User ID=" + username + "; Password=" + password + ";";
        }
        public static string IPConnectionString(string ip, string networkLibrary, string databaseName, string username, string pasword)
        {
            return "Data Source=" + ip + "; Network Library=" + networkLibrary + "; Initial Catalog=" + databaseName + "; User ID=" + username + "; Password=" + pasword + ";";
        }
        public static string MARSConnectionString(string serverName, string databaseName)
        {
            return "Server=" + serverName + "; Database=" + databaseName + "; Trusted_Connection=True; MultipleActiveResultSets=True";
        }
    }
}
