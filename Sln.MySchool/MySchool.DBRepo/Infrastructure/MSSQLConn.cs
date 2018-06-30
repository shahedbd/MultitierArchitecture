using MySchool.Shared.ResourceFiles;
using System;
using System.Data.SqlClient;

namespace MySchool.DBRepo.Infrastructure
{
    public static class MSSQLConn
    {
        public static SqlConnection MSSQLConnection()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ResCommon.MSSQLConnStringLocal.ToString());
                //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnDev"].ConnectionString);
                //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnSTG"].ConnectionString);
                //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlConnProd"].ConnectionString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conn;
        }
    }
}
