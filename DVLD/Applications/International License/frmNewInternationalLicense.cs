using DVLD.Global_Classes;
using DVLD.Licenses;
using DVLD.Licenses.International_Licenses;
using DVLD_Business;
using System;
using System.Windows.Forms;
using Application = DVLD_Business.Application;

namespace DVLD.Applications.International_License
{
    public partial class frmNewInternationalLicense : Form
    {
        private int _InternationalLicenseID = -1;

        public frmNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void uc_DriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int selectedLicenseId = obj;
            if (selectedLicenseId == -1)
            {
                return;
            }
            lbLocalLicenseId.Text = selectedLicenseId.ToString();
            lnklabLicenseHistory.Enabled = (selectedLicenseId != -1);


            int activeInternationalLicenseId = InternationalLicense.GetActiveInternationalLicenseIDByDriverID(uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DriverId);
            if (activeInternationalLicenseId != -1)
            {
                MessageBox.Show($"Person already have an active international license with ID = {activeInternationalLicenseId}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lnklabShowNewLicenseInfo.Enabled = true;
                _InternationalLicenseID = activeInternationalLicenseId;
                btnIssue.Enabled = false;
                return;
            }
            if (uc_DriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClass.Id != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lnklabShowNewLicenseInfo.Enabled = true;
                _InternationalLicenseID = activeInternationalLicenseId;
                btnIssue.Enabled = false;
                return;
            }
            btnIssue.Enabled = true;

        }

        private void frmNewInternationalLicense_Load(object sender, System.EventArgs e)
        {
            lbAppDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = Global.CurrentUser.Username;
            lbFees.Text = ApplicationType.GetFeesForSpecificApplication(Application.enApplicationType.NewInternationalLicense).ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            InternationalLicense internationalLicense = new InternationalLicense();

            internationalLicense.Date = DateTime.Parse(lbAppDate.Text);
            internationalLicense.PaidFees = decimal.Parse(lbFees.Text);
            internationalLicense.LastStatusDate = DateTime.Now;
            internationalLicense.CreateByUserId = Global.CurrentUser.Id;
            internationalLicense.PersonId = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonId;
            internationalLicense.Status = Application.enApplicationStatus.Completed;

            internationalLicense.CreatedByUserId = Global.CurrentUser.Id;
            internationalLicense.IssueDate = DateTime.Parse(lbIssueDate.Text);
            internationalLicense.ExpirationDate = DateTime.Parse(lbExpirationDate.Text);
            internationalLicense.IssuedUsingLocalLicenseId = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.Id;
            internationalLicense.IsActive = true;
            internationalLicense.DriverId = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DriverId;
            if (!internationalLicense.Save())
            {
                MessageBox.Show("Failed to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _InternationalLicenseID = internationalLicense.Id;
            lbInterLicAppId.Text = internationalLicense.Id.ToString();
            lbInterLicAppId.Text = internationalLicense.ApplicationId.ToString();

            MessageBox.Show($"International License Issued Successfully with ID={_InternationalLicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lnklabShowNewLicenseInfo.Enabled = true;
            uc_DriverLicenseWithFilter1.FilterEnabled = false;
            btnIssue.Enabled = false;

        }

        private void lnkLabShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frmShowInternationalLicenseInfo = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frmShowInternationalLicenseInfo.ShowDialog();
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

        private void frmNewInternationalLicense_Activated(object sender, EventArgs e)
        {
            uc_DriverLicenseWithFilter1.txtLicenseIDFocus();
        }
    }
}
