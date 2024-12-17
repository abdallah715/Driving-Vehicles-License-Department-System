using DVLD_BussinessLayer;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.Local_licenses.Control
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        private clsLicense _License;
        private int _LicenseID;
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense License
        { get { return _License; } }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadInfoByLicenseID(int LicenseID)
        {
            _LicenseID = LicenseID;
         _License = clsLicense.FindLicenseByLicenseID(LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName();
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblIssueDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");

           
                lblIssueReason.Text = _License.IssueReasonText;
            

            lblNotes.Text = _License.Notes == ""? "No Notes":_License.Notes;

            lblIsActive.Text = _License.IsActive?"Yes":"No";
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MMM/yyyy");
            

            _LoadPersonImage();
        }
    }
}
