using DVLD.Global_Classes;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _localDrivingLicenseApplicationId = -1;
        private LocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private DVLD_Business.License _license;
        public frmIssueDriverLicenseFirstTime(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(_localDrivingLicenseApplicationId);
            if (_localDrivingLicenseApplication == null)
            {

                MessageBox.Show($"No Application with ID = {_localDrivingLicenseApplicationId}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (_localDrivingLicenseApplication.GetPassedTestCount() != 3)
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int licenseID = _localDrivingLicenseApplication.GetActiveLicenseID();
            if (licenseID != -1)
            {

                MessageBox.Show($"Person already has License before with License ID= {licenseID}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }
            uc_LocalDrivingLicenseInfoCard1.LoadLocalDrivingLicenseInfoById(_localDrivingLicenseApplicationId);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            int licenseId = _localDrivingLicenseApplication.IssueLicenseForTheFirstTime(txtNotes.Text, Global.CurrentUser.Id);
            if (licenseId != -1)
            {
                MessageBox.Show($"License Issued Successfully with License ID ={licenseId}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
