using DVLD_BussinessLayer;
using DVLD_Project.Global_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Login
{
    public partial class frmLoginScreen : Form
    {
       

        
        enum enMode { DeActive = 0, Active = 1 };
        public frmLoginScreen()
        {
            InitializeComponent();
            
        }
      
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void _ResetScreen()
        {
            txtUserName.Text = "";
            txtpassword.Text = "";
            txtUserName.Focus();
            chkRemeberMe.Checked = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Ensuring All Data Required Entered 
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Please Enter all data required First!");
            }



            else
            {
                clsUser User = clsUser.FindByUserNameAndPassword(txtUserName.Text.Trim(), txtpassword.Text.Trim());
                if (User != null)
                {
                    // Checking the Activition of The User
                    if(Convert.ToByte(User.isActive) == (byte)enMode.Active )
                    {
                        if (chkRemeberMe.Checked) clsGlobal.RememberUserNameandPassword(txtUserName.Text.Trim(), txtpassword.Text.Trim());
                        else clsGlobal.DeleteUserNameandPassword();

                        clsGlobal.CurrentUser = User;
                        this.Hide();
                        FrmMainScreen frmMainScreen = new FrmMainScreen(this);
                        
                        frmMainScreen.ShowDialog();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _ResetScreen();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username/Password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    _ResetScreen();
                }
            }
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string Password = "";
            if(clsGlobal.LoadUserNameandPassword(ref UserName,ref Password))
            {
                txtUserName.Text = UserName;
                txtpassword.Text = Password;
                chkRemeberMe.Checked = true;
            }
            else
            {
                chkRemeberMe.Checked= false;
            }
        }
    }
}
