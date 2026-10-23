using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsReservations
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int ReservationID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
        public byte Status { get; set; }



        public clsReservations()
        {
            this.ReservationID = -1;
            this.PersonID = -1;
            this.ReservationDate = DateTime.Now;
            this.Notes = "";
            this.CreatedBy = -1;
            this.Status = 0;

            this.Mode = enMode.AddNew;
        }

        private clsReservations(int ReservationID, int PersonID, DateTime ReservationDate, string Notes, int CreatedBy, byte Status)
        {
            this.ReservationID = ReservationID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.GetPersonInfoByID(PersonID);
            this.ReservationDate = ReservationDate;
            this.Notes = Notes;
            this.CreatedBy = CreatedBy;
            this.Status = Status;

            this.Mode = enMode.Update;
        }

        public static clsReservations GetReservationInfoByID(int ReservationID)
        {
            int PersonID = -1;
            DateTime ReservationDate = DateTime.Now.Date;
            string Notes = "";
            int CreatedBy = -1;
            byte Status = 0;

            if (clsReservationsData.GetReservationInfoByID(ReservationID, ref PersonID, ref ReservationDate, ref Notes, ref CreatedBy, ref Status))
            {
                return new clsReservations(ReservationID, PersonID, ReservationDate, Notes, CreatedBy, Status);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewReservation()
        {
            this.ReservationID = clsReservationsData.AddNewReservation(this.PersonID, this.ReservationDate, this.Notes, this.CreatedBy, this.Status);

            return (ReservationID != -1);
        }

        private bool _UpdateReservation()
        {
            return clsReservationsData.UpdateReservation(this.ReservationID, this.PersonID, this.ReservationDate, this.Notes, this.CreatedBy, this.Status);
        }

        public bool DeleteReservation()
        {
            return clsReservationsData.DeleteReservation(this.ReservationID);
        }

        public static bool IsReservationExist(int ReservationID)
        {
            return clsReservationsData.IsReservationExist(ReservationID);
        }

        public static DataTable GetAllReservations()
        {
            return clsReservationsData.GetAllReservations();
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReservation())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateReservation();

            }

            return false;
        }

    }
}
