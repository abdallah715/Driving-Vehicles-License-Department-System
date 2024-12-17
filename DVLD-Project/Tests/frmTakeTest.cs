using DVLD_BussinessLayer;
using DVLD_Project.Global_Class;
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
    public partial class frmTakeTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = 0;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _TestAppointmentID = 0;
        private clsTestAppointment _TestAppointment;
        private clsTest _Test;
        private clsTestType.enTestType _TestType;
        public frmTakeTest(int LocalDrivingLicenseApplicationID , int AppointmentID, clsTestType.enTestType testType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _TestType = testType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1._TestType = _TestType;
            ctrlScheduledTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);
          
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            lblUserMessage.Visible = false;
            if(_TestAppointment.IsLocked )
            {
                _Test= clsTest.Find(_TestAppointment.TestID);
                btnSave.Enabled = false;
                txtNotes.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                rbFail.Checked = true;
                lblUserMessage.Visible = true;
                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                if (_Test.Notes != "")txtNotes.Text = _Test.Notes;
                
                return;
            }
            else _Test = new clsTest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            if (rbPass.Checked)
            {
                _Test.TestResult = true;
            }
            else { _Test.TestResult = false; }

            if(txtNotes.Text == null)
            {
                _Test.Notes = "";
            }
            else _Test.Notes = txtNotes.Text.Trim();

            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to save ? After that you cannot change the Pass/Fall results after you save?.",
                        "Confirmation",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if(_Test.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved");
                    _TestAppointment.IsLocked = true;
                    _TestAppointment.Save();
                }
                else
                {
                    MessageBox.Show("Error Data don't Saved Successfully");
                }
            }


        }
    }
}
