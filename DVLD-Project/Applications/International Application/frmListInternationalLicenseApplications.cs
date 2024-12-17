using DVLD_BussinessLayer;
using DVLD_Project.Licenses;
using DVLD_Project.Licenses.International_Licenses;
using DVLD_Project.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project.Applications.International_Application
{
    public partial class frmListInternationalLicenseApplications : Form
    {
        private enum enFilterData
        {
            None = 0,
            internationalLicenseID = 1,
            ApplicationID = 2,
            DriverID = 3,
            LocalLicenseID = 4,
            IsActive = 5

        };
        private enFilterData _CurrentFilter = enFilterData.None;
        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }
        private DataTable _dtInternationalLicenses;

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication app = new frmNewInternationalLicenseApplication();
            app.ShowDialog();
            frmListInternationalLicenseApplications_Load(null,null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbIsReleased.SelectedIndex = 0;
            _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _dtInternationalLicenses;
            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";

            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";

            _CurrentFilter = (enFilterData)cbFilterBy.SelectedIndex;

            if (_CurrentFilter == enFilterData.None)
            {
                txtFilterValue.Visible = false;
                dgvInternationalLicenses.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
                cbIsReleased.Visible = false;

            }
            else if(_CurrentFilter == enFilterData.IsActive)
            {
                cbIsReleased.Visible = true;
                txtFilterValue.Visible=false;
            }
            else
            {
                txtFilterValue.Visible = true;
                cbIsReleased.Visible = false;

            }

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilter == enFilterData.internationalLicenseID || _CurrentFilter == enFilterData.ApplicationID||
                _CurrentFilter == enFilterData.DriverID || _CurrentFilter == enFilterData.LocalLicenseID)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Prevent the character from being added to the TextBox
                }
            }
            else
            {
                if (txtFilterValue.Text.Length == 0 && char.IsNumber(e.KeyChar))
                {
                    e.Handled = true; // Prevent the number from being entered as the first character
                }
            }
        }
        private void FilterBy(string TextWritten)
        {
            DataTable FilteredTable = clsInternationalLicense.GetAllInternationalLicenses();

            if (!string.IsNullOrEmpty(TextWritten))
            {
                switch (_CurrentFilter)

                {
                    case enFilterData.internationalLicenseID:
                        FilteredTable.DefaultView.RowFilter = $"Convert(InternationalLicenseID, 'System.String') = '{TextWritten}'";
                        break;

                    case enFilterData.ApplicationID:
                        FilteredTable.DefaultView.RowFilter = $"Convert(ApplicationID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.DriverID:
                        FilteredTable.DefaultView.RowFilter = $"Convert(DriverID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.LocalLicenseID:
                        FilteredTable.DefaultView.RowFilter = $"Convert(IssuedUsingLocalLicenseID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.IsActive:
                        if (TextWritten == "true")
                            FilteredTable.DefaultView.RowFilter = $"IsActive = true";
                        else FilteredTable.DefaultView.RowFilter = $"IsActive = false";
                        break;
                }

            }
            else
            {

                // Clear the filter if the text is empty
                FilteredTable.DefaultView.RowFilter = string.Empty;

            }
            dgvInternationalLicenses.DataSource = FilteredTable;
            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string TextWritten = (sender as TextBox).Text.Trim();
            FilterBy(TextWritten);

        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.SelectedIndex == 0)
            {
                frmListInternationalLicenseApplications_Load(null, null);
            }
            else if(cbIsReleased.SelectedIndex == 1)
            {
                FilterBy("true");
            }
            else
            {
                FilterBy("False");
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;

            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);

            frm.ShowDialog();        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID  ;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }
    }
}
