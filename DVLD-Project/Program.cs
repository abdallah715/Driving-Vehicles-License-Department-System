using DVLD_Project.Applications;
using DVLD_Project.Applications.International_Application;
using DVLD_Project.Applications.Local_Driving_License_Application;
using DVLD_Project.Applications.Release_Detained_license_Application;
using DVLD_Project.Applications.Renew_Local_Driving_License_Application;
using DVLD_Project.Applications.Replacement_For_Lost_or_Damaged_Application;
using DVLD_Project.Licenses.Detain_Licenses;
using DVLD_Project.Login;
using DVLD_Project.People;
using DVLD_Project.Tests;
using DVLD_Project.TestTypes;
using DVLD_Project.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            Application.Run(new frmLoginScreen());
            



        }
    }
}
