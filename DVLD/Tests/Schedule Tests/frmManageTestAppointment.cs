using DVLD_Business;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Tests.Schedule_Tests
{
    public partial class frmManageTestAppointments : Form
    {
        private DataTable _dtAllAppointments;
        private int _localDrivingLicenseId;
        private TestType.enTestTypes _testType = TestType.enTestTypes.VisionTest;

        public frmManageTestAppointments(int localDrivingLicenseId, TestType.enTestTypes testType)
        {
            InitializeComponent();
            _localDrivingLicenseId = localDrivingLicenseId;
            _testType = testType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_testType)
            {

                case TestType.enTestTypes.VisionTest:
                    {
                        labTitleForm.Text = "Vision Test Appointments";
                        this.Text = labTitleForm.Text;
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Vision_512))
                        {
                            picTest.Image = Image.FromStream(ms);
                        }
                        break;
                    }

                case TestType.enTestTypes.WrittenTest:
                    {
                        labTitleForm.Text = "Written Test Appointments";
                        this.Text = labTitleForm.Text;
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Written_Test_512))
                        {
                            picTest.Image = Image.FromStream(ms);
                        }
                        break;
                    }
                case TestType.enTestTypes.StreetTest:
                    {
                        labTitleForm.Text = "Street Test Appointments";
                        this.Text = labTitleForm.Text;
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Street_Test_32))
                        {
                            picTest.Image = Image.FromStream(ms);
                        }
                        break;
                    }
            }
        }
        private void _LoadAppointmentDataToForm()
        {
            _LoadTestTypeImageAndTitle();
            uc_LocalDrivingLicenseInfoCard1.LoadLocalDrivingLicenseInfoById(_localDrivingLicenseId);
            _dtAllAppointments = TestAppointment.GetApplicationTestAppointmentsPerTestType(_localDrivingLicenseId, _testType);
            dgvAllAppointments.DataSource = _dtAllAppointments;
            labCountRecords.Text = dgvAllAppointments.RowCount.ToString();

        }
        private void frmManageTestAppointments_Load(object sender, System.EventArgs e)
        {
            _LoadAppointmentDataToForm();
        }
        private void btnAddNewAppointment_Click(object sender, System.EventArgs e)
        {
            LocalDrivingLicenseApplication localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(_localDrivingLicenseId);
            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_testType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Test lastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_testType);

            if (lastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_localDrivingLicenseId, _testType);
                frm1.ShowDialog();
                frmManageTestAppointments_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retake it.
            if (lastTest.Result == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake failed test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest(lastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationsId, _testType);
            frm2.ShowDialog();
            frmManageTestAppointments_Load(null, null);

        }
        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmScheduleTest frmSchedule = new frmScheduleTest(_localDrivingLicenseId, _testType, (int)dgvAllAppointments.CurrentRow.Cells[0].Value);
            frmSchedule.ShowDialog();
            frmManageTestAppointments_Load(null, null);
        }
        private void takeTestToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmTakeTest frmTakeTest = new frmTakeTest((int)dgvAllAppointments.CurrentRow.Cells[0].Value, _testType);
            frmTakeTest.ShowDialog();

        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


    }
}
