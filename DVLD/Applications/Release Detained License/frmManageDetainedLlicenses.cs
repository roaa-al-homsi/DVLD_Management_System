using DVLD.Licenses;
using DVLD.Licenses.Detained_Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD.People;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Release_Detained_License
{
    public partial class frmManageDetainedLicenses : Form
    {
        private DataTable _dtDetainedLicenses;
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        private void _FillComboFilterBy()
        {
            cmbFilterBy.Items.Clear();
            foreach (DataColumn dc in _dtDetainedLicenses.Columns)
            {
                if (dc.ColumnName == "Detain Date" || dc.ColumnName == "Fine Fees" || dc.ColumnName == "Release Date")
                {
                    continue;
                }
                cmbFilterBy.Items.Add(dc.ColumnName);
            }
        }
        private void ChangeFormatDgvAllDetained()
        {
            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].Width = 90;
                dgvDetainedLicenses.Columns[1].Width = 90;
                dgvDetainedLicenses.Columns[2].Width = 100;
                dgvDetainedLicenses.Columns[3].Width = 110;
                dgvDetainedLicenses.Columns[4].Width = 110;
                dgvDetainedLicenses.Columns[5].Width = 110;
                dgvDetainedLicenses.Columns[6].Width = 130;
                dgvDetainedLicenses.Columns[7].Width = 110;
                dgvDetainedLicenses.Columns[8].Width = 250;

            }
        }
        private void _RefreshData()
        {
            _dtDetainedLicenses = DetainedLicense.All();
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            labCountRecords.Text = dgvDetainedLicenses.RowCount.ToString();
            cmbFilterBy.SelectedIndex = 0;
            txtValueFilterBy.Focus();
        }
        private void FrmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshData();
            ChangeFormatDgvAllDetained();
            _FillComboFilterBy();

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();

            _RefreshData();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frmDetainLicenseApplication = new frmDetainLicenseApplication();
            frmDetainLicenseApplication.ShowDialog();
            FrmManageDetainedLicenses_Load(null, null);
        }

        private void txtValueFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.Text == "None" || string.IsNullOrWhiteSpace(txtValueFilterBy.Text))
            {
                _dtDetainedLicenses.DefaultView.RowFilter = string.Empty;
                labCountRecords.Text = dgvDetainedLicenses.RowCount.ToString();
                return;
            }
            switch (cmbFilterBy.Text)
            {
                case "D.Id":
                case "L.Id":
                case "R.App.Id":
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}]={1}", cmbFilterBy.Text, txtValueFilterBy.Text);
                    break;
                default:
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}]Like '{1}%'", cmbFilterBy.Text, txtValueFilterBy.Text.Trim());
                    break;
            }
            labCountRecords.Text = dgvDetainedLicenses.RowCount.ToString();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.Text == "Is Release")
            {
                cmbReleased.Visible = true;
                txtValueFilterBy.Visible = false;
                cmbReleased.SelectedIndex = 0;
                cmbReleased.Focus();
            }
            else
            {
                txtValueFilterBy.Visible = (cmbFilterBy.SelectedIndex != 0);
                txtValueFilterBy.Text = string.Empty;
                cmbReleased.Visible = false;
                txtValueFilterBy.Focus();
                _dtDetainedLicenses.DefaultView.RowFilter = string.Empty;

            }

        }

        private void txtValueFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.Text == "D.Id" || cmbFilterBy.Text == "L.Id" || cmbFilterBy.Text == "R.App.Id" || cmbFilterBy.Text == "National No")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private int _GetPersonId()
        {
            int personId = License.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonId;
            return personId;
        }

        private void ReleaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frmReleaseDetainedLicense.ShowDialog();
            _RefreshData();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicensesHistory frmShowPersonLicenses = new frmShowPersonLicensesHistory(_GetPersonId());
            frmShowPersonLicenses.ShowDialog();
        }

        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDriverLicenseInfo frmShowDriverLicenseInfo = new frmShowDriverLicenseInfo(_GetPersonId());
            frmShowDriverLicenseInfo.ShowDialog();
        }

        private void cmsManageDetainedLicenses_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReleaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[5].Value;
        }

        private void cmbReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterValue = string.Empty;
            switch (cmbReleased.Text)
            {
                case "Yes":
                    filterValue = "1";
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", cmbFilterBy.Text, filterValue);
                    break;
                case "No":
                    filterValue = "0";
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", cmbFilterBy.Text, filterValue);
                    break;
                default:
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Empty;
                    break;
            }
            labCountRecords.Text = _dtDetainedLicenses.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frmShowPersonInfo = new frmShowPersonInfo(_GetPersonId());
            frmShowPersonInfo.ShowDialog();
        }
    }

}
