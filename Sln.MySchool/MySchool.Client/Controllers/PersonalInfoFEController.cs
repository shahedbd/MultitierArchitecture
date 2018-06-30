using Microsoft.AspNetCore.Mvc;
using MySchool.Client.APICallingInterfaces;
using MySchool.Model.DBModel;
using System.Collections.Generic;

namespace MySchool.Client.Controllers
{
    public class PersonalInfoFEController : Controller
    {
        private readonly IAPICalling<PersonalInfo> aPICallingPersonalInfo = null;

        public PersonalInfoFEController(IAPICalling<PersonalInfo> _aPICallingPersonalInfo)
        {
            aPICallingPersonalInfo = _aPICallingPersonalInfo; //new PersonalInfoAPI();
        }
        public ActionResult Index()
        {
            List<PersonalInfo> listPersonalInfo = aPICallingPersonalInfo.GetAll();

            //listPersonalInfo.TrimExcess();
            //ViewBag.listHoliday = personalInfoAPI.GetAll();

            return View(listPersonalInfo);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(PersonalInfo personalInfo)
        {
            aPICallingPersonalInfo.Create(personalInfo);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(long? id)
        {
            PersonalInfo oPersonalInfo = new PersonalInfo();
            oPersonalInfo = aPICallingPersonalInfo.GetByID(id);
            return View("Edit", oPersonalInfo);
        }

        [HttpPost]
        public ActionResult Edit(PersonalInfo personalInfo)
        {
            aPICallingPersonalInfo.Edit(personalInfo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            PersonalInfo oPersonalInfo = new PersonalInfo();
            oPersonalInfo = aPICallingPersonalInfo.GetByID(id);
            return View("Delete", oPersonalInfo);
        }

        [HttpPost]
        public ActionResult Delete(PersonalInfo personalInfo)
        {
            aPICallingPersonalInfo.Delete(personalInfo);
            return RedirectToAction("Index");
        }

    }
}