using MySchool.DBRepo.Repositories.Services;
using MySchool.Shared.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MySchool.DBRepo.Infrastructure
{
    public class DBOperations<T> : IDBOperation<T> where T : class
    {
        private static SqlConnection conn = MSSQLConn.MSSQLConnection();
        public Logger logger { get; set; }
        public DBOperations()
        {
            logger = new Logger();
        }

        //ExecuteNonQueryProc
        public virtual async Task<string> ExecuteStoredProc(SqlCommand cmd)
        {
            try
            {
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                await Task.FromResult(cmd.ExecuteNonQuery());
                return (string)cmd.Parameters["@Msg"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                //return ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public virtual async Task<int> ExecuteText(string strText)
        {
            try
            {
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(strText);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                return await Task.FromResult(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
                //return ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        //public Task<IEnumerable<T>> GetAllExecuteStoredProc(SqlCommand cmd)
         public async Task<IEnumerable<T>> GetAllExecuteStoredProc(SqlCommand cmd)
        {
            var list = new List<T>();
            try
            {
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                try
                {
                    //list = DynamicMappingList<TEntity>(reader);

                    while (reader.Read())
                    {
                        list.Add(PopulateRecord(reader, typeof(T).Name));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return await Task.FromResult(list);
        }

        public Task<IEnumerable<T>> GetAllExecuteText(string strText)
        {
            throw new NotImplementedException();
        }

        //public Task<T> GetByExecuteStoredProc(SqlCommand cmd)
        public virtual async Task<T> GetByExecuteStoredProc(SqlCommand cmd)
        {
            //var list = new List<TEntity>();
            T record = null;
            try
            {
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                try
                {
                    //record = DynamicMapping<TEntity>(reader);
                    while (reader.Read())
                    {
                        record = PopulateRecord(reader, typeof(T).Name);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return await Task.FromResult(record);
        }

        public Task<T> GetByIDExecuteText(string strText)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<string, int, bool, dynamic>> GetResultByExecuteStoredProc(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<dynamic> GetResultByExecuteText(string strText)
        {
            dynamic record = null;
            try
            {
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(strText);
                cmd.Connection = conn;
                var reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = (reader[0] == DBNull.Value) ? 0 : reader[0];
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                conn.Close();
            }
            return await Task.FromResult(record);
        }

        public virtual dynamic PopulateRecord(SqlDataReader sqldatareader, string TableName)
        {
            try
            {
                switch (TableName)
                {
                    case "PersonalInfo": return new PersonalInfoRepository(logger).Mapping(sqldatareader);
                    default: return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
