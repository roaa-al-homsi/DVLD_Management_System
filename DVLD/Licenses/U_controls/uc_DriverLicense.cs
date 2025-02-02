using System.Windows.Forms;

namespace DVLD.Licenses.U_controls
{
    public partial class uc_DriverLicense : UserControl
    {
        private int _licenseId = -1;
        private DVLD_Business.License _licenses;
        public uc_DriverLicense()
        {
            InitializeComponent();
        }

        public void LoadDriverLicenseInfo(int licenseId)
        {
            _licenseId = licenseId;
            _licenses = DVLD_Business.License.Find(licenseId);
            if (_licenses == null)
            {
                MessageBox.Show($"Could not find License ID = {licenseId} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _licenseId = -1;
                return;
            }
            lbDateOfBirth.Text = _licenses.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lbDriverId.Text = _licenses.DriverId.ToString();
            lbExpirationDate.Text = _licenses.ExpirationDate.ToShortDateString();
            lbGendor.Text = _licenses.DriverInfo?.PersonInfo?.GenderText;//what is meaning ?. 
            lbIsActive.Text = _licenses.IsActive ? "Yes" : "No";
            //  lbIsDetained.Text = _licenses.? "Yes" : "No";
            lbIssueDate.Text = _licenses.IssueDate.ToShortDateString();
            lbIssueReason.Text = _licenses.IssueReason.ToString();
            lbLicesneId.Text = _licenses.Id.ToString();
            lbName.Text = _licenses.DriverInfo.PersonInfo.FullName;
            lbNotes.Text = _licenses.Notes.ToString();
            picPerson.Load(_licenses.DriverInfo.PersonInfo.ImagePath);
        }


    }
}
