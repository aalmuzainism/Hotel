namespace HotelPresentationLayer.Maintenance
{
    partial class frmListMaintenance
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
            this.components = new System.ComponentModel.Container();
            this.cbFilterMaintenance = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.flpListMaintenance = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMaintenaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.maintenanceCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.canselToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbFilterMaintenance
            // 
            this.cbFilterMaintenance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterMaintenance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbFilterMaintenance.FormattingEnabled = true;
            this.cbFilterMaintenance.Location = new System.Drawing.Point(952, 296);
            this.cbFilterMaintenance.Name = "cbFilterMaintenance";
            this.cbFilterMaintenance.Size = new System.Drawing.Size(194, 27);
            this.cbFilterMaintenance.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnClose.Location = new System.Drawing.Point(1063, 633);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 34);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "اغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flpListMaintenance
            // 
            this.flpListMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpListMaintenance.ContextMenuStrip = this.contextMenuStrip1;
            this.flpListMaintenance.Location = new System.Drawing.Point(12, 329);
            this.flpListMaintenance.Name = "flpListMaintenance";
            this.flpListMaintenance.Size = new System.Drawing.Size(1134, 298);
            this.flpListMaintenance.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMaintenaceToolStripMenuItem,
            this.toolStripMenuItem2,
            this.maintenanceCompletedToolStripMenuItem,
            this.toolStripMenuItem1,
            this.canselToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(291, 106);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addMaintenaceToolStripMenuItem
            // 
            this.addMaintenaceToolStripMenuItem.Name = "addMaintenaceToolStripMenuItem";
            this.addMaintenaceToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.addMaintenaceToolStripMenuItem.Text = "Add/Update Maintenace";
            this.addMaintenaceToolStripMenuItem.Click += new System.EventHandler(this.addMaintenaceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(287, 6);
            // 
            // maintenanceCompletedToolStripMenuItem
            // 
            this.maintenanceCompletedToolStripMenuItem.Name = "maintenanceCompletedToolStripMenuItem";
            this.maintenanceCompletedToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.maintenanceCompletedToolStripMenuItem.Text = "Maintenance completed";
            this.maintenanceCompletedToolStripMenuItem.Click += new System.EventHandler(this.maintenanceCompletedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(287, 6);
            // 
            // canselToolStripMenuItem
            // 
            this.canselToolStripMenuItem.Name = "canselToolStripMenuItem";
            this.canselToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.canselToolStripMenuItem.Text = "Cancel";
            this.canselToolStripMenuItem.Click += new System.EventHandler(this.canselToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 30F);
            this.label1.Location = new System.Drawing.Point(509, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(132, 48);
            this.label1.TabIndex = 14;
            this.label1.Text = "الصيانة";
            // 
            // frmListMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1154, 674);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterMaintenance);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.flpListMaintenance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListMaintenance";
            this.Load += new System.EventHandler(this.frmListMaintenance_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFilterMaintenance;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flpListMaintenance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addMaintenaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem maintenanceCompletedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem canselToolStripMenuItem;
    }
}