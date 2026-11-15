using HotelBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPresentationLayer
{
    public partial class frmAddUpdatePayment : Form
    {
        private clsReservations _Reservation;

        private clsReservationRooms _ReservationRoom;

        private int _ReservationID;

        public frmAddUpdatePayment(int ReservationID)
        {
            InitializeComponent();

            _ReservationID = ReservationID;
        }

        private void _ResetControls()
        {
            lblPaymentID.Text = "[???]";
            lblReservationID.Text = "[???]";
            lnklblNationalID.Text = "[???]";
            lblReservedUnits.Text = "[???]";
            lblReservationDate.Text = "[???]";
            lblCheckInDate.Text = "[???]";
            lblCheckOutDate.Text = "[???]";
            lblTotalAmount.Text = "[???]";
        }

        private void _FillData()
        {
            if (_Reservation != null && _ReservationRoom != null)
            {
                lblReservationID.Text = _Reservation.ReservationID.ToString();
                lnklblNationalID.Text = _Reservation.PersonInfo.NationalID.ToString();
                lblReservedUnits.Text = clsReservationRooms.GetCountReservationRoomByReservationID(_Reservation.ReservationID).ToString();
                lblReservationDate.Text = _Reservation.ReservationDate.ToShortDateString();
                lblCheckInDate.Text = _ReservationRoom.CheckInDate.ToShortDateString();
                lblCheckOutDate.Text = _ReservationRoom.CheckOutDate.ToShortDateString();
                lblTotalAmount.Text = clsPayments.GetTotalAmountByReservationID(_Reservation.ReservationID).ToString();
            }
        }

        private void frmAddUpdatePayment_Load(object sender, EventArgs e)
        {
            _ResetControls();

            if (_ReservationID != -1 && _ReservationID != null)
            {
                // Load Data in Object
                _Reservation = clsReservations.GetReservationInfoByID(_ReservationID);
                _ReservationRoom = clsReservationRooms.GetReservationRoomInfoByReservationID(_ReservationID);

                _FillData();
            }
            else
                this.Close();
        }
    }
}