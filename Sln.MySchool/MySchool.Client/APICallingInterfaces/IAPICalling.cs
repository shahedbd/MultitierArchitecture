using MySchool.Model.DBModel;
using System.Collections.Generic;

namespace MySchool.Client.APICallingInterfaces
{
    public interface IAPICalling<T> where T : class
    {
        List<T> GetAll();
        T GetByID(long? id);
        bool Create(T entity);
        bool Edit(T entity);
        bool Delete(int id);
    }
}
