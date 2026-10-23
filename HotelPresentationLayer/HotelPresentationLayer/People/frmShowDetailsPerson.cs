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
    public partial class frmShowDetailsPerson : Form
    {
        
        public frmShowDetailsPerson(int PersonID)
        {
            InitializeComponent();

            ctrPersonInfo1.LoadPersonInfo(PersonID);
        }
        public frmShowDetailsPerson(string NationalID)
        {
            InitializeComponent();

            ctrPersonInfo1.LoadPersonInfo(NationalID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
