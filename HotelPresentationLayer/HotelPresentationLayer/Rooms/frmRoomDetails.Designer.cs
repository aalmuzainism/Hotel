namespace HotelPresentationLayer.Rooms
{
    partial class frmRoomDetails
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
            this.ctrRoomDetails1 = new HotelPresentationLayer.Rooms.Controls.ctrRoomDetails();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrRoomDetails1
            // 
            this.ctrRoomDetails1.BackColor = System.Drawing.Color.White;
            this.ctrRoomDetails1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrRoomDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrRoomDetails1.Name = "ctrRoomDetails1";
            this.ctrRoomDetails1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrRoomDetails1.Size = new System.Drawing.Size(444, 527);
            this.ctrRoomDetails1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Location = new System.Drawing.Point(371, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 41);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRoomDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 598);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrRoomDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRoomDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRoomDetails";
            this.Load += new System.EventHandler(this.frmRoomDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrRoomDetails ctrRoomDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}