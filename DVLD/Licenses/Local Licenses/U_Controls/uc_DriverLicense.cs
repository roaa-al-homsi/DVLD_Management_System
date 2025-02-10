using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Licenses.U_controls
{
    public partial class uc_DriverLicense : UserControl
    {
        private int _licenseId = -1;
        private DVLD_Business.License _licenses;
        public int LicenseID
        {
            get { return _licenseId; }
        }
        public DVLD_Business.License SelectedLicenseInfo
        { get { return _licenses; } }
        public uc_DriverLicense()
        {
            InitializeComponent();
        }
        private void _LoadPicPerson()
        {      //mister didn't use this way. he used file to insure if a image is exist..??
            string imagePath = string.Empty;
            if (string.IsNullOrWhiteSpace(_licenses.DriverInfo.PersonInfo.ImagePath))
            {
                switch (_licenses.DriverInfo.PersonInfo.Gender)
                {
                    case DVLD_Business.Person.enGender.Male:
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
                        {
                            picPerson.Image = Image.FromStream(ms);
                        }
                        break;
                    case DVLD_Business.Person.enGender.Female:
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.Female_512))
                        {
                            picPerson.Image = Image.FromStream(ms);
                        }
                        break;
                }
            }
            else
            {
                picPerson.Load(_licenses.DriverInfo.PersonInfo.ImagePath);
            }
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
            lbIsDetained.Text = _licenses.IsDetained ? "Yes" : "No";
            lbIssueDate.Text = _licenses.IssueDate.ToShortDateString();
            lbIssueReason.Text = _licenses.IssueReasonText;
            lbLicesneId.Text = _licenses.Id.ToString();
            lbName.Text = _licenses.DriverInfo.PersonInfo.FullName;
            lbNotes.Text = string.IsNullOrWhiteSpace(_licenses.Notes) ? "No Notes.." : _licenses.Notes;
            lbClass.Text = _licenses.LicenseClass.Name;
            lbNationalNo.Text = _licenses.DriverInfo.PersonInfo.NationalNo;
            _LoadPicPerson();

        }
    }
}
