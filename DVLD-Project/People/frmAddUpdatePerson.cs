using DVLD_BussinessLayer;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using DVLD.Classes;


namespace DVLD_Project.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 }
        private enGendor _Gendor = enGendor.Male;
        private enMode _Mode;
        
        private int _PersonID = -1;
         clsPerson _Person;


        // Declare a Delegate (interface for the function 
        public delegate void DataBackEventHandler(int PersonID);
        //Declare an Event using the Delegate 
        public event DataBackEventHandler DataBack;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdatePerson (int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            
                _Mode = enMode.Update;
            
                    
        }
        private void _LoadCountriesComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                // Get the CountryName from the current row
                string countryName = row["CountryName"].ToString();

                // Add the CountryName to the ComboBox
                cbCountry.Items.Add(countryName);
            }
            // seting the default country is Egypt .
            cbCountry.SelectedIndex = cbCountry.FindString("Egypt");
        }
        private void _FillUpdatePerson()
        {
            
            lblMainLabel.Text = "Update Person";
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            if(_Person.ThirdName != null)
            txtThirdName.Text = _Person.ThirdName;

            txtLastName.Text = _Person.LastName;

           txtNationalNumber.Text = _Person.NationalNo;
            dtDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Gendor == (short) enGendor.Male)
            {
                rbMale.Checked = true;

            }
            else rbFemale.Checked = true;

            txtPhone.Text = _Person.phone;

            if(_Person.Email != null)
            txtEmail.Text = _Person.Email;
            
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName) ;
            txtAddress.Text = _Person.Address;

            if(_Person.ImagePath != null)
            pbPersonImage.ImageLocation = _Person.ImagePath;

            llRemoveImage.Visible = (_Person.ImagePath != "");

            




        }
        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMainLabel.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            }
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID.ToString(), "Person Not Found", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            _FillUpdatePerson();

        }
        
        private void _RestDefaultValues()
        {
            _LoadCountriesComboBox();
            _LoadData();
        }
        private void frmAddPerson_Load(object sender, EventArgs e)
        {
            _RestDefaultValues();
           

            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.Value = dtDateOfBirth.MaxDate;
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtDateOfBirth.Format = DateTimePickerFormat.Custom; // Set to custom format

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void txtNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNationalNumber.Text.Length == 0 && char.IsNumber(e.KeyChar))
            {
                e.Handled = true; // Prevent the number from being entered as the first character
            }
        }

        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNumber.Text))
            {
                e.Cancel = true;
                txtNationalNumber.Focus();
                errorProvider1.SetError(txtNationalNumber, $"National Number is Empty !");
            }
            if (clsPerson.isPersonExist(txtNationalNumber.Text) && _Mode == enMode.AddNew)
            {
                e.Cancel = true;
                txtNationalNumber.Focus();
                errorProvider1.SetError(txtNationalNumber, "National Number is used for another Person!");
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError(txtNationalNumber,"");
            }
        }

        private void GendorCheck_CheckedChanged(object sender, EventArgs e)
        {


            if (pbPersonImage.ImageLocation == null)
            {
                if (rbFemale.Checked)
                {

                    pbPersonImage.Image = Properties.Resources.Female_512;
                }
                else
                {
                    pbPersonImage.Image = Properties.Resources.Male_512;
                }
            }

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being added to the TextBox
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                bool isValid = Regex.IsMatch(txtEmail.Text, pattern);

                if (!isValid)
                {
                    e.Cancel = true;
                    txtNationalNumber.Focus();
                    // If the email format is invalid, set the error message
                    errorProvider1.SetError(txtEmail, "Invalid email address format !");
                }
                else
                {
                    e.Cancel = false;
                    // Clear the error if the email format is valid
                    errorProvider1.SetError(txtEmail, string.Empty);
                }
            }
        }
        private void CheckValidData_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox CurrentTextBox = (System.Windows.Forms.TextBox)sender ;
            if (string.IsNullOrEmpty(CurrentTextBox.Text))
            {
                e.Cancel = true;
                txtNationalNumber.Focus();
                errorProvider1.SetError(CurrentTextBox, $"{CurrentTextBox.Tag.ToString()} is Empty !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(CurrentTextBox, "");
            }
        }

        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbPersonImage.Load(selectedFilePath);
               llRemoveImage.Visible = true;
                
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            GendorCheck_CheckedChanged(null, null);
            llRemoveImage.Visible = false;
        }
        private bool _HandlePersonImage()
        {
            try
            {
                if (_Person.ImagePath != pbPersonImage.ImageLocation)
                {
                    if (_Person.ImagePath != "")
                    {
                        //first we delete the old image from the folder in case there is any.

                        try
                        {
                            File.Delete(_Person.ImagePath);
                        }
                        catch (IOException)
                        {
                            // We could not delete the file.
                            //log it later   
                        }
                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
               
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error copying image: " + ex.Message);
            }
            return true;
        }
        
        private bool AddNewEditPerson()
        {

            
                _Person.FirstName = txtFirstName.Text.Trim();
            
             
                _Person.SecondName = txtSecondName.Text.Trim();
            
            
            _Person.ThirdName = txtThirdName.Text.Trim();

            
                _Person.LastName = txtLastName.Text.Trim();
            

            
                _Person.NationalNo = txtNationalNumber.Text.Trim();
           

            _Person.DateOfBirth = dtDateOfBirth.Value;
            _Person.Gendor = (rbMale.Checked==true) ? (short)enGendor.Male : (short)enGendor.Female;

           
                _Person.Address = txtAddress.Text.Trim();
            
            
           
                _Person.phone = txtPhone.Text.Trim();
            
            
                _Person.Email = txtEmail.Text.Trim();
            

            _Person.NationalityCountryID = (int)cbCountry.SelectedIndex ;
            
           
            if (_Person.Save())
            {
                _Mode = enMode.Update;
                DataBack?.Invoke( _Person.PersonID);
                return true;
            }
            return false;

        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            // for ensuring that all data is entered in the form 
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _Person.ImagePath = pbPersonImage.ImageLocation;
            if (!_HandlePersonImage())
            {
                return;
            }
            if (AddNewEditPerson())
                {
                    MessageBox.Show("Data Saved Successfully.");
                
                }
                else
                {
                    MessageBox.Show("Data is not Saved because there are some data not entered");
                }
           

        }

        
    }
}
