﻿using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Renew_Local_License;
using DVLD.Applications.Replace_lost_or_damage_license;
using DVLD.ApplicationTypes;
using DVLD.Global_Classes;
using DVLD.Local_Driving_License_App;
using DVLD.People;
using DVLD.TestTypes;
using DVLD.Users;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;
        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void localLicenseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmNewLocalDrivingLicense = new frmAddUpdateLocalDrivingLicenseApplication();
            frmNewLocalDrivingLicense.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManageLocalDrivingLicenseApplication frmManageLocalDrivingLicense = new frmManageLocalDrivingLicenseApplication();
            frmManageLocalDrivingLicense.ShowDialog();

        }

        private void peopleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManagePeople managePeople = new frmManagePeople();
            managePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManageUsers manageUsers = new frmManageUsers();
            manageUsers.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Global.CurrentUser = null;
            this.Close();
            _frmLogin.Show();

        }

        private void siToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Global.CurrentUser = null;
            this.Close();
            _frmLogin.Show();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(Global.CurrentUser.Id);
            frmChangePassword.ShowDialog();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            labCurrentUser.Text = Global.CurrentUser.Username;
        }

        private void retakeTestToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManageLocalDrivingLicenseApplication frmManageLocalDrivingLicense = new frmManageLocalDrivingLicenseApplication();
            frmManageLocalDrivingLicense.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManageApplicationTypes manageApplicationTypes = new frmManageApplicationTypes();
            manageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManageTestTypes frmManageTestTypes = new frmManageTestTypes();
            frmManageTestTypes.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmRenewLocalLicense frmRenewLocalLicense = new frmRenewLocalLicense();
            frmRenewLocalLicense.ShowDialog();
        }

        private void replacementForDamagedOrLostLicenseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmReplaceLostOrDamageLicense frmReplaceLostOrDamageLicesnse = new frmReplaceLostOrDamageLicense();
            frmReplaceLostOrDamageLicesnse.ShowDialog();
        }
    }
}
