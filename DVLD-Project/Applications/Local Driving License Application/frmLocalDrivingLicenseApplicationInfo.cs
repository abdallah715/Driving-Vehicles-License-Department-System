using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Local_Driving_License_Application
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _LocalDrivinglincenseApplicationID = -1;
        public frmLocalDrivingLicenseApplicationInfo(int localDrivinglincenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivinglincenseApplicationID = localDrivinglincenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadDrivingApplicationInfo(_LocalDrivinglincenseApplicationID);
        }
    }
}
