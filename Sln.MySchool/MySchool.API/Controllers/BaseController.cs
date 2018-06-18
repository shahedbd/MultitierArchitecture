using Microsoft.AspNetCore.Mvc;
using MySchool.Shared.Log;

namespace FXTF.CRM.Web.Admin.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ILogger Logger { get; set; }
    }
}
