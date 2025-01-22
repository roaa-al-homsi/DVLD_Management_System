﻿using DVLD.Local_Driving_License_App;
using DVLD.Tests.Schedule_Tests;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;
using Application = DVLD_Business.Application;

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
                if (column.ColumnName == "Application Date" || column.ColumnName == "Driving Class")
                {
                    continue;
                }
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
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValueFilterBy.Visible = (cmbFilterBy.SelectedIndex != 0);
            if (txtValueFilterBy.Visible)
            {
                txtValueFilterBy.Text = string.Empty;
                txtValueFilterBy.Focus();
            }

            _dtLDLA.DefaultView.RowFilter = "";
            labCountRecords.Text = dgvAllLDLA.Rows.Count.ToString();
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

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalDrivingLicenseDetails frmShowLocalDrivingLicense = new frmShowLocalDrivingLicenseDetails((int)dgvAllLDLA.CurrentRow.Cells[0].Value);
            frmShowLocalDrivingLicense.ShowDialog();
        }

        private void addNewLicesneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmAddUpdateLocalDrivingLicense = new frmAddUpdateLocalDrivingLicenseApplication();
            frmAddUpdateLocalDrivingLicense.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmAddUpdateLocalDrivingLicense = new frmAddUpdateLocalDrivingLicenseApplication((int)dgvAllLDLA.CurrentRow.Cells[0].Value);
            frmAddUpdateLocalDrivingLicense.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application application = Application.FindBaseApplication((int)dgvAllLDLA.CurrentRow.Cells[0].Value);
            LocalDrivingLicenseApplication localDrivingLicense = LocalDrivingLicenseApplication.Find((int)dgvAllLDLA.CurrentRow.Cells[0].Value);
            if (localDrivingLicense != null)

            {
                if (MessageBox.Show("Are you sure you want cancel this application? ", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

                {
                    if (localDrivingLicense.Cancel())
                    {
                        MessageBox.Show("Application cancelled successfully..");
                    }
                    else
                    {
                        MessageBox.Show(" Failed Application cancelled ..");
                    }
                }

            }
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void cmsManageLDLA_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int localDrivingLicenseId = (int)dgvAllLDLA.CurrentRow.Cells[0].Value;
            LocalDrivingLicenseApplication localDrivingLicense = LocalDrivingLicenseApplication.Find(localDrivingLicenseId);
            switch (localDrivingLicense.Status)
            {
                case Application.enApplicationStatus.New:
                    cancelApplicationToolStripMenuItem.Enabled = true;
                    updateToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = false;
                    scheduleTestToolStripMenuItem.Enabled = true;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                    break;
                default:
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    updateToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                    scheduleTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = true;
                    break;

            }


            //if (localDrivingLicense != null)
            //{
            //    cancelApplicationToolStripMenuItem.Enabled = (localDrivingLicense.Status == Application.enApplicationStatus.New);
            //    updateToolStripMenuItem.Enabled = localDrivingLicense.Status != Application.enApplicationStatus.Completed;
            //    showLicenseToolStripMenuItem.Enabled = localDrivingLicense.Status == Application.enApplicationStatus.Completed;
            //    scheduleTestToolStripMenuItem.Enabled = localDrivingLicense.Status == Application.enApplicationStatus.New;
            //}


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            LocalDrivingLicenseApplication LocalDrivingLicenseApplication = LocalDrivingLicenseApplication.Find((int)dgvAllLDLA.CurrentRow.Cells[0].Value);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete application, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void visionTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frmManageTestAppointments = new frmManageTestAppointments();
            frmManageTestAppointments.ShowDialog();
        }
    }
}
