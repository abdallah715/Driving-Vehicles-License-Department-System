using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicatonID = -1;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID,int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicatonID= LocalDrivingLicenseApplicationID;
            _TestType = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1._TestTypeID = _TestType;
            ctrlScheduleTest1.LoadScheduleTestBy(_LocalDrivingLicenseApplicatonID, _AppointmentID);

        }
    }
}
