using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD.Local_Driving_License_App;
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
        private void addNewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
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
            int TotalPassedTests = (int)dgvAllLDLA.CurrentRow.Cells[6].Value;

            bool LicenseExists = localDrivingLicense.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            updateToolStripMenuItem.Enabled = !LicenseExists && (localDrivingLicense.Status == Application.enApplicationStatus.New);
            scheduleTestToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menu Item
            //We only cancel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (localDrivingLicense.Status == Application.enApplicationStatus.New);

            //Enable/Disable Delete Menu Item
            //We only allow delete in case the application status is new not complete or Cancelled.
            deleteToolStripMenuItem.Enabled = (localDrivingLicense.Status == Application.enApplicationStatus.New);

            //Enable Disable Schedule menu and it's sub menu
            bool PassedVisionTest = localDrivingLicense.DoesPassTestType(TestType.enTestTypes.VisionTest); ;
            bool PassedWrittenTest = localDrivingLicense.DoesPassTestType(TestType.enTestTypes.WrittenTest);
            bool PassedStreetTest = localDrivingLicense.DoesPassTestType(TestType.enTestTypes.StreetTest);

            scheduleTestToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (localDrivingLicense.Status == Application.enApplicationStatus.New);

            if (scheduleTestToolStripMenuItem.Enabled)
            {
                //To Allow Schedule vision test, Person must not passed the same test before.
                visionTEToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schedule written test, Person must pass the vision test and must not passed the same test before.
                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schedule street test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }
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
        private void _ScheduleTest(TestType.enTestTypes testType)
        {
            int localDrivingLicenseApplicationID = (int)dgvAllLDLA.CurrentRow.Cells[0].Value;
            frmManageTestAppointments frmManageTestAppointments = new frmManageTestAppointments(localDrivingLicenseApplicationID, testType);
            frmManageTestAppointments.ShowDialog();

            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }
        private void visionTEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _ScheduleTest(TestType.enTestTypes.VisionTest);
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(TestType.enTestTypes.WrittenTest);
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(TestType.enTestTypes.StreetTest);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int activeLicenseId = -1;
            LocalDrivingLicenseApplication localDrivingLicense = LocalDrivingLicenseApplication.Find((int)dgvAllLDLA.CurrentRow.Cells[0].Value);
            if (localDrivingLicense != null)
            {
                activeLicenseId = localDrivingLicense.GetActiveLicenseID();
                if (activeLicenseId != -1)
                {
                    frmShowDriverLicenseInfo frmShowDriverLicenseInfo = new frmShowDriverLicenseInfo(activeLicenseId);
                    frmShowDriverLicenseInfo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseFirstTime frmIssueDriverLicenseFirst = new frmIssueDriverLicenseFirstTime((int)dgvAllLDLA.CurrentRow.Cells[0].Value);
            frmIssueDriverLicenseFirst.ShowDialog();

        }

        private void showPersonLicesnseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplication localDrivingLicense = LocalDrivingLicenseApplication.Find((int)dgvAllLDLA.CurrentRow.Cells[0].Value);
            if (localDrivingLicense != null)
            {
                frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(localDrivingLicense.PersonId);
                frmShowPersonLicensesHistory.ShowDialog();
            }

        }
    }
}