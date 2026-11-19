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
        private List<int> _ListUnits;

        clsReservations NewReservation;

        clsReservationRooms NewReservationRoom;

        public frmAddUpdateReservationRoom(List<int> ListUnits)
        {
            InitializeComponent();

            _ListUnits = ListUnits;
        }

        private void frmAddUpdateReservationRoom_Load(object sender, EventArgs e)
        {
            txtListUnits.Text = "";
            for (int index = 0; index < _ListUnits.Count(); index++)
            {
                txtListUnits.Text += _ListUnits[index].ToString();
                if (index != _ListUnits.Count() - 1)
                    txtListUnits.Text += ", ";
            }


            dtpCheckInDate.MinDate = DateTime.Now;
            dtpCheckOutDate.MinDate = dtpCheckInDate.Value.AddDays(1);
        }

        private void HandleIfCheckInDateAfter12AMOrBefore()
        {
            if (DateTime.Now.ToShortDateString() == dtpCheckInDate.Value.ToShortDateString())
            {
                string DateAfterِAddingTwelveHours = DateTime.Now.AddHours(12).ToShortDateString();

                if (dtpCheckInDate.Value.ToShortDateString() == DateAfterِAddingTwelveHours)
                {
                    dtpCheckOutDate.MinDate = dtpCheckInDate.Value;
                }
                else
                {
                    dtpCheckOutDate.MinDate = dtpCheckInDate.Value.AddDays(1);
                }
            }
            else
            {
                dtpCheckOutDate.MinDate = dtpCheckInDate.Value.AddDays(1);
            }
        }

        private void CheckConflictForPlural()
        {
            DataTable dt = clsReservationRooms.GetConflictByRoomNumberAndDates(_ListUnits, dtpCheckInDate.Value.Date, dtpCheckOutDate.Value.Date);

            bool IsConflict = false;
            if (dt.Rows.Count > 0)
            {
                lblAlert.Text = "";
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToDateTime(row["CheckOutDate"]).ToShortDateString() != dtpCheckInDate.Value.ToShortDateString())
                    {
                        lblAlert.Text += $"{row["RoomNumber"]} Is Booked From {Convert.ToDateTime(row["CheckInDate"]).ToShortDateString()} To {Convert.ToDateTime(row["CheckOutDate"]).ToShortDateString()}\n";
                        IsConflict = true;
                    }
                }
            }

            if (IsConflict)
            {
                btnSave.Enabled = false;
                lblAlert.Visible = true;
            }
            else
            {
                btnSave.Enabled = true;
                lblAlert.Visible = false;
            }
        }

        private void dtpCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            HandleIfCheckInDateAfter12AMOrBefore();

            CheckConflictForPlural();
        }

        private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            CheckConflictForPlural();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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

            List<int> RoomIDs = clsRooms.GetRoomIDsByRoomNumbers(_ListUnits);

            if (RoomIDs == null)
            {
                NewReservation.DeleteReservation();
                MessageBox.Show("No Data In dt");
                return;
            }

            NewReservationRoom = new clsReservationRooms();

            NewReservationRoom.ReservationID = NewReservation.ReservationID;
            NewReservationRoom.ListUnits = RoomIDs;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}