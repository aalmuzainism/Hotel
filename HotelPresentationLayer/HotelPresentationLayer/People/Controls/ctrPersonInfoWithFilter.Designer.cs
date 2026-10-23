namespace HotelPresentationLayer.People.Controls
{
    partial class ctrPersonInfoWithFilter
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.pbSearchPerson = new System.Windows.Forms.PictureBox();
            this.pbAddPerson = new System.Windows.Forms.PictureBox();
            this.cbMenue = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ctrPersonInfo1 = new HotelPresentationLayer.People.Controls.ctrPersonInfo();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.pbSearchPerson);
            this.gbFilter.Controls.Add(this.pbAddPerson);
            this.gbFilter.Controls.Add(this.cbMenue);
            this.gbFilter.Controls.Add(this.txtSearch);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbFilter.Location = new System.Drawing.Point(4, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(595, 72);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // pbSearchPerson
            // 
            this.pbSearchPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSearchPerson.Image = global::HotelPresentationLayer.Properties.Resources.SearchPerson;
            this.pbSearchPerson.Location = new System.Drawing.Point(541, 26);
            this.pbSearchPerson.Name = "pbSearchPerson";
            this.pbSearchPerson.Size = new System.Drawing.Size(48, 31);
            this.pbSearchPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearchPerson.TabIndex = 3;
            this.pbSearchPerson.TabStop = false;
            this.pbSearchPerson.Click += new System.EventHandler(this.pbSearchPerson_Click);
            // 
            // pbAddPerson
            // 
            this.pbAddPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAddPerson.Image = global::HotelPresentationLayer.Properties.Resources.Add_Person_40;
            this.pbAddPerson.Location = new System.Drawing.Point(484, 26);
            this.pbAddPerson.Name = "pbAddPerson";
            this.pbAddPerson.Size = new System.Drawing.Size(51, 31);
            this.pbAddPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddPerson.TabIndex = 2;
            this.pbAddPerson.TabStop = false;
            this.pbAddPerson.Click += new System.EventHandler(this.pbAddPerson_Click);
            // 
            // cbMenue
            // 
            this.cbMenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMenue.Font = new System.Drawing.Font("Tahoma", 14F);
            this.cbMenue.FormattingEnabled = true;
            this.cbMenue.Items.AddRange(new object[] {
            "Person ID",
            "National ID"});
            this.cbMenue.Location = new System.Drawing.Point(6, 26);
            this.cbMenue.Name = "cbMenue";
            this.cbMenue.Size = new System.Drawing.Size(121, 31);
            this.cbMenue.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtSearch.Location = new System.Drawing.Point(133, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 30);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // ctrPersonInfo1
            // 
            this.ctrPersonInfo1.BackColor = System.Drawing.Color.White;
            this.ctrPersonInfo1.Location = new System.Drawing.Point(4, 81);
            this.ctrPersonInfo1.Name = "ctrPersonInfo1";
            this.ctrPersonInfo1.Size = new System.Drawing.Size(602, 362);
            this.ctrPersonInfo1.TabIndex = 0;
            // 
            // ctrPersonInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrPersonInfo1);
            this.Name = "ctrPersonInfoWithFilter";
            this.Size = new System.Drawing.Size(607, 447);
            this.Load += new System.EventHandler(this.ctrPersonInfoWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonInfo ctrPersonInfo1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.ComboBox cbMenue;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pbSearchPerson;
        private System.Windows.Forms.PictureBox pbAddPerson;
    }
}
