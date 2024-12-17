using DVLD_BussinessLayer;
using DVLD_Project.Global_Class;
using DVLD_Project.Licenses;
using DVLD_Project.Licenses.Local_licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Release_Detained_license_Application
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private clsLicense _License;
        private clsDetainedLicense _DetainedLicense;
        
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrlDriverLicenseInfoWithFilter_DataBack(LicenseID);
            ctrlDriverLicenseInfoWithFilter1.DisableFiltering();

        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.DataBack += ctrlDriverLicenseInfoWithFilter_DataBack;

        }
        private void ctrlDriverLicenseInfoWithFilter_DataBack(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
            _License = clsLicense.FindLicenseByLicenseID(LicenseID);

            if (!_License.IsDetained)
            {
                MessageBox.Show("Selected License is Not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DetainedLicense = clsDetainedLicense.FindByLicenseID(LicenseID);
            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblCreatedByUser.Text = _DetainedLicense.CreatedByUserInfo.UserName.ToString();
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrvingLicense).ApplicationFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            llShowLicenseHistory.Enabled = true;
            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
         
            if (MessageBox.Show("Are you sure you want to Release the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;
            bool IsReleased = _DetainedLicense.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID,ref ApplicationID);
            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.Enabled = false;
            llShowLicenseInfo.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
             new frmShowPersonLicenseHistory(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
    }
}
