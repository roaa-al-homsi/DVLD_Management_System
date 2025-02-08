namespace DVLD.Licenses.Local_Licenses.U_Controls
{
    partial class uc_DriverLicenseWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_DriverLicenseWithFilter));
            this.gbFilter = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.uc_DriverLicense1 = new DVLD.Licenses.U_controls.uc_DriverLicense();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.BorderColor = System.Drawing.Color.Black;
            this.gbFilter.BorderThickness = 0;
            this.gbFilter.Controls.Add(this.btnFind);
            this.gbFilter.Controls.Add(this.txtFilterValue);
            this.gbFilter.Controls.Add(this.guna2HtmlLabel1);
            this.gbFilter.CustomBorderColor = System.Drawing.Color.Gainsboro;
            this.gbFilter.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.ForeColor = System.Drawing.Color.Black;
            this.gbFilter.Location = new System.Drawing.Point(239, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(393, 100);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageRotate = 0F;
            this.btnFind.Location = new System.Drawing.Point(342, 56);
            this.btnFind.Name = "btnFind";
            this.btnFind.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnFind.Size = new System.Drawing.Size(53, 37);
            this.btnFind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFind.TabIndex = 4;
            this.btnFind.TabStop = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.AutoRoundedCorners = true;
            this.txtFilterValue.BackColor = System.Drawing.Color.Transparent;
            this.txtFilterValue.BorderRadius = 17;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtFilterValue.ForeColor = System.Drawing.Color.Black;
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Location = new System.Drawing.Point(140, 57);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PasswordChar = '\0';
            this.txtFilterValue.PlaceholderText = "";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(195, 36);
            this.txtFilterValue.TabIndex = 2;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(17, 64);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(85, 29);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Licesne Id:";
            // 
            // uc_DriverLicense1
            // 
            this.uc_DriverLicense1.Location = new System.Drawing.Point(0, 102);
            this.uc_DriverLicense1.Name = "uc_DriverLicense1";
            this.uc_DriverLicense1.Size = new System.Drawing.Size(927, 512);
            this.uc_DriverLicense1.TabIndex = 2;
            // 
            // uc_DriverLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_DriverLicense1);
            this.Controls.Add(this.gbFilter);
            this.Name = "uc_DriverLicenseWithFilter";
            this.Size = new System.Drawing.Size(923, 613);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbFilter;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnFind;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private U_controls.uc_DriverLicense uc_DriverLicense1;
    }
}
