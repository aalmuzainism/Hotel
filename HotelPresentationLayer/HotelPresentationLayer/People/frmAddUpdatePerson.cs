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

namespace HotelPresentationLayer.People
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        enum enMode { AddNew = 0, Update = 1}
        enMode _Mode = enMode.AddNew;

        clsPerson _Person;
        int _PersonID = -1;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;

            _PersonID = PersonID;
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetControls();

            if(_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblMode.Text = "Update Person";
                _LoadData();
            }

        }

        void _ResetControls()
        {

            lblPersonID.Text = "[???]";
            txtNationalID.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            try
            {
                dtpDateOfBitrh.MaxDate = DateTime.Now.AddYears(-15);
                dtpDateOfBitrh.MinDate = DateTime.Now.AddYears(-100);
            }
            catch (Exception ex)
            {
                MessageBox.Show("عمرك اقل من 18 او اكبر من 100");
                this.Close();
            }
        }

        void _LoadData()
        {
            if(_PersonID == -1 || _Mode == enMode.AddNew)
            {
                MessageBox.Show("لا يمكن تحديث البيانات هناك خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Person = clsPerson.GetPersonInfoByID(_PersonID);

            if(_Person != null)
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                txtNationalID.Text= _Person.NationalID;
                txtFirstName.Text = _Person.FirstName;
                txtSecondName.Text = _Person.SecondName;
                txtThirdName.Text = _Person.ThirdName;
                txtLastName.Text= _Person.LastName;
                txtPhone.Text= _Person.Phone;
                txtEmail.Text= _Person.Email;
                dtpDateOfBitrh.Value = Convert.ToDateTime( _Person.DateOfBirth);
            }


        }

        private void txtDigit(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtAlphabet(object sender, KeyPressEventArgs e)
        {
            

            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNationalID_Validating(object sender, CancelEventArgs e)
        {
            if(clsPerson.IsPersonExistByNationalID(txtNationalID.Text) && _Person.NationalID != txtNationalID.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalID, "الهوية مستخدمه من قبل");
            }
            else
            {
                errorProvider1.SetError(txtNationalID, null);
            }
        }

        private void txtEmpty_Validating(object sender, CancelEventArgs e)
        {

            TextBox Temp = ((TextBox)sender);

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "لا يمكن تركه فارغ");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }

            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
                MessageBox.Show("يوجد حقل فارغ/مكرر", "خطأ",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Person.NationalID = txtNationalID.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.DateOfBirth = dtpDateOfBitrh.Value;

            if(_Person.Save())
            {
                _Mode = enMode.Update;
                lblPersonID.Text = _Person.PersonID.ToString();
                lblMode.Text = "Update Person";


                MessageBox.Show("تمت الاضافة بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("خطأ: لم يتم حفظ البيانات", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}