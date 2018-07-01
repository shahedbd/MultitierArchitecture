using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MySchool.API.Controllers.Interfaces
{
    public interface IApiDBOperations<T> where T : class
    {
        ActionResult GetAll();
        ActionResult GetById(long ID);
        HttpResponseMessage Insert(T entity);
        HttpResponseMessage Update(T entity);
        HttpResponseMessage Delete(T entity);
    }
}
