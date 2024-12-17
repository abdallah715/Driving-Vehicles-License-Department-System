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

namespace DVLD_Project.User
{
    public partial class frmAddUpdateUser : Form
    {
        private clsPerson _Person;
        clsUser _User;
        private int _UserID = -1;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;
                _Mode = enMode.Update;
            
        }
        public frmAddUpdateUser()
        {
            InitializeComponent();            
                _Mode = enMode.AddNew;
            
            
               
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        
        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tabUserInfo.SelectedTab = tabUserInfo.TabPages["tpLoginInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter1.Person == null)
                return;
                if (clsUser.isExistforPersonID(ctrlPersonCardWithFilter1.Person.PersonID))
                {
                
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another person");
                ctrlPersonCardWithFilter1.FilterFocus();
            }
                else
                {
                    _Person = ctrlPersonCardWithFilter1.Person;
                    btnSave.Enabled = true;
                tabUserInfo.SelectedTab = tabUserInfo.TabPages["tpLoginInfo"];
                tpLoginInfo.Enabled = true;

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (clsUser.isUserExistByUserNameandPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim())
                && _User.isActive == chkisActive.Checked)
            {
                
                    MessageBox.Show("the User data is already used before !");
                      return;
                    //txtUserName.Text = "";
                    //txtUserName.Focus();
                    //txtPassword.Text = "";
                    //txtComfirmPassword.Text = "";
                
              
            }
            else 
            {
                _User.PersonID = _Person.PersonID;
                _User.UserName = txtUserName.Text.Trim();
                if(_Mode == enMode.AddNew)
                _User.Password = txtPassword.Text.Trim();
                _User.isActive = (chkisActive.Checked);
                if (_User.Save())
                {
                    _Mode = enMode.Update;

                    lblUserID.Text = _User.UserID.ToString();
                    lblMainLabel.Text = "Update User";
                    this.Text = "Update User";

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMainLabel.Text = "Add New User";
                this.Text = "Add New User";
                ctrlPersonCardWithFilter1.FilterFocus();

                _User = new clsUser();
                tpLoginInfo.Enabled = false;


            }
            else
            {
                lblMainLabel.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtComfirmPassword.Text = "";
            chkisActive.Checked = true;
        }
        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);
            _Person = clsPerson.Find(_User.PersonID);
            ctrlPersonCardWithFilter1.LoadByPersonID(_Person.PersonID);
            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            // Fill Update User
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtComfirmPassword.Text = _User.Password;
            if (_User.isActive) chkisActive.Checked = true;
            else chkisActive.Checked = false;
            btnNext.Enabled = false;
            btnSave.Enabled = true;
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {

           _ResetDefaultValues();

            if(_Mode == enMode.Update)
                _LoadData();
           
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox CurrentTextBox = (System.Windows.Forms.TextBox)sender;
            if (string.IsNullOrEmpty(CurrentTextBox.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(CurrentTextBox, $"{CurrentTextBox.Tag.ToString()} is Empty !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(CurrentTextBox, "");
            }
            if (_Mode == enMode.AddNew)
            {

                if (clsUser.isExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.isExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox CurrentTextBox = (System.Windows.Forms.TextBox)sender;
            if (string.IsNullOrEmpty(CurrentTextBox.Text))
            {
                e.Cancel = true;
                CurrentTextBox.Focus();
                errorProvider1.SetError(CurrentTextBox, $"{CurrentTextBox.Tag.ToString()} is Empty !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(CurrentTextBox, "");
            }
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtComfirmPassword.Text != txtPassword.Text)
            {

                e.Cancel = true;
                txtComfirmPassword.Focus();
                errorProvider1.SetError(txtComfirmPassword,"Password Confirmation does not match Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtComfirmPassword, "");
            }
        }

       
    }
}
