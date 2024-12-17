﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsApplication
    {
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrvingLicense = 5, NewInternaltionalLicense = 6, Retaketest = 8
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enApplicationStatus ApplicationStatus { get; set; }
        public enApplicationType ApplicationType { get; set; }
        public int ApplicationID {  get; set; }
        public int ApplicantPersonID {  get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime ApplicationDate {  get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;
        public byte AppStatus {  get; set; }
        public string ApplicantFullName
        {
            get { return clsPerson.Find(ApplicantPersonID).FullName(); }
        }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID {  get; set; }
        public clsUser CreatedbyuserInfo;
       

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationStatus = enApplicationStatus.New;
            this.ApplicationTypeID = -1;
            this.AppStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsApplication(int ApplicationID,int applicantPersonID, DateTime appDate, int appTypeID, byte appStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
           this.ApplicationID=ApplicationID;
            ApplicantPersonID = applicantPersonID;
            this.PersonInfo = clsPerson.Find(applicantPersonID);
            ApplicationDate = appDate;
            ApplicationTypeID = appTypeID;
            AppStatus = appStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
            ApplicationStatus = (enApplicationStatus)appStatus;
            ApplicationType = (enApplicationType)appTypeID;
            this.CreatedbyuserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.ApplicationTypeInfo = clsApplicationType.Find(appTypeID);

        }
        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicaitonData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                (byte)this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now; int ApplicationTypeID = -1;
            byte ApplicationStatus = 1; DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0; int CreatedByUserID = -1;

            bool IsFound = clsApplicaitonData.GetApplicationInfoByID
                                (
                                    ApplicationID, ref ApplicantPersonID,
                                    ref ApplicationDate, ref ApplicationTypeID,
                                    ref ApplicationStatus, ref LastStatusDate,
                                    ref PaidFees, ref CreatedByUserID
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsApplication(ApplicationID, ApplicantPersonID,
                                     ApplicationDate, ApplicationTypeID,
                                    ApplicationStatus, LastStatusDate,
                                     PaidFees, CreatedByUserID);
            else
                return null;
        }

        public static clsApplication Find(int ApplicationID)
        {


            int ApplicationPersonID = -1 ,ApplicationTypeID = -1 , CreatedByUserID = -1;
            DateTime ApplicationDate= DateTime.Now, LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            byte ApplicaitonStatus = 0;

            bool IsFound = clsApplicaitonData.GetApplicationInfoByID
                                (
                                    ApplicationID, ref ApplicationPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicaitonStatus,
                                    ref LastStatusDate , ref PaidFees , ref CreatedByUserID
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsApplication(ApplicationID,ApplicationPersonID,ApplicationDate,ApplicationTypeID,ApplicaitonStatus,LastStatusDate,PaidFees,CreatedByUserID);
            else
                return null;
        }

        private bool _UpdateApplication()
        {
            return true;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicaitonData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public  bool  SetComplete()
        {
            return clsApplicaitonData.UpdateStatus(ApplicationID, 3);
        }
        public static bool CancelApplication(int ApplicationID)
        {
            return clsApplicaitonData.UpdateStatus(ApplicationID,(short)enApplicationStatus.Cancelled);
        }
        public bool Cancel()
        {
            return CancelApplication(this.ApplicationID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicaitonData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        private static bool UpdateStatus(int ApplicationID, short ApplicationStatue)
        {
            return clsApplicaitonData.UpdateStatus(ApplicationID,ApplicationStatue);
        }
        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }
        public bool Delete()
        {
            return clsApplicaitonData.DeleteApplication(this.ApplicationID);
        }
    }
}
