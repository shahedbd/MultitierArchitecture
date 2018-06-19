/*
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;


namespace FXTF.CRM.Web.Admin.Controllers.ServiceController
{
    [Route("api/holiday")]
    public class HoliDayController : BaseController
    {
        private readonly IHoliDayBL holidayBL = null;

        public HoliDayController(ILogger _logger, IHoliDayBL _holiDayBl)
        {
            Logger = _logger;
            holidayBL = _holiDayBl; //new HolidayBL(Logger);
        }

        /// <summary>
        /// Get All Holiday List
        /// </summary>
        /// <returns>Holiday List</returns>
        // GET: api/Holiday
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var holidayList = holidayBL.GetAllHoliDay();

                if (holidayList == null)
                {
                    return NotFound();
                }

                return Ok(holidayList);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



        /// <summary>
        /// GetById Holiday
        /// </summary>
        /// <returns> Holiday list by id</returns>
        // GET: /api/Holiday/GetById
        [Route("GetById/{id:long}")]
        [HttpGet]
        public IHttpActionResult GetById(long id)
        {
            try
            {
                var result = holidayBL.GetHoliDayByID(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Insert Holiday
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns>HttpResponseMessage</returns>
        // POST: api/Holiday
        [HttpPost]
        [Route("InsertHoliDay")]
        public HttpResponseMessage InsertHoliDay(HoliDay holiday)
        {
            HttpResponseMessage response = null;
            try
            {
                dynamic data = holidayBL.InsertHoliDay(holiday);
                response = data != null ? Request.CreateResponse(HttpStatusCode.Created, "Holiday saved successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not created");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Update Holiday
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns>HttpResponseMessage</returns>
        [Route("UpdateHoliday")]
        [HttpPut]
        public HttpResponseMessage UpdateHoliday(HoliDay holiday)
        {
            HttpResponseMessage response = null;
            try
            {
                var result = holidayBL.UpdateHoliDay(holiday);
                response = result != null ? Request.CreateResponse(HttpStatusCode.Created, "Holiday updated successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not updated");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        /// <summary>
        /// Delete HoliDay
        /// </summary>
        /// <param name="id">long SL</param>
        /// <returns> Delete Holiday by id</returns>
        // GET: /api/Holiday/DeleteHoliday
        [Route("DeleteHoliday/{id:long}")]
        [HttpDelete]
        public HttpResponseMessage DeleteHoliday(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                var result = holidayBL.DeleteHoliday(id);
                response = result != null ? Request.CreateResponse(HttpStatusCode.Created, "Holiday deleted successfully") : Request.CreateResponse(HttpStatusCode.InternalServerError, "Not deleted");
            }
            catch (Exception ex)
            {

                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}



*/