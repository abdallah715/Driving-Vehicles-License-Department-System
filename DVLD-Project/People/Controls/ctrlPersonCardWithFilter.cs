using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public clsPerson Person;

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action <int> handle = OnPersonSelected;
            if(handle != null)
            {
                handle(PersonID);
            }
        }

        // for interacting externally with Buttons of the control 
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set 
            {
                _ShowAddPerson=value;
                pbAddNewPerson.Visible = _ShowAddPerson;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Visible = _FilterEnabled;
            }
        }
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private enum enFilterData
        {
            
            NationalNo = 0,
            PersonID = 1
           

        };
        private enFilterData _CurrentFilter = enFilterData.NationalNo;
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterData.SelectedIndex = 0;
            txtSearchText.Focus();
        }
        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentFilter = (enFilterData)cbFilterData.SelectedIndex;
            txtSearchText.Text = "";
        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) pbSearchPerson_Click(null,null);
            if (_CurrentFilter == enFilterData.PersonID)
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
        public void LoadByPersonID(int PersonID)
        {
            cbFilterData.SelectedIndex = 1;
            txtSearchText.Text = PersonID.ToString();
            gbFilter.Enabled = false;

            _CurrentFilter = enFilterData.PersonID;
            pbSearchPerson_Click(null, null);
        }

       public void FilterFocus()
        {
            txtSearchText.Focus();
        }
        private void pbSearchPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchText.Text))
            {
                MessageBox.Show("Please enter text to Find a Person");
            }
            else
            {
                
                string TextWritten = txtSearchText.Text.Trim();
                if (_CurrentFilter == enFilterData.NationalNo && clsPerson.isPersonExist(TextWritten))
                {
                    Person = clsPerson.Find(TextWritten);
                    ctrlPersonCard1.LoadPersonInfo(TextWritten);
                    ctrlPersonCard1.Enabled = true;
                }
                else if(_CurrentFilter == enFilterData.PersonID && clsPerson.isPersonExist(int.Parse(TextWritten)))
                {
                    Person = clsPerson.Find(int.Parse(TextWritten));
                    
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(TextWritten));
                    ctrlPersonCard1.Enabled = true;
                }
                else
                {
                    if(_CurrentFilter == enFilterData.PersonID)
                    MessageBox.Show($"No Person with Person ID {TextWritten} !", "Person Card");
                    else MessageBox.Show($"No Person with National No {TextWritten} !", "Person Card");

                }
            }
        }

        private void pbAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.DataBack += FrmAddEditPerson_DataBack;// Subscribe to the Event 

            frm.ShowDialog();
           
        }
        private void FrmAddEditPerson_DataBack( int PersonID)
        {
            // Handling the data recived from the Form2 
            cbFilterData.SelectedIndex = 1;
            txtSearchText.Text = PersonID.ToString();
            Person = clsPerson.Find(PersonID);
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }


    }
}
