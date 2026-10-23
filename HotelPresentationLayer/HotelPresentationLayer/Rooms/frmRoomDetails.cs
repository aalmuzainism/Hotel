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

namespace HotelPresentationLayer.Rooms
{
    public partial class frmRoomDetails : Form
    {

        private int _RoomNumber = -1;

        public frmRoomDetails(int RoomNumber)
        {
            InitializeComponent();

            _RoomNumber = RoomNumber;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); ;
        }

        private void frmRoomDetails_Load(object sender, EventArgs e)
        {
            if(!clsRooms.IsRoomExistByRoomNumber(_RoomNumber))
            {
                MessageBox.Show("لم يتم العثور على الوحدة", "Room NOT Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrRoomDetails1.LoadByRoomNumber(_RoomNumber);
        }
    }
}
