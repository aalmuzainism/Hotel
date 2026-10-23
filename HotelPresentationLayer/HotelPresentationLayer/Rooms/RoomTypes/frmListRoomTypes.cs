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

namespace HotelPresentationLayer.Rooms.RoomTypes
{
    public partial class frmListRoomTypes : Form
    {

        private DataTable _dt = clsRoomTypes.GetAllRoomTypes();

        public frmListRoomTypes()
        {
            InitializeComponent();
        }

        private void frmListRoomTypes_Load(object sender, EventArgs e)
        {
            _dt = clsRoomTypes.GetAllRoomTypes();

            dgvListRoomTypes.DataSource = _dt;

            if (dgvListRoomTypes.ColumnCount > 0)
            {
                dgvListRoomTypes.Columns[0].HeaderText = "Room Type ID";
                dgvListRoomTypes.Columns[0].Width = 100;

                dgvListRoomTypes.Columns[1].HeaderText = "Type Name";
                dgvListRoomTypes.Columns[1].Width = 120;

                dgvListRoomTypes.Columns[2].HeaderText = "Description";
                dgvListRoomTypes.Columns[2].Width = 200;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRoomType_Click(object sender, EventArgs e)
        {
            frmAddUpdateRoomTypes frm = new frmAddUpdateRoomTypes();
            frm.ShowDialog();
            frmListRoomTypes_Load(null, null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateRoomTypes frm = new frmAddUpdateRoomTypes((int)dgvListRoomTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListRoomTypes_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int IDForDeleted = (int)dgvListRoomTypes.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"{IDForDeleted} هل انت متأكد من حذف معرف الوحدة  ", "Deleted", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(clsRoomTypes.DeleteRoomType(IDForDeleted))
                {
                    MessageBox.Show("تم الحذف بنجاح");
                    frmListRoomTypes_Load(null, null);
                }
                else
                    MessageBox.Show("لم يتم الحذف هناك خطأ", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

        }
    }
}