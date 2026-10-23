using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsPayments
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int PaymentID { get; set; }
        public int ReservationID { get; set; }
        clsReservations ReservationInfo { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public byte Status { get; set; }

        public clsPayments()
        {
            this.PaymentID = -1;
            this.ReservationID = -1;
            this.PaymentDate = DateTime.Now;
            this.Amount = 0;
            this.Status = 0;

            this.Mode = enMode.AddNew;
        }

        private clsPayments(int PaymentID, int ReservationID, DateTime PaymentDate, double Amount, byte Status)
        {
            this.PaymentID = PaymentID;
            this.ReservationID = ReservationID;
            this.ReservationInfo = clsReservations.GetReservationInfoByID(this.ReservationID);
            this.PaymentDate = PaymentDate;
            this.Amount = Amount;
            this.Status = Status;

            this.Mode = enMode.Update;
        }

        public static clsPayments GetPaymentInfoByID(int PaymentID)
        {
            int ReservationID = -1;
            DateTime PaymentDate = DateTime.Now;
            double Amount = 0;
            byte Status = 0;

            if (clsPaymentsData.GetPaymentInfoByID(PaymentID, ref ReservationID, ref PaymentDate, ref Amount, ref Status))
            {
                return new clsPayments(PaymentID, ReservationID, PaymentDate, Amount, Status);
            }
            else
            {
                return null;
            }
        }

        public static clsPayments GetPaymentInfoByReservationID(int ReservationID)
        {
            int PaymentID = -1;
            DateTime PaymentDate = DateTime.Now;
            double Amount = 0;
            byte Status = 0;

            if (clsPaymentsData.GetPaymentInfoByReservationID(ReservationID, ref PaymentID, ref PaymentDate, ref Amount, ref Status))
            {
                return new clsPayments(PaymentID, ReservationID, PaymentDate, Amount, Status);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentsData.AddNewPayment(this.ReservationID, this.PaymentDate, this.Amount, this.Status);

            return (PaymentID != -1);
        }

        private bool _UpdatePayment()
        {
            return clsPaymentsData.UpdatePayment(this.PaymentID, this.ReservationID, this.PaymentDate, this.Amount, this.Status);
        }

        public bool DeletePayment()
        {
            return clsPaymentsData.DeletePayment(this.PaymentID);
        }

        public static bool IsPaymentExistByPaymentID(int PaymentID)
        {
            return clsPaymentsData.IsPaymentExistByPaymentID(PaymentID);
        }

        public static bool IsPaymentExistByReservationID(int ReservationID)
        {
            return clsPaymentsData.IsPaymentExistByReservationID(ReservationID);
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentsData.GetAllPayments();
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePayment();


            }

            return false;
        }

    }
}
