namespace DVLD.Licenses
{
    partial class frmShowPersonLicensesHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPersonLicensesHistory));
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.uc_DriverLicenses1 = new DVLD.Licenses.U_controls.uc_DriverLicenses();
            this.uc_PersonInfoCardWithFilter1 = new DVLD.People.userControls.uc_PersonInfoCardWithFilter();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Andalus", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(393, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(322, 35);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Person Licenses History";
            // 
            // uc_DriverLicenses1
            // 
            this.uc_DriverLicenses1.Location = new System.Drawing.Point(2, 611);
            this.uc_DriverLicenses1.Name = "uc_DriverLicenses1";
            this.uc_DriverLicenses1.Size = new System.Drawing.Size(1140, 389);
            this.uc_DriverLicenses1.TabIndex = 2;
            this.uc_DriverLicenses1.Load += new System.EventHandler(this.uc_DriverLicenses1_Load);
            // 
            // uc_PersonInfoCardWithFilter1
            // 
            this.uc_PersonInfoCardWithFilter1.FilterEnable = true;
            this.uc_PersonInfoCardWithFilter1.Location = new System.Drawing.Point(12, 53);
            this.uc_PersonInfoCardWithFilter1.Name = "uc_PersonInfoCardWithFilter1";
            this.uc_PersonInfoCardWithFilter1.ShowAddPerson = true;
            this.uc_PersonInfoCardWithFilter1.Size = new System.Drawing.Size(741, 552);
            this.uc_PersonInfoCardWithFilter1.TabIndex = 1;
            this.uc_PersonInfoCardWithFilter1.OnPersonSelected += new System.Action<int>(this.uc_PersonInfoCardWithFilter1_OnPersonSelected);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(759, 124);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(369, 277);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmShowPersonLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 1021);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.uc_DriverLicenses1);
            this.Controls.Add(this.uc_PersonInfoCardWithFilter1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Person Licenses History";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private People.userControls.uc_PersonInfoCardWithFilter uc_PersonInfoCardWithFilter1;
        private U_controls.uc_DriverLicenses uc_DriverLicenses1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}