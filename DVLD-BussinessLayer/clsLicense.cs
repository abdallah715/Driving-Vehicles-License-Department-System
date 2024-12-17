using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using static DVLD_BussinessLayer.clsLicense;

namespace DVLD_BussinessLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReasons { FirstTime = 1 , Renew = 2 , ReplacementForDamaged = 3 ,ReplacementForLost = 4 }

        public enIssueReasons IssueReason { get; set; }
        public  int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Notes {  get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public int CreatedByUserID { get; set; }
        public clsDriver DriverInfo;
        public clsLicenseClass LicenseClassInfo;
        public clsLicense()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReasons.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }
        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
           DateTime IssueDate, DateTime ExpirationDate, string Notes,
           float PaidFees, bool IsActive, enIssueReasons IssueReason, int CreatedByUserID)

        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClass);

            Mode = enMode.Update;
        }

        public static string GetIssueReasonText(enIssueReasons IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReasons.FirstTime:
                    return "First Time";
                case enIssueReasons.Renew:
                    return "Renew";
                case enIssueReasons.ReplacementForDamaged:
                    return "Replacement for Damaged";
                case enIssueReasons.ReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.IsActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        internal static int GetActiveLicenseIDByPersonID(int applicantPersonID, int licenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(applicantPersonID, licenseClassID);
        }
        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);


            return (this.LicenseID != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }
        public bool IsLcenseExpired()
        {
            return (this.ExpirationDate >DateTime.Now);
        }
        private bool _UpdateLicense()
        {
            return true;        }

        public static clsLicense FindLicenseByLicenseID(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;
            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReasons)IssueReason, CreatedByUserID);
            else
                return null;
        }

        internal static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        internal static DataTable GetDriverInternationalLicenses(int driverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(driverID);
        }


        public clsLicense RenewLicense(string Notes, int  CreatedByUserID)
        {
            // Create new Application With Type Renew 

            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.AppStatus = (byte)clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;
            if(!Application.Save())
            {
                return null;
            }
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID; 
            NewLicense.LicenseClass= this.LicenseClass;

            NewLicense.IssueDate = DateTime.Now;
            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReasons.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if(NewLicense.Save()) {

                DeActivateCurrentLicense();
                return NewLicense;
            }
            return null;
        }

        private bool DeActivateCurrentLicense()
        {
            return (clsLicenseData.DeactivateLicense(this.LicenseID));
        }

        public clsLicense ReplaceForDamagedOrLost(clsApplication.enApplicationType ApplicationType, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)ApplicationType;
            Application.AppStatus = (byte)clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)ApplicationType).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;
            if (!Application.Save())
            {
                return null;
            }
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;


            NewLicense.IssueDate = this.IssueDate;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = this.PaidFees;
            NewLicense.IsActive = true;
            if (ApplicationType == clsApplication.enApplicationType.ReplaceDamagedDrivingLicense)
                NewLicense.IssueReason = enIssueReasons.ReplacementForDamaged;
            else NewLicense.IssueReason = enIssueReasons.ReplacementForLost;

            NewLicense.CreatedByUserID = CreatedByUserID;

            if (NewLicense.Save())
            {

                DeActivateCurrentLicense();
                return NewLicense;
            }
            return null;

        }

        public int Detain(float PaidFines, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle(PaidFines);
            detainedLicense.CreatedByUserID = CreatedByUserID;
            detainedLicense.IsReleased = false;

            if (!detainedLicense.Save())
            {
                return -1;
            }
            return detainedLicense.DetainID;

        }
    }
}
