using DVLD_BussinessLayer;
using DVLD_Project.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.User
{
    public partial class frmManageUsers : Form
    {
        
        private enum enFilterData
        {
            None = 0,
            UserID = 1,
            PersonID = 2,
            FullName = 3,
            UserName = 4,
            IsActive = 5


        };
        private enFilterData _CurrentFilter = enFilterData.None;
        private enum enIsActive { All = 0 , Yes = 1 , No = 2};
        enIsActive _isActive = enIsActive.All;

    public frmManageUsers()
        {
            InitializeComponent();
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {

            cbFilterData.SelectedIndex = 0;
            cbIsActiveFilter.SelectedIndex = 0;
            dgvManageUsers.DataSource = clsUser.GellAllUsers();
            lblNoOfRecords.Text = dgvManageUsers.Rows.Count.ToString();
            if(dgvManageUsers.Rows.Count>0)
            {
                dgvManageUsers.Columns["PersonID"].HeaderText = "Person ID";
                dgvManageUsers.Columns["UserID"].HeaderText = "User ID";
                dgvManageUsers.Columns["IsActive"].HeaderText = "Is Active";
                dgvManageUsers.Columns["FullName"].HeaderText = "Full Name";

            }
        }
        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchText.Text = "";

            _CurrentFilter = (enFilterData)cbFilterData.SelectedIndex;

            if (_CurrentFilter == enFilterData.None)
            {
                cbIsActiveFilter.Visible = false;
                txtSearchText.Visible = false;
                _RefreashData();
            }
            else if(_CurrentFilter == enFilterData.IsActive)
            {
                cbIsActiveFilter.Visible = true;
                txtSearchText.Visible = false;
                cbIsActiveFilter.Focus();
                cbIsActiveFilter.SelectedIndex = 0;
            }
            else
            {
                cbIsActiveFilter.Visible = false;
                txtSearchText.Visible = true;
                txtSearchText.Focus();
                txtSearchText.Text = "";
            }

        }
        private void _RefreashData()
        {
           dgvManageUsers.DataSource=clsUser.GellAllUsers();
            lblNoOfRecords.Text = dgvManageUsers.Rows.Count.ToString();

        }
        private void FilterBy(string TextWritten)
        {
           DataTable dt = clsUser.GellAllUsers();

            if(!string.IsNullOrEmpty(TextWritten))
            {
                switch (_CurrentFilter)
                {
                    case enFilterData.PersonID:
                        dt.DefaultView.RowFilter = $"Convert(PersonID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.UserID:
                        dt.DefaultView.RowFilter = $"Convert(UserID, 'System.String') = '{TextWritten}'";
                        break;
                    case enFilterData.FullName:
                        dt.DefaultView.RowFilter = $"FullName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.UserName:
                        dt.DefaultView.RowFilter = $"UserName LIKE '{TextWritten}%'";
                        break;
                    case enFilterData.IsActive:
                        if(TextWritten == "true")
                        dt.DefaultView.RowFilter = $"IsActive = true";
                        else dt.DefaultView.RowFilter = $"IsActive = false";

                        break;
                }
                
            }
            else
            {
                // Clear the filter if the text is empty
                dt.DefaultView.RowFilter = string.Empty;
            }
            dgvManageUsers.DataSource = dt;
            lblNoOfRecords.Text = dgvManageUsers.Rows.Count.ToString();
        }
      private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            string TextWritten = (sender as TextBox).Text.Trim();
            FilterBy(TextWritten);
        }
      private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilter == enFilterData.PersonID || _CurrentFilter == enFilterData.UserID)
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
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser();
            frmAddUpdateUser.ShowDialog();
            _RefreashData();
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isActive = (enIsActive)cbIsActiveFilter.SelectedIndex;
            if (_isActive == enIsActive.All)
            {
                _RefreashData();
            }
            else if (_isActive == enIsActive.Yes)
            {
                FilterBy("true");
            }
            else
            {
                FilterBy("false");
            }
           
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser();
            frmAddUpdateUser.ShowDialog();
            _RefreashData();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Don't Work on it yet!");
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Don't Work on it yet!");

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.SelectedRows.Count > 0)
            {
               

                DialogResult YesOrNot = MessageBox.Show("Are you sure you want to delete this Person?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (YesOrNot == DialogResult.Yes)
                {
                    clsUser.DeleteUser((int)dgvManageUsers.CurrentRow.Cells[0].Value);
                    _RefreashData();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
               
                frmAddUpdateUser frmEditUser = new frmAddUpdateUser((int)dgvManageUsers.CurrentRow.Cells[0].Value);
                frmEditUser.ShowDialog();
                _RefreashData();
            
        }

        private void showDetialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.SelectedRows.Count > 0)
            {
                
                frmUserInfo frm = new frmUserInfo((int)dgvManageUsers.CurrentRow.Cells[0].Value);
               frm.ShowDialog();
                _RefreashData();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void miChangePassword_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.SelectedRows.Count > 0)
            {
               
               
                frmChangePassword frm = new frmChangePassword((int)dgvManageUsers.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _RefreashData();
            }
        }
    }
}
