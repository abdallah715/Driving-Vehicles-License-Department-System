using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ApplicationTypeID { get; set; }
        public string ApplicationTitle { get; set; }
        public float ApplicationFees { get; set; }

        public clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTitle = "";
            this.ApplicationFees = 0;
            Mode = enMode.AddNew;
        }
        private clsApplicationType( int applicationTypeID, string applicationTitle, float applicationFees)
        {
           
            ApplicationTypeID = applicationTypeID;
            ApplicationTitle = applicationTitle;
            ApplicationFees = applicationFees;
            Mode = enMode.Update;   
        }

        static public DataTable GetAllApplicationTypes()
        {
            return ApplicationTypeData.GeTAllApplicationTypes();
        }
        public static clsApplicationType Find(int ID)
        {
            string Title = ""; float Fees = 0;

            if (ApplicationTypeData.GetApplicationTypeInfoByID((int)ID, ref Title, ref Fees))

                return new clsApplicationType(ID, Title, Fees);
            else
                return null;

        }
        private bool _UpdateApplicationType()
        {
            return ApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID,this.ApplicationTitle,this.ApplicationFees);
        }
        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = ApplicationTypeData.AddNewApplicationType(this.ApplicationTitle, this.ApplicationFees);


            return (this.ApplicationTypeID != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }
    }
}
