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
using DVLD_Project.Properties;

namespace DVLD_Project.Tests
{
    public partial class frmListTestAppointment : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private DataTable _dtTestAppointments;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        public frmListTestAppointment(int LocalDrivingLicenseApplicationID,clsTestType.enTestType Testtype)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = Testtype;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointment";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Properties.Resources.Vision_Test_32;
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Properties.Resources.Written_Test_32_Sechdule;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }
        private void frmVisionTestAppiontments_Load(object sender, EventArgs e)
        {

            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadDrivingApplicationInfo(_LocalDrivingLicenseApplicationID);
            _dtTestAppointments = clsTestAppointment.GetApplicationTestAppointmentPerTestType(_LocalDrivingLicenseApplicationID, _TestType);
            
            dgvLicenseTestAppointments.DataSource = _dtTestAppointments;
            lblRecordsCount.Text = _dtTestAppointments.Rows.Count.ToString();
            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void ctrlDrivingLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);
            
            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frmVisionTestAppiontments_Load(null, null);
                return;
            }
            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmVisionTestAppiontments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            // finding the current Appointment ID 
            if (dgvLicenseTestAppointments.SelectedRows.Count > 0)
            {

                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                frmVisionTestAppiontments_Load(null, null);
            }

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (dgvLicenseTestAppointments.SelectedRows.Count > 0)
            {
               
                frmTakeTest frm = new frmTakeTest(_LocalDrivingLicenseApplicationID, (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value, _TestType);
                frm.ShowDialog();
                frmVisionTestAppiontments_Load(null, null);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
