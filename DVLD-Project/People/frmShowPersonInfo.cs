using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.People
{
    public partial class frmShowPersonInfo : Form
    {
       
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            
            PersonDetials.LoadPersonInfo(PersonID);


        }
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            
            PersonDetials.LoadPersonInfo(NationalNo);


        }
        private void frmPersonDetials_Load(object sender, EventArgs e)
        {
        }

        private void PersonDetials_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
