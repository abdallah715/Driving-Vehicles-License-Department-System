using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int UserID {  get; set; }
        public int PersonID {  get; set; }
        public clsPerson PersonInfo;

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive {  get; set; }

        private clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            this.isActive = isActive;
            Mode = enMode.Update;
        }
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.isActive = false;
            Mode = enMode.AddNew;
        }
        static public DataTable GellAllUsers()
        {
            return clsUserData.GellAllUsers();  
        }
        public static bool isUserExistByUserNameandPassword(string userName, string password)
        {
            return clsUserData.isUserExistByUserNameandPassword(userName, password);
        }

        public static clsUser FindByUserNameAndPassword(string username , string password)
        {

            
            bool isActive = false;
            int PersonID = -1,UserID = -1;
          

            bool IsFound = clsUserData.GetUserInfoByUserNameandPassword
                                (
                                    username, password,ref UserID , ref PersonID , ref isActive
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsUser(UserID,PersonID,username,password,isActive);
            else
                return null;
        }
        public static clsUser FindByUserID(int UserID)
        {


            bool isActive = false;
            string UserName = "", Password = "";
            int PersonID = -1;


            bool IsFound = clsUserData.GetUserInfoByUserID
                                (
                                    UserID, ref PersonID, ref UserName,ref Password, ref isActive
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {


            bool isActive = false;
            string UserName = "", Password = "";
            int UserID = -1;


            bool IsFound = clsUserData.GetUserInfoByPersonID
                                (
                                    PersonID, ref UserID, ref UserName, ref Password, ref isActive
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            else
                return null;
        }
        private bool _AddNewUser()
        {
            // call DataAccessLayer
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            // call DataAccess Layer
            return clsUserData.UpdateUser(this.UserID,this.PersonID, this.UserName, this.Password, this.isActive);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool isExistforPersonID(int PersonID)
        {
            return clsUserData.isExistforPersonID(PersonID);
        }

        public static bool isExist(int UserID)
        {
            return clsUserData.isExist(UserID);
        }
        public static bool isExist(string UserName)
        {
            return clsUserData.isExist(UserName);
        }
       public bool ChangePassword (string NewPassword)
        {
            return clsUserData.ChangePassword(this.UserID, NewPassword);
        }
    }
}
