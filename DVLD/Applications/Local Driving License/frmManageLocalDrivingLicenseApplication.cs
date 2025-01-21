using DVLD.Local_Driving_License_App;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLicenseApplication : Form
    {
        private DataTable _dtLDLA;

        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _FillComboBoxFilterBy()
        {
            foreach (DataColumn column in _dtLDLA.Columns)
            {
                cmbFilterBy.Items.Add(column);
            }
        }
        private void _ChangeFormatDgvAllLDLA()
        {
            if (dgvAllLDLA.Rows.Count > 0)
            {
                dgvAllLDLA.Columns[0].Width = 100;
                dgvAllLDLA.Columns[1].Width = 250;
                dgvAllLDLA.Columns[2].Width = 150;
                dgvAllLDLA.Columns[3].Width = 200;
                dgvAllLDLA.Columns[4].Width = 150;
                dgvAllLDLA.Columns[5].Width = 100;
                dgvAllLDLA.Columns[6].Width = 150;
            }
        }
        private void _ResetDefaultValues()
        {
            _ChangeFormatDgvAllLDLA();
            _FillComboBoxFilterBy();
            cmbFilterBy.SelectedIndex = 0;
            txtValueFilterBy.Visible = (cmbFilterBy.Text != "None");
        }
        private void _LoadDataToForm()
        {
            _dtLDLA = LocalDrivingLicenseApplication.All();
            dgvAllLDLA.DataSource = _dtLDLA;
            labCountRecords.Text = dgvAllLDLA.Rows.Count.ToString();
        }

        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
            _ResetDefaultValues();
        }

        private void btnAddLDLA_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmAddUpdateLocalDrivingLicense = new frmAddUpdateLocalDrivingLicenseApplication();
            frmAddUpdateLocalDrivingLicense.ShowDialog();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValueFilterBy.Visible = (cmbFilterBy.SelectedIndex != 0);
            if (txtValueFilterBy.Visible)
            {
                txtValueFilterBy.Text = string.Empty;
                txtValueFilterBy.Focus();
            }
        }

        private void txtValueFilterBy_TextChanged(object sender, EventArgs e)
        {
            //date and class problems
            if (cmbFilterBy.SelectedIndex == 0 || string.IsNullOrEmpty(txtValueFilterBy.Text))
            {
                _dtLDLA.DefaultView.RowFilter = null;
                labCountRecords.Text = dgvAllLDLA.Rows.Count.ToString();
                return;
            }
            switch (cmbFilterBy.Text)
            {
                case "LDLA.Id":
                case "National No":
                case "Passed Test":
                    _dtLDLA.DefaultView.RowFilter = string.Format("[{0}]={1}", cmbFilterBy.Text, txtValueFilterBy.Text);
                    break;
                default:
                    _dtLDLA.DefaultView.RowFilter = string.Format("[{0}]Like '{1}%'", cmbFilterBy.Text, txtValueFilterBy.Text);
                    break;

            }
        }

        private void txtValueFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.Text == "LDLA.Id" || cmbFilterBy.Text == "Passed Test")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
