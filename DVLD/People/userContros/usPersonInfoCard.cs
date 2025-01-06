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
        public Person Person
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
            //    (_Person.Gender == 1) ? Properties.Resources.Female_512 : Properties.Resources.Male_512 :
            //    _Person.ImagePath;

            if (_Person.Gender == 1)
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
            labPersonId.Text = _Person.Id.ToString();
            txtAddress.Text = _Person.Address;
            txtBirth.Text = _Person.DateOfBirth.ToString();
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtNationalNo.Text = _Person.NationalNo;
            txtAddress.Text = _Person.Address;
            txtGender.Text = (_Person.Gender == 1) ? "Female" : "Male";
            txtName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            txtCountry.Text = Person.GetNameCountryById(_Person.NationalityCountryID);
            _LoadImagePerson();
        }

        private void _LoadPersonInfo(int personId)
        {
            _Person = Person.Find(personId);
            if (_Person == null)
            {
                MessageBox.Show($"There is no person with this Id {_Person.Id}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        private void _LoadPersonInfo(string nationalNo)
        {
            _Person = Person.FindByNationalNo(nationalNo);
            if (_Person == null)
            {
                MessageBox.Show($"There is no person with this nationalNo {_Person.NationalNo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void linkLabEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frmAddUpdate = new frmAddUpdatePerson(_PersonId);
            frmAddUpdate.ShowDialog();
            //RefreshData
            _LoadPersonInfo(_PersonId);
        }
    }
}
