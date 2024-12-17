using DVLD_BussinessLayer;
using DVLD_Project.Licenses;
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

namespace DVLD_Project
{
    public partial class frmListDrivers : Form
    {
        private DataTable _dtDrivers;
        private enum enFilterData
        {
            None = 0,
            DriverID = 1,
            PersonID = 2,
            NationalNo = 3 ,
            FullName = 4 

        };
        private enFilterData _CurrentFilter = enFilterData.None;
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtDrivers;
            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";

                dgvDrivers.Columns[1].HeaderText = "Person ID";

                dgvDrivers.Columns[2].HeaderText = "National No.";

                dgvDrivers.Columns[3].HeaderText = "Full Name";

                dgvDrivers.Columns[4].HeaderText = "Date";

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            _CurrentFilter = (enFilterData)cbFilterBy.SelectedIndex;

            if (_CurrentFilter == enFilterData.None)
            {
                txtFilterValue.Visible = false;
                dgvDrivers.DataSource = clsDriver.GetAllDrivers();
            }
            else
            {
                txtFilterValue.Visible = true;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string TextWritten = (sender as TextBox).Text.Trim();
            FilterBy(TextWritten);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilter == enFilterData.PersonID || _CurrentFilter == enFilterData.DriverID)
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
            DataTable FilteredTable = clsDriver.GetAllDrivers();

            if (!string.IsNullOrEmpty(TextWritten))
            {
                switch (_CurrentFilter)

                {
                    case enFilterData.PersonID:

                        FilteredTable.DefaultView.RowFilter = $"Convert(PersonID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.DriverID:

                        FilteredTable.DefaultView.RowFilter = $"Convert(DriverID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.FullName:
                        FilteredTable.DefaultView.RowFilter = $"FullName LIKE '{TextWritten}%'";
                        break;
                   
                    case enFilterData.NationalNo:
                        FilteredTable.DefaultView.RowFilter = $"NationalNo LIKE '{TextWritten}%'";
                        break;
                }

            }
            else
            {

                // Clear the filter if the text is empty
                FilteredTable.DefaultView.RowFilter = string.Empty;

            }
            dgvDrivers.DataSource = FilteredTable;
            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();

        }

        private void sowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        
    }
}
