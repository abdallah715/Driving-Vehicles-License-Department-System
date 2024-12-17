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
using DVLD_Project.Applications;

namespace DVLD_Project.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            dgvManageTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblNoOfRecords.Text = dgvManageTestTypes.Rows.Count.ToString();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                
                frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvManageTestTypes.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
               frmManageTestTypes_Load(null, null);
            
        }
    }
}
