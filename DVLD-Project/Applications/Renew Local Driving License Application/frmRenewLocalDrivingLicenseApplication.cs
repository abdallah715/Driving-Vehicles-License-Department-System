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

namespace DVLD_Project.Applications.Renew_Local_Driving_License_Application
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private clsLicense _License;
        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();

            ctrlDriverLicenseInfoWithFilter1.DataBack += ctrlDriverLicenseInfoWithFilter_DataBack;
        }
        private void ctrlDriverLicenseInfoWithFilter_DataBack(int LicenseID)
        {
            lblOldLicenseID.Text = LicenseID.ToString();
            _License = clsLicense.FindLicenseByLicenseID(LicenseID);
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MMM/yyyy");
            llShowLicenseHistory.Enabled = true;
            if (_License.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("Selected License is not yet Expired , it will expire on: " + _License.ExpirationDate.ToString("dd/MMM/yyyy") , " Not Allowed");
                btnRenewLicense.Enabled = false;

                return;
            }

            if (!_License.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }
            int DefaultValidatyLength = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidatyLength).ToString("dd/MMM/yyyy");
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = _License.Notes;
            btnRenewLicense.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
               new frmShowPersonLicenseHistory(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = _License.RenewLicense(txtNotes.Text.Trim(),clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _License = NewLicense;
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + NewLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRenewLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.Enabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }
    }
    }
