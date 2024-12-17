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
using DVLD_BussinessLayer;
using System.Runtime.CompilerServices;
using DVLD_Project.People;

namespace DVLD_Project.Applications.Control
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID;
        private clsApplication _Application;
        
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        private void _FillApplicationInfo()
        {
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = clsPerson.Find(_Application.ApplicantPersonID).FullName();
            lblCreatedByUser.Text = clsUser.FindByUserID(_Application.CreatedByUserID).UserName;
            lblType.Text = clsApplicationType.Find(_Application.ApplicationTypeID).ApplicationTitle;

            if (_Application.ApplicationStatus == clsApplication.enApplicationStatus.New)
            {
                lblStatus.Text = "New";
            }
            else if (_Application.ApplicationStatus == clsApplication.enApplicationStatus.Cancelled)
            {
                lblStatus.Text = "Cancelled";
            }
            else
            {
                lblStatus.Text = "Completed";
            }

            lblDate.Text = _Application.ApplicationDate.Date.ToString("dd/MMM/yyyy");
            lblStatusDate.Text = _Application.LastStatusDate.ToString("dd/MMM/yyyy");

        }

        private void _ResetApplicationInfo()
        {
            lblApplicationID.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[$$$]";
            lblType.Text = "[???]";
            lblApplicant.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblDate.Text = "[??/??/????]";
            lblStatusDate.Text = "[??/??/????]";
            llViewPersonInfo.Enabled = false;
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);
           
            if (_Application == null)
            {
                _ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                _FillApplicationInfo();
            }
        }

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID); 
            frm.ShowDialog();
        }
    }
}
