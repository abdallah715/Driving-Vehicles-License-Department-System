using DVLD_BussinessLayer;
using DVLD_Project.Global_Class;
using DVLD_Project.Licenses;
using DVLD_Project.Licenses.International_Licenses;
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

namespace DVLD_Project.Applications.International_Application
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private clsLicense _License;
        private int _InternationalLicenseID;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.DataBack += ctrlDriverLicenseInfoWithFilter_DataBack;
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            
        }
        private void ctrlDriverLicenseInfoWithFilter_DataBack( int LicenseID) 
        {
            _License = clsLicense.FindLicenseByLicenseID(LicenseID);
            llShowLicenseHistory.Enabled = true;
            btnIssueLicense.Enabled = true; 
            lblLocalLicenseID.Text = LicenseID.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternaltionalLicense).ApplicationFees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MMM/yyyy");
            lblIssueDate.Text = lblApplicationDate.Text;
            
            if(_License.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueLicense.Enabled = false;
                _InternationalLicenseID = _License.LicenseID;
                return;
            }
            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show($"Person Already have an active international License with ID"+ActiveInternaionalLicenseID.ToString(),"Not Allowed");
                btnIssueLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                return;
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsDriver.FindByDriverID(_License.DriverID).PersonID);
            frm.ShowDialog();

        }

        private void gpApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // check if there is an Issued one 
            
            //
            if (_License.IsActive == false || _License.LicenseClass != 3)
            {
                MessageBox.Show("You can't make international License with this License");
            }
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.ApplicantPersonID = _License.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.AppStatus = (byte) clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternaltionalLicense).ApplicationFees;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            InternationalLicense.DriverID = _License.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = _License.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);




            btnIssueLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;




        }
    }
}
