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
    public partial class frmListPeople : Form
    {
        private static DataTable _dt = clsPerson.GetAllPeople();

        public frmListPeople()
        {
            InitializeComponent();
            
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {

            _dt = clsPerson.GetAllPeople();

            dgvListPeople.DataSource = _dt;

            dgvListPeople.Columns[0].HeaderText = "Person ID";
            dgvListPeople.Columns[0].Width = 110;

            dgvListPeople.Columns[1].HeaderText = "National ID";
            dgvListPeople.Columns[1].Width = 120;

            dgvListPeople.Columns[2].HeaderText = "Full Name";
            dgvListPeople.Columns[2].Width = 200;

            dgvListPeople.Columns[3].HeaderText = "Phone";
            dgvListPeople.Columns[3].Width = 120;

            dgvListPeople.Columns[4].HeaderText = "Email";
            dgvListPeople.Columns[4].Width = 250;

            dgvListPeople.Columns[5].HeaderText = "Date Of Birth";
            dgvListPeople.Columns[5].Width = 170;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDetailsPerson frm = new frmShowDetailsPerson((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListPeople_Load(null, null);
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListPeople_Load(null, null);
        }

        private void pbAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            frmListPeople_Load(null, null);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonIdForDeleted = (int)dgvListPeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($" {PersonIdForDeleted} = هل انت متاكد من حذف المعرف", "حذف شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsPerson DeletedPerson = clsPerson.GetPersonInfoByID(PersonIdForDeleted);

                if (DeletedPerson.DeletePerson())
                {
                    MessageBox.Show("تم الحذف بنجاح", "حذف");

                    frmListPeople_Load(null, null);
                }
                else
                    MessageBox.Show("لم يتم الحذف هناك خطأ", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                return;
        }
    }
}
