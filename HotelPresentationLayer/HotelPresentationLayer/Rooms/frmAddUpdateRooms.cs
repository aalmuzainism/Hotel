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
    public partial class frmAddUpdateRooms : Form
    {

        private clsRooms _Room;
        private int _RoomID = -1;
        private clsRooms.enMode _Mode = clsRooms.enMode.AddNew;

        public frmAddUpdateRooms()
        {
            InitializeComponent();

            _Mode = clsRooms.enMode.AddNew;
        }

        public frmAddUpdateRooms(int RoomID)
        {
            InitializeComponent();

            _Mode = clsRooms.enMode.Update;
            _RoomID = RoomID;
        }

        private void _ResetControls()
        {
            _Room = new clsRooms();

            DataTable dtRoomTypes = clsRoomTypes.GetAllRoomTypes();

            foreach (DataRow row in dtRoomTypes.Rows)
            {
                cbRoomTypes.Items.Add(row["Name"]);
            }

            lblMode.Text = "Add New Room";
            this.Text = "Add New Room";

            if(_Mode == clsRooms.enMode.AddNew)
                cbRoomTypes.SelectedIndex = 0;

            lblRoomID.Text = "[???]";
            txtRoomNumber.Text = "";
            cbRoomCount.SelectedIndex = 0;
            cbKingBedCount.SelectedIndex = 1;
            cbSingleBedCount.SelectedIndex = 0;
            cbLivingRoomCount.SelectedIndex = 0;
            cbBathroomCount.SelectedIndex = 0;
            cbFullCithcenCount.SelectedIndex = 0;
            cbKitchenetteCount.SelectedIndex = 1;
            txtPrice.Text = "";

        }

        private void _LoadData()
        {
            _Room = clsRooms.GetRoomInfoByID(_RoomID);

            if(_Room != null && _RoomID != -1)
            {
                lblMode.Text = "Update Room";
                this.Text = "Update Room";

                lblRoomID.Text = _Room.RoomID.ToString();
                txtRoomNumber.Text = _Room.RoomNumber.ToString();
                cbRoomCount.SelectedItem = _Room.RoomCount.ToString();
                cbRoomTypes.SelectedItem = clsRoomTypes.GetRoomTypeInfoByID(_Room.RoomTypeID).Name;
                cbKingBedCount.SelectedItem = _Room.KingBedCount.ToString();
                cbSingleBedCount.SelectedItem = _Room.SingleBedCount.ToString();
                cbLivingRoomCount.SelectedItem = _Room.LivingRoomCount.ToString();
                cbBathroomCount.SelectedItem = _Room.BathroomCount.ToString();
                cbFullCithcenCount.SelectedItem = _Room.FullKitchenCount.ToString();
                cbKitchenetteCount.SelectedItem = _Room.KitchenetteCount.ToString();
                txtPrice.Text = _Room.Price.ToString();

            }
        }

        private void frmAddUpdateRooms_Load(object sender, EventArgs e)
        {

            _ResetControls();

            if(_Mode == clsRooms.enMode.Update)
                _LoadData();
        }

        private void TextBoxDigitOnle(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void TextBoxNotNullValidating(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "حقل اجباري");
            }
            else
                errorProvider1.SetError(Temp, null);

        }

        private void txtRoomNumber_Validating_KeyPress(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtRoomNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRoomNumber, "حقل اجباري");
            }
            else
            {
                errorProvider1.SetError(txtRoomNumber, null);
            }

            if (!string.IsNullOrEmpty(txtRoomNumber.Text))
            {

                int RoomNumber = Convert.ToInt32(txtRoomNumber.Text);

                if(clsRooms.IsRoomExistByRoomNumber(RoomNumber))
                {
                    if (RoomNumber == _Room.RoomNumber)
                        return;
                    else
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtRoomNumber, "الغرفة مسجلة من قبل");

                    }
                }
                else
                {
                    errorProvider1.SetError(txtRoomNumber, null);
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("هناك حقول اجبارية يجب تعبئتها", "Notes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            _Room.RoomNumber = Convert.ToInt32(txtRoomNumber.Text.Trim());
            _Room.RoomCount = Convert.ToByte(cbRoomCount.Text);
            _Room.RoomTypeID = Convert.ToInt32(clsRoomTypes.GetRoomTypeInfoByName(cbRoomTypes.Text).RoomTypeID);
            _Room.KingBedCount = Convert.ToByte(cbKingBedCount.Text);
            _Room.SingleBedCount = Convert.ToByte(cbSingleBedCount.Text);
            _Room.LivingRoomCount = Convert.ToByte(cbLivingRoomCount.Text);
            _Room.BathroomCount = Convert.ToByte(cbBathroomCount.Text);
            _Room.FullKitchenCount = Convert.ToByte(cbFullCithcenCount.Text);
            _Room.KitchenetteCount = Convert.ToByte(cbKitchenetteCount.Text);
            _Room.Price = Convert.ToDouble(txtPrice.Text.Trim());

            if(_Room.Save())
            {
                _Mode = clsRooms.enMode.Update;

                lblMode.Text = "Update Room";

                lblRoomID.Text = _Room.RoomID.ToString();

                _RoomID = _Room.RoomID;

                MessageBox.Show("تم الحفظ بنجاح", "Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("هناك خطأ ما يرجى المحاولة لاحقا", "Notes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
