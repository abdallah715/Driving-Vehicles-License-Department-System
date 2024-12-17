using DVLD_BussinessLayer;
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
    public partial class ctrlScheduledTest : UserControl
    {
        private int _LocalDrivingLicenseApplicationID = 0;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _TestAppointmentID = 0;
        private clsTestAppointment _TestAppointment;
        public clsTestType.enTestType _TestType;
        
        public ctrlScheduledTest()
        {
            InitializeComponent();
           
        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
        private void _LoadScreen()
        {
            switch (_TestType)
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

        public void LoadInfo(int LocalDrivingLicenseApplicaitonID , int AppointmentID)
        {
            _LoadScreen();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicaitonID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblTitle.Text = "Scheduled Test";
           
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName.ToString();
            lblFullName.Text = clsPerson.Find(_LocalDrivingLicenseApplication.ApplicantPersonID).FullName();

            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestAppointment.TestTypeID).ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();

            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblFees.Text = clsTestType.Find(_TestAppointment.TestTypeID).Fees.ToString();


        }
    }
}
