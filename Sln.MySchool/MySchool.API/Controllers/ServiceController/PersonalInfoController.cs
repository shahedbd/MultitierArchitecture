using FXTF.CRM.Web.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using MySchool.BL.Interfaces;
using MySchool.Model.DBModel;
using MySchool.Shared.Log;
using System;
using System.Net.Http;

namespace MySchool.API.Controllers.ServiceController
{
    [Route("api/personalinfo")]
    public class PersonalInfoController : BaseController
    {
        private readonly IPersonalInfoBL personalInfoBL = null;

        public PersonalInfoController(ILogger _logger, IPersonalInfoBL _personalInfoBL)
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
                var personalInfoList = personalInfoBL.GetAllPersonalInfo();

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
                var result = personalInfoBL.GetPersonalInfoByPersonalInfoID(id);
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
        [Route("InsertPersonalInfo")]
        public HttpResponseMessage InsertPersonalInfo(PersonalInfo personalInfo)
        {
            HttpResponseMessage response = null;
            try
            {
                dynamic data = personalInfoBL.InsertPersonalInfo(personalInfo);
                //response = data != null ? Request.CreateResponse(HttpStatusCode.Created, "PersonalInfo saved successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not created");
            }
            catch (Exception ex)
            {
                //response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);]
                throw ex;
            }
            return null;
        }



        [Route("UpdatePersonalInfo")]
        [HttpPut]
        public HttpResponseMessage UpdatePersonalInfo(PersonalInfo personalInfo)
        {
            HttpResponseMessage response = null;
            try
            {
                var result = personalInfoBL.UpdatePersonalInfo(personalInfo);
                //response = result != null ? Request.CreateResponse(HttpStatusCode.Created, "PersonalInfo updated successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not updated");
            }
            catch (Exception ex)
            {
                //response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                throw ex;
            }
            return null;
        }



        [Route("DeletePersonalInfo/{id:long}")]
        [HttpDelete]
        public HttpResponseMessage DeletePersonalInfo(PersonalInfo personalInfo)
        {
            HttpResponseMessage response = null;
            try
            {
                var result = personalInfoBL.DeletePersonalInfo(personalInfo);
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