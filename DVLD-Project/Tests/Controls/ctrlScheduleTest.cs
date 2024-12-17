using DVLD_BussinessLayer;
using DVLD_Project.Global_Class;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int _LocalDrivingLicenseApplicationID = 0;
        private int _TestAppointmentID = 0;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestAppointment _TestAppointment;

        public clsTestType.enTestType _TestTypeID;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;
        private clsRetakeTestApplication _RetakeTest;

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_Test_32;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_32_Sechdule;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }
        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
        private void _LoadTheScreen()
        {
            switch (_TestTypeID)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = Properties.Resources.Vision_Test_32;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = Properties.Resources.Written_Test_32_Sechdule;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;


                    }
            }
        }
        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

            dtpTestDate.Value = _TestAppointment.AppointmentDate;
            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
                gbRetakeTestInfo.Enabled = false;
            }
            else
            {
                lblRetakeAppFees.Text = _RetakeTest.Fees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _RetakeTest.RetakeTestApplicationID.ToString();
            }
            lblUserMessage.Visible = false;
            return true;

        }
        private bool _HandleAppointmentLocked()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lblUserMessage.Visible = false;

            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    lblUserMessage.Visible = false;

                    return true;

                case clsTestType.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

                case clsTestType.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        public void LoadScheduleTestBy(int LocalDrivingLicenseApplicationID , int AppointmentID = -1)
        {
            _LoadTheScreen();
            if(AppointmentID == -1) 
                _Mode = enMode.AddNew;
            else 
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            if(_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
              

            }
            else _CreationMode = enCreationMode.FirstTimeSchedule;


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.Retaketest).ApplicationFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                //lblRetakeTestAppID.Text = "0";
                
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName.ToString();
            //lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblFullName.Text = clsPerson.Find(_LocalDrivingLicenseApplication.ApplicantPersonID).FullName();

            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            _RetakeTest = clsRetakeTestApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
            if( _RetakeTest != null ) 
           lblRetakeTestAppID.Text = _RetakeTest.RetakeTestApplicationID.ToString();
            else _RetakeTest = new clsRetakeTestApplication();
            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(_TestTypeID).Fees.ToString();

                dtpTestDate.MinDate = DateTime.Now;
                lblTotalFees.Text = "0";
                _TestAppointment = new clsTestAppointment();

            }
            else
            {
                if (!_LoadTestAppointmentData()) return;
                

            }
            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();
            // Handle if the The Test is Already Taken 
            if (!_HandleAppointmentLocked())
                return;
            if (!_HandlePrviousTestConstraint())
                return;

        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            
            if(_CreationMode == enCreationMode.RetakeTestSchedule && clsRetakeTestApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID) == null)
            {
                _RetakeTest.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
                _RetakeTest.Fees = clsApplicationType.Find((int)clsApplication.enApplicationType.Retaketest).ApplicationFees;
                _RetakeTest.Save();
            }    


            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
