using DVLD.Global_Classes;
using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD_Business;
using System;
using System.Windows.Forms;
using Application = DVLD_Business.Application;

namespace DVLD.Applications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _LicenseId = -1;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicense(int licenseId)
        {
            InitializeComponent();
            _LicenseId = licenseId;
            uc_DriverLicenseWithFilter1.LoadLicenseInfo(licenseId);
            uc_DriverLicenseWithFilter1.FilterEnabled = false;

        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            lbCreatedBy.Text = Global.CurrentUser.Username;

        }
        private void uc_DriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseId = obj;
            lnklabLicenseHistory.Enabled = (_LicenseId != -1);
            if (_LicenseId == -1)
            {
                return;
            }
            if (!uc_DriverLicenseWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This License IS Not Detained So, You Can Not Release It..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }
            lbDetainId.Text = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DetainInfo.Id.ToString();
            lbFineFees.Text = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DetainInfo.FineFees.ToString();
            lbAppFees.Text = ApplicationType.GetFeesForSpecificApplication(Application.enApplicationType.ReleaseDetainedDrivingLicense).ToString();
            lbTotalFees.Text = (decimal.Parse(lbFineFees.Text) + decimal.Parse(lbAppFees.Text)).ToString();
            lbDetainDate.Text = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DetainInfo.DetainDate.ToShortDateString();
            lbLicenseId.Text = _LicenseId.ToString();
            btnRelease.Enabled = true;
        }
        private void frmReleaseDetainedLicense_Activated(object sender, EventArgs e)
        {
            uc_DriverLicenseWithFilter1.txtLicenseIDFocus();
        }
        private void lnkLabShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frmShowDriverLicenseInfo = new frmShowDriverLicenseInfo(_LicenseId);
            frmShowDriverLicenseInfo.ShowDialog();
        }
        private void lnkLabLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonId);
            frmShowPersonLicensesHistory.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (!uc_DriverLicenseWithFilter1.SelectedLicenseInfo.Release(Global.CurrentUser.Id))
            {
                MessageBox.Show("Failed to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            lbAppId.Text = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DetainInfo.ReleaseApplicationId.ToString();
            btnRelease.Enabled = false;
            uc_DriverLicenseWithFilter1.FilterEnabled = false;
            lnklabShowLicenseInfo.Enabled = false;
            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

