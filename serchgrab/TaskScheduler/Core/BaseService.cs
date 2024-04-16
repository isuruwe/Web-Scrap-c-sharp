using System;
using System.Data.SqlClient;
using System.Data;

namespace TaskScheduler
{
    public class BaseService
    {

        public DataTable Select(string sqlQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection connection=new SqlConnection();
                connection = ConnectionManager.Open();
                SqlCommand oSqlCommand =new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter(oSqlCommand);
                adapter.Fill(dt);
                ConnectionManager.Close(connection);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        public int InsertAndReturn(string sql)
        {
            int rowAffected = 0;
            try
            {
                SqlConnection connection = new SqlConnection();
                connection = ConnectionManager.Open();
                SqlCommand oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sql;
                oSqlCommand.Connection = connection;
                object val = oSqlCommand.ExecuteScalar();
                if (val != null)
                    rowAffected = int.Parse(val.ToString());

                ConnectionManager.Close(connection);
            }
            catch (SqlException ex)
            {
                throw;
            }
            return rowAffected;
        }
        public int Insert(string sqlQuery)
        {
            int rowAffected = 0;
            try
            {
                SqlConnection connection = new SqlConnection();
                connection = ConnectionManager.Open();
                SqlCommand oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = connection;
                rowAffected = oSqlCommand.ExecuteNonQuery();
                ConnectionManager.Close(connection);
            }
            catch (Exception ex)
            {
                throw;
            }
            return rowAffected;
        }

        public bool Update(string sqlQuery)
        {
            bool status = false;
            try
            {
                SqlConnection connection = new SqlConnection();
                connection = ConnectionManager.Open();
                SqlCommand oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = connection;
                int rowAffected = oSqlCommand.ExecuteNonQuery();

                if (rowAffected > 0)
                    status = true;

                ConnectionManager.Close(connection);
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }

        public bool Delete(string sqlQuery)
        {
            bool status = false;
            try
            {
                SqlConnection connection = new SqlConnection();
                connection = ConnectionManager.Open();
                SqlCommand oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = connection;
                int rowAffected = oSqlCommand.ExecuteNonQuery();

                if (rowAffected > 0)
                    status = true;

                ConnectionManager.Close(connection);
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }


        public DateTime GetSriLankaTime()
        {
            return DateTime.Now;
        }

        //public bool Insert(string sql)
        //{
        //    bool status = false;
        //    try
        //    {
        //        SqlConnection connection = ConnectionManager.Open();
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        int rowAffected= command.ExecuteNonQuery();
        //        if (rowAffected > 0)
        //            status = true;
        //        ConnectionManager.Close(connection);
        //    }
        //    catch (Exception)
        //    {                
        //        throw;
        //    }
        //    return status;
        //}

        //public bool Insert(string sql, SqlConnection conn, SqlTransaction trans)
        //{
        //    bool status = false;
        //    try
        //    {
        //        SqlCommand command = new SqlCommand(sql, conn, trans);
        //        int rowAffected = command.ExecuteNonQuery();
        //        if (rowAffected > 0)
        //            status = true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return status;
        //}

        //public int InsertAndReturn(string sql, SqlConnection conn, SqlTransaction trans)
        //{
        //    int rowAffected = 0;
        //    try
        //    {               
        //        SqlCommand command = new SqlCommand(sql, conn,trans);
        //        object val = command.ExecuteScalar();
        //        if (val != null)
        //            rowAffected = int.Parse(val.ToString());
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return rowAffected;
        //}

        //public int InsertAndReturn(string sql)
        //{
        //    int rowAffected = 0;
        //    try
        //    {
        //        SqlConnection conn = ConnectionManager.Open();
        //        SqlCommand command = new SqlCommand(sql, conn);
        //        object val = command.ExecuteScalar();
        //        if (val != null)
        //            rowAffected = int.Parse(val.ToString());
        //        conn.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return rowAffected;
        //}

        //public int InsertAndReturn(SqlCommand cmd)
        //{

        //    int ReturnId = 0;
        //    try
        //    {
        //        SqlConnection conn = ConnectionManager.Open();
        //        cmd.Connection = conn;
        //        ReturnId = (int)cmd.ExecuteScalar();
        //        conn.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return ReturnId;
        //}

        //public bool Update(string sql, SqlConnection conn, SqlTransaction trans)
        //{
        //    bool status = false;
        //    try
        //    {
        //        SqlCommand command = new SqlCommand(sql, conn, trans);
        //        int rowAffected = command.ExecuteNonQuery();
        //        if (rowAffected > 0)
        //            status = true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return status;
        //}

        //public bool Update(string sql)
        //{
        //    bool status = false;
        //    try
        //    {
        //        SqlConnection connection = ConnectionManager.Open();
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        int rowAffected = command.ExecuteNonQuery();
        //        if (rowAffected > 0)
        //            status = true;
        //        ConnectionManager.Close(connection);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return status;
        //}

        //public bool Delete(string sql)
        //{
        //    bool status = false;
        //    try
        //    {
        //        SqlConnection connection = ConnectionManager.Open();
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        int rowAffected = command.ExecuteNonQuery();
        //        if (rowAffected > 0)
        //            status = true;
        //        ConnectionManager.Close(connection);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return status;
        //}


    }
}