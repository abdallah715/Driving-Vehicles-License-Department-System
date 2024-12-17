﻿using DVLD_BussinessLayer;
using DVLD_Project.Licenses.International_Licenses;
using DVLD_Project.Licenses.Local_licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;

        private DataTable _dtLocalDrvingLicenses;
        private DataTable _dtInternationalDrvingLicenses;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        private void _LoadLocalLicenseInfo()
        {
            _dtLocalDrvingLicenses = clsDriver.GetLicenses(_DriverID);
            dgvLocalLicensesHistory.DataSource = _dtLocalDrvingLicenses;
            lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();
            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;

            }

        }
        private void _LoadInternationalLicenseInfo()
        {
            _dtInternationalDrvingLicenses = clsDriver.GetInternationalLicenses(_DriverID);


            dgvInternationalLicensesHistory.DataSource = _dtInternationalDrvingLicenses ;
            lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 160;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 130;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 130;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 180;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 180;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 120;

            }
        }
        public void LoadInfoByPersonID(int PersonID)
        {

            _Driver = clsDriver.FindByPersonID(PersonID);
            
            if (_Driver == null)
            {
                MessageBox.Show("There is no driver with Person ID = " + PersonID.ToString());
                return;
            }
            _DriverID = _Driver.DriverID;
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }
        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(DriverID);
            if (_Driver == null)
            {
                MessageBox.Show("There is no driver with driver ID = " + DriverID.ToString());
                return;
            }
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cmsLocalLicenseHistory_Opening(object sender, CancelEventArgs e)
        {
            if(dgvLocalLicensesHistory.Rows.Count ==0)
            {
                showLicenseInfoToolStripMenuItem.Enabled = false; return;
            }
            else showLicenseInfoToolStripMenuItem.Enabled=true;
        }
        public void Clear()
        {
            _dtLocalDrvingLicenses.Clear();
            _dtInternationalDrvingLicenses.Clear();
        }
        private void cmsInterenationalLicenseHistory_Opening(object sender, CancelEventArgs e)
        {
            if (dgvInternationalLicensesHistory.Rows.Count == 0)
            {
                InternationalLicenseHistorytoolStripMenuItem.Enabled = false; return;
            }
            else InternationalLicenseHistorytoolStripMenuItem.Enabled = true;
        }
    }
}
