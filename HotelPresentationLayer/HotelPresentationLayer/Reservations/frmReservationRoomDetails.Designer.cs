namespace HotelPresentationLayer.Reservations
{
    partial class frmReservationRoomDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.ctrReservationRoomDetails1 = new HotelPresentationLayer.Reservations.Controls.ctrReservationRoomDetails();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.button1.Location = new System.Drawing.Point(391, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "اغلاق";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrReservationRoomDetails1
            // 
            this.ctrReservationRoomDetails1.BackColor = System.Drawing.Color.White;
            this.ctrReservationRoomDetails1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrReservationRoomDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrReservationRoomDetails1.Name = "ctrReservationRoomDetails1";
            this.ctrReservationRoomDetails1.Size = new System.Drawing.Size(462, 329);
            this.ctrReservationRoomDetails1.TabIndex = 0;
            // 
            // frmReservationRoomDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 392);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrReservationRoomDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReservationRoomDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation Room Details";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrReservationRoomDetails ctrReservationRoomDetails1;
        private System.Windows.Forms.Button button1;
    }
}