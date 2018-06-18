using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MySchool.DBRepo.Repositories.Interfaces
{
    interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetBy(long ID);
        Task<string> Insert(T Entity);
        Task<string> Update(T Entity);
        Task<string> Delete(long ID);       
        T Mapping(SqlDataReader sqlDataReader);
    }
}
