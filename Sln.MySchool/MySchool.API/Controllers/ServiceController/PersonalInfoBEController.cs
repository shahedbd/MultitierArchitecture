using FXTF.CRM.Web.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using MySchool.API.Controllers.Interfaces;
using MySchool.BL.Interfaces;
using MySchool.Model.DBModel;
using MySchool.Shared.Log;
using System;
using System.Net.Http;

namespace MySchool.API.Controllers.ServiceController
{
    [Route("api/personalinfo")]
    public class PersonalInfoBEController : BaseController, IAPIDBOperations<PersonalInfo>
    {
        private readonly IBusinessLogic<PersonalInfo> personalInfoBL = null;

        public PersonalInfoBEController(ILogger _logger, IBusinessLogic<PersonalInfo> _personalInfoBL)
        {
            Logger = _logger;
            personalInfoBL = _personalInfoBL; //new PersonalInfoBL(Logger);
        }


        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            try
            {
                var personalInfoList = personalInfoBL.GetAllBL();

                if (personalInfoList == null)
                {
                    return NotFound();
                }

                return Ok(personalInfoList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [Route("GetById/{id:long}")]
        [HttpGet]
        public ActionResult GetById(long id)
        {
            try
            {
                var result = personalInfoBL.GetByIDBL(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("Insert")]
        public HttpResponseMessage Insert(PersonalInfo personalInfo)
        {
            HttpResponseMessage response = null;
            try
            {
                dynamic data = personalInfoBL.InsertBL(personalInfo);
                //response = data != null ? Request.CreateResponse(HttpStatusCode.Created, "PersonalInfo saved successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not created");
            }
            catch (Exception ex)
            {
                //response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);]
                throw ex;
            }
            return null;
        }



        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(PersonalInfo personalInfo)
        {
            HttpResponseMessage response = null;
            try
            {
                var result = personalInfoBL.UpdateBL(personalInfo);
                //response = result != null ? Request.CreateResponse(HttpStatusCode.Created, "PersonalInfo updated successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not updated");
            }
            catch (Exception ex)
            {
                //response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                throw ex;
            }
            return null;
        }



        [Route("Delete/{id:long}")]
        [HttpDelete]
        public HttpResponseMessage Delete(PersonalInfo personalInfo)
        {
            HttpResponseMessage response = null;
            try
            {
                var result = personalInfoBL.DeleteBL(personalInfo);
                //response = result != null ? Request.CreateResponse(HttpStatusCode.Created, "Holiday deleted successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not deleted");
            }
            catch (Exception ex)
            {

                //response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                throw ex;
            }
            return null;
        }
    }




}