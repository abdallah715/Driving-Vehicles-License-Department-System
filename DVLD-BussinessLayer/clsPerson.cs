using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update =1};
        public enMode Mode  = enMode.AddNew;


        private int userID;
        private string username;
        private string password;
        private bool isActive;

        public clsCountry CountryInfo;

        public int PersonID {  get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }   
        public string LastName { get; set; }   

        public string FullName()
        {
            return FirstName + " "+SecondName+ " "+ ThirdName+" "+LastName;
        }

        public string NationalNo {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor {  get; set; }  
        public string Address {  get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        private string _ImagePath;
        public string ImagePath 
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }


        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.phone = "";
            this.Email = "";
            this.NationalityCountryID = 0;
            this.ImagePath = "";
            Mode = enMode.AddNew;

        }
        private clsPerson( int personID, string firstName, string secondName, string thirdName,
            string lastName, string nationalNo, DateTime dateOfBirth, short gendor,
            string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            
            this.PersonID = personID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNo = nationalNo;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;
        }

        public clsPerson(int userID, int personID, string username, string password, bool isActive)
        {
            this.userID = userID;
            PersonID = personID;
            this.username = username;
            this.password = password;
            this.isActive = isActive;
        }

        private bool _AddNewPerson()
        {
            // call DataAccessLayer
            this.PersonID = clsPersonData.AddNewPerson(this.FirstName,this.SecondName,this.ThirdName,this.LastName,
               this.NationalNo , this.DateOfBirth,this.Gendor,this.Address,this.phone,this.Email,this.NationalityCountryID
               ,this.ImagePath);
            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            // call DataAccess Layer
            return clsPersonData.UpdatePerson(this.PersonID,this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.NationalNo, this.DateOfBirth, this.Gendor, this.Address, this.phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool IsFound = clsPersonData.GetPersonInfoByID
                                (
                                    PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            short Gendor = 0;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo
                                (
                                    NationalNo, ref PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)

                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
        public static bool isPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        public static bool isPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

    }
}
