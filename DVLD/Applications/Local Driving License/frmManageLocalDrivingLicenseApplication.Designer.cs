namespace DVLD.Applications.Local_Driving_License
{
    partial class frmManageLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageLocalDrivingLicenseApplication));
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dgvAllLDLA = new System.Windows.Forms.DataGridView();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labCountRecords = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAddLDLA = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtValueFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLDLA)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Andalus", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(537, 185);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(368, 43);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Manage Local Driving License ";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(610, 18);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(205, 161);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            // 
            // dgvAllLDLA
            // 
            this.dgvAllLDLA.AllowUserToAddRows = false;
            this.dgvAllLDLA.AllowUserToDeleteRows = false;
            this.dgvAllLDLA.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllLDLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLDLA.Location = new System.Drawing.Point(36, 300);
            this.dgvAllLDLA.Name = "dgvAllLDLA";
            this.dgvAllLDLA.ReadOnly = true;
            this.dgvAllLDLA.RowHeadersWidth = 70;
            this.dgvAllLDLA.RowTemplate.Height = 24;
            this.dgvAllLDLA.Size = new System.Drawing.Size(1291, 318);
            this.dgvAllLDLA.TabIndex = 12;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(36, 635);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(114, 32);
            this.guna2HtmlLabel3.TabIndex = 14;
            this.guna2HtmlLabel3.Text = "#Records:";
            // 
            // labCountRecords
            // 
            this.labCountRecords.AutoSize = false;
            this.labCountRecords.BackColor = System.Drawing.Color.Transparent;
            this.labCountRecords.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCountRecords.ForeColor = System.Drawing.Color.Black;
            this.labCountRecords.Location = new System.Drawing.Point(131, 634);
            this.labCountRecords.Name = "labCountRecords";
            this.labCountRecords.Size = new System.Drawing.Size(52, 33);
            this.labCountRecords.TabIndex = 13;
            this.labCountRecords.Text = "??";
            this.labCountRecords.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddLDLA
            // 
            this.btnAddLDLA.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAddLDLA.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAddLDLA.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLDLA.Image")));
            this.btnAddLDLA.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddLDLA.ImageRotate = 0F;
            this.btnAddLDLA.Location = new System.Drawing.Point(1263, 224);
            this.btnAddLDLA.Name = "btnAddLDLA";
            this.btnAddLDLA.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAddLDLA.Size = new System.Drawing.Size(64, 70);
            this.btnAddLDLA.TabIndex = 15;
            this.btnAddLDLA.Click += new System.EventHandler(this.btnAddLDLA_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(36, 253);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(114, 32);
            this.guna2HtmlLabel2.TabIndex = 16;
            this.guna2HtmlLabel2.Text = "Filter By:";
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
            this.cmbFilterBy.Location = new System.Drawing.Point(131, 249);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(229, 36);
            this.cmbFilterBy.TabIndex = 17;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
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
            this.txtValueFilterBy.Location = new System.Drawing.Point(366, 249);
            this.txtValueFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValueFilterBy.Name = "txtValueFilterBy";
            this.txtValueFilterBy.PasswordChar = '\0';
            this.txtValueFilterBy.PlaceholderText = "";
            this.txtValueFilterBy.SelectedText = "";
            this.txtValueFilterBy.Size = new System.Drawing.Size(228, 36);
            this.txtValueFilterBy.TabIndex = 18;
            this.txtValueFilterBy.TextChanged += new System.EventHandler(this.txtValueFilterBy_TextChanged);
            this.txtValueFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueFilterBy_KeyPress);
            // 
            // frmManageLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 705);
            this.Controls.Add(this.txtValueFilterBy);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.btnAddLDLA);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.labCountRecords);
            this.Controls.Add(this.dgvAllLDLA);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Local Driving License Application";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLDLA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.DataGridView dgvAllLDLA;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel labCountRecords;
        private Guna.UI2.WinForms.Guna2ImageButton btnAddLDLA;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterBy;
        private Guna.UI2.WinForms.Guna2TextBox txtValueFilterBy;
    }
}