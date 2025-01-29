using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Tests.Schedule_Tests
{
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest(int localDrivingLicenseId, TestType.enTestTypes testType, int appointmentId = -1)
        {
            InitializeComponent();

            uc_ScheduleTest1.TestType = testType;
            uc_ScheduleTest1.LoadInfo(localDrivingLicenseId, appointmentId);
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
