using HotelBusinessLayer;
using HotelPresentationLayer.Global_Classes;
using HotelPresentationLayer.Rooms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPresentationLayer.Reservations
{
    public partial class frmListReservationRooms : Form
    {
        clsRooms _Room;

        private int _RoomNumber = -1;

        public frmListReservationRooms()
        {
            InitializeComponent();
        }

        private void frmListReservationRooms_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _RefreshList();
        }

        private void _RefreshList()
        {

            flpListRooms.Controls.Clear();

            DataTable dt = clsRooms.GetAllRooms();

            foreach (DataRow row in dt.Rows)
            {
                ctrCardRoomDetails RoomCard = new ctrCardRoomDetails();
                RoomCard.LoadRoomInfoByRoomNumber(Convert.ToInt32(row["RoomNumber"]));
                RoomCard.DataBack += DataBack;

                flpListRooms.Controls.Add(RoomCard);
            }

        }

        private void DataBack(object sender, int RoomNumber)
        {
            _RoomNumber = RoomNumber;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _Room = clsRooms.GetRoomInfoByRoomNumber(_RoomNumber);

            if (_Room != null)
            {
                clsReservationRooms ReservationRoom = clsReservationRooms.GetReservationRoomInfoByRoomID(_Room.RoomID);

                if (ReservationRoom != null)
                {
                    if (ReservationRoom.Status == 1)
                    {
                        bookingDetailsToolStripMenuItem.Enabled = true;
                        checkInToolStripMenuItem.Enabled = true;
                        checkOutToolStripMenuItem.Enabled = false;
                        cancelToolStripMenuItem.Enabled = true;
                    }
                    else if (ReservationRoom.Status == 2)
                    {
                        bookingDetailsToolStripMenuItem.Enabled = true;
                        checkInToolStripMenuItem.Enabled = false;
                        checkOutToolStripMenuItem.Enabled = true;
                        cancelToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        bookingDetailsToolStripMenuItem.Enabled = false;
                        checkInToolStripMenuItem.Enabled = false;
                        checkOutToolStripMenuItem.Enabled = false;
                        cancelToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    bookingDetailsToolStripMenuItem.Enabled = false;
                    checkInToolStripMenuItem.Enabled = false;
                    checkOutToolStripMenuItem.Enabled = false;
                    cancelToolStripMenuItem.Enabled = false;
                }
            }

        }

        private void bookingDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsReservationRooms.IsRoomBooked(_Room.RoomID))
            {
                clsReservationRooms ReservationRoom = clsReservationRooms.GetReservationRoomInfoByRoomID(_Room.RoomID);

                frmReservationRoomDetails frm = new frmReservationRoomDetails(ReservationRoom.ReservationRoomID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("الوحدة غير محجوزة", "Notes");
            }
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateReservationRoom frm = new frmAddUpdateReservationRoom(_RoomNumber);
            frm.ShowDialog();
            frmListReservationRooms_Load(null, null);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                btnSearchText.Visible = false;
                txtSearch.Visible = false;
                groupBox1.Visible = false;
                txtSearch.Clear();
                _RefreshList();
            }
            else if (cbFilter.SelectedIndex == 1)
            {
                btnSearchText.Visible = false;
                txtSearch.Visible = false;
                txtSearch.Clear();
                flpListRooms.Controls.Clear();
                DataTable dt = clsReservationRooms.GetAllReservationRoomsCheckInToday(DateTime.Today);

                foreach (DataRow row in dt.Rows)
                {
                    ctrCardRoomDetails RoomCard = new ctrCardRoomDetails();
                    RoomCard.LoadRoomInfoByRoomID(Convert.ToInt32(row["RoomID"]));
                    RoomCard.DataBack += DataBack;

                    flpListRooms.Controls.Add(RoomCard);
                }

            }
            else if (cbFilter.SelectedIndex == 2)
            {
                btnSearchText.Visible = false;
                txtSearch.Visible = false;
                txtSearch.Clear();
                flpListRooms.Controls.Clear();

                DataTable dt = clsReservationRooms.GetAllReservationRoomsCheckOutToday(DateTime.Today);

                foreach (DataRow row in dt.Rows)
                {
                    ctrCardRoomDetails RoomCard = new ctrCardRoomDetails();
                    RoomCard.LoadRoomInfoByRoomID(Convert.ToInt32(row["RoomID"]));
                    RoomCard.DataBack += DataBack;

                    flpListRooms.Controls.Add(RoomCard);
                }
            }
            else if (cbFilter.SelectedIndex == 3)
            {
                btnSearchText.Visible = false;
                txtSearch.Visible = false;
                groupBox1.Visible = true;
                txtSearch.Clear();
                dtpCheckIn.MinDate = DateTime.Now;
                dtpCheckOut.MinDate = DateTime.Now.AddDays(1);
            }
            else if (cbFilter.SelectedIndex == 4)
            {
                txtSearch.Visible = true;
                btnSearchText.Visible = true;
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flpListRooms.Controls.Clear();

            DataTable dt = clsReservationRooms.GetAllAvailableRooms(dtpCheckIn.Value, dtpCheckOut.Value);

            foreach (DataRow row in dt.Rows)
            {
                ctrCardRoomDetails RoomCard = new ctrCardRoomDetails();
                RoomCard.LoadRoomInfoByRoomNumber(Convert.ToInt32(row["RoomNumber"]));
                RoomCard.DataBack += DataBack;

                flpListRooms.Controls.Add(RoomCard);
            }

        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsReservationRooms ReservationRoomCheckIn = clsReservationRooms.GetReservationRoomInfoByRoomIDForCheckIn(_Room.RoomID);


            if (ReservationRoomCheckIn != null)
            {

                if (ReservationRoomCheckIn.Status == 1)
                {
                    if (ReservationRoomCheckIn.CheckIn(1))
                    {
                        MessageBox.Show("تم تسجيل الدخول", "Checked in Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("هناك خطأ ما.", "Error.");
                    }
                }
                else if (ReservationRoomCheckIn.Status == 2)
                {
                    MessageBox.Show("لا يمكن تكرار تسجيل الدخول", "Person Alredy Checked In.");
                }
                else
                {
                    MessageBox.Show("هناك خطأ ما.", "Error.");
                }

            }
            else
            {
                MessageBox.Show("لايوجد حجز", "Error.");
            }

        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsReservationRooms ReservationRoomCheckOut = clsReservationRooms.GetReservationRoomInfoByRoomIDForCheckOut(_Room.RoomID);

            if (ReservationRoomCheckOut != null)
            {

                if (ReservationRoomCheckOut.Status == 2)
                {
                    if (ReservationRoomCheckOut.CheckOut(1))
                    {
                        MessageBox.Show("تم تسجيل الخروج", "Checked in Successfully.");
                        frmListReservationRooms_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("هناك خطأ ما.", "Error.");
                    }
                }
                else if (ReservationRoomCheckOut.CheckInBy == -1 || ReservationRoomCheckOut.Status == 2)
                {
                    MessageBox.Show("يجب تسجيل الدخول اولا", "Wrong.");
                }
                else
                {
                    MessageBox.Show("هناك خطأ", "Error");
                }

            }
            else
            {
                MessageBox.Show("لايوجد حجز", "Error.");
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsReservationRooms ReservationRoom = clsReservationRooms.GetReservationRoomInfoByRoomID(_Room.RoomID);

            if (ReservationRoom != null)
            {
                if (MessageBox.Show($"هل انت متاكد من الغاء الحجز للوحدة رقم {ReservationRoom.RoomInfo.RoomNumber}", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (ReservationRoom.Cancel())
                    {
                        MessageBox.Show("تم الغاء الحجز", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmListReservationRooms_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("هناك خطأ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSearchText_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                return;
            }

            if (clsPerson.IsPersonExistByNationalID(txtSearch.Text.Trim()))
            {

                flpListRooms.Controls.Clear();

                DataTable dt = clsReservationRooms.GetAllReservationRoomsForPersonByNationalID(txtSearch.Text.Trim());

                foreach (DataRow row in dt.Rows)
                {
                    ctrCardRoomDetails RoomCard = new ctrCardRoomDetails();
                    RoomCard.LoadRoomInfoByRoomID(Convert.ToInt32(row["RoomID"]));
                    RoomCard.DataBack += DataBack;

                    flpListRooms.Controls.Add(RoomCard);
                }
            }
            else
                MessageBox.Show("لم يتم العثور على الشخص", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}