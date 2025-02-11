using DVLD.Global_Classes;
using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD_Business;
using System;
using System.Windows.Forms;
using Application = DVLD_Business.Application;

namespace DVLD.Applications.Renew_Local_License
{
    public partial class frmRenewLocalLicense : Form
    {
        private int _licenseId;
        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            uc_DriverLicenseWithFilter1.txtLicenseIDFocus();

            lbApplicationDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = lbApplicationDate.Text;
            lbExpirationDate.Text = "??";
            lbCreatedBy.Text = Global.CurrentUser.Username;
            lbApplicationFees.Text = ApplicationType.GetFeesForSpecificApplication(Application.enApplicationType.RenewDrivingLicense).ToString();
        }

        private void uc_DriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int licenseId = obj;
            lbOldLicenseId.Text = licenseId.ToString();
            lnklabLicenseHistory.Enabled = (licenseId != -1);

            if (!uc_DriverLicenseWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show($"Selected License is not yet expired, it will expire on: {uc_DriverLicenseWithFilter1.SelectedLicenseInfo.ExpirationDate} ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                lnklabShowNewLicenseInfo.Enabled = false;
                return;
            }

            if (!uc_DriverLicenseWithFilter1.SelectedLicenseInfo.IsActive)
            {

                MessageBox.Show("Selected License is not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                lnklabShowNewLicenseInfo.Enabled = false;
                return;

            }

            lbExpirationDate.Text = DateTime.Now.AddYears(uc_DriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClass.DefaultValidityLength).ToShortDateString();
            lbLicesneFees.Text = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClass.Fees.ToString();
            lbTotalFees.Text = (float.Parse(lbApplicationFees.Text) + float.Parse(lbLicesneFees.Text)).ToString();
            txtNotes.Text = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.Notes;
            btnRenew.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            License license = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text, Global.CurrentUser.Id);
            if (license == null)
            {
                MessageBox.Show("Failed to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _licenseId = license.Id;
            lbRenewLicenseId.Text = license.Id.ToString();
            lbRLApplicationId.Text = license.ApplicationId.ToString();
            btnRenew.Enabled = false;
            uc_DriverLicenseWithFilter1.FilterEnabled = false;
            lnklabShowNewLicenseInfo.Enabled = true;
            MessageBox.Show($"Licensed Renewed Successfully with ID= {license.Id}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LnkLabShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frmShowDriverLicense = new frmShowDriverLicenseInfo(_licenseId);
            frmShowDriverLicense.ShowDialog();
        }

        private void lnkLabLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicensesHistory ShowPersonLicensesHistory = new frmShowPersonLicensesHistory(uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonId);
            ShowPersonLicensesHistory.ShowDialog();
        }

        private void frmRenewLocalLicense_Activated(object sender, EventArgs e)
        {
            uc_DriverLicenseWithFilter1.txtLicenseIDFocus();
        }
    }
}
