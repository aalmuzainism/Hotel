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
    public partial class ctrRoomDetails : UserControl
    {

        clsRooms _Room = new clsRooms();
        private int _RoomNumber = -1;
        private int _RoomID = -1;

        public ctrRoomDetails()
        {
            InitializeComponent();
        }

        public void LoadByRoomID(int RoomID)
        {
            _RoomID = RoomID;

            if (_RoomID != -1)
                _LoadDataByRoomID();
            
        }

        public void LoadByRoomNumber(int RoomNumber)
        {
            _RoomNumber = RoomNumber;

            if (_RoomNumber != -1)
                _LoadDataByRoomNumber();
        }

        private void _LoadDataByRoomID()
        {
            _Room = clsRooms.GetRoomInfoByID(_RoomID);

            if( _Room == null )
            {
                return;
            }
            _RoomNumber = _Room.RoomNumber;

            lblRoomID.Text = _Room.RoomID.ToString();
            lblRoomNumber.Text = _Room.RoomNumber.ToString();
            lblRoomType.Text = _Room.RoomTypeID.ToString();
            lblRoomCount.Text = _Room.RoomCount.ToString();
            lblKingBedCount.Text = _Room.KingBedCount.ToString();
            lblSingleBedCount.Text = _Room.SingleBedCount.ToString();
            lblLivingRoomCount.Text = _Room.LivingRoomCount.ToString();
            lblBathroomCount.Text = _Room.BathroomCount.ToString();
            lblFullKitchenCount.Text = _Room.FullKitchenCount.ToString();
            lblKitchenetteCount.Text = _Room.KitchenetteCount.ToString();
            lblPrice.Text = _Room.Price.ToString();

        }

        private void _LoadDataByRoomNumber()
        {
            _Room = clsRooms.GetRoomInfoByRoomNumber(_RoomNumber);

            if (_Room == null)
            {
                return;
            }

            _RoomID = _Room.RoomID;

            lblRoomID.Text = _Room.RoomID.ToString();
            lblRoomNumber.Text = _Room.RoomNumber.ToString();
            lblRoomType.Text = _Room.RoomTypeInfo.Name;
            lblRoomCount.Text = _Room.RoomCount.ToString();
            lblKingBedCount.Text = _Room.KingBedCount.ToString();
            lblSingleBedCount.Text = _Room.SingleBedCount.ToString();
            lblLivingRoomCount.Text = _Room.LivingRoomCount.ToString();
            lblBathroomCount.Text = _Room.BathroomCount.ToString();
            lblFullKitchenCount.Text = _Room.FullKitchenCount.ToString();
            lblKitchenetteCount.Text = _Room.KitchenetteCount.ToString();
            lblPrice.Text = _Room.Price.ToString();
        }
    }
}
