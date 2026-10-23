using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1}
        public enMode Mode = enMode.AddNew;

        public  int PersonID {  get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName { get;}
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalID = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Phone = "";
            this.DateOfBirth = DateTime.Now.Date;
            this.Email = "";

            this.Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalID, string FirstName, string SecondName,
            string ThirdName, string LastName, string Phone, DateTime DateOfBirth, string Email)
        {
            this.PersonID = PersonID;
            this.NationalID = NationalID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.FullName = this.FirstName + " " + this.SecondName + (ThirdName != "" ? " " + this.ThirdName + " " : " ") + this.LastName ; 
            this.Phone = Phone;
            this.DateOfBirth = DateOfBirth;
            this.Email = Email;

            this.Mode = enMode.Update;
        }

        public static clsPerson GetPersonInfoByID(int PersonID)
        {
            string NationalID = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "";
            DateTime DateOfBirth = DateTime.Now.Date;

            if(clsPersonData.GetPersonInfoByID(PersonID, ref NationalID, ref FirstName, ref SecondName, ref ThirdName,
                                                    ref LastName, ref Phone, ref DateOfBirth, ref Email))
            {
                return new clsPerson(PersonID, NationalID, FirstName, SecondName, ThirdName, LastName, Phone, DateOfBirth, Email);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson GetPersonInfoByNationalID(string NationalID)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "";
            DateTime DateOfBirth = DateTime.Now.Date;

            if (clsPersonData.GetPersonInfoByNationalID(NationalID, ref PersonID, ref FirstName, ref SecondName, ref ThirdName,
                                                    ref LastName, ref Phone, ref DateOfBirth, ref Email))
            {
                return new clsPerson(PersonID, NationalID, FirstName, SecondName, ThirdName, LastName, Phone, DateOfBirth, Email);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalID, this.FirstName, this.SecondName,
                                this.ThirdName, this.LastName, this.Phone, this.DateOfBirth, this.Email);

            return (PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalID, this.FirstName, this.SecondName,
                                      this.ThirdName, this.LastName, this.Phone, this.DateOfBirth, this.Email);
        }

        public bool DeletePerson()
        {
            return clsPersonData.DeletePerson(this.PersonID);
        }

        public static bool IsPersonExistByPersonID(int PersonID)
        {
            return clsPersonData.IsPersonExistByPersonID(PersonID);
        }

        public static bool IsPersonExistByNationalID(string NationalID)
        {
            return clsPersonData.IsPersonExistByNationalID(NationalID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public bool Save()
        {

            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();

                
            }

            return false;
        }

    }
}
