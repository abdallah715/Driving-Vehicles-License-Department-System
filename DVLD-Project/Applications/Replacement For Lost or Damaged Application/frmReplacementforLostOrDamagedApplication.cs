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

namespace DVLD_Project.Applications.Replacement_For_Lost_or_Damaged_Application
{
    public partial class frmReplacementforLostOrDamagedApplication : Form
    {
        private clsLicense _License;
        private clsApplication.enApplicationType _ApplicationType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
        public frmReplacementforLostOrDamagedApplication()
        {
            InitializeComponent();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked)
            {
                this.Text = "Replacement for Damaged License";
                lblTitle.Text = "Replacement For Damaged License";
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).ApplicationFees.ToString();

            }
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                this.Text = "Replacement for Lost License";
                lblTitle.Text = "Replacement For Lost License";
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).ApplicationFees.ToString();

            }
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

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replace the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (rbDamagedLicense.Checked)
                _ApplicationType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else _ApplicationType = clsApplication.enApplicationType.ReplaceLostDrivingLicense;


            clsLicense NewLicense = _License.ReplaceForDamagedOrLost(_ApplicationType,clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Replace the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _License = NewLicense;
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + NewLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnIssueLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
            gbReplacementFor.Enabled = false;



        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
               new frmShowPersonLicenseHistory(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmReplacementforLostOrDamagedApplication_Load(object sender, EventArgs e)
        {
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).ApplicationFees.ToString();
            ctrlDriverLicenseInfoWithFilter1.DataBack += ctrlDriverLicenseInfoWithFilter_DataBack;

        }
        private void ctrlDriverLicenseInfoWithFilter_DataBack(int LicenseID)
        {
            lblOldLicenseID.Text = LicenseID.ToString();
            _License = clsLicense.FindLicenseByLicenseID(LicenseID);
            if(_License == null ) return;
            llShowLicenseHistory.Enabled = true;
            if (!_License.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueLicense.Enabled = false;
                return;
            }

            btnIssueLicense.Enabled = true;
            lblOldLicenseID.Text = _License.LicenseID.ToString();
            btnIssueLicense.Enabled = true;


        }
    }
}
