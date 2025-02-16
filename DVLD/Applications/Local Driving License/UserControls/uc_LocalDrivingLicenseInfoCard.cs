using DVLD.Licenses.Local_Licenses;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class uc_LocalDrivingLicenseInfoCard : UserControl
    {
        private int _localDrivingLicenseId = -1;
        private LocalDrivingLicenseApplication _localDrivingLicenseApplication;
        public uc_LocalDrivingLicenseInfoCard()
        {
            InitializeComponent();
        }
        public int localDrivingLicenseId
        {
            get { return _localDrivingLicenseId; }
        }
        private void _LoadDataToForm()
        {
            labLDLAId.Text = _localDrivingLicenseApplication.Id.ToString();
            labAppliedForLicense.Text = _localDrivingLicenseApplication.LicenseClass.Name;
            labPassedTest.Text = _localDrivingLicenseApplication.GetPassedTestCount().ToString();
            uc_BasicApplicationInfo1.LoadApplicationInfo(_localDrivingLicenseApplication.ApplicationId);
            lnkViewLicenseInfo.Enabled = _localDrivingLicenseApplication.GetActiveLicenseID() != -1;
        }
        public void LoadLocalDrivingLicenseInfoById(int localDrivingLicenseId)
        {
            _localDrivingLicenseId = localDrivingLicenseId;
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(localDrivingLicenseId);
            if (_localDrivingLicenseApplication == null)
            {

                MessageBox.Show($"There is no local driving license with this Id {localDrivingLicenseId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadDataToForm();

        }
        public void LoadLocalDrivingLicenseInfoByApplicationId(int applicationId)
        {
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.FindByApplicationId(applicationId);
            if (_localDrivingLicenseApplication == null)
            {

                MessageBox.Show($"There is no local driving license with this application Id {localDrivingLicenseId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDataToForm();

        }

        private void lnkViewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frmShowDriverLicenseInfo = new frmShowDriverLicenseInfo(_localDrivingLicenseApplication.GetActiveLicenseID());
            frmShowDriverLicenseInfo.ShowDialog();
        }
    }
}
