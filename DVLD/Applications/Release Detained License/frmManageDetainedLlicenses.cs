using DVLD.Licenses.Detained_Licenses;
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
        private void FrmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _dtDetainedLicenses = DetainedLicense.All();
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            labCountRecords.Text = dgvDetainedLicenses.RowCount.ToString();
            ChangeFormatDgvAllDetained();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frmDetainLicenseApplication = new frmDetainLicenseApplication();
            frmDetainLicenseApplication.ShowDialog();
        }

        private void txtValueFilterBy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
