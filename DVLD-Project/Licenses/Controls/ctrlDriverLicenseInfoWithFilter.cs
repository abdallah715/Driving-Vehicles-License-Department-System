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

namespace DVLD_Project.Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public delegate void DataBackEventHandler( int LicenseID);
        //Declare an Event using the Delegate 
        public event DataBackEventHandler DataBack;
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private int _LicenseID;
        private bool _FilterEnabled = true;
        public int LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return ctrlDriverLicenseInfo1.License; } }

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public void DisableFiltering()
        {
            gbFilters.Enabled = false;
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadInfoByLicenseID(LicenseID);
            _LicenseID = LicenseID;

            // for returning the Selected License 
            if(ctrlDriverLicenseInfo1.License != null)
            DataBack?.Invoke(_LicenseID);
            
        }
        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }
        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;

            }
            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // preventing Charcters and tabs or enter keys 
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            // Activing the Enter Press for the Performaing Finding 
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

        }
    }
}
