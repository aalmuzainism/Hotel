using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsReservationRooms
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int ReservationRoomID { get; set; }
        public int ReservationID { get; set; }
        public clsReservations ReservationInfo { get; set; }
        public int RoomID { get; set; }
        public clsRooms RoomInfo { get; set; }
        public DateTime CheckInDate { get; set; }
        public int CheckInBy { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ActualCheckOutDate { get; set; }
        public int CheckOutBy { get; set; }
        public byte Status { get; set; }



        public clsReservationRooms()
        {
            this.ReservationRoomID = -1;
            this.ReservationID = -1;
            this.RoomID = -1;
            this.CheckInDate = DateTime.MaxValue;
            this.CheckInBy = -1;
            this.CheckOutDate = DateTime.MaxValue;
            this.ActualCheckOutDate = DateTime.MaxValue;
            this.CheckOutBy = -1;
            this.Status = 0;

            this.Mode = enMode.AddNew;
        }

        private clsReservationRooms(int ReservationRoomID, int ReservationID, int RoomID, DateTime CheckInDate, int CheckInBy,
                                                    DateTime CheckOutDate, DateTime ActualCheckOutDate, int CheckOutBy, byte Status)
        {
            this.ReservationRoomID = ReservationRoomID;
            this.ReservationID = ReservationID;
            this.ReservationInfo = clsReservations.GetReservationInfoByID(ReservationID);
            this.RoomID = RoomID;
            this.RoomInfo = clsRooms.GetRoomInfoByID(RoomID);
            this.CheckInDate = CheckInDate;
            this.CheckInBy = CheckInBy;
            this.CheckOutDate = CheckOutDate;
            this.ActualCheckOutDate = ActualCheckOutDate;
            this.CheckOutBy = CheckOutBy;
            this.Status = Status;

            this.Mode = enMode.Update;
        }

        public static clsReservationRooms GetReservationRoomInfoByID(int ReservationRoomID)
        {
            int ReservationID = -1, RoomID = -1, CheckInBy = -1, CheckOutBy = -1;
            byte Status = 0;
            DateTime CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now, ActualCheckOutDate = DateTime.MaxValue;

            if (clsReservationRoomsData.GetReservationRoomInfoByID(ReservationRoomID, ref ReservationID, ref RoomID, ref CheckInDate, ref CheckInBy,
                                                    ref CheckOutDate, ref ActualCheckOutDate, ref CheckOutBy, ref Status))
            {
                return new clsReservationRooms(ReservationRoomID, ReservationID, RoomID, CheckInDate, CheckInBy,
                                                           CheckOutDate, ActualCheckOutDate, CheckOutBy, Status);
            }
            else
            {
                return null;
            }
        }

        public static clsReservationRooms GetReservationRoomWithDateByRoomNumber(int RoomID, DateTime CheckInDate, DateTime CheckOutDate)
        {
            int ReservationRoomID = -1, ReservationID = -1, CheckInBy = -1, CheckOutBy = -1;
            byte Status = 0;
            DateTime ActualCheckOutDate = DateTime.MaxValue;

            if (clsReservationRoomsData.GetReservationRoomWithDateByRoomNumber(RoomID, ref CheckInDate, ref CheckOutDate, ref ReservationRoomID, ref ReservationID,
                                                    ref CheckInBy, ref ActualCheckOutDate, ref CheckOutBy, ref Status))
            {
                return new clsReservationRooms(ReservationRoomID, ReservationID, RoomID, CheckInDate, CheckInBy,
                                                           CheckOutDate, ActualCheckOutDate, CheckOutBy, Status);
            }
            else
            {
                return null;
            }
        }

        public static clsReservationRooms GetReservationRoomInfoByRoomID(int RoomID)
        {
            int ReservationRoomID = -1, ReservationID = -1, CheckInBy = -1, CheckOutBy = -1;
            byte Status = 0;
            DateTime CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now, ActualCheckOutDate = DateTime.MaxValue;

            if (clsReservationRoomsData.GetReservationRoomInfoByRoomID(RoomID, ref ReservationRoomID, ref ReservationID, ref CheckInDate, ref CheckInBy,
                                                    ref CheckOutDate, ref ActualCheckOutDate, ref CheckOutBy, ref Status))
            {
                return new clsReservationRooms(ReservationRoomID, ReservationID, RoomID, CheckInDate, CheckInBy,
                                                           CheckOutDate, ActualCheckOutDate, CheckOutBy, Status);
            }
            else
            {
                return null;
            }
        }

        public static clsReservationRooms GetReservationRoomInfoByRoomIDForCheckIn(int RoomID)
        {
            int ReservationRoomID = -1, ReservationID = -1, CheckInBy = -1, CheckOutBy = -1;
            byte Status = 0;
            DateTime CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now, ActualCheckOutDate = DateTime.MaxValue;

            if (clsReservationRoomsData.GetReservationRoomInfoByRoomID(RoomID, ref ReservationRoomID, ref ReservationID, ref CheckInDate, ref CheckInBy,
                                                    ref CheckOutDate, ref ActualCheckOutDate, ref CheckOutBy, ref Status))
            {
                return new clsReservationRooms(ReservationRoomID, ReservationID, RoomID, CheckInDate, CheckInBy,
                                                           CheckOutDate, ActualCheckOutDate, CheckOutBy, Status);
            }
            else
            {
                return null;
            }
        }

        public static clsReservationRooms GetReservationRoomInfoByRoomIDForCheckOut(int RoomID)
        {
            int ReservationRoomID = -1, ReservationID = -1, CheckInBy = -1, CheckOutBy = -1;
            byte Status = 0;
            DateTime CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now, ActualCheckOutDate = DateTime.MaxValue;

            if (clsReservationRoomsData.GetReservationRoomInfoByRoomID(RoomID, ref ReservationRoomID, ref ReservationID, ref CheckInDate, ref CheckInBy,
                                                    ref CheckOutDate, ref ActualCheckOutDate, ref CheckOutBy, ref Status))
            {
                return new clsReservationRooms(ReservationRoomID, ReservationID, RoomID, CheckInDate, CheckInBy,
                                                           CheckOutDate, ActualCheckOutDate, CheckOutBy, Status);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewReservationRoom()
        {
            this.ReservationRoomID = clsReservationRoomsData.AddNewReservationRoom(this.ReservationID, this.RoomID, this.CheckInDate, this.CheckOutDate, this.Status);

            return (ReservationRoomID != -1);
        }

        private bool _UpdateReservationRoom()
        {
            return clsReservationRoomsData.UpdateReservationRoom(this.ReservationRoomID, this.ReservationID, this.RoomID, this.CheckInDate, this.CheckOutDate, this.Status);
        }

        public bool DeleteReservationRoom(int ReservationRoomID)
        {
            return clsReservationRoomsData.DeleteReservationRoom(this.ReservationRoomID);
        }

        public static bool IsReservationRoomExist(int ReservationRoomID)
        {
            return clsReservationRoomsData.IsReservationRoomExist(ReservationRoomID);
        }

        public static DataTable GetAllReservationRooms()
        {
            return clsReservationRoomsData.GetAllReservationRooms();
        }

        public static DataTable GetAllAvailableRooms(DateTime CheckInDate, DateTime CheckOutDate)
        {
            return clsReservationRoomsData.GetAllAvailableRooms(CheckInDate, CheckOutDate);
        }

        public static DataTable GetAllAvailableRoomsWithRoomCount(byte RoomCount, DateTime CheckInDate, DateTime CheckOutDate)
        {
            return clsReservationRoomsData.GetAllAvailableRoomsWithRoomCount(RoomCount, CheckInDate, CheckOutDate);
        }

        public static bool IsRoomBooked(int RoomID)
        {
            return clsReservationRoomsData.IsRoomBooked(RoomID);
        }

        public static bool IsReservationRoomWithDateByRoomNumber(int RoomNumber, DateTime CheckInDate, DateTime CheckOutDate)
        {
            return clsReservationRoomsData.IsReservationRoomWithDateByRoomNumber(RoomNumber, CheckInDate, CheckOutDate);
        }

        public bool CheckIn(int CheckInBy)
        {

            if (!clsReservationRoomsData.IsReservationRoomNotCheckedIn(this.ReservationRoomID))
            {
                return false;
            }

            if (this.CheckInDate.Date >= DateTime.Now.Date && this.CheckInDate <= DateTime.Now.Date)
            {
                return false;
            }

            this.CheckInBy = CheckInBy;

            return clsReservationRoomsData.CheckIn(this.ReservationRoomID, CheckInBy);
        }

        public bool CheckOut(int CheckOutBy)
        {

            if (!clsReservationRoomsData.IsReservationRoomCheckedIn(this.ReservationRoomID))
            {
                return false;
            }

            this.ActualCheckOutDate = DateTime.Now;
            this.CheckOutBy = CheckOutBy;

            return clsReservationRoomsData.CheckOut(this.ReservationRoomID, this.ActualCheckOutDate, CheckOutBy);
        }

        public bool Cancel()
        {
            if (clsReservationRoomsData.IsReservationRoomNotCheckedIn(this.ReservationRoomID))
            {
                return clsReservationRoomsData.Cancel(this.ReservationRoomID);
            }

            return false;
        }

        public static DataTable GetAllReservationRoomsCheckInToday(DateTime CheckInDate)
        {
            return clsReservationRoomsData.GetAllReservationRoomsCheckInToday(CheckInDate);
        }

        public static DataTable GetAllReservationRoomsCheckOutToday(DateTime CheckOutDate)
        {
            return clsReservationRoomsData.GetAllReservationRoomsCheckOutToday(CheckOutDate);
        }

        public static DataTable GetAllReservationRoomsForPersonByNationalID(string NationalID)
        {
            return clsReservationRoomsData.GetAllReservationRoomsForPersonByNationalID(NationalID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReservationRoom())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateReservationRoom();

            }

            return false;
        }

    }
}