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

namespace HotelPresentationLayer.Maintenance
{
    public partial class frmListMaintenance : Form
    {

        private clsRooms _Room = new clsRooms();
        private int _RoomNumber = -1;

        public frmListMaintenance()
        {
            InitializeComponent();
        }

        private void frmListMaintenance_Load(object sender, EventArgs e)
        {
            _ListRefresh();
        }

        private void _ListRefresh()
        {
            flpListMaintenance.Controls.Clear();

            DataTable dt = clsRooms.GetAllRooms();

            foreach (DataRow row in dt.Rows)
            {
                ctrCardRoomDetails RoomCard = new ctrCardRoomDetails();

                RoomCard.DataBack += DataBack;

                RoomCard.LoadRoomInfoByRoomNumber(Convert.ToInt32(row["RoomNumber"]));

                flpListMaintenance.Controls.Add(RoomCard);
            }
        }

        private void DataBack(object sender, int RoomNumber)
        {
            _RoomNumber = RoomNumber;
        }

        private void addMaintenaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Room != null)
            {
                frmAddUpdateMaintenance frm = new frmAddUpdateMaintenance(_Room.RoomID);
                frm.ShowDialog();
                frmListMaintenance_Load(null, null);
            }
        }

        private void maintenanceCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متاكد من انهاء الطلب؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (_Room != null)
                {
                    clsMaintenance MaintenanceCompleted = clsMaintenance.GetMaintenanceInfoByRoomID(_Room.RoomID);

                    if (MaintenanceCompleted != null && MaintenanceCompleted.Status == 1)
                    {

                        if (MaintenanceCompleted.MaintenanceComplete())
                        {
                            MessageBox.Show("تم الانتهاء من الصيانة");
                            frmListMaintenance_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("هناك خطأ ما", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا يمكنك انهاء الطلب, الوحدة لا يوجد عليها طلب صيانة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void canselToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("هل انت متاكد من الغاء الطلب ؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (_Room != null)
                {
                    clsMaintenance MaintenanceCompleted = clsMaintenance.GetMaintenanceInfoByRoomID(_Room.RoomID);

                    if (MaintenanceCompleted != null && MaintenanceCompleted.Status != 2)
                    {

                        if (MaintenanceCompleted.MaintenanceCancel())
                        {
                            MessageBox.Show("تم الغاء طلب الصيانة");
                            frmListMaintenance_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("هناك خطأ ما", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا يمكنك الغاء الطلب, الوحدة لا يوجد عليها طلب صيانة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _Room = clsRooms.GetRoomInfoByRoomNumber(_RoomNumber);

            if (_Room != null)
            {
                if (clsMaintenance.IsMaintenanceExistByRoomID(_Room.RoomID))
                {
                    addMaintenaceToolStripMenuItem.Enabled = true;
                    maintenanceCompletedToolStripMenuItem.Enabled = true;
                    canselToolStripMenuItem.Enabled = true;
                }
                else
                {
                    addMaintenaceToolStripMenuItem.Enabled = true;
                    maintenanceCompletedToolStripMenuItem.Enabled = false;
                    canselToolStripMenuItem.Enabled = false;
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
