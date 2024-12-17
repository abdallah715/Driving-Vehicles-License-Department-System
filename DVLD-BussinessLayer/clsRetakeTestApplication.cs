using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsRetakeTestApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int RetakeTestApplicationID {  get; set; }
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public float Fees {  get; set; }

        public clsRetakeTestApplication()
        {
            this.RetakeTestApplicationID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.Fees = 0;
            Mode = enMode.AddNew;
        }
        private clsRetakeTestApplication( int retakeTestApplicationID, int localDrivingLicenseApplicationID, float fees)
        {
            Mode = enMode.Update;
            this.RetakeTestApplicationID = retakeTestApplicationID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.Fees = fees;
        }
        private bool _AddNewTest()
        {
            //call DataAccess Layer 

            this.RetakeTestApplicationID = clsRetakeTestApplicationData.AddNewRetakeTest(this.LocalDrivingLicenseApplicationID,this.Fees);


            return (this.RetakeTestApplicationID != -1);
        }
        public static clsRetakeTestApplication FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int retakeTestApplicationID = 0;
            float fees = 0;
            if(clsRetakeTestApplicationData.GetRetakeTestInfo(LocalDrivingLicenseApplicationID, ref retakeTestApplicationID, ref fees))
            {
                return new clsRetakeTestApplication(retakeTestApplicationID, LocalDrivingLicenseApplicationID, fees);
            }
            else { return null; }
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                

            }

            return false;
        }

        
    }
}
