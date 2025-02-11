using DVLD.Licenses;
using DVLD.People;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmManageDrivers : Form
    {
        private DataTable _dtDrivers;

        public frmManageDrivers()
        {
            InitializeComponent();
        }
        private void _changeDesignDgvDrivers()
        {
            if (dgvAllDrivers.Rows.Count > 0)
            {
                dgvAllDrivers.Columns[0].Width = 100;
                dgvAllDrivers.Columns[1].Width = 100;
                dgvAllDrivers.Columns[2].Width = 150;
                dgvAllDrivers.Columns[3].Width = 200;
                dgvAllDrivers.Columns[4].Width = 175;
                dgvAllDrivers.Columns[5].Width = 150;
            }
        }
        private void _FillCmbFilterBy()
        {
            foreach (DataColumn dc in _dtDrivers.Columns)
            {
                if (dc.ColumnName.Equals("Created Date") || dc.ColumnName.Equals("Activate Licenses"))
                {
                    continue;
                }
                cmbFilterBy.Items.Add(dc.ColumnName);
            }
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _dtDrivers = Driver.All();
            dgvAllDrivers.DataSource = _dtDrivers;
            labCountRecords.Text = dgvAllDrivers.RowCount.ToString();
            _changeDesignDgvDrivers();
            _FillCmbFilterBy();
            cmbFilterBy.SelectedIndex = 0;
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cmbFilterBy.Text)
            {
                case "Person Id":
                case "Driver Id":
                case "National No":
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cmbFilterBy.Text != "None");

            txtFilterValue.Text = string.Empty;
            txtFilterValue.Focus();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.Text == "None" || string.IsNullOrEmpty(txtFilterValue.Text))
            {
                _dtDrivers.DefaultView.RowFilter = string.Empty;
                labCountRecords.Text = dgvAllDrivers.RowCount.ToString();
                return;
            }

            switch (cmbFilterBy.Text)
            {
                case "Person Id":
                case "Driver Id":
                case "National No":
                    _dtDrivers.DefaultView.RowFilter = string.Format("[{0}]={1}", cmbFilterBy.Text, txtFilterValue.Text.Trim());
                    break;
                default:
                    _dtDrivers.DefaultView.RowFilter = string.Format("[{0}]Like '{1}%'", cmbFilterBy.Text, txtFilterValue.Text.Trim());
                    break;
            }
            labCountRecords.Text = dgvAllDrivers.RowCount.ToString();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frmShowPersonInfo = new frmShowPersonInfo((int)dgvAllDrivers.CurrentRow.Cells[1].Value);
            frmShowPersonInfo.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory((int)dgvAllDrivers.CurrentRow.Cells[1].Value);
            frmShowPersonLicensesHistory.ShowDialog();
        }
    }
}
