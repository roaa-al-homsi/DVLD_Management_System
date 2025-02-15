using DVLD.Licenses;
using DVLD.Licenses.International_Licenses;
using DVLD.People;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmManageInternationalLicenses : Form
    {
        private DataTable _dtInternationalLicenses;
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }
        private void changeFormatDgvLicenses()
        {
            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;

                dgvInternationalLicenses.Columns[7].HeaderText = "Created By User";
                dgvInternationalLicenses.Columns[7].Width = 200;
            }
        }
        private void _LoadData()
        {
            _dtInternationalLicenses = InternationalLicense.All();
            dgvInternationalLicenses.DataSource = _dtInternationalLicenses;
            labCountRecords.Text = dgvInternationalLicenses.RowCount.ToString();
            changeFormatDgvLicenses();
        }
        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frmNewInternationalLicense = new frmNewInternationalLicense();
            frmNewInternationalLicense.ShowDialog();
        }

        private void showInternationalLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frmShowInternationalLicenseInfo = new frmShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frmShowInternationalLicenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;

            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(Driver.Find(DriverID).PersonId);
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void ShowPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;

            frmShowPersonInfo frmShowPersonInfo = new frmShowPersonInfo(Driver.Find(DriverID).PersonId);
            frmShowPersonInfo.ShowDialog();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cmbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    };

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
                labCountRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
                return;
            }



            _dtInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            labCountRecords.Text = _dtInternationalLicenses.Rows.Count.ToString();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cmbFilterBy.Text != "None");

            txtFilterValue.Text = "";
            txtFilterValue.Focus();

        }

        private void cmbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

