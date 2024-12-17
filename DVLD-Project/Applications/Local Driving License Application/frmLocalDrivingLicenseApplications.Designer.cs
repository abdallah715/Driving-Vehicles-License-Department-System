namespace DVLD_Project.Applications.Local_Driving_License_Application
{
    partial class frmLocalDrivingLicenseApplications
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
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.cbFilterData = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvManageLDLIcenseApp = new System.Windows.Forms.DataGridView();
            this.cmsManageLDLApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewApplication = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLDLIcenseApp)).BeginInit();
            this.cmsManageLDLApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.Location = new System.Drawing.Point(440, 297);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(283, 30);
            this.txtSearchText.TabIndex = 17;
            this.txtSearchText.Visible = false;
            this.txtSearchText.TextChanged += new System.EventHandler(this.txtSearchText_TextChanged);
            this.txtSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchText_KeyPress);
            // 
            // cbFilterData
            // 
            this.cbFilterData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterData.FormattingEnabled = true;
            this.cbFilterData.Items.AddRange(new object[] {
            "None",
            "L.D AppID",
            "National No",
            "FullName",
            "Status"});
            this.cbFilterData.Location = new System.Drawing.Point(150, 297);
            this.cbFilterData.Name = "cbFilterData";
            this.cbFilterData.Size = new System.Drawing.Size(246, 33);
            this.cbFilterData.TabIndex = 16;
            this.cbFilterData.SelectedIndexChanged += new System.EventHandler(this.cbFilterData_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(433, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 38);
            this.label2.TabIndex = 14;
            this.label2.Text = "Local Driving License Applications";
            // 
            // lblNoOfRecords
            // 
            this.lblNoOfRecords.AutoSize = true;
            this.lblNoOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfRecords.Location = new System.Drawing.Point(206, 745);
            this.lblNoOfRecords.Name = "lblNoOfRecords";
            this.lblNoOfRecords.Size = new System.Drawing.Size(65, 32);
            this.lblNoOfRecords.TabIndex = 13;
            this.lblNoOfRecords.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 745);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "# Records:";
            // 
            // dgvManageLDLIcenseApp
            // 
            this.dgvManageLDLIcenseApp.AllowUserToAddRows = false;
            this.dgvManageLDLIcenseApp.AllowUserToDeleteRows = false;
            this.dgvManageLDLIcenseApp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvManageLDLIcenseApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageLDLIcenseApp.ContextMenuStrip = this.cmsManageLDLApplications;
            this.dgvManageLDLIcenseApp.Location = new System.Drawing.Point(1, 344);
            this.dgvManageLDLIcenseApp.Name = "dgvManageLDLIcenseApp";
            this.dgvManageLDLIcenseApp.ReadOnly = true;
            this.dgvManageLDLIcenseApp.RowHeadersWidth = 51;
            this.dgvManageLDLIcenseApp.RowTemplate.Height = 24;
            this.dgvManageLDLIcenseApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageLDLIcenseApp.Size = new System.Drawing.Size(1388, 365);
            this.dgvManageLDLIcenseApp.TabIndex = 11;
            // 
            // cmsManageLDLApplications
            // 
            this.cmsManageLDLApplications.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmsManageLDLApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageLDLApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetialsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.CancelAppToolStripMenuItem,
            this.toolStripSeparator1,
            this.SechduleTestsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.issueToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showPersonToolStripMenuItem});
            this.cmsManageLDLApplications.Name = "cmsManagePeople";
            this.cmsManageLDLApplications.Size = new System.Drawing.Size(368, 324);
            this.cmsManageLDLApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageLDLApplications_Opening);
            // 
            // showDetialsToolStripMenuItem
            // 
            this.showDetialsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonDetails_32;
            this.showDetialsToolStripMenuItem.Name = "showDetialsToolStripMenuItem";
            this.showDetialsToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.showDetialsToolStripMenuItem.Text = "Show Application Details";
            this.showDetialsToolStripMenuItem.Click += new System.EventHandler(this.showDetialsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(364, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.editToolStripMenuItem.Text = "Edit Application";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Delete_32_21;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.deleteToolStripMenuItem.Text = "Delete Application";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(364, 6);
            // 
            // CancelAppToolStripMenuItem
            // 
            this.CancelAppToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Delete_32;
            this.CancelAppToolStripMenuItem.Name = "CancelAppToolStripMenuItem";
            this.CancelAppToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.CancelAppToolStripMenuItem.Text = "Canel Application";
            this.CancelAppToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(364, 6);
            // 
            // SechduleTestsToolStripMenuItem
            // 
            this.SechduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.SechduleTestsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Schedule_Test_32;
            this.SechduleTestsToolStripMenuItem.Name = "SechduleTestsToolStripMenuItem";
            this.SechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.SechduleTestsToolStripMenuItem.Text = "Schedule Tests";
            this.SechduleTestsToolStripMenuItem.Click += new System.EventHandler(this.SechduleTestsToolStripMenuItem_Click);
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Vision_Test_32;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(291, 32);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Enabled = false;
            this.scheduleWrittenTestToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Written_Test_32_Sechdule;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(291, 32);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule  Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Enabled = false;
            this.scheduleStreetTestToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(291, 32);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(364, 6);
            // 
            // issueToolStripMenuItem
            // 
            this.issueToolStripMenuItem.Enabled = false;
            this.issueToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.IssueDrivingLicense_32;
            this.issueToolStripMenuItem.Name = "issueToolStripMenuItem";
            this.issueToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.issueToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueToolStripMenuItem.Click += new System.EventHandler(this.issueToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(364, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Driver_License_483;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(364, 6);
            // 
            // showPersonToolStripMenuItem
            // 
            this.showPersonToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonLicenseHistory_512;
            this.showPersonToolStripMenuItem.Name = "showPersonToolStripMenuItem";
            this.showPersonToolStripMenuItem.Size = new System.Drawing.Size(367, 32);
            this.showPersonToolStripMenuItem.Text = "Show Person License History";
            this.showPersonToolStripMenuItem.Click += new System.EventHandler(this.showPersonToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 22);
            this.label3.TabIndex = 19;
            this.label3.Text = "Filter By:";
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.CheckedState.Parent = this.btnAddNewApplication;
            this.btnAddNewApplication.CustomImages.Parent = this.btnAddNewApplication;
            this.btnAddNewApplication.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewApplication.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewApplication.ForeColor = System.Drawing.Color.White;
            this.btnAddNewApplication.HoverState.Parent = this.btnAddNewApplication;
            this.btnAddNewApplication.Image = global::DVLD_Project.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.ImageSize = new System.Drawing.Size(70, 70);
            this.btnAddNewApplication.Location = new System.Drawing.Point(1245, 237);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.ShadowDecoration.Parent = this.btnAddNewApplication;
            this.btnAddNewApplication.Size = new System.Drawing.Size(118, 93);
            this.btnAddNewApplication.TabIndex = 18;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // btnClose
            // 
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(1062, 745);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DVLD_Project.Properties.Resources.Applications1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(528, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 232);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::DVLD_Project.Properties.Resources.Local_32;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(797, 78);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 131;
            this.pictureBox2.TabStop = false;
            // 
            // frmLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 812);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.cbFilterData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNoOfRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvManageLDLIcenseApp);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocalDrivingLicenseApplications";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLDLIcenseApp)).EndInit();
            this.cmsManageLDLApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAddNewApplication;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.ComboBox cbFilterData;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvManageLDLIcenseApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsManageLDLApplications;
        private System.Windows.Forms.ToolStripMenuItem showDetialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CancelAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem issueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}