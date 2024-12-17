using DVLD_BussinessLayer;
using DVLD_Project.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications
{
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvManageApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypes();
            lblNoOfRecords.Text = dgvManageApplicationTypes.Rows.Count.ToString();
        }

        private void dgvManageApplicationTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
               
                frmEditApplicaionType frm = new frmEditApplicaionType((int)dgvManageApplicationTypes.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                frmListApplicationTypes_Load(null, null);
            
        }
    }
}
