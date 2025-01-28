using DVLD_Business;
using System;
using System.Windows.Forms;
using Application = DVLD_Business.Application;
using TestType = DVLD_Business.TestType;

namespace DVLD.Tests.Controls
{
    public partial class uc_ScheduleTest : UserControl
    {
        public enum Mode { Add = 1, Update = 2 }
        private Mode _mode = Mode.Add;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private int _testAppointmentId = -1;
        private TestAppointment _testAppointment;
        private int _localDrivingLicenseApplicationId = -1;
        private LocalDrivingLicenseApplication _localDrivingLicenseApplication;

        private TestType.enTestTypes _TestTypeId = DVLD_Business.TestType.enTestTypes.VisionTest;

        public TestType.enTestTypes TestType
        {
            get { return _TestTypeId; }
            set
            {
                labTitleTest.Text = value.ToString();
                _TestTypeId = value;
            }
        }
        public uc_ScheduleTest()
        {
            InitializeComponent();
        }
        public uc_ScheduleTest(int testAppointment)
        {
            InitializeComponent();
            _testAppointmentId = testAppointment;
            _mode = Mode.Update;
        }

        public void LoadInfo(int localDrivingLicenseApplicationId, int testAppointmentId = -1)
        {
            _mode = (testAppointmentId == -1) ? Mode.Add : Mode.Update;

            _localDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            _testAppointmentId = testAppointmentId;

            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(localDrivingLicenseApplicationId);
            if (_localDrivingLicenseApplication == null)

            {
                MessageBox.Show($"Error: No Local Driving License Application with ID = {_localDrivingLicenseApplicationId}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            _CreationMode = (_localDrivingLicenseApplication.DoesAttendTestType(_TestTypeId)) ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;
            switch (_CreationMode)
            {
                case enCreationMode.RetakeTestSchedule:
                    labRetakeAppFees.Text = ApplicationType.GetFeesForSpecificApplication((int)Application.enApplicationType.RetakeTest).ToString();
                    labTitleTest.Text = "Schedule Retake Test ";
                    break;
                case enCreationMode.FirstTimeSchedule:
                    gbRetakeTestInfo.Enabled = false;
                    labTitleTest.Text = "Schedule Test ";
                    labRetakeAppFees.Text = "0";
                    break;
                default:
                    return;
            }


            labLDLAId.Text = _localDrivingLicenseApplication.Id.ToString();
            labPersonName.Text = _localDrivingLicenseApplication.FullName.ToString();
            labClassName.Text = _localDrivingLicenseApplication.LicenseClass.Name;
            labTrial.Text = _localDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeId).ToString();
            switch (_mode)
            {
                case Mode.Add:
                    labFees.Text = DVLD_Business.TestType.GetFeesForSpecificTest(_TestTypeId).ToString();
                    dtpDate.MinDate = DateTime.Now;
                    _testAppointment = new TestAppointment();
                    break;
                case Mode.Update:
                    if (!_LoadTestAppointmentData())
                    {
                        return;
                    }
                    break;
            }
            labTotalFees.Text = (decimal.Parse(labRetakeAppFees.Text) + _localDrivingLicenseApplication.PaidFees).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
            {
                return;
            }

            if (!_HandleAppointmentLockedConstraint())
            {
                return;
            }

            if (!_HandlePreviousTestConstraint())
            {
                return;
            }
        }

        private bool _LoadTestAppointmentData()
        {
            _testAppointment = TestAppointment.Find(_testAppointmentId);
            if (_testAppointment == null)
            {
                MessageBox.Show($"Error: No Appointment with ID = {_testAppointmentId} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }
            labFees.Text = _testAppointment.PaidFees.ToString();
            dtpDate.MinDate = (DateTime.Compare(DateTime.Now, _testAppointment.Date) < 0) ? DateTime.Now : _testAppointment.Date;
            dtpDate.Value = _testAppointment.Date;
            if (_testAppointment.RetakeTestApplicationId != -1)
            {
                labRetakeAppFees.Text = _testAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                labTitleTest.Text = "Schedule Retake Test";
                labRetakeTestId.Text = _testAppointment.RetakeTestApplicationId.ToString();
            }
            return true;
        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_mode == Mode.Add && _localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeId))
            {
                labMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_testAppointment.IsLocked)
            {
                //if appointment is locked that means the person already sat for this test
                //we cannot update locked appointment
                labMessage.Visible = true;
                labMessage.Text = "Person already sat for the test, appointment locked.";
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            else
            {
                labMessage.Visible = false;
            }
            return true;
        }

        private bool _HandlePreviousTestConstraint()
        { //we need to make sure that this person passed the previous required test before apply to the new test.
            //person can't apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.
            switch (_TestTypeId)
            {
                case DVLD_Business.TestType.enTestTypes.VisionTest:
                    labMessage.Visible = false;
                    return true;

                case DVLD_Business.TestType.enTestTypes.WrittenTest:
                    if (!_localDrivingLicenseApplication.DoesPassTestType(DVLD_Business.TestType.enTestTypes.VisionTest))
                    {
                        labMessage.Visible = true;
                        labMessage.Text = "Cannot schedule, Vision Test should be passed first";
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        labMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }
                    return true;

                case DVLD_Business.TestType.enTestTypes.StreetTest:
                    if (!_localDrivingLicenseApplication.DoesPassTestType(DVLD_Business.TestType.enTestTypes.WrittenTest))
                    {
                        labMessage.Text = "Cannot schedule, Written Test should be passed first";
                        labMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        labMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }
                    return true;
                default:
                    return false;
            }

        }








    }







}

