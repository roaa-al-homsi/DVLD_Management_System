using DVLD_Business;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace DVLD.People.userControls
{
    public partial class uc_PersonInfoCard : UserControl
    {
        private Person _Person;
        private int _PersonId = -1;
        public int PersonId
        {
            get { return _PersonId; }
        }
        public Person SelectedPersonInfo
        {
            get { return _Person; }
        }
        public uc_PersonInfoCard()
        {
            InitializeComponent();
        }
        private void _LoadImagePerson()
        {
            //picPerson.ImageLocation = string.IsNullOrWhiteSpace(_Person.ImagePath) ?
            //    (_Person.enGender == 1) ? Properties.Resources.Female_512 : Properties.Resources.Male_512 :
            //    _Person.ImagePath;

            if (_Person.Gender == 0)
            {
                using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
                {
                    picPerson.Image = Image.FromStream(ms);
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(Properties.Resources.Female_512))
                {
                    picPerson.Image = Image.FromStream(ms);
                }
            }
            if (!string.IsNullOrWhiteSpace(_Person.ImagePath))
            {
                if (File.Exists(_Person.ImagePath))
                {
                    picPerson.ImageLocation = _Person.ImagePath;
                }
                else { MessageBox.Show($"There is no image with this path : {_Person.ImagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        }
        private void _FillPersonInfo()
        {
            _PersonId = _Person.Id;
            LabPersonId.Text = _Person.Id.ToString();
            txtAddress.Text = _Person.Address;
            txtBirth.Text = _Person.DateOfBirth.ToString();
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtNationalNo.Text = _Person.NationalNo;
            txtAddress.Text = _Person.Address;
            txtGender.Text = _Person.GenderText;
            txtName.Text = (string.IsNullOrWhiteSpace(_Person.ThirdName)) ? $"{_Person.FirstName} {_Person.SecondName} {_Person.LastName}" :
                $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            txtCountry.Text = Person.GetNameCountryById(_Person.NationalityCountryID);
            linkLabEdit.Enabled = true;
            _LoadImagePerson();
        }
        private void _ResetPersonInfo()
        {
            txtAddress.Text = string.Empty;
            txtBirth.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGender.Text = string.Empty;
            txtName.Text = string.Empty;
            txtCountry.Text = string.Empty;

            using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
            {
                picPerson.Image = Image.FromStream(ms);
            }

        }
        public void LoadPersonInfo(int personId)
        {
            _Person = Person.Find(personId);
            if (_Person == null)
            {
                //_ResetPersonInfo();
                MessageBox.Show($"There is no person with this Id {personId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string nationalNo)
        {
            _Person = Person.FindByNationalNo(nationalNo);
            if (_Person == null)
            {
                MessageBox.Show($"There is no person with this nationalNo {nationalNo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void linklabEdit_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frmAddUpdate = new frmAddUpdatePerson(_PersonId);
            frmAddUpdate.ShowDialog();
            //RefreshData
            LoadPersonInfo(_PersonId);
        }

        private void picPerson_Click(object sender, System.EventArgs e)
        {

        }
    }
}
