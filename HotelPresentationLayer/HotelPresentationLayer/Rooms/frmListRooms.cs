using HotelBusinessLayer;
using HotelPresentationLayer.Rooms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPresentationLayer.Rooms
{
    public partial class frmListRooms : Form
    {

        clsRooms _Room = new clsRooms();
        private int _RoomNumber = -1;

        public frmListRooms()
        {
            InitializeComponent();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            frmAddUpdateRooms frm = new frmAddUpdateRooms();
            frm.ShowDialog();

            frmListRooms_Load(null, null);
        }

        private void RefreshListRooms()
        {
            flpListRoom.Controls.Clear();

            DataTable dt = clsRooms.GetAllRooms();

            foreach (DataRow row in dt.Rows)
            {
                ctrCardRoomDetails RoomCard = new ctrCardRoomDetails();

                RoomCard.LoadRoomInfoByRoomNumber(Convert.ToInt32(row["RoomNumber"]));

                RoomCard.DataBack += DataBack;

                flpListRoom.Controls.Add(RoomCard);
            }

        }

        private void DataBack(object sender, int RoomNumber)
        {
            _RoomNumber = RoomNumber;
        }

        private void frmListRooms_Load(object sender, EventArgs e)
        {
            RefreshListRooms();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _Room = clsRooms.GetRoomInfoByRoomNumber(_RoomNumber);
        }

        private void updateRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_RoomNumber != -1)
            {
                frmAddUpdateRooms frm = new frmAddUpdateRooms(_Room.RoomID);
                frm.ShowDialog();
                frmListRooms_Load(null, null);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (_RoomNumber != -1)
            {
                if (MessageBox.Show($" {_Room.RoomNumber} هل انت متأكد من حذف غرفة رقم", "Deleted Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_Room.DeleteRoomByID())
                    {
                        MessageBox.Show("تم الحذف بنجاح", "Deleted Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmListRooms_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("هناك خطأ ما", "Deleted NOT Successfullu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_RoomNumber != -1)
            {
                frmRoomDetails frm = new frmRoomDetails(_Room.RoomNumber);
                frm.ShowDialog();
            }
        }
    }
}