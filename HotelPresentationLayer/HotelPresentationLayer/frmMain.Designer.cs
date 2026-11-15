namespace HotelPresentationLayer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMainMenue = new System.Windows.Forms.MenuStrip();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msMainMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenue
            // 
            this.msMainMenue.AutoSize = false;
            this.msMainMenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.msMainMenue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.msMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem,
            this.roomsToolStripMenuItem,
            this.reservationsToolStripMenuItem,
            this.maintenanceToolStripMenuItem});
            this.msMainMenue.Location = new System.Drawing.Point(0, 0);
            this.msMainMenue.Name = "msMainMenue";
            this.msMainMenue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.msMainMenue.Size = new System.Drawing.Size(1560, 71);
            this.msMainMenue.TabIndex = 1;
            this.msMainMenue.Text = "menuStrip1";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(101)))));
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(97, 67);
            this.peopleToolStripMenuItem.Text = "الاشخاص";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomTypesToolStripMenuItem,
            this.manageRoomToolStripMenuItem});
            this.roomsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(101)))));
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(88, 67);
            this.roomsToolStripMenuItem.Text = "الوحدات";
            // 
            // roomTypesToolStripMenuItem
            // 
            this.roomTypesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.roomTypesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(101)))));
            this.roomTypesToolStripMenuItem.Name = "roomTypesToolStripMenuItem";
            this.roomTypesToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.roomTypesToolStripMenuItem.Text = "انواع الوحدات";
            this.roomTypesToolStripMenuItem.Click += new System.EventHandler(this.roomTypesToolStripMenuItem_Click);
            // 
            // manageRoomToolStripMenuItem
            // 
            this.manageRoomToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.manageRoomToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(101)))));
            this.manageRoomToolStripMenuItem.Name = "manageRoomToolStripMenuItem";
            this.manageRoomToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.manageRoomToolStripMenuItem.Text = "ادارة الوحدات";
            this.manageRoomToolStripMenuItem.Click += new System.EventHandler(this.manageRoomToolStripMenuItem_Click);
            // 
            // reservationsToolStripMenuItem
            // 
            this.reservationsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(101)))));
            this.reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
            this.reservationsToolStripMenuItem.Size = new System.Drawing.Size(95, 67);
            this.reservationsToolStripMenuItem.Text = "الحجوزات";
            this.reservationsToolStripMenuItem.Click += new System.EventHandler(this.reservationsToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(101)))));
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(81, 67);
            this.maintenanceToolStripMenuItem.Text = "الصيانة";
            this.maintenanceToolStripMenuItem.Click += new System.EventHandler(this.maintenanceToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::HotelPresentationLayer.Properties.Resources.BackGroundMain_2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1560, 703);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1560, 774);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msMainMenue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMainMenue;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الصفحة الرئيسية";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMainMenue.ResumeLayout(false);
            this.msMainMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenue;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

