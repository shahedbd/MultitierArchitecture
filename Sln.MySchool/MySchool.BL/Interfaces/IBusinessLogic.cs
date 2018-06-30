using MySchool.Model.DBModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.BL.Interfaces
{
    public interface IBusinessLogic<T> where T : class
    {
        Task<string> InsertBL(T entity);
        Task<string> UpdateBL(T entity);
        Task<string> DeleteBL(T entity);
        Task<IEnumerable<T>> GetAllBL();
        Task<T> GetByIDBL(long ID);
    }
}
