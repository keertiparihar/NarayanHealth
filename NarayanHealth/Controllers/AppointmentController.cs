using NarayanHealth.Models;
using NarayanHealth.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NarayanHealth.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            AppointmentDetailsRepository oAppointmentDetailsRepository = new AppointmentDetailsRepository();

            AppointmentDetailsModel oAppointmentDetailsModel = new AppointmentDetailsModel();
      
         
            List<LocationDropdownModel> CityList1 = oAppointmentDetailsRepository.GetAllLocationName();
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (var c in CityList1)
            {
                CityList.Add(new SelectListItem { Text = c.Location_Name, Value = c.Location_Id.ToString() });
            }

            //ViewBag.country = CityList;
            ViewData["City"] = CityList;

            List<PreferredTimeDropdownModel> TimeList1 = oAppointmentDetailsRepository.GetAllPreferredTimeName();
            List<SelectListItem> TimeList = new List<SelectListItem>();
            foreach (var c in TimeList1)
            {
                TimeList.Add(new SelectListItem { Text = c.PreferredTime_Name, Value = c.PreferredTime_Id.ToString() });
            }

            ViewData["Time"] = TimeList;


            return View();
        }


        [HttpPost]
        public JsonResult GetHospital(int Location_Id)
        {
            AppointmentDetailsRepository oAppointmentDetailsRepository = new AppointmentDetailsRepository();

            PatientDetailsModel oPatientDetailsModel = new PatientDetailsModel();
            List<HospitalDropdownModel> oList =
            oAppointmentDetailsRepository.GetAllHospitalName(Location_Id);

            return Json(oList);
        }

        [HttpPost]
        public ActionResult Save(AppointmentDetailsModel oAppointmentDetailsModel)
        {

            
            //var record = oAppointmentDetailsRepository.AddAppointment(oAppointmentDetailsModel);
            //return RedirectToAction("Index");

            try
            {

                if (ModelState.IsValid)
                {
                    AppointmentDetailsRepository oAppointmentDetailsRepository = new AppointmentDetailsRepository();
                    if (oAppointmentDetailsModel.Id == 0)
                    {
                        if (oAppointmentDetailsRepository.AddAppointment(oAppointmentDetailsModel))
                        {
                            ViewBag.Message = "Appointment details added successfully";
                        }
                    }
                    else
                    {

                    }
                }
                return RedirectToAction("Success");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Success()
        {
            return View();
        }
              
    }
    
}