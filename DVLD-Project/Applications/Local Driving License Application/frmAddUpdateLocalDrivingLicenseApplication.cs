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

namespace DVLD_Project.Applications
{
    public partial class frmAddUpdateLocalDrivingApplication : Form
    {
        private int _SelectedPersonID = -1;
        private int _LDLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public frmAddUpdateLocalDrivingApplication( int LDLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LDLicenseApplicationID = LDLicenseApplicationID;
            //Find Method for the update mode
        }
        public frmAddUpdateLocalDrivingApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            
        }
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.Person == null)
                return;
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tabApplicationInfo.SelectedTab = tabApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }


            btnSave.Enabled = true;
            tpApplicationInfo.Enabled = true;
            tabApplicationInfo.SelectedTab = tabApplicationInfo.TabPages["tpApplicationInfo"];
        }
        private void _FillLicenseClasses()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow dr in dt.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"]);
            }
        }
        private void _ResetDefaultScreen()
        {
            _FillLicenseClasses();

            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblDate.Text = DateTime.Now.ToShortDateString();
               lblMainLabel.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                cbLicenseClass.SelectedIndex = 2;
                lblDate.Text = DateTime.Now.ToShortDateString();
            // that is a test case so will not work
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {

                lblMainLabel.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tabApplicationInfo.Enabled=true;
                btnSave.Enabled=true;
            }
        }
        private void _LoadData()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LDLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            ctrlPersonCardWithFilter1.LoadByPersonID(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLDAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToString("dd/MMM/yyyy");
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }
        private void frmLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            _ResetDefaultScreen();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;


            // Finding if there is the same active application with the same type (like Class 3 and New as applicaiton Status)
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);
            
            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            //check if the user already issued license of the same driving Class
            // is the person has an Active License with same License Class like already has Class 3 Active oone.
            if(clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.Person.PersonID,LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID; ;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblLDAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblMainLabel.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else 
                {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmAddUpdateLocalDrivingApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
