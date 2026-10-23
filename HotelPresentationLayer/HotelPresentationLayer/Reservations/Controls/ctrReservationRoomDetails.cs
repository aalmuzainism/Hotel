using HotelBusinessLayer;
using HotelPresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPresentationLayer.Reservations.Controls
{
    public partial class ctrReservationRoomDetails : UserControl
    {

        private clsReservationRooms _ReservationRoom = new clsReservationRooms();
        private int _ReservationRoomID = -1;
        public ctrReservationRoomDetails()
        {
            InitializeComponent();
        }

        public void LoadInfoByReservationRoomID(int ReservationRoomID)
        {
            _ReservationRoomID = ReservationRoomID;

            if (_ReservationRoomID != -1)
                _LoadData();
        }

        private void _LoadData()
        {
            _ReservationRoom = clsReservationRooms.GetReservationRoomInfoByID(_ReservationRoomID);

            if(_ReservationRoom != null && _ReservationRoomID != -1)
            {
                lblReservationRoomID.Text = _ReservationRoomID.ToString();
                lblReservationID.Text = _ReservationRoom.ReservationID.ToString();
                lnklblPersonID.Text = _ReservationRoom.ReservationInfo.PersonID.ToString(); // Error Here
                lblRoomNumber.Text = _ReservationRoom.RoomInfo.RoomNumber.ToString();
                lblCheckInDate.Text =  _ReservationRoom.CheckInDate.ToShortDateString();
                lblCheckOutDate.Text = _ReservationRoom.CheckOutDate.ToShortDateString();
                lnklblPersonID.Enabled = true;
            }
            else
            {
                MessageBox.Show("لم يتم العثور على النزيل", "Notes");
            }
        }

        private void lnklblPersonID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDetailsPerson frm = new frmShowDetailsPerson(_ReservationRoom.ReservationInfo.PersonID);
            frm.ShowDialog();
        }
    }
}
