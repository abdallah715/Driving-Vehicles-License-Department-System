﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int TestID {  get; set; }
        public int TestAppointmentID {  get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()

        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsTest(int TestID, int TestAppointmentID,
            bool TestResult, string Notes, int CreatedByUserID)

        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }
        private bool _AddNewTest()
        {
            //call DataAccess Layer 

            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);


            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            //call DataAccess Layer 

            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetTestInfoByID(TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();

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

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;
        }

        public static clsTest GetLastTestPerPersonAndLicenseClass(int PersonID, int licenseClassID, int testTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1; 
            bool TestResult = false;string Notes = "";int CreatedByUserID = -1;
            if(clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID,licenseClassID,(int)testTypeID,
                                            ref TestID , ref TestAppointmentID , ref TestResult , ref Notes , ref CreatedByUserID))
                return new clsTest(TestID,TestAppointmentID,TestResult,Notes , CreatedByUserID);
            else { return null; }
        }
    }
}
