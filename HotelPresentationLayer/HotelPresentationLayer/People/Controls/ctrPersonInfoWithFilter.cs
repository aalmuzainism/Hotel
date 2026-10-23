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
    public partial class ctrPersonInfoWithFilter : UserControl
    {

        private clsPerson _Person;

        private int _PersonID = -1;

        public int PersonID = -1;

        public ctrPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pbSearchPerson_Click(object sender, EventArgs e)
        {
            if (cbMenue.Text == "Person ID")
            {
                if (int.TryParse(txtSearch.Text.Trim(), out _PersonID))
                {
                    _Person = clsPerson.GetPersonInfoByID(_PersonID);

                    if (_Person != null)
                    {
                        _PersonID = _Person.PersonID;
                        PersonID = _Person.PersonID;
                        ctrPersonInfo1.LoadPersonInfo(_PersonID);
                    }
                    else
                        MessageBox.Show("لم يتم العثور على الشخص", "لم يتم العثور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("لا يمكن التحويل", "لا يمكن التحويل", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                _Person = clsPerson.GetPersonInfoByNationalID(txtSearch.Text.Trim());

                if (_Person != null)
                {
                    _PersonID = _Person.PersonID;
                    PersonID = _Person.PersonID;
                    ctrPersonInfo1.LoadPersonInfo(_PersonID);
                }
                else
                    MessageBox.Show("لم يتم العثور على الشخص", "لم يتم العثور", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ctrPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbMenue.SelectedItem = 0;
        }

        private void pbAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBack;
            frm.ShowDialog();
        }

        private void DataBack(object sender, int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.GetPersonInfoByID(_PersonID);
            ctrPersonInfo1.LoadPersonInfo(_Person.PersonID);

        }


    }
}
