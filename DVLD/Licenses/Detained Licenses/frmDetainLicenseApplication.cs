using DVLD.Global_Classes;
using DVLD.Licenses.Local_Licenses;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Licenses.Detained_Licenses
{
    public partial class frmDetainLicenseApplication : Form
    {
        private int _LicenseId = -1;
        private DetainedLicense _detainedLicense;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void uc_DriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseId = obj;
            lbLicenseId.Text = _LicenseId.ToString();
            lnklabLicenseHistory.Enabled = (_LicenseId != -1);
            if (_LicenseId == -1)
            {
                return;
            }

            if (uc_DriverLicenseWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This License Is Detained Aleardy!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                txtFineFees.Enabled = false;
                return;
            }
            btnDetain.Enabled = true;
            txtFineFees.Focus();
        }

        private void frmDetainLicenseApplication_Load(object sender, System.EventArgs e)
        {
            lbDetainDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = Global.CurrentUser.Username;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int detainedLicenseId = uc_DriverLicenseWithFilter1.SelectedLicenseInfo.Detain(decimal.Parse(txtFineFees.Text), Global.CurrentUser.Id);
            if (detainedLicenseId == -1)
            {
                MessageBox.Show("Failed to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbDetainId.Text = detainedLicenseId.ToString();
            MessageBox.Show($"License Detained Successfully with ID={detainedLicenseId}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            uc_DriverLicenseWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            lnklabShowLicenseInfo.Enabled = true;
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

        private void txtFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }


        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            uc_DriverLicenseWithFilter1.txtLicenseIDFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
