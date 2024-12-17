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
using DVLD_Project.Licenses;
using DVLD_Project.Licenses.Local_licenses;
using DVLD_Project.People;
using DVLD_Project.Tests;

namespace DVLD_Project.Applications.Local_Driving_License_Application
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private enum enFilterData
        {
            None = 0,
            LDLAppID = 1,
            NationalNo = 2,
            FullName = 3,
            Status = 4,
            

        };
        private enFilterData _CurrentFilter = enFilterData.None;
        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvManageLDLIcenseApp.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            lblNoOfRecords.Text = dgvManageLDLIcenseApp.Rows.Count.ToString();
            cbFilterData.SelectedIndex = 0;
            dgvManageLDLIcenseApp.Columns["ClassName"].HeaderText = "Driving Class";
            dgvManageLDLIcenseApp.Columns["PassedTestCount"].HeaderText = "Passed Tests";
            dgvManageLDLIcenseApp.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.LApplicationID";



        }
     
        private void _RefreashData()
        {
            dgvManageLDLIcenseApp.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            lblNoOfRecords.Text = dgvManageLDLIcenseApp.Rows.Count.ToString();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingApplication frm = new frmAddUpdateLocalDrivingApplication();
            frm.ShowDialog();
            _RefreashData();
        }

        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchText.Text = "";

            _CurrentFilter = (enFilterData)cbFilterData.SelectedIndex;

            if (_CurrentFilter == enFilterData.None)
            {
                txtSearchText.Visible = false;
                _RefreashData();
            }
            else
            {
                txtSearchText.Visible = true;
                txtSearchText.Focus();
            }
        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilter == enFilterData.LDLAppID)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Prevent the character from being added to the TextBox
                }
            }
            else
            {
                if (txtSearchText.Text.Length == 0 && char.IsNumber(e.KeyChar))
                {
                    e.Handled = true; // Prevent the number from being entered as the first character
                }
            }
        }
        private void FilterBy(string TextWritten)
        {
            DataTable FilteredTable = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            if (!string.IsNullOrEmpty(TextWritten))
            {
                switch (_CurrentFilter)

                {
                    case enFilterData.LDLAppID:

                        FilteredTable.DefaultView.RowFilter = $"Convert(LocalDrivingLicenseApplicationID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.NationalNo:

                        FilteredTable.DefaultView.RowFilter = $"Convert(NationalNo, 'System.String') LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.FullName:
                        FilteredTable.DefaultView.RowFilter = $"FullName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.Status:
                        FilteredTable.DefaultView.RowFilter = $"Status LIKE '{TextWritten}%'";
                        break;
                }

            }
            else
            {

                // Clear the filter if the text is empty
                FilteredTable.DefaultView.RowFilter = string.Empty;

            }
            dgvManageLDLIcenseApp.DataSource = FilteredTable;
            lblNoOfRecords.Text = dgvManageLDLIcenseApp.Rows.Count.ToString();  

        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            string TextWritten = (sender as TextBox).Text.Trim();
            FilterBy(TextWritten);
        }

        private void showDetialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
               
                clsLocalDrivingLicenseApplication Current = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value);
                DialogResult YesOrNo = MessageBox.Show(
                    "Are you sure you want to cancel this application?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (YesOrNo == DialogResult.Yes)
                {
                    if (Current.Cancel())
                    {
                        MessageBox.Show("Application Cancelled Successfully.", "Cancelled");
                    }
                }
                _RefreashData();

            
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
               
               frmListTestAppointment frm = new frmListTestAppointment((int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value, clsTestType.enTestType.VisionTest);
                frm.ShowDialog();
                _RefreashData();

            
        }

        private void cmsManageLDLApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                                                    (LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvManageLDLIcenseApp.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            issueToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            SechduleTestsToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            CancelAppToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            deleteToolStripMenuItem.Enabled =
               (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            SechduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (SechduleTestsToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }


        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                frmListTestAppointment frm = new frmListTestAppointment((int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value, clsTestType.enTestType.WrittenTest);
                frm.ShowDialog();
                _RefreashData();

            
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmListTestAppointment frm = new frmListTestAppointment((int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value, clsTestType.enTestType.StreetTest);
                frm.ShowDialog();
                _RefreashData();

            
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                frmIssuingDrivingLicenseFortheFirstTime frm = new frmIssuingDrivingLicenseFortheFirstTime((int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _RefreashData();

            
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value;
            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID)
                .GetActiveLicenseID();
           
            
            if (LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(localDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int TestPassed = (int)dgvManageLDLIcenseApp.CurrentRow.Cells[5].Value;
            int LocalDrivingLicenseApplicationID = (int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                  clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingApplication frm =  new frmAddUpdateLocalDrivingApplication((int)dgvManageLDLIcenseApp.CurrentRow.Cells[0].Value);
        frm.ShowDialog();
        }

        private void SechduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
