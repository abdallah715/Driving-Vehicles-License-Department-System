using DVLD_BussinessLayer;
using DVLD_Project.Applications.Release_Detained_license_Application;
using DVLD_Project.Licenses.Local_licenses;
using DVLD_Project.People;
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
    public partial class frmListDetainLicense : Form
    {
        private DataTable _dtDetainLicense;
        public frmListDetainLicense()
        {
            InitializeComponent();
        }
        private enum enFilterData
        {
            None = 0,
        DetainID = 1,
        IsReleased = 2 ,
            NationalNo = 3,
                FullName = 4 ,
                    ReleaseApplicationID = 5

        };
        private enFilterData _CurrentFilter = enFilterData.None;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDetainLicense_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtDetainLicense = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLiccenses.DataSource = _dtDetainLicense;
            lblNoOfRecords.Text = dgvDetainedLiccenses.Rows.Count.ToString();
            if (dgvDetainedLiccenses.Rows.Count > 0)
            {
                dgvDetainedLiccenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLiccenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLiccenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLiccenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLiccenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLiccenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLiccenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLiccenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLiccenses.Columns[8].HeaderText = "Rlease App.ID";

                
            }
            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentFilter = (enFilterData)cbFilterBy.SelectedIndex;

            if (_CurrentFilter == enFilterData.None)
            {
                txtFilterValue.Visible = false;
                frmListDetainLicense_Load(null,null);
                cbIsReleased.Visible = false;

            }
            else if (_CurrentFilter == enFilterData.IsReleased)
            {
                cbIsReleased.Visible = true;
                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                cbIsReleased.Visible = false;

            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilter == enFilterData.DetainID || _CurrentFilter == enFilterData.ReleaseApplicationID)
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            
                string TextWritten = (sender as TextBox).Text.Trim();
                FilterBy(TextWritten);

            
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.SelectedIndex == 0)
            {
                frmListDetainLicense_Load(null, null);
            }
            else if (cbIsReleased.SelectedIndex == 1)
            {
                FilterBy("true");
            }
            else
            {
                FilterBy("False");
            }
        }

        private void FilterBy(string TextWritten)
        {
            DataTable FilteredTable = clsDetainedLicense.GetAllDetainedLicenses();

            if (!string.IsNullOrEmpty(TextWritten))
            {
                switch (_CurrentFilter)

                {
                    case enFilterData.DetainID:
                        FilteredTable.DefaultView.RowFilter = $"Convert(DetainID, 'System.String') = '{TextWritten}'";
                        break;

                    case enFilterData.NationalNo:
                        FilteredTable.DefaultView.RowFilter = $"Convert(NationalNo, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.FullName:
                        FilteredTable.DefaultView.RowFilter = $"Convert(FullName, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.ReleaseApplicationID:
                        FilteredTable.DefaultView.RowFilter = $"Convert(ReleaseApplicationID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.IsReleased:
                        if (TextWritten == "true")
                            FilteredTable.DefaultView.RowFilter = $"IsReleased = true";
                        else FilteredTable.DefaultView.RowFilter = $"IsReleased = false";
                        break;
                }

            }
            else
            {

                // Clear the filter if the text is empty
                FilteredTable.DefaultView.RowFilter = string.Empty;

            }
            dgvDetainedLiccenses.DataSource = FilteredTable;
            lblNoOfRecords.Text = dgvDetainedLiccenses.Rows.Count.ToString();

        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLiccenses.SelectedRows[0].Cells[1].Value;
            frmShowPersonInfo frm = new frmShowPersonInfo(clsLicense.FindLicenseByLicenseID(LicenseID).DriverInfo.PersonID);
        frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLiccenses.SelectedRows[0].Cells[1].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLiccenses.SelectedRows[0].Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsLicense.FindLicenseByLicenseID(LicenseID).DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            
                releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLiccenses.SelectedRows[0].Cells[3].Value;
            

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
            frmListDetainLicense_Load(null, null);

        }

        private void btnRelase_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            frmListDetainLicense_Load(null, null);

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLiccenses.SelectedRows[0].Cells[1].Value;
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(LicenseID);
            frm.ShowDialog();
            frmListDetainLicense_Load(null, null);

        }
    }
}
