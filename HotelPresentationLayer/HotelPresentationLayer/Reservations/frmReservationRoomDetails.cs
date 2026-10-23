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
    public partial class frmReservationRoomDetails : Form
    {
        public frmReservationRoomDetails(int ReservationRoomID)
        {
            InitializeComponent();

            ctrReservationRoomDetails1.LoadInfoByReservationRoomID(ReservationRoomID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
