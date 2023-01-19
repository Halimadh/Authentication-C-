using WebApp.Models.DAL;
using System;
using System.Data.SqlClient;

namespace WebApp.Models.Utilities
{
    public class DBConnection
    {
        static string connectionString = "Data Source=DESKTOP-ATV0UHT\\SQLEXPRESS;Initial Catalog = DB_article; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "Database Connection Error", ex.Message, "Connection");
            }
            return cn;
        }
    }
}
