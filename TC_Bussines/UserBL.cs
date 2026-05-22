using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_DataAccess;

namespace TC_Bussines
{
   public class UserBL
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public string UserName { set; get; }
        public string PasswordHash { set; get; }
        public bool IsActive { set; get; }
        
        public UserBL()
        {
            this.UserID = -1;
            this.UserName = "";
            this.PasswordHash = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private UserBL(int userID, string userName, string passwordHash, bool isActive)
        {
            UserID = userID;
            UserName = userName;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }

        public static UserBL FindByUserID(int userID)
        {
            string userName = "", passwordHash = "";

            bool isActive = false;

            bool IsFound = clsUser.GetUserInfoByUserID(userID,ref userName, ref isActive);

            if (IsFound)
                //we return new object of that person with the right data
                return new UserBL(userID, userName, passwordHash, isActive);
            else
                return null;

        }

        public static UserBL FindByUserNameAndPassword(string UserName, string passwordHash)
        {

            int  UserID = -1;
            bool isActive = false;


            bool IsFound = clsUser.GetUserInfoByUsernameAndPassword(UserName,passwordHash, ref UserID, ref isActive);

            if (IsFound)
                //we return new object of that person with the right data
                return new UserBL(UserID, UserName, passwordHash, isActive);
            else
                return null;

        }

        private bool _AddNewUser()
        {
            this.UserID = clsUser.AddNewUser( this.UserName, HashClass.HashMethod(this.PasswordHash), this.IsActive);

            return (this.UserID != -1);
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

        private bool _UpdateUser()
        {
            return clsUser.UpdateUser(this.UserID , this.UserName, HashClass.HashMethod(this.PasswordHash), this.IsActive);
        }

        public static DataTable GetAllUsers()
        {
            return clsUser.GetAllUsers();
        }

        public static bool DeleteUser(int ID)
        {
            return clsUser.DeleteUser(ID);
        }

        public static bool isUserExist(int ID)
        {
            return clsUser.IsUserExist(ID);
        }
        
        public static bool ChangePassword(int UserID, string Password)
        {
            return clsUser.ChangePassword(UserID, HashClass.HashMethod(Password));
        }
       
    }
}
