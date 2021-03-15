using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NarayanHealth.Models
{
    public class AppointmentDetailsModel
    {
        public int Id { get; set; }
        public List<LocationDropdownModel> LocationDropdown { get; set; }
        public int Location_Id { get; set; }
        public string Location_Name { get; set; }

        public List<HospitalDropdownModel> HospitalDropdown { get; set; }
        public int Hospital_Id { get; set; }

        public string Hospital_Name { get; set; }
        

        public int PreferredTime_Id { get; set; }
        public string PreferredTime_Name { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }
        public string Date { get; set; }

        public string YourQuery { get; set; }
       
        
    }
}