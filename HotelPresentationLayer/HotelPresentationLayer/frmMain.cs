using HotelPresentationLayer.Maintenance;
using HotelPresentationLayer.People;
using HotelPresentationLayer.Reservations;
using HotelPresentationLayer.Rooms;
using HotelPresentationLayer.Rooms.RoomTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPresentationLayer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }
        private void roomTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListRoomTypes frm = new frmListRoomTypes();
            frm.ShowDialog();

        }

        private void manageRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListRooms frm = new frmListRooms();
            frm.ShowDialog();
        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListReservationRooms frm = new frmListReservationRooms();
            frm.ShowDialog();
        }

        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListMaintenance frm = new frmListMaintenance();
            frm.ShowDialog();
        }
    }
}
