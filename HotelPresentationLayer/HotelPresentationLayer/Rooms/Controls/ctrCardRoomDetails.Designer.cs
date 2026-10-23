namespace HotelPresentationLayer.Rooms.Controls
{
    partial class ctrCardRoomDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblRoomCount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pbRoomStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber.Location = new System.Drawing.Point(113, 3);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(39, 19);
            this.lblRoomNumber.TabIndex = 1;
            this.lblRoomNumber.Text = "202";
            this.lblRoomNumber.Click += new System.EventHandler(this.ReturnData);
            this.lblRoomNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.lblRoomNumber.MouseHover += new System.EventHandler(this.ReturnData);
            this.lblRoomNumber.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRoomType.Location = new System.Drawing.Point(114, 25);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(42, 18);
            this.lblRoomType.TabIndex = 2;
            this.lblRoomType.Text = "Type";
            this.lblRoomType.MouseHover += new System.EventHandler(this.ReturnData);
            // 
            // lblRoomCount
            // 
            this.lblRoomCount.AutoSize = true;
            this.lblRoomCount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRoomCount.Location = new System.Drawing.Point(113, 46);
            this.lblRoomCount.Name = "lblRoomCount";
            this.lblRoomCount.Size = new System.Drawing.Size(16, 18);
            this.lblRoomCount.TabIndex = 3;
            this.lblRoomCount.Text = "3";
            this.lblRoomCount.MouseHover += new System.EventHandler(this.ReturnData);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPrice.Location = new System.Drawing.Point(114, 67);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(32, 18);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "250";
            this.lblPrice.MouseHover += new System.EventHandler(this.ReturnData);
            // 
            // pbRoomStatus
            // 
            this.pbRoomStatus.Image = global::HotelPresentationLayer.Properties.Resources.RoomIsReady;
            this.pbRoomStatus.Location = new System.Drawing.Point(3, 3);
            this.pbRoomStatus.Name = "pbRoomStatus";
            this.pbRoomStatus.Size = new System.Drawing.Size(104, 83);
            this.pbRoomStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRoomStatus.TabIndex = 0;
            this.pbRoomStatus.TabStop = false;
            this.pbRoomStatus.Click += new System.EventHandler(this.ReturnData);
            this.pbRoomStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.pbRoomStatus.MouseHover += new System.EventHandler(this.ReturnData);
            this.pbRoomStatus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // ctrCardRoomDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbRoomStatus);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.lblRoomCount);
            this.Name = "ctrCardRoomDetails";
            this.Size = new System.Drawing.Size(200, 89);
            this.Click += new System.EventHandler(this.ReturnData);
            this.MouseHover += new System.EventHandler(this.ReturnData);
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRoomStatus;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblRoomCount;
        private System.Windows.Forms.Label lblPrice;
    }
}
