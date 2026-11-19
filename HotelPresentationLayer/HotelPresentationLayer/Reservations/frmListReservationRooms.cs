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

        private List<int> _ListUnits = new List<int>();

        private List<int> _liRoomNumbers = new List<int>();

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
            if (_RoomNumber == -1)
                return;

            _Room = clsRooms.GetRoomInfoByRoomNumber(_RoomNumber);

            if (_Room != null)
            {
                clsReservationRooms ReservationRoom = clsReservationRooms.GetReservationRoomInfoByRoomID(_Room.RoomID);

                if (ReservationRoom != null)
                {
                    if (ReservationRoom.Status == 1)
                    {
                        bookingDetailsToolStripMenuItem.Enabled = true;

                    }
                    else if (ReservationRoom.Status == 2)
                    {
                        bookingDetailsToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        bookingDetailsToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    bookingDetailsToolStripMenuItem.Enabled = false;
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
            if (_RoomNumber == -1)
                return;

            _ListUnits.Clear();
            _ListUnits.Add(_RoomNumber);
            _FillTxtListUnits();

            frmAddUpdateReservationRoom frm = new frmAddUpdateReservationRoom(_ListUnits);
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
                dgvListAllReservationRoomForPerson.Visible = false;
                flpListRooms.Visible = true;
                txtSearch.Clear();
                _RefreshList();
            }
            else if (cbFilter.SelectedIndex == 1)
            {
                btnSearchText.Visible = false;
                txtSearch.Visible = false;
                groupBox1.Visible = false;
                dgvListAllReservationRoomForPerson.Visible = false;
                flpListRooms.Visible = true;
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
                groupBox1.Visible = false;
                dgvListAllReservationRoomForPerson.Visible = false;
                flpListRooms.Visible = true;
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
                dgvListAllReservationRoomForPerson.Visible = false;
                flpListRooms.Visible = true;
                txtSearch.Clear();
                dtpCheckIn.MinDate = DateTime.Now;
                dtpCheckOut.MinDate = DateTime.Now.AddDays(1);
            }
            else if (cbFilter.SelectedIndex == 4)
            {
                txtSearch.Visible = true;
                btnSearchText.Visible = true;
                groupBox1.Visible = false;
                dgvListAllReservationRoomForPerson.Visible = true;
                flpListRooms.Visible = false;
                txtSearch.Clear();
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
                return;


            if (clsPerson.IsPersonExistByNationalID(txtSearch.Text.Trim()))
            {
                DataTable dt = clsReservationRooms.GetAllReservationRoomsByNationalID(txtSearch.Text.Trim());
                dgvListAllReservationRoomForPerson.DataSource = dt;

                if (dgvListAllReservationRoomForPerson.Rows.Count > 0)
                {

                    dgvListAllReservationRoomForPerson.Columns[0].HeaderText = "الهوية الوطنية";
                    dgvListAllReservationRoomForPerson.Columns[0].Width = 140;

                    dgvListAllReservationRoomForPerson.Columns[1].HeaderText = "الاسم";
                    dgvListAllReservationRoomForPerson.Columns[1].Width = 300;

                    dgvListAllReservationRoomForPerson.Columns[2].HeaderText = "الرقم";
                    dgvListAllReservationRoomForPerson.Columns[2].Width = 120;

                    dgvListAllReservationRoomForPerson.Columns[3].HeaderText = "رقم الوحده";
                    dgvListAllReservationRoomForPerson.Columns[3].Width = 100;

                    dgvListAllReservationRoomForPerson.Columns[4].HeaderText = "تاريخ الدخول";
                    dgvListAllReservationRoomForPerson.Columns[4].Width = 200;

                    dgvListAllReservationRoomForPerson.Columns[5].HeaderText = "تاريخ الخروج";
                    dgvListAllReservationRoomForPerson.Columns[5].Width = 200;

                    dgvListAllReservationRoomForPerson.Columns[6].HeaderText = "الحاله";
                    dgvListAllReservationRoomForPerson.Columns[6].Width = 150;


                }

            }
            else
                MessageBox.Show("لم يتم العثور على الشخص", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillTxtListUnits()
        {
            txtListUnits.Text = "";
            for (int index = 0; index < _ListUnits.Count(); index++)
            {
                txtListUnits.Text += _ListUnits[index];
                if (index != _ListUnits.Count() - 1)
                    txtListUnits.Text += ", ";
            }
        }

        private void addToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_RoomNumber == -1 || _ListUnits.Contains(_RoomNumber))
                return;

            _ListUnits.Add(_RoomNumber);
            _FillTxtListUnits();
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ListUnits.Remove(_RoomNumber);
            _FillTxtListUnits();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _ListUnits.Clear();
            txtListUnits.Text = "";
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            if (_ListUnits.Count() == 0)
                return;

            frmAddUpdateReservationRoom frm = new frmAddUpdateReservationRoom(_ListUnits);
            frm.ShowDialog();
        }

        private void checkInToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _liRoomNumbers.Clear();

            if (dgvListAllReservationRoomForPerson.CurrentRow != null)
            {
                string strNationalID = (string)dgvListAllReservationRoomForPerson.CurrentRow.Cells[0].Value;
                int RM = (int)dgvListAllReservationRoomForPerson.CurrentRow.Cells[3].Value;

                _liRoomNumbers.Add(RM);

                if (clsReservationRooms.CheckIn(strNationalID, _liRoomNumbers, 1))
                {
                    MessageBox.Show("Done");
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
        }

        private void checkOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _liRoomNumbers.Clear();

            if (dgvListAllReservationRoomForPerson.CurrentRow != null)
            {
                string strNationalID = (string)dgvListAllReservationRoomForPerson.CurrentRow.Cells[0].Value;
                int RM = (int)dgvListAllReservationRoomForPerson.CurrentRow.Cells[3].Value;

                _liRoomNumbers.Add(RM);

                if (clsReservationRooms.CheckOut(strNationalID, _liRoomNumbers, 1))
                {
                    MessageBox.Show("Done");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _liRoomNumbers.Clear();

            if (dgvListAllReservationRoomForPerson.CurrentRow != null)
            {
                string strNationalID = (string)dgvListAllReservationRoomForPerson.CurrentRow.Cells[0].Value;
                int RM = (int)dgvListAllReservationRoomForPerson.CurrentRow.Cells[3].Value;

                _liRoomNumbers.Add(RM);

                if (clsReservationRooms.Cancel(strNationalID, _liRoomNumbers))
                {
                    MessageBox.Show("Done");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}