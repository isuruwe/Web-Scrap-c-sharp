using System;
using System.Data.SqlClient;
using System.Data;

namespace TaskScheduler
{
    public static class ConnectionManager
    {
        //static string connectionString = "Data Source=100.42.52.204;Initial Catalog=netauction_pcom;Persist Security Info=True;User ID=netauction_user;Password=Password@1986";

        static string connectionString = "Data Source=WIN-7QFBSP6HCCB;Initial Catalog=AraiTask;Integrated Security=True;";
        static string connectionStringSakurai = "Data Source=WIN-7QFBSP6HCCB;Initial Catalog=SakuraiAuction;Integrated Security=True;";
        public static SqlConnection Open()
        {
            SqlConnection connection = new SqlConnection();
            try
            {                
                connection.ConnectionString = connectionString;
                connection.Open();
            }
            catch (Exception)
            {                
                throw;
            }
            return connection;
        }
        public static SqlConnection OpenSakurai()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = connectionStringSakurai;
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return connection;
        }
        public static void Close(SqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}