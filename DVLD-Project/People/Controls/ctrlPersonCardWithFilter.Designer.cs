namespace DVLD_Project.People.Controls
{
    partial class ctrlPersonCardWithFilter
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
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.cbFilterData = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.pbAddNewPerson = new System.Windows.Forms.PictureBox();
            this.pbSearchPerson = new System.Windows.Forms.PictureBox();
            this.ctrlPersonCard1 = new DVLD_Project.People.Controls.ctrlPersonCard();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.Location = new System.Drawing.Point(336, 40);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(246, 30);
            this.txtSearchText.TabIndex = 11;
            this.txtSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchText_KeyPress);
            // 
            // cbFilterData
            // 
            this.cbFilterData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterData.FormattingEnabled = true;
            this.cbFilterData.Items.AddRange(new object[] {
            "National No",
            "Person ID"});
            this.cbFilterData.Location = new System.Drawing.Point(124, 37);
            this.cbFilterData.Name = "cbFilterData";
            this.cbFilterData.Size = new System.Drawing.Size(190, 33);
            this.cbFilterData.TabIndex = 10;
            this.cbFilterData.SelectedIndexChanged += new System.EventHandler(this.cbFilterData_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filter By:";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.pbAddNewPerson);
            this.gbFilter.Controls.Add(this.pbSearchPerson);
            this.gbFilter.Controls.Add(this.txtSearchText);
            this.gbFilter.Controls.Add(this.cbFilterData);
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbFilter.Location = new System.Drawing.Point(22, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(755, 97);
            this.gbFilter.TabIndex = 12;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // pbAddNewPerson
            // 
            this.pbAddNewPerson.BackgroundImage = global::DVLD_Project.Properties.Resources.Add_Person_72;
            this.pbAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAddNewPerson.Location = new System.Drawing.Point(656, 38);
            this.pbAddNewPerson.Name = "pbAddNewPerson";
            this.pbAddNewPerson.Size = new System.Drawing.Size(32, 32);
            this.pbAddNewPerson.TabIndex = 13;
            this.pbAddNewPerson.TabStop = false;
            this.pbAddNewPerson.Click += new System.EventHandler(this.pbAddNewPerson_Click);
            // 
            // pbSearchPerson
            // 
            this.pbSearchPerson.BackgroundImage = global::DVLD_Project.Properties.Resources.SearchPerson;
            this.pbSearchPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSearchPerson.Location = new System.Drawing.Point(606, 38);
            this.pbSearchPerson.Name = "pbSearchPerson";
            this.pbSearchPerson.Size = new System.Drawing.Size(32, 32);
            this.pbSearchPerson.TabIndex = 12;
            this.pbSearchPerson.TabStop = false;
            this.pbSearchPerson.Click += new System.EventHandler(this.pbSearchPerson_Click);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(22, 106);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(778, 277);
            this.ctrlPersonCard1.TabIndex = 13;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(809, 405);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.ComboBox cbFilterData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.PictureBox pbSearchPerson;
        private System.Windows.Forms.PictureBox pbAddNewPerson;
        private ctrlPersonCard ctrlPersonCard1;
    }
}
