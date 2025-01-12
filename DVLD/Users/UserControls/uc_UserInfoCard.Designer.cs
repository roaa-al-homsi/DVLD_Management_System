namespace DVLD.Users.UserControls
{
    partial class uc_UserInfoCard
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
            this.uc_PersonInfoCard1 = new DVLD.People.userControls.uc_PersonInfoCard();
            this.panelLoginInfo = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtUserId = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIsActive = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // uc_PersonInfoCard1
            // 
            this.uc_PersonInfoCard1.Location = new System.Drawing.Point(12, 13);
            this.uc_PersonInfoCard1.Name = "uc_PersonInfoCard1";
            this.uc_PersonInfoCard1.Size = new System.Drawing.Size(723, 398);
            this.uc_PersonInfoCard1.TabIndex = 0;
            // 
            // panelLoginInfo
            // 
            this.panelLoginInfo.BorderColor = System.Drawing.Color.Black;
            this.panelLoginInfo.BorderThickness = 1;
            this.panelLoginInfo.Controls.Add(this.txtIsActive);
            this.panelLoginInfo.Controls.Add(this.txtUsername);
            this.panelLoginInfo.Controls.Add(this.txtUserId);
            this.panelLoginInfo.Controls.Add(this.guna2HtmlLabel3);
            this.panelLoginInfo.Controls.Add(this.guna2HtmlLabel2);
            this.panelLoginInfo.Controls.Add(this.guna2HtmlLabel1);
            this.panelLoginInfo.Location = new System.Drawing.Point(12, 404);
            this.panelLoginInfo.Name = "panelLoginInfo";
            this.panelLoginInfo.Size = new System.Drawing.Size(723, 157);
            this.panelLoginInfo.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(64, 15);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(88, 30);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "User Id:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(64, 57);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(88, 30);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Username:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(64, 99);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(88, 30);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Is Active:";
            // 
            // txtUserId
            // 
            this.txtUserId.AutoRoundedCorners = true;
            this.txtUserId.BackColor = System.Drawing.Color.Transparent;
            this.txtUserId.BorderColor = System.Drawing.Color.Transparent;
            this.txtUserId.BorderRadius = 16;
            this.txtUserId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserId.DefaultText = "";
            this.txtUserId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserId.Font = new System.Drawing.Font("Andalus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUserId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserId.Location = new System.Drawing.Point(196, 11);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.PasswordChar = '\0';
            this.txtUserId.PlaceholderForeColor = System.Drawing.Color.Transparent;
            this.txtUserId.PlaceholderText = "";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.SelectedText = "";
            this.txtUserId.Size = new System.Drawing.Size(177, 34);
            this.txtUserId.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.AutoRoundedCorners = true;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderRadius = 16;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Andalus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(196, 57);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.Transparent;
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(177, 34);
            this.txtUsername.TabIndex = 7;
            // 
            // txtIsActive
            // 
            this.txtIsActive.AutoRoundedCorners = true;
            this.txtIsActive.BackColor = System.Drawing.Color.Transparent;
            this.txtIsActive.BorderColor = System.Drawing.Color.Transparent;
            this.txtIsActive.BorderRadius = 16;
            this.txtIsActive.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIsActive.DefaultText = "";
            this.txtIsActive.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIsActive.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIsActive.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIsActive.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIsActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIsActive.Font = new System.Drawing.Font("Andalus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtIsActive.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIsActive.Location = new System.Drawing.Point(196, 103);
            this.txtIsActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.PasswordChar = '\0';
            this.txtIsActive.PlaceholderForeColor = System.Drawing.Color.Transparent;
            this.txtIsActive.PlaceholderText = "";
            this.txtIsActive.ReadOnly = true;
            this.txtIsActive.SelectedText = "";
            this.txtIsActive.Size = new System.Drawing.Size(177, 34);
            this.txtIsActive.TabIndex = 8;
            // 
            // uc_UserInfoCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLoginInfo);
            this.Controls.Add(this.uc_PersonInfoCard1);
            this.Name = "uc_UserInfoCard";
            this.Size = new System.Drawing.Size(745, 576);
            this.panelLoginInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private People.userControls.uc_PersonInfoCard uc_PersonInfoCard1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelLoginInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtUserId;
        private Guna.UI2.WinForms.Guna2TextBox txtIsActive;
    }
}
