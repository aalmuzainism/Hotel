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

namespace HotelPresentationLayer.Reservations
{
    public partial class frmAddUpdateReservationRoom : Form
    {

        clsReservations NewReservation;

        clsReservationRooms NewReservationRoom;

        int _RoomNumber = -1;

        public frmAddUpdateReservationRoom(int RoomNumber)
        {
            InitializeComponent();
            _RoomNumber = RoomNumber;

        }

        private void frmAddUpdateReservationRoom_Load(object sender, EventArgs e)
        {
            lblRoomNumber.Text = _RoomNumber.ToString();

            dtpCheckInDate.MinDate = DateTime.Now;
            dtpCheckOutDate.MinDate = dtpCheckInDate.Value.AddDays(1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            dtpCheckOutDate.MinDate = dtpCheckInDate.Value.AddDays(1);

            if (clsReservationRooms.IsReservationRoomWithDateByRoomNumber(_RoomNumber, dtpCheckInDate.Value, dtpCheckOutDate.Value))
            {
                clsReservationRooms Temp = clsReservationRooms.GetReservationRoomWithDateByRoomNumber(clsRooms.GetRoomInfoByRoomNumber(_RoomNumber).RoomID, dtpCheckInDate.Value, dtpCheckOutDate.Value);

                if (Temp.CheckOutDate.ToShortDateString() != dtpCheckInDate.Value.ToShortDateString())
                {
                    lblAlert.Visible = true;
                    lblAlert.Text = $"التاريخ يتعارض مع حجز اخر من {Temp.CheckInDate.ToShortDateString()} الى {Temp.CheckOutDate.ToShortDateString()}";
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                    lblAlert.Visible = false;
                }


            }
            else
            {
                btnSave.Enabled = true;
                lblAlert.Visible = false;
            }
        }

        private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
        {

            if (clsReservationRooms.IsReservationRoomWithDateByRoomNumber(_RoomNumber, dtpCheckInDate.Value, dtpCheckOutDate.Value))
            {
                clsReservationRooms Temp = clsReservationRooms.GetReservationRoomWithDateByRoomNumber(clsRooms.GetRoomInfoByRoomNumber(_RoomNumber).RoomID, dtpCheckInDate.Value, dtpCheckOutDate.Value);

                if (Temp.CheckOutDate.ToShortDateString() != dtpCheckInDate.Value.ToShortDateString())
                {
                    lblAlert.Visible = true;
                    lblAlert.Text = $"التاريخ يتعارض مع حجز اخر من {Temp.CheckInDate.ToShortDateString()} الى {Temp.CheckOutDate.ToShortDateString()}";
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                    lblAlert.Visible = false;
                }


            }
            else
            {
                btnSave.Enabled = true;
                lblAlert.Visible = false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (clsReservationRooms.IsReservationRoomWithDateByRoomNumber(_RoomNumber, dtpCheckInDate.Value, dtpCheckOutDate.Value))
            {
                clsReservationRooms Temp = clsReservationRooms.GetReservationRoomWithDateByRoomNumber(clsRooms.GetRoomInfoByRoomNumber(_RoomNumber).RoomID, dtpCheckInDate.Value, dtpCheckOutDate.Value);

                if (Temp.CheckOutDate.ToShortDateString() != dtpCheckInDate.Value.ToShortDateString())
                {
                    lblAlert.Visible = true;
                    lblAlert.Text = $"التاريخ يتعارض مع حجز اخر من {Temp.CheckInDate.ToShortDateString()} الى {Temp.CheckOutDate.ToShortDateString()}";
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    btnSave.Enabled = true;
                    lblAlert.Visible = false;
                }


            }
            else
            {
                btnSave.Enabled = true;
                lblAlert.Visible = false;
            }

            if (ctrPersonInfoWithFilter1.PersonID == -1)
            {
                MessageBox.Show("الرجاء اختيار نزيل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewReservation = new clsReservations();

            NewReservation.PersonID = ctrPersonInfoWithFilter1.PersonID;
            NewReservation.CreatedBy = 1;
            NewReservation.Notes = txtNotes.Text.Trim();
            NewReservation.Status = 1;

            if (NewReservation.Save())
            {
                lblReservationID.Text = NewReservation.ReservationID.ToString();
                MessageBox.Show("Saved Successfully Reservation");
            }
            else
            {
                MessageBox.Show("Error In Reservation");
                return;
            }

            NewReservationRoom = new clsReservationRooms();

            NewReservationRoom.ReservationID = NewReservation.ReservationID;
            NewReservationRoom.RoomID = clsRooms.GetRoomInfoByRoomNumber(Convert.ToInt32(_RoomNumber)).RoomID;
            NewReservationRoom.CheckInDate = dtpCheckInDate.Value;
            NewReservationRoom.CheckOutDate = dtpCheckOutDate.Value;
            NewReservationRoom.Status = 1;

            if (NewReservationRoom.Save())
            {
                MessageBox.Show("Saved Successfully ReservationRoom");
            }
            else
            {
                MessageBox.Show("Error In ReservationRoom");
            }

        }
    }
}