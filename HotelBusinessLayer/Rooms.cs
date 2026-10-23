using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsRooms
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public clsRoomTypes RoomTypeInfo { get; set; }
        public int RoomNumber { get; set; }
        public byte KingBedCount { get; set; }
        public byte RoomCount { get; set; }
        public byte SingleBedCount { get; set; }
        public byte LivingRoomCount { get; set; }
        public byte BathroomCount { get; set; }
        public byte FullKitchenCount { get; set; }
        public byte KitchenetteCount { get; set; }
        public double Price { get; set; }


        public clsRooms()
        {
            this.RoomID = -1;
            this.RoomTypeID = 0;
            this.RoomNumber = 0;
            this.RoomCount = 0;
            this.KingBedCount = 0;
            this.SingleBedCount = 0;
            this.LivingRoomCount = 0;
            this.BathroomCount = 0;
            this.FullKitchenCount = 0;
            this.KitchenetteCount = 0;
            this.Price = 0;

            this.Mode = enMode.AddNew;
        }

        private clsRooms(int RoomID, int RoomTypeID, int RoomNumber, byte RoomCount, byte KingBedCount, byte SingleBedCount, byte LivingRoomCount,
                                                     byte BathroomCount, byte FullKitchenCount, byte KitchenetteCount, double Price)
        {
            this.RoomID = RoomID;
            this.RoomTypeID = RoomTypeID;
            this.RoomNumber = RoomNumber;
            this.RoomTypeInfo = clsRoomTypes.GetRoomTypeInfoByID(this.RoomTypeID);
            this.RoomCount = RoomCount;
            this.KingBedCount = KingBedCount;
            this.SingleBedCount = SingleBedCount;
            this.LivingRoomCount = LivingRoomCount;
            this.BathroomCount = BathroomCount;
            this.FullKitchenCount = FullKitchenCount;
            this.KitchenetteCount = KitchenetteCount;
            this.Price = Price;

            this.Mode = enMode.Update;
        }

        public static clsRooms GetRoomInfoByID(int RoomID)
        {
            int RoomNumber = -1;
            byte RoomTypeID = 0, RoomCount = 0, KingBedCount = 0, SingleBedCount = 0, LivingRoomCount = 0, BathroomCount = 0, FullKitchenCount = 0, KitchenetteCount = 0;
            double Price = 0;

            if (clsRoomsData.GetRoomInfoByID(RoomID, ref RoomTypeID, ref RoomNumber, ref RoomCount, ref KingBedCount, ref SingleBedCount,
                            ref LivingRoomCount, ref BathroomCount, ref FullKitchenCount, ref KitchenetteCount, ref Price))
            {
                return new clsRooms(RoomID, RoomTypeID, RoomNumber, RoomCount, KingBedCount, SingleBedCount, LivingRoomCount,
                                                        BathroomCount, FullKitchenCount, KitchenetteCount, Price);
            }
            else
            {
                return null;
            }
        }

        public static clsRooms GetRoomInfoByRoomNumber(int RoomNumber)
        {
            int RoomID = -1;
            byte RoomTypeID = 0, RoomCount = 0, KingBedCount = 0, SingleBedCount = 0, LivingRoomCount = 0, BathroomCount = 0, FullKitchenCount = 0, KitchenetteCount = 0;
            double Price = 0;

            if (clsRoomsData.GetRoomInfoByRoomNumber(RoomNumber, ref RoomID, ref RoomTypeID, ref RoomCount, ref KingBedCount, ref SingleBedCount,
                            ref LivingRoomCount, ref BathroomCount, ref FullKitchenCount, ref KitchenetteCount, ref Price))
            {
                return new clsRooms(RoomID, RoomTypeID, RoomNumber, RoomCount, KingBedCount, SingleBedCount, LivingRoomCount,
                                                        BathroomCount, FullKitchenCount, KitchenetteCount, Price);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewRoom()
        {
            this.RoomID = clsRoomsData.AddNewRoom(this.RoomTypeID, this.RoomNumber, this.RoomCount, this.KingBedCount, this.SingleBedCount,
                                            this.LivingRoomCount, this.BathroomCount, this.FullKitchenCount, this.KitchenetteCount, this.Price);

            return (RoomID != -1);
        }

        private bool _UpdateRoom()
        {
            return clsRoomsData.UpdateRoom(this.RoomID, this.RoomTypeID, this.RoomNumber, this.RoomCount, this.KingBedCount, this.SingleBedCount,
                                            this.LivingRoomCount, this.BathroomCount, this.FullKitchenCount, this.KitchenetteCount, this.Price);
        }

        public bool DeleteRoomByID()
        {
            return clsRoomsData.DeleteRoomByID(this.RoomID);
        }

        public bool DeleteRoomByRoomNumber()
        {
            return clsRoomsData.DeleteRoomByRoomNumber(this.RoomNumber);
        }

        public static bool IsRoomExistByRoomID(int RoomID)
        {
            return clsRoomsData.IsRoomExistByRoomID(RoomID);
        }

        public static bool IsRoomExistByRoomNumber(int RoomNumber)
        {
            return clsRoomsData.IsRoomExistByRoomNumber(RoomNumber);
        }

        public static DataTable GetAllRooms()
        {
            return clsRoomsData.GetAllRooms();
        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:
                    if (_AddNewRoom())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateRoom();


            }

            return false;
        }

    }
}
