using NarayanHealth.Models;
using NarayanHealth.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NarayanHealth.Controllers
{
    public class EnquiryController : Controller
    {
        // GET: Enquiry
        public ActionResult Index()
        {
            EnquiryDetailsRepository oEnquiryDetailsRepository = new EnquiryDetailsRepository();

            EnquiryDetailsModel oEnquiryDetailsModel = new EnquiryDetailsModel();


            List<LocationDropdownModel> CityList1 = oEnquiryDetailsRepository.GetAllLocationName();
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (var c in CityList1)
            {
                CityList.Add(new SelectListItem { Text = c.Location_Name, Value = c.Location_Id.ToString() });
            }

            //ViewBag.country = CityList;
            ViewData["City"] = CityList;

            return View();
        }


        [HttpPost]
        public JsonResult GetHospital(int Location_Id)
        {
            EnquiryDetailsRepository oEnquiryDetailsRepository = new EnquiryDetailsRepository();

            EnquiryDetailsModel oEnquiryDetailsModel = new EnquiryDetailsModel();
            List<HospitalDropdownModel> oList =
            oEnquiryDetailsRepository.GetAllHospitalName(Location_Id);

            return Json(oList);
        }

        [HttpPost]
        public ActionResult Save(EnquiryDetailsModel oEnquiryDetailsModel)
        {


            //var record = oAppointmentDetailsRepository.AddAppointment(oAppointmentDetailsModel);
            //return RedirectToAction("Index");

            try
            {

                if (ModelState.IsValid)
                {
                    EnquiryDetailsRepository oEnquiryDetailsRepository = new EnquiryDetailsRepository();
                    if (oEnquiryDetailsModel.Id == 0)
                    {
                        if (oEnquiryDetailsRepository.AddEnquiry(oEnquiryDetailsModel))
                        {
                            ViewBag.Message = "Enquiry details added successfully";
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