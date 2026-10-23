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

namespace HotelPresentationLayer.Maintenance
{
    public partial class frmAddUpdateMaintenance : Form
    {
        private clsRooms _Room;
        private clsMaintenance _Maintenance = new clsMaintenance();
        clsRooms.enMode _Mode = clsRooms.enMode.AddNew;
        private int _RoomID = -1;
        private int _RoomNumber = -1;

        public frmAddUpdateMaintenance(int RoomID)
        {
            InitializeComponent();

            _RoomID = RoomID;

            if (clsMaintenance.IsMaintenanceExistByRoomID(RoomID))
                _Mode = clsRooms.enMode.Update;
            else
                _Mode = clsRooms.enMode.AddNew;

        }

        private void _ResetControls()
        {
            _Room = clsRooms.GetRoomInfoByID(_RoomID);

            if (_Room != null)
            {
                lblMaintenanceID.Text = "[???]";
                lblRoomID.Text = _Room.RoomID.ToString();
                lblRoomNumber.Text = _Room.RoomNumber.ToString();
                txtDescription.Text = "";
            }
        }

        private void _LoadData()
        {
            _Maintenance = clsMaintenance.GetMaintenanceInfoByRoomID(_Room.RoomID);

            if (_Maintenance != null)
            {
                lblMaintenanceID.Text = _Maintenance.MaintenanceID.ToString();
                txtDescription.Text = _Maintenance.Description;
            }

        }

        private void AddUpdateMaintenance_Load(object sender, EventArgs e)
        {
            _ResetControls();

            if (_Mode == clsRooms.enMode.Update)
                _LoadData();

        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "يجب ادخال وصف للمشكلة");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("هناك حقول فارغة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _Maintenance.RoomID = _Room.RoomID;
            _Maintenance.Description = txtDescription.Text.Trim();
            _Maintenance.Status = 1;


            if (_Maintenance.Save())
            {
                lblMaintenanceID.Text = _Maintenance.MaintenanceID.ToString();
                btnSave.Enabled = false;
                MessageBox.Show("تم الحفظ", "Data Saved Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("هناك خطأ ما", "ُError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}