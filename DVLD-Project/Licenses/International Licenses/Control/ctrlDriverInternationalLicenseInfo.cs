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

namespace DVLD_Project.Licenses.International_Licenses.Control
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private clsInternationalLicense _InternationalLicense;
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show($"There is No International License with ID {InternationalLicenseID}");
                return;
            }
            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName();
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo.ToString();
            lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString("dd/MMM/yyyy");
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString("dd/MMM/yyyy");
            _LoadPersonImage();



        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
