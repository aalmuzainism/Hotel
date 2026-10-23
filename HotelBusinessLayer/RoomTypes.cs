using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsRoomTypes
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int RoomTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public clsRoomTypes()
        {
            this.RoomTypeID = -1;
            this.Name = "";
            this.Description = "";

            this.Mode = enMode.AddNew;
        }

        private clsRoomTypes(int RoomTypeID, string Name, string Description)
        {
            this.RoomTypeID = RoomTypeID;
            this.Name = Name;
            this.Description = Description;

            this.Mode = enMode.Update;
        }



        public static clsRoomTypes GetRoomTypeInfoByID(int RoomTypeID)
        {
            string Name = "", Description = "";

            if (clsRoomTypesData.GetRoomTypeInfoByID(RoomTypeID, ref Name, ref Description))
            {
                return new clsRoomTypes(RoomTypeID, Name, Description);
            }
            else
            {
                return null;
            }
        }

        public static clsRoomTypes GetRoomTypeInfoByName(string Name)
        {
            int RoomTypeID = -1;
            string Description = "";

            if (clsRoomTypesData.GetRoomTypeInfoByName(Name, ref RoomTypeID, ref Description))
            {
                return new clsRoomTypes(RoomTypeID, Name, Description);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewRoomType()
        {
            this.RoomTypeID = clsRoomTypesData.AddNewRoomType(this.Name, this.Description);

            return (RoomTypeID != -1);
        }

        private bool _UpdateRoomType()
        {
            return clsRoomTypesData.UpdateRoomType(this.RoomTypeID, this.Name, this.Description);
        }

        public static bool DeleteRoomType(int RoomTypeID)
        {
            return clsRoomTypesData.DeleteRoomType(RoomTypeID);
        }

        public static bool IsRoomTypeExist(int RoomTypeID)
        {
            return clsRoomTypesData.IsRoomTypeExist(RoomTypeID);
        }

        public static DataTable GetAllRoomTypes()
        {
            return clsRoomTypesData.GetAllRoomTypes();
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoomType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateRoomType();


            }

            return false;
        }

    }
}
