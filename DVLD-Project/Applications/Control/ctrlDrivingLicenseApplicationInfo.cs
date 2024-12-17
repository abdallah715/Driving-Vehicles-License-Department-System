using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;
using DVLD_Project.Licenses.Local_licenses;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project.Applications.Control
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LDLApplication;
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadDrivingApplicationInfo(int LDLApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLApplicationID);

            if (_LDLApplication == null)
            {
                _ResetDrivingLicenseApplicationInfo();
                MessageBox.Show("No Driving License Application with ApplicationID = " + LDLApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                _FillDrivingLicenseApplicationInfo();
               
            }
        }

        private void _FillDrivingLicenseApplicationInfo()
        {
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LDLApplication.ApplicationID);
            lblLDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedLicense.Text = clsLicenseClass.Find(_LDLApplication.LicenseClassID).ClassName;
            lblPassedTest.Text = clsLocalDrivingLicenseApplication.GetPassedTestByLDApplicationID(_LDLApplication.LocalDrivingLicenseApplicationID).ToString() + "/3";
            if(clsLocalDrivingLicenseApplication.GetPassedTestByLDApplicationID(_LDLApplication.LocalDrivingLicenseApplicationID) == 3)
            {
                pbShowLicense.Visible = true;
                llShowLicenceInfo.Visible = true;
            }
        else
            {
                pbShowLicense.Visible= false;
                llShowLicenceInfo.Visible = false;
            }
        }

        private void _ResetDrivingLicenseApplicationInfo()
        {
            throw new NotImplementedException();
        }

        private void gbDrivingLicenseApplication_Enter(object sender, EventArgs e)
        {

        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LDLApplication.GetActiveLicenseID());
            frm.ShowDialog();
        }
    }
}
