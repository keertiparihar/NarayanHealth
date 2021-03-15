using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NarayanHealth.Models
{
    public class PatientDetailsModel
    {

        public List<LocationDropdownModel> LocationDropdown { get; set; }
        public int Location_Id { get; set; }
        public string Location_Name { get; set; }

        public List<HospitalDropdownModel> HospitalDropdown { get; set; }
        public int Hospital_Id { get; set; }
       
        public string Hospital_Name { get; set; }

    }
}