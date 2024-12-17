using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_BussinessLayer;
using System.Runtime.InteropServices;

namespace DVLD_Project.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        private void _ResetPersonInfo()
        {
            lblPersonID.Text = "[???]";
            lblName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGendor.Text = "[???]";
            lblEmail.Text = "[???]";
            lblAddress.Text = "[???]";
            lblPhone.Text = "[???]";
            lblCountry.Text = "[???]";
            pbGendor.ImageLocation = null;
            pbGendor.Image = Properties.Resources.Male_512;
        }
        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName();
            if(_Person.Gendor == 0)
            {
                pbGendor.Image = Properties.Resources.Man_32;
                lblGendor.Text = "Male";
            }
            else
            {
                pbGendor.Image = Properties.Resources.Woman_32;
                lblGendor.Text = "Female";
            }
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.phone;
            lblCountry.Text = clsCountry.GetCountryName(_Person.NationalityCountryID);
            pbGendor.ImageLocation = _Person.ImagePath;
        }
        public void LoadPersonInfo(int  PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillPersonInfo();
            }

        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillPersonInfo();
            }

        }

        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frmAddUpdate = new frmAddUpdatePerson(_PersonID);
            frmAddUpdate.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
