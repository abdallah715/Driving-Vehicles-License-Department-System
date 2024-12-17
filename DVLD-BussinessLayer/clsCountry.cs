using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsCountry
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }
        private clsCountry(int ID, string CountryName)

        {
            this.CountryID = ID;
            this.CountryName = CountryName;
        }
        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
        public static string GetCountryName (int countryID)
        {
            return clsCountryData.GetCountryName(countryID);
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryInfoByID(ID, ref CountryName))

                return new clsCountry(ID, CountryName);
            else
                return null;
        }
    }
}
