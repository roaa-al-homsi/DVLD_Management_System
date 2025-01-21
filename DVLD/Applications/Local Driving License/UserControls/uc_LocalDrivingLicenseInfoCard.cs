using DVLD.People;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class uc_LocalDrivingLicenseInfoCard : UserControl
    {
        private int _localDrivingLicenseId = -1;
        private LocalDrivingLicenseApplication _localDrivingLicenseApplication;
        public int localDrivingLicenseId
        {
            get { return _localDrivingLicenseId; }
        }

        public uc_LocalDrivingLicenseInfoCard()
        {
            InitializeComponent();
        }

        private void _LoadDataToForm()
        {
            labLDLAId.Text = _localDrivingLicenseApplication.Id.ToString();
            labAppliedForLicense.Text = _localDrivingLicenseApplication.LicenseClass.Name;
            //  labPassedTest.Text=

            labApplicationId.Text = _localDrivingLicenseApplication.ApplicationId.ToString();
            labFees.Text = _localDrivingLicenseApplication.PaidFees.ToString();
            labStatus.Text = _localDrivingLicenseApplication.StatusText;
            labStatusDate.Text = _localDrivingLicenseApplication.LastStatusDate.ToString();
            labDate.Text = _localDrivingLicenseApplication.Date.ToString();
            labType.Text = _localDrivingLicenseApplication.ApplicationType.Title;
            labFullNamePerson.Text = _localDrivingLicenseApplication.FullName;
            labCreatedByUser.Text = _localDrivingLicenseApplication.CreatedByUser.Username;

        }
        public void LoadLocalDrivingLicenseInfo(int localDrivingLicenseId)
        {
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(localDrivingLicenseId);
            if (_localDrivingLicenseApplication == null)
            {

                MessageBox.Show($"There is no local driving license with this Id {localDrivingLicenseId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadDataToForm();

        }
        private void lnkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowPersonInfo frmShowPerson = new frmShowPersonInfo(_localDrivingLicenseApplication.PersonId);
            frmShowPerson.ShowDialog();
        }
    }
}
