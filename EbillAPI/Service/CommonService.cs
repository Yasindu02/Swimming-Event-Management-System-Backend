using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EbillAPI.Service
{
    public class CommonService
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString;

        public static bool ExecuteStoredProcedure(string storedProcedure, object[] parameter)
        {
            int result;
            SqlConnection sqlConn = new SqlConnection(connectionString);

            try
            {
                if (sqlConn.State != ConnectionState.Open)
                {
                    sqlConn.Close();
                    sqlConn.Open();
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConn;

                foreach (SqlParameter param in parameter)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.CommandTimeout = 90;
                result = cmd.ExecuteNonQuery();

                return true;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet ExecuteStoredProcedureForDS(string storedProcedure, object[] parameter)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            try
            {
                

                if (sqlConn.State != ConnectionState.Open)
                {
                    sqlConn.Close();
                    sqlConn.Open();
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConn;

                foreach (SqlParameter param in parameter)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.CommandTimeout = 120;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
            return ds;
        }
    }
}