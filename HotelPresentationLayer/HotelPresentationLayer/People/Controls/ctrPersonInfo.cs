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

namespace HotelPresentationLayer.People.Controls
{
    public partial class ctrPersonInfo : UserControl
    {
        private clsPerson _Person;

        public ctrPersonInfo()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.GetPersonInfoByID(PersonID);

            if (_Person != null)
                _FillPersonInfo();
            else
                MessageBox.Show("لم يتم العثور على الشخص", "لم يتم العثور", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadPersonInfo(string NationalID)
        {
            _Person = clsPerson.GetPersonInfoByNationalID(NationalID);

            if (_Person != null)
                _FillPersonInfo();
            else
                MessageBox.Show("لم يتم العثور على الشخص", "لم يتم العثور", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _ResetControls()
        {
            lblPersonID.Text = "[???]";
            lblNationalID.Text = "[???]";
            lblName.Text = "[???]";
            lblPhone.Text = "[???]";
            lblEmail.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
        }

        private void _FillPersonInfo()
        {
            _ResetControls();

            if (_Person != null)
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                lblNationalID.Text = _Person.NationalID;
                lblName.Text = _Person.FullName;
                lblPhone.Text = _Person.Phone;
                lblEmail.Text = _Person.Email;
                lblDateOfBirth.Text = Convert.ToDateTime(_Person.DateOfBirth).ToShortDateString();
            }
        }
    }
}
