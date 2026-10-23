using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsUsers
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = false;

            this.Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.GetPersonInfoByID(this.PersonID);
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            this.Mode = enMode.Update;
        }

        public static clsUsers GetUserInfoByID(int UserID)
        {
            int PersonID = -1;
            string Username = "", Password = "";
            bool IsActive = false;

            if (clsUsersData.GetUserInfoByID(UserID, ref PersonID, ref Username, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, Username, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUsers GetUserInfoByPersonID(int PersonID)
        {
            int UserID = -1;
            string Username = "", Password = "";
            bool IsActive = false;

            if (clsUsersData.GetUserInfoByPersonID(PersonID, ref UserID, ref Username, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, Username, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.Username, this.Password, this.IsActive);

            return (UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.PersonID, this.Username, this.Password, this.IsActive);
        }

        public bool DeleteUser()
        {
            return clsUsersData.DeleteUser(this.UserID);
        }

        public static bool IsUserExistByUserID(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
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

    }
}
