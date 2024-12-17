namespace DVLD_Project.User
{
    partial class frmManageUsers
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
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManageUsers = new System.Windows.Forms.DataGridView();
            this.cmsManageUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNoOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsActiveFilter = new System.Windows.Forms.ComboBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageUsers)).BeginInit();
            this.cmsManageUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.Location = new System.Drawing.Point(408, 337);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(246, 30);
            this.txtSearchText.TabIndex = 12;
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
            "User ID",
            "Person ID",
            "FullName",
            "UserName",
            "Is Active"});
            this.cbFilterData.Location = new System.Drawing.Point(137, 338);
            this.cbFilterData.Name = "cbFilterData";
            this.cbFilterData.Size = new System.Drawing.Size(246, 33);
            this.cbFilterData.TabIndex = 11;
            this.cbFilterData.SelectedIndexChanged += new System.EventHandler(this.cbFilterData_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(348, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 38);
            this.label2.TabIndex = 10;
            this.label2.Text = "Manage Users";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Filter By:";
            // 
            // dgvManageUsers
            // 
            this.dgvManageUsers.AllowUserToAddRows = false;
            this.dgvManageUsers.AllowUserToDeleteRows = false;
            this.dgvManageUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageUsers.ContextMenuStrip = this.cmsManageUser;
            this.dgvManageUsers.Location = new System.Drawing.Point(12, 377);
            this.dgvManageUsers.Name = "dgvManageUsers";
            this.dgvManageUsers.ReadOnly = true;
            this.dgvManageUsers.RowHeadersWidth = 51;
            this.dgvManageUsers.RowTemplate.Height = 24;
            this.dgvManageUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageUsers.Size = new System.Drawing.Size(933, 324);
            this.dgvManageUsers.TabIndex = 14;
            // 
            // cmsManageUser
            // 
            this.cmsManageUser.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManageUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetialsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewPersonToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.miChangePassword,
            this.toolStripMenuItem2,
            this.sendEmailToolStripMenuItem,
            this.phoneCallToolStripMenuItem});
            this.cmsManageUser.Name = "cmsManagePeople";
            this.cmsManageUser.Size = new System.Drawing.Size(229, 226);
            // 
            // showDetialsToolStripMenuItem
            // 
            this.showDetialsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonDetails_32;
            this.showDetialsToolStripMenuItem.Name = "showDetialsToolStripMenuItem";
            this.showDetialsToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.showDetialsToolStripMenuItem.Text = "Show Details";
            this.showDetialsToolStripMenuItem.Click += new System.EventHandler(this.showDetialsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Add_Person_72;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.addNewPersonToolStripMenuItem.Text = "Add New User";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Delete_32;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // miChangePassword
            // 
            this.miChangePassword.Image = global::DVLD_Project.Properties.Resources.Password_321;
            this.miChangePassword.Name = "miChangePassword";
            this.miChangePassword.Size = new System.Drawing.Size(228, 30);
            this.miChangePassword.Text = "Change Password";
            this.miChangePassword.Click += new System.EventHandler(this.miChangePassword_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 6);
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.send_email_32;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.call_32;
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.phoneCallToolStripMenuItem.Text = "Phone Call";
            this.phoneCallToolStripMenuItem.Click += new System.EventHandler(this.phoneCallToolStripMenuItem_Click);
            // 
            // lblNoOfRecords
            // 
            this.lblNoOfRecords.AutoSize = true;
            this.lblNoOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfRecords.Location = new System.Drawing.Point(178, 742);
            this.lblNoOfRecords.Name = "lblNoOfRecords";
            this.lblNoOfRecords.Size = new System.Drawing.Size(65, 32);
            this.lblNoOfRecords.TabIndex = 18;
            this.lblNoOfRecords.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 742);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "# Records:";
            // 
            // cbIsActiveFilter
            // 
            this.cbIsActiveFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActiveFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbIsActiveFilter.FormattingEnabled = true;
            this.cbIsActiveFilter.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActiveFilter.Location = new System.Drawing.Point(408, 338);
            this.cbIsActiveFilter.Name = "cbIsActiveFilter";
            this.cbIsActiveFilter.Size = new System.Drawing.Size(190, 33);
            this.cbIsActiveFilter.TabIndex = 19;
            this.cbIsActiveFilter.Visible = false;
            this.cbIsActiveFilter.SelectedIndexChanged += new System.EventHandler(this.cbIsActiveFilter_SelectedIndexChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.guna2Button1.Location = new System.Drawing.Point(745, 742);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 16;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.CheckedState.Parent = this.btnAddPerson;
            this.btnAddPerson.CustomImages.Parent = this.btnAddPerson;
            this.btnAddPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPerson.ForeColor = System.Drawing.Color.White;
            this.btnAddPerson.HoverState.Parent = this.btnAddPerson;
            this.btnAddPerson.Image = global::DVLD_Project.Properties.Resources.Add_New_User_72;
            this.btnAddPerson.ImageSize = new System.Drawing.Size(70, 70);
            this.btnAddPerson.Location = new System.Drawing.Point(807, 278);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.ShadowDecoration.Parent = this.btnAddPerson;
            this.btnAddPerson.Size = new System.Drawing.Size(118, 93);
            this.btnAddPerson.TabIndex = 15;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DVLD_Project.Properties.Resources.Users_2_400;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(292, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 230);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.guna2Button1;
            this.ClientSize = new System.Drawing.Size(945, 833);
            this.Controls.Add(this.cbIsActiveFilter);
            this.Controls.Add(this.lblNoOfRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.dgvManageUsers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.cbFilterData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageUsers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageUsers)).EndInit();
            this.cmsManageUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.ComboBox cbFilterData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvManageUsers;
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label lblNoOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbIsActiveFilter;
        private System.Windows.Forms.ContextMenuStrip cmsManageUser;
        private System.Windows.Forms.ToolStripMenuItem showDetialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miChangePassword;
    }
}