using DVLD.Global_Classes;
using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD_Business;
using System;
using System.Windows.Forms;
using static DVLD_Business.License;
using Application = DVLD_Business.Application;

namespace DVLD.Applications.Replace_lost_or_damage_license
{
    public partial class frmReplaceLostOrDamageLicense : Form
    {
        private int _NewLicenseId = -1;

        private License.enIssueReason _IssueReason;
        public frmReplaceLostOrDamageLicense()
        {
            InitializeComponent();
        }

        private void frmReplaceLostOrDamageLicense_Load(object sender, EventArgs e)
        {
            lbApplicationDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = Global.CurrentUser.Username;
            rdDamagedLicesne.Checked = true;
            lnklabShowNewLicenseInfo.Enabled = false;
        }
        private int _GetApplicationTypeID()
        {

            if (rdDamagedLicesne.Checked)
            {
                return (int)Application.enApplicationType.ReplaceDamagedDrivingLicense;
            }
            else
            {
                return (int)Application.enApplicationType.ReplaceLostDrivingLicense;
            }
        }

        private enIssueReason _GetIssueReason()
        {

            if (rdDamagedLicesne.Checked)
            {
                return enIssueReason.DamagedReplacement;
            }
            else
            {
                return enIssueReason.LostReplacement;
            }
        }

        private void uc_DriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int LicenseId = obj;
            lnklabLicenseHistory.Enabled = (LicenseId != -1);
            if (LicenseId == -1)
            {
                return;
            }
            if (!uc_DriverLicenseWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lnklabShowNewLicenseInfo.Enabled = false;
                btnReplacement.Enabled = false;
                return;
            }
            lbOldLicenseId.Text = LicenseId.ToString();
            btnReplacement.Enabled = true;
        }

        private void rdLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement For Lost License.";
            lbTitleForm.Text = "Replacement For Lost License.";
            lbApplicationFees.Text = ApplicationType.GetFeesForSpecificApplication((Application.enApplicationType)_GetApplicationTypeID()).ToString();

        }

        private void rdDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement For Damaged License.";
            lbTitleForm.Text = "Replacement For Damaged License.";
            lbApplicationFees.Text = ApplicationType.GetFeesForSpecificApplication((Application.enApplicationType)_GetApplicationTypeID()).ToString();

        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            License license = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), Global.CurrentUser.Id);
            if (license == null)
            {
                MessageBox.Show("Failed to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbReplacedLicenseId.Text = license.Id.ToString();
            lbRLApplicationId.Text = license.ApplicationId.ToString();

            _NewLicenseId = license.Id;
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseId.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            uc_DriverLicenseWithFilter1.FilterEnabled = false;
            lnklabShowNewLicenseInfo.Enabled = true;
        }

        private void lnkLabShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frmShowDriverLicenseInfo = new frmShowDriverLicenseInfo(_NewLicenseId);
            frmShowDriverLicenseInfo.ShowDialog();
        }

        private void lnkLabLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicensesHistory ShowPersonLicensesHistory = new frmShowPersonLicensesHistory(uc_DriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonId);
            ShowPersonLicensesHistory.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
