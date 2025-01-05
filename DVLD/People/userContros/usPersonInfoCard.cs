using DVLD_Business;
using System.Windows.Forms;
namespace DVLD.People.userControls
{
    public partial class uc_PersonInfoCard : UserControl
    {
        private Person _Person;
        private int _PersonId = -1;
        public uc_PersonInfoCard()
        {
            InitializeComponent();
        }
        public uc_PersonInfoCard(int personId)
        {
            InitializeComponent();
            _PersonId = personId;
            _Person = Person.Find(personId);
            if (_Person == null)
            {
                return;
            }
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
        }







    }
}
