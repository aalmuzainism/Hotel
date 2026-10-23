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
    public partial class frmAddUpdateRoomTypes : Form
    {

        private clsRoomTypes _RoomType;
        private int _RoomTypeID = -1;

        clsRoomTypes.enMode _Mode = clsRoomTypes.enMode.AddNew;
        public frmAddUpdateRoomTypes()
        {
            InitializeComponent();

            _Mode = clsRoomTypes.enMode.AddNew;
        }
        public frmAddUpdateRoomTypes(int RoomTypeID)
        {
            InitializeComponent();

            _Mode = clsRoomTypes.enMode.Update;
            _RoomTypeID = RoomTypeID;
        }

        private void frmAddUpdateRoomTypes_Load(object sender, EventArgs e)
        {
            _ResetControls();

            if (_Mode == clsRoomTypes.enMode.AddNew)
            {
                lblMode.Text = "Add New Room Type";
                _RoomType = new clsRoomTypes();
            }
            else
            {
                lblMode.Text = "Update Room Type";
                _LoadData();
            }
        }

        private void _ResetControls()
        {
            lblRoomTypeID.Text = "[???]";
            txtTypeName.Text = "";
            txtDescription.Text = "";
        }

        private void _LoadData()
        {
            _RoomType = clsRoomTypes.GetRoomTypeInfoByID(_RoomTypeID);

            if (_RoomType != null)
            {
                lblRoomTypeID.Text = _RoomTypeID.ToString();
                txtTypeName.Text = _RoomType.Name;
                txtDescription.Text = _RoomType.Description;
            }
        }

        private void txtTypeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTypeName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTypeName, "يجب تعبئة الحقل");
            }
            else
                errorProvider1.SetError(txtTypeName, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("يرجئ تعبئة الحقل الفارغ", "Notes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _RoomType.Name = txtTypeName.Text;
            _RoomType.Description = txtDescription.Text;

            if(_RoomType.Save())
            {
                lblRoomTypeID.Text = _RoomType.RoomTypeID.ToString();
                lblMode.Text = "Update Room Type";

                _Mode = clsRoomTypes.enMode.Update;

                MessageBox.Show("تم الحفظ بنجاح", "Saved Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("هناك خطأ ما", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
