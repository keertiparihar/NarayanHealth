using NarayanHealth.Models;
using NarayanHealth.Repository;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace NarayanHealth.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            PatientDetailsRepository oPatientDetailsRepository = new PatientDetailsRepository();

            PatientDetailsModel oPatientDetailsModel = new PatientDetailsModel();
            //oPatientDetailsModel.LocationDropdown = 
            //oPatientDetailsRepository.GetAllLocationName();
            List<LocationDropdownModel> CityList1 = oPatientDetailsRepository.GetAllLocationName();
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (var c in CityList1)
            {
                CityList.Add(new SelectListItem { Text = c.Location_Name, Value = c.Location_Id.ToString() });
            }
            
            ViewData["City"] = CityList;


        

            return View();
        }
        [HttpPost]
        public JsonResult GetHospital(int Location_Id)
        {
            PatientDetailsRepository oPatientDetailsRepository = new PatientDetailsRepository();

            PatientDetailsModel oPatientDetailsModel = new PatientDetailsModel();
            List<HospitalDropdownModel> oList = 
            oPatientDetailsRepository.GetAllHospitalName(Location_Id);
            
            return Json(oList);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Appointment()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}