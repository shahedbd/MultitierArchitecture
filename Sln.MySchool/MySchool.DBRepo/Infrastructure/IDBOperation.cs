using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DBRepo.Infrastructure
{
    public interface IDBOperation<T> where T : class
    {
        //Execute Stored Procedure
        Task<string> ExecuteStoredProc(SqlCommand cmd);
        Task<T> GetByExecuteStoredProc(SqlCommand cmd);
        Task<IEnumerable<T>> GetAllExecuteStoredProc(SqlCommand cmd);
        Task<Tuple<string, int, bool, dynamic>> GetResultByExecuteStoredProc(SqlCommand cmd);


        //Execute Inline Query
        Task<IEnumerable<T>> GetAllExecuteText(string strText);
        Task<T> GetByIDExecuteText(string strText);
        Task<int> ExecuteText(string strText);
        Task<dynamic> GetResultByExecuteText(string strText);
    }
}
