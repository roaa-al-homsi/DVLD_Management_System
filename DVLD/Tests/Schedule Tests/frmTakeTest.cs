using DVLD.Global_Classes;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Tests.Schedule_Tests
{
    public partial class frmTakeTest : Form
    {
        private int _testAppointmentId = 1;
        private int _testId = -1;
        private Test _test;
        private TestType.enTestTypes _testTypeId;
        public frmTakeTest(int testAppointmentId, TestType.enTestTypes testTypeId)
        {
            InitializeComponent();
            _testAppointmentId = testAppointmentId;
            _testTypeId = testTypeId;

        }


        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _test.CreatedByUserId = Global.CurrentUser.Id;
            _test.Notes = txtNotes.Text;
            _test.Result = (RbPass.Checked);
            _test.TestAppointmentId = _testAppointmentId;
            if (_test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                frmTakeTest_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTakeTest_Load(object sender, System.EventArgs e)
        {
            uc_ScheduledTest1.TestTypeId = _testTypeId;
            uc_ScheduledTest1.LoadAppointmentInfo(_testAppointmentId);

            btnSave.Enabled = (uc_ScheduledTest1.TestAppointmentId != -1);//How test appointment does not find?
            _testId = uc_ScheduledTest1.TestId;
            if (_testId != -1)
            {
                _test = Test.Find(_testId);

                if (_test.Result)
                {
                    RbPass.Checked = true;
                }
                else
                {
                    RbFail.Checked = true;
                }
                txtNotes.Text = _test.Notes;
                labMessageToUser.Visible = true;
                RbFail.Enabled = false;
                RbPass.Enabled = false;


            }
            else
            {
                _test = new Test();
                labMessageToUser.Visible = false;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
