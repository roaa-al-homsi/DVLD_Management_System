namespace DVLD.Applications.Local_Driving_License
{
    partial class frmShowLocalDrivingLicenseDetails
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
            this.labTitleForm = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.uc_LocalDrivingLicenseInfoCard1 = new DVLD.Applications.Local_Driving_License.uc_LocalDrivingLicenseInfoCard();
            this.SuspendLayout();
            // 
            // labTitleForm
            // 
            this.labTitleForm.AutoSize = false;
            this.labTitleForm.BackColor = System.Drawing.Color.Transparent;
            this.labTitleForm.Font = new System.Drawing.Font("Andalus", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitleForm.Location = new System.Drawing.Point(384, 12);
            this.labTitleForm.Name = "labTitleForm";
            this.labTitleForm.Size = new System.Drawing.Size(322, 38);
            this.labTitleForm.TabIndex = 1;
            this.labTitleForm.Text = "Local Driving License Details";
            // 
            // btnClose
            // 
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BorderRadius = 22;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(923, 577);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 46);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // uc_LocalDrivingLicenseInfoCard1
            // 
            this.uc_LocalDrivingLicenseInfoCard1.Location = new System.Drawing.Point(3, 76);
            this.uc_LocalDrivingLicenseInfoCard1.Name = "uc_LocalDrivingLicenseInfoCard1";
            this.uc_LocalDrivingLicenseInfoCard1.Size = new System.Drawing.Size(1052, 495);
            this.uc_LocalDrivingLicenseInfoCard1.TabIndex = 3;
            // 
            // frmShowLocalDrivingLicenseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 626);
            this.Controls.Add(this.uc_LocalDrivingLicenseInfoCard1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labTitleForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLocalDrivingLicenseDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Details";
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel labTitleForm;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private uc_LocalDrivingLicenseInfoCard uc_LocalDrivingLicenseInfoCard1;
    }
}