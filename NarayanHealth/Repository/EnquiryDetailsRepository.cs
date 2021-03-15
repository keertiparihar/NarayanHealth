using NarayanHealth.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NarayanHealth.Repository
{
    public class EnquiryDetailsRepository
    {
        public List<LocationDropdownModel> GetAllLocationName()
        {
            List<LocationDropdownModel> cityList = new List<LocationDropdownModel>();
            LocationDropdownModel oTestModel = new LocationDropdownModel();
            //DataSet ds = new DataSet();
            string myConnection = "Data Source=DESKTOP-JVJFROS;Integrated Security=true;Database=NarayanaHospitalDB";

            SqlConnection con = new SqlConnection(myConnection);
            SqlCommand cmd = new SqlCommand("GetAllLocationName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            cityList = (from DataRow dr in dt.Rows
                        select new LocationDropdownModel()
                        {
                            Location_Id = Convert.ToInt32(dr["LocationId"]),
                            Location_Name = Convert.ToString(dr["LocationName"])
                        }).ToList();


            con.Close();
            return cityList;
        }


        public List<HospitalDropdownModel> GetAllHospitalName(int Location_Id)
        {
            List<HospitalDropdownModel> hospitalList = new List<HospitalDropdownModel>();
            HospitalDropdownModel oTestModel = new HospitalDropdownModel();
            //DataSet ds = new DataSet();
            string myConnection = "Data Source=DESKTOP-JVJFROS;Integrated Security=true;Database=NarayanaHospitalDB";

            SqlConnection con = new SqlConnection(myConnection);
            SqlCommand cmd = new SqlCommand("GetAllHospitalName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Location_Id", Location_Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            hospitalList = (from DataRow dr in dt.Rows
                            select new HospitalDropdownModel()
                            {
                                Hospital_Id = Convert.ToInt32(dr["HospitalId"]),

                                Hospital_Name = Convert.ToString(dr["HospitalName"])
                            }).ToList();


            con.Close();
            return hospitalList;
        }

        public bool AddEnquiry(EnquiryDetailsModel app)
        {
            string myConnection = "Data Source=DESKTOP-JVJFROS;Integrated Security=true;Database=NarayanaHospitalDB";

            SqlConnection con = new SqlConnection(myConnection);
            SqlCommand cmd = new SqlCommand("saveEnquiry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LocationId", app.Location_Id);
            cmd.Parameters.AddWithValue("@HospitalId", app.Hospital_Id);
            
            cmd.Parameters.AddWithValue("@Name", app.Name);
            cmd.Parameters.AddWithValue("@ContactNumber", app.ContactNumber);
          
            cmd.Parameters.AddWithValue("@YourQuery", app.YourQuery);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}