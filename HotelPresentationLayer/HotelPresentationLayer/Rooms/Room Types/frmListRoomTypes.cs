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
    public partial class frmListRoomTypes : Form
    {

        public frmListRoomTypes()
        {
            InitializeComponent();
        }

        private void frmListRooms_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                ListViewItem item = new ListViewItem($"{i + 100}");
                item.ImageIndex = 0;

                item.SubItems.Add("غرفة ستاندرد");
                item.SubItems.Add("2");

                //if(i == 1)
                item.SubItems.Add("abdulrahman");

                
               
                listView1.Items.Add(item);

                
            } 
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string RoomNumber = "";
            if(listView1.SelectedItems.Count > 0)
            {
                ListViewItem row = listView1.SelectedItems[0];
                //RoomNumber = row.SubItems[0].Text;
                MessageBox.Show(row.SubItems[0].Text);
            }

            
            
        }
    }
}
