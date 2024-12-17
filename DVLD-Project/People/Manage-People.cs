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
using DVLD_Project.People;

namespace DVLD_Project
{
    public partial class frmManagePeople : Form
    {
        
        private enum enFilterData
        {
            None = 0,
            PersonID = 1,
            NationalNo = 2,
            FirstName = 3,
            SecondName = 4,
            ThirdName = 5,
            LastName = 6,
            Nationality = 7,
            Gendor = 8,
            Phone = 9,
            Email = 10

        };
        private enFilterData _CurrentFilter = enFilterData.None;
        public frmManagePeople()
        {
            InitializeComponent();
            cbFilterData.SelectedIndex = 0;

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        

        
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            dgvManagePeople.DataSource = clsPerson.GetAllPeople();
            lblNoOfRecords.Text = dgvManagePeople.Rows.Count.ToString();
            if (dgvManagePeople.Rows.Count > 0)
            {
                dgvManagePeople.Columns["Gendor"].Visible = false;
                dgvManagePeople.Columns["ImagePath"].Visible = false;
                dgvManagePeople.Columns["NationalityCountryID"].Visible = false;
                dgvManagePeople.Columns["Address"].Visible = false;
                dgvManagePeople.Columns["PersonID"].HeaderText = "Person ID";
                dgvManagePeople.Columns["NationalNo"].HeaderText = "National No";
                dgvManagePeople.Columns["FirstName"].HeaderText = "First Name";
                dgvManagePeople.Columns["SecondName"].HeaderText = "Second Name";
                dgvManagePeople.Columns["ThirdName"].HeaderText = "Third Name";
                dgvManagePeople.Columns["LastName"].HeaderText = "Last Name";
                dgvManagePeople.Columns["GendorName"].HeaderText = "Gendor";
                dgvManagePeople.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
                dgvManagePeople.Columns["CountryName"].HeaderText = "Nationality";
            }



        }
        private void FilterBy(string TextWritten)
        {
            DataTable FilteredTable = clsPerson.GetAllPeople();

            if (!string.IsNullOrEmpty(TextWritten))
            {
                switch (_CurrentFilter)

                {
                    case enFilterData.PersonID:

                        FilteredTable.DefaultView.RowFilter = $"Convert(PersonID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.Phone:

                        FilteredTable.DefaultView.RowFilter = $"Convert(Phone, 'System.String') LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.FirstName:
                        FilteredTable.DefaultView.RowFilter = $"FirstName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.SecondName:
                        FilteredTable.DefaultView.RowFilter = $"SecondName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.ThirdName:
                        FilteredTable.DefaultView.RowFilter = $"ThirdName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.LastName:
                        FilteredTable.DefaultView.RowFilter = $"LastName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.Gendor:
                        FilteredTable.DefaultView.RowFilter = $"GendorName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.Email:
                        FilteredTable.DefaultView.RowFilter = $"Email LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.Nationality:
                        FilteredTable.DefaultView.RowFilter = $"CountryName LIKE '{TextWritten}%'";
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
            dgvManagePeople.DataSource = FilteredTable;
            lblNoOfRecords.Text = dgvManagePeople.Rows.Count.ToString();

        }

        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchText.Text = "";

            _CurrentFilter = (enFilterData)cbFilterData.SelectedIndex;

            if (_CurrentFilter == enFilterData.None)
            {
                txtSearchText.Visible = false;
                dgvManagePeople.DataSource = clsPerson.GetAllPeople();
            }
            else
            {
                txtSearchText.Visible = true;
            }


        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {

            string TextWritten = (sender as TextBox).Text.Trim();
            FilterBy(TextWritten);


        }


        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilter == enFilterData.PersonID || _CurrentFilter == enFilterData.Phone)
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

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog();
            frmManagePeople_Load(null,null);

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog();
            frmManagePeople_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("didn't Work on it yet");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("didn't Work on it yet");

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvManagePeople.SelectedRows.Count > 0)
            {
                
                DialogResult YesOrNot = MessageBox.Show("Are you sure you want to delete this Person?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (YesOrNot == DialogResult.Yes)
                {
                    clsPerson.DeletePerson((int)dgvManagePeople.CurrentRow.Cells[0].Value);
                    frmManagePeople_Load(null, null);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManagePeople.SelectedRows.Count > 0)
            {
                               
                frmAddUpdatePerson frmEditPerson = new frmAddUpdatePerson((int)dgvManagePeople.CurrentRow.Cells[0].Value);
                frmEditPerson.ShowDialog();
                frmManagePeople_Load(null, null);
            }
        }

        private void showDetialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManagePeople.SelectedRows.Count > 0)
            {
                
                
                frmShowPersonInfo frmPersonDetials = new frmShowPersonInfo((int)dgvManagePeople.CurrentRow.Cells[0].Value);
                frmPersonDetials.ShowDialog();
                frmManagePeople_Load(null, null);
            }

                
        }

        private void dgvManagePeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
