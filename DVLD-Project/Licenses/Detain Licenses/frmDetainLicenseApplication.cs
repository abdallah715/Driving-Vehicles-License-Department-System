using DVLD_BussinessLayer;
using DVLD_Project.Global_Class;
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

namespace DVLD_Project.Licenses.Detain_Licenses
{
    public partial class frmDetainLicenseApplication : Form
    {
        private clsLicense _License;
        private int _DetainID;

        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
              new frmShowPersonLicenseHistory(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            ctrlDriverLicenseInfoWithFilter1.DataBack += ctrlDriverLicenseInfoWithFilter_DataBack;
            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        }
        private void ctrlDriverLicenseInfoWithFilter_DataBack(int LicenseID)
        {
            _License = clsLicense.FindLicenseByLicenseID(LicenseID);   
            lblLicenseID.Text = LicenseID.ToString();

            if (_License == null )

            {
                return;
            }
            if (_License.IsDetained)
            {
                clsDetainedLicense Detained = clsDetainedLicense.FindByLicenseID(LicenseID);
                txtFineFees.Text = Detained.FineFees.ToString();
                lblDetainID.Text = Detained.DetainID.ToString();
                txtFineFees.Enabled = false;
                MessageBox.Show("Selected License is already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblDetainID.Text = "[???]";
            txtFineFees.Text = "";
            txtFineFees.Enabled=true;
            llShowLicenseHistory.Enabled = true;
            btnDetain.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being added to the TextBox
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                txtFineFees.Focus();
                MessageBox.Show("you Need to enter Fine Fees!");
                return;
            }
            if (MessageBox.Show("Are you sure you want to Detain the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _DetainID = _License.Detain(Convert.ToSingle(txtFineFees.Text.Trim()) , clsGlobal.CurrentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
                llShowLicenseInfo.Enabled = true;
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);

            };

        }

        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
    }
}
