using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace STOCKNDRIVE
{
    class DBConnection
    {
        // This is the connection string. It tells your program how to find the database.
        // You MUST change this to match your SQL Server setup.
        private static readonly string connectionString = @"Server=ArienPeredoPC;Database=stockndrive;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            // This method creates a new connection object using the string above.
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}

