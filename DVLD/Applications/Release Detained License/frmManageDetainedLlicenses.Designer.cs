namespace DVLD.Applications.Release_Detained_License
{
    partial class frmManageDetainedLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDetainedLicenses));
            this.txtValueFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnDetain = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labCountRecords = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicesnseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsManageLDLA = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.cmbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRelease = new Guna.UI2.WinForms.Guna2ImageButton();
            this.cmsManageLDLA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValueFilterBy
            // 
            this.txtValueFilterBy.AutoRoundedCorners = true;
            this.txtValueFilterBy.BorderRadius = 17;
            this.txtValueFilterBy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValueFilterBy.DefaultText = "";
            this.txtValueFilterBy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtValueFilterBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtValueFilterBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValueFilterBy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValueFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValueFilterBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtValueFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValueFilterBy.Location = new System.Drawing.Point(335, 243);
            this.txtValueFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValueFilterBy.Name = "txtValueFilterBy";
            this.txtValueFilterBy.PasswordChar = '\0';
            this.txtValueFilterBy.PlaceholderText = "";
            this.txtValueFilterBy.SelectedText = "";
            this.txtValueFilterBy.Size = new System.Drawing.Size(228, 36);
            this.txtValueFilterBy.TabIndex = 27;
            this.txtValueFilterBy.TextChanged += new System.EventHandler(this.txtValueFilterBy_TextChanged);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(5, 247);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(114, 32);
            this.guna2HtmlLabel2.TabIndex = 25;
            this.guna2HtmlLabel2.Text = "Filter By:";
            // 
            // btnDetain
            // 
            this.btnDetain.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDetain.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDetain.Image = ((System.Drawing.Image)(resources.GetObject("btnDetain.Image")));
            this.btnDetain.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDetain.ImageRotate = 0F;
            this.btnDetain.Location = new System.Drawing.Point(1116, 218);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDetain.Size = new System.Drawing.Size(64, 70);
            this.btnDetain.TabIndex = 24;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(5, 629);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(114, 32);
            this.guna2HtmlLabel3.TabIndex = 23;
            this.guna2HtmlLabel3.Text = "#Records:";
            // 
            // labCountRecords
            // 
            this.labCountRecords.AutoSize = false;
            this.labCountRecords.BackColor = System.Drawing.Color.Transparent;
            this.labCountRecords.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCountRecords.ForeColor = System.Drawing.Color.Black;
            this.labCountRecords.Location = new System.Drawing.Point(100, 628);
            this.labCountRecords.Name = "labCountRecords";
            this.labCountRecords.Size = new System.Drawing.Size(52, 33);
            this.labCountRecords.TabIndex = 22;
            this.labCountRecords.Text = "??";
            this.labCountRecords.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleStreetTestToolStripMenuItem.Image")));
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.scheduleStreetTestToolStripMenuItem.Text = "schedule Street Test";
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleWrittenTestToolStripMenuItem.Image")));
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.scheduleWrittenTestToolStripMenuItem.Text = "schedule Written Test";
            // 
            // visionTEToolStripMenuItem
            // 
            this.visionTEToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visionTEToolStripMenuItem.Image")));
            this.visionTEToolStripMenuItem.Name = "visionTEToolStripMenuItem";
            this.visionTEToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.visionTEToolStripMenuItem.Text = "schedule Vision Test";
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTEToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheduleTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleTestToolStripMenuItem.Image")));
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.scheduleTestToolStripMenuItem.Text = " schedule Test";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.deleteToolStripMenuItem.Text = " Delete Application";
            // 
            // showPersonLicesnseHistoryToolStripMenuItem
            // 
            this.showPersonLicesnseHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonLicesnseHistoryToolStripMenuItem.Image")));
            this.showPersonLicesnseHistoryToolStripMenuItem.Name = "showPersonLicesnseHistoryToolStripMenuItem";
            this.showPersonLicesnseHistoryToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showPersonLicesnseHistoryToolStripMenuItem.Text = "Show Person Licesnse History";
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseToolStripMenuItem.Image")));
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("issueDrivingLicenseFirstTimeToolStripMenuItem.Image")));
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelApplicationToolStripMenuItem.Image")));
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            // 
            // addNewLicenseToolStripMenuItem
            // 
            this.addNewLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewLicenseToolStripMenuItem.Image")));
            this.addNewLicenseToolStripMenuItem.Name = "addNewLicenseToolStripMenuItem";
            this.addNewLicenseToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.addNewLicenseToolStripMenuItem.Text = "Add New Licesne";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateToolStripMenuItem.Image")));
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // cmsManageLDLA
            // 
            this.cmsManageLDLA.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageLDLA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.addNewLicenseToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicesnseHistoryToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.scheduleTestToolStripMenuItem});
            this.cmsManageLDLA.Name = "cmsManageLDLA";
            this.cmsManageLDLA.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsManageLDLA.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsManageLDLA.RenderStyle.ColorTable = null;
            this.cmsManageLDLA.RenderStyle.RoundedEdges = true;
            this.cmsManageLDLA.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsManageLDLA.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsManageLDLA.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsManageLDLA.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsManageLDLA.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsManageLDLA.Size = new System.Drawing.Size(297, 238);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.AutoRoundedCorners = true;
            this.cmbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cmbFilterBy.BorderRadius = 17;
            this.cmbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFilterBy.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.cmbFilterBy.ItemHeight = 30;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None"});
            this.cmbFilterBy.Location = new System.Drawing.Point(100, 243);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(229, 36);
            this.cmbFilterBy.TabIndex = 26;
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.ContextMenuStrip = this.cmsManageLDLA;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(5, 294);
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.RowHeadersWidth = 70;
            this.dgvDetainedLicenses.RowTemplate.Height = 24;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1175, 281);
            this.dgvDetainedLicenses.TabIndex = 21;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(579, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(205, 161);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 20;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Andalus", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(506, 179);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(312, 43);
            this.guna2HtmlLabel1.TabIndex = 19;
            this.guna2HtmlLabel1.Text = "Manage Detained License ";
            // 
            // btnRelease
            // 
            this.btnRelease.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnRelease.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnRelease.Image = ((System.Drawing.Image)(resources.GetObject("btnRelease.Image")));
            this.btnRelease.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRelease.ImageRotate = 0F;
            this.btnRelease.Location = new System.Drawing.Point(1028, 218);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnRelease.Size = new System.Drawing.Size(64, 70);
            this.btnRelease.TabIndex = 28;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 761);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.txtValueFilterBy);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.labCountRecords);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "frmManageDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Detained Llicenses";
            this.Load += new System.EventHandler(this.FrmManageDetainedLicenses_Load);
            this.cmsManageLDLA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtValueFilterBy;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ImageButton btnDetain;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel labCountRecords;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicesnseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsManageLDLA;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterBy;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ImageButton btnRelease;
    }
}