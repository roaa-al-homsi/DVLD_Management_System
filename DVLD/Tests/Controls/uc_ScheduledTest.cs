using DVLD_Business;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestType = DVLD_Business.TestType;


namespace DVLD.Tests.Controls
{
    public partial class uc_ScheduledTest : UserControl
    {
        private int _testAppointmentId = -1;
        private TestAppointment _testAppointment;
        private int _localDrivingLicenseApplicationId = -1;
        private LocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private TestType.enTestTypes _testTypeId = TestType.enTestTypes.VisionTest;
        private int _testId;
        public int TestAppointmentId
        {
            get { return _testAppointmentId; }
        }
        public TestType.enTestTypes TestTypeId
        {
            get { return _testTypeId; }
            set
            {
                _testTypeId = value;
                switch (_testTypeId)
                {
                    case DVLD_Business.TestType.enTestTypes.VisionTest:
                        gbTestType.Text = "Vision Test";
                        labTitleTest.Text = "Schedule Vision Test";
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Vision_512))
                        {
                            picTestType.Image = Image.FromStream(ms);
                        }
                        return;
                    case DVLD_Business.TestType.enTestTypes.WrittenTest:
                        gbTestType.Text = "Written Test";
                        labTitleTest.Text = "Schedule Written Test";
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Written_Test_512))
                        {
                            picTestType.Image = Image.FromStream(ms);
                        }
                        return;
                    case DVLD_Business.TestType.enTestTypes.StreetTest:
                        gbTestType.Text = "Street Test";
                        labTitleTest.Text = "Schedule Street Test";
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Street_Test_32))
                        {
                            picTestType.Image = Image.FromStream(ms);
                        }
                        return;
                }

            }
        }
        public int TestId
        {
            get
            {
                return _testId;
            }
        }
        public uc_ScheduledTest()
        {
            InitializeComponent();
        }
        public void LoadAppointmentInfo(int testAppointmentId)
        {
            _testAppointmentId = testAppointmentId;
            _testAppointment = TestAppointment.Find(_testAppointmentId);
            if (_testAppointment == null)
            {
                MessageBox.Show($"Error: No  Appointment ID = {_testAppointmentId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _testAppointmentId = -1;
                return;
            }
            _testId = _testAppointment.TestID;
            _localDrivingLicenseApplicationId = _testAppointment.LocalDrivingLicenseApplicationsId;
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(_localDrivingLicenseApplicationId);
            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show($"Error: No Local Driving License Application with ID = {_localDrivingLicenseApplication}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            labLDLAId.Text = _localDrivingLicenseApplicationId.ToString();
            labClassName.Text = _localDrivingLicenseApplication.LicenseClass.Name;
            labPersonName.Text = _localDrivingLicenseApplication.FullName;
            labFees.Text = _testAppointment.PaidFees.ToString();
            labDate.Text = _testAppointment.Date.ToString("dd/MMM/yyyy");
            labTestId.Text = (_testAppointment.TestID == -1) ? "No Taken Yet.." : _testAppointment.TestID.ToString();

            //numbers of trials for this test before 
            labTrial.Text = _localDrivingLicenseApplication.TotalTrialsPerTest(_testTypeId).ToString();


        }


    }

}
