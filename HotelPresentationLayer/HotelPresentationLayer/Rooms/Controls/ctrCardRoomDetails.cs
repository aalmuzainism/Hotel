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

namespace HotelPresentationLayer.Rooms.Controls
{
    public partial class ctrCardRoomDetails : UserControl
    {
        private clsRooms _Room;
        private int _RoomNumber = -1;
        public int RoomNumber = -1;
        public int RoomID = -1;
        private int _RoomID = -1;
        public delegate void DataBackEventHandler(object sender, int RoomNumber);
        public event DataBackEventHandler DataBack;

        public event EventHandler CardRoomCliek;

        public ctrCardRoomDetails()
        {
            InitializeComponent();
        }

        public void LoadRoomInfoByRoomNumber(int RoomNumber)
        {
            _RoomNumber = RoomNumber;
            this.RoomNumber = RoomNumber;
            

            if(clsRooms.IsRoomExistByRoomNumber(_RoomNumber))
            {
                _LoadDataByRoomNumber();
            }
            else
            {
                MessageBox.Show("Room Not Found");
            }

        }

        public void LoadRoomInfoByRoomID(int RoomID)
        {
            _RoomID = RoomID;
            this.RoomID = _RoomID;


            if (clsRooms.IsRoomExistByRoomID(_RoomID))
            {
                _LoadDataByRoomID();
            }
            else
            {
                MessageBox.Show("Room Not Found");
            }

        }

        private void _LoadDataByRoomNumber()
        {
            _Room = clsRooms.GetRoomInfoByRoomNumber(_RoomNumber);

            if(_Room != null)
            {
                lblRoomNumber.Text = _Room.RoomNumber.ToString();
                lblRoomType.Text = _Room.RoomTypeInfo.Name;
                lblRoomCount.Text = _Room.RoomCount.ToString();
                lblPrice.Text = Convert.ToInt32(_Room.Price).ToString();

                if (clsReservationRooms.IsRoomBooked(_Room.RoomID))
                    pbRoomStatus.Image = Properties.Resources.RoomIsOccupied;

                else if(clsMaintenance.DoesRoomNeedMaintenance(_Room.RoomID))
                    pbRoomStatus.Image = Properties.Resources.RoomNeedsMaintenance;

                else
                    pbRoomStatus.Image = Properties.Resources.RoomIsReady;
            }
        }

        private void _LoadDataByRoomID()
        {
            _Room = clsRooms.GetRoomInfoByID(_RoomID);

            if(_Room != null)
            {
                lblRoomNumber.Text = _Room.RoomNumber.ToString();
                lblRoomType.Text = _Room.RoomTypeInfo.Name;
                lblRoomCount.Text = _Room.RoomCount.ToString();
                lblPrice.Text = Convert.ToInt32(_Room.Price).ToString();

                if (clsReservationRooms.IsRoomBooked(_Room.RoomID))
                    pbRoomStatus.Image = Properties.Resources.RoomIsOccupied;

                else if(clsMaintenance.DoesRoomNeedMaintenance(_Room.RoomID))
                    pbRoomStatus.Image = Properties.Resources.RoomNeedsMaintenance;

                else
                    pbRoomStatus.Image = Properties.Resources.RoomIsReady;
            }
        }

        private void ReturnData(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _Room.RoomNumber);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor= Color.Gray;
        }

    }
}