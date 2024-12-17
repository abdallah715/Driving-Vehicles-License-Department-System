using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Global_Class
{
    public class clsGlobal

    {
        // we made a file in the system of the Application for saving the Login 
        static public string credentialsFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                            "DVLD-Project",
                        "credentials.txt");
        public static clsUser CurrentUser;

        static public bool LoadUserNameandPassword(ref string UserName , ref string Password)
        {
            try
            {
                if (File.Exists(credentialsFilePath))
                {
                    string combinedCredentials = File.ReadAllText(credentialsFilePath);
                    string[] parts = combinedCredentials.Split(':');
                    if (parts.Length == 2)
                    {
                       UserName = parts[0];
                        Password = parts[1];
                      
                    }
                    return true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading credentials: " + ex.Message);
            }
            return false;
        }
        static public void RememberUserNameandPassword(string username, string password)
        {
            try
            {
                string combinedCredentials = $"{username}:{password}";

                // Ensure directory exists before saving
                string directory = Path.GetDirectoryName(credentialsFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Save the credentials as plain text
                File.WriteAllText(credentialsFilePath, combinedCredentials);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving credentials: " + ex.Message);
            }
        }
        static public void DeleteUserNameandPassword()
        {
            try
            {
                if (File.Exists(credentialsFilePath))
                {
                    File.Delete(credentialsFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting credentials: " + ex.Message);
            }
        }
    }
}
