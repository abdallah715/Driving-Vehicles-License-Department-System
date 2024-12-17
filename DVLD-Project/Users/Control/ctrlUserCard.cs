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

namespace DVLD_Project.User.Control
{
    public partial class ctrlUserCard : UserControl
    {
        clsUser _User;
        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {

        }
        private void _ResetUserInfo()
        {
            lblUserID.Text = "[???]";
            lblUsername.Text = "[???]";
            lblIsActive.Text = "[???]";
        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName;
            if(_User.isActive)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
        }
        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;

            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillUserInfo();
            }
        }
    }
}
