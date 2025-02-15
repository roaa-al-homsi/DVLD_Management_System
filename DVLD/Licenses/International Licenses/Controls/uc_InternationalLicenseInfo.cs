using DVLD_Business;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Licenses.International_Licenses.Controls
{
    public partial class uc_InternationalLicenseInfo : UserControl
    {
        private int _internationalLicenseId = -1;
        private InternationalLicense _internationalLicense;
        public uc_InternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public int InternationalLicenseId
        {
            get { return _internationalLicenseId; }
        }
        public InternationalLicense SelectedInternationalLicenseInfo
        { get { return _internationalLicense; } }

        private void _LoadPicPerson()
        {      //mister didn't use this way. he used file to insure if a image is exist..??
            string imagePath = string.Empty;
            if (string.IsNullOrWhiteSpace(_internationalLicense.DriverInfo.PersonInfo.ImagePath))
            {
                switch (_internationalLicense.DriverInfo.PersonInfo.Gender)
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
                picPerson.Load(_internationalLicense.DriverInfo.PersonInfo.ImagePath);
            }
        }
        public void LoadDriverLicenseInfo(int internationalLicenseId)
        {
            _internationalLicenseId = internationalLicenseId;
            _internationalLicense = InternationalLicense.Find(_internationalLicenseId);
            if (_internationalLicense == null)
            {
                MessageBox.Show($"Could not find international License ID = {_internationalLicenseId} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _internationalLicenseId = -1;
                return;
            }
            lbDateOfBirth.Text = _internationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lbDriverId.Text = _internationalLicense.DriverId.ToString();
            lbExpiratioinDate.Text = _internationalLicense.ExpirationDate.ToShortDateString();
            lbGendor.Text = _internationalLicense.DriverInfo?.PersonInfo?.GenderText;//what is meaning ?. 
            lbIsActive.Text = _internationalLicense.IsActive ? "Yes" : "No";
            lbIssueDate.Text = _internationalLicense.IssueDate.ToShortDateString();
            lbLicesneId.Text = _internationalLicense.IssuedUsingLocalLicenseId.ToString();
            lbName.Text = _internationalLicense.DriverInfo.PersonInfo.FullName;
            lbIntLicId.Text = _internationalLicense.Id.ToString();
            lbNationalNo.Text = _internationalLicense.DriverInfo.PersonInfo.NationalNo;
            lbApplicationId.Text = _internationalLicense.ApplicationId.ToString();
            _LoadPicPerson();
        }

    }
}
