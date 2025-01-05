using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        enum Mode { Add = 1, Update = 2 }
        private Mode _mode;
        private Person _person;
        private int _PersonId;

        public frmAddUpdatePerson(int personId)
        {
            InitializeComponent();
            _PersonId = personId;
            _mode = personId == -1 ? Mode.Add : Mode.Update;
        }
        private void _FillCmbCountry()
        {
            DataTable dt = Person.GetNamesCountries();
            foreach (DataRow row in dt.Rows)
            {
                cmbCountry.Items.Add(row["Name"]);

            }
        }

        private void _LoadData()
        {
            if (_mode == Mode.Add)
            {
                _person = new Person();
                this.Text = "Add Person";
                labTitleForm.Text = "Add Person";
                linkLabPic.Text = "Set Image";
                return;
            }

            this.Text = "Update Person";
            labTitleForm.Text = "Update Person";
            linkLabPic.Text = "Remove Image";
            _person = Person.Find(_PersonId);
            if (_person == null)
            {
                return;
            }
            labPersonId.Text = _person.Id.ToString();
            txtAddress.Text = _person.Address;
            txtEmail.Text = _person.Email;
            txtFirstName.Text = _person.FirstName;
            txtLastName.Text = _person.LastName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtPhone.Text = _person.Phone;
            txtNationalNo.Text = _person.NationalNo;
            pickerBirth.Text = _person.DateOfBirth.ToString();
            if (_person.Gender == 1)
            {
                radioBtnFemale.Checked = true;
            }
            else
            {
                radioBtnMale.Checked = true;
            }

            string nameCountry = Person.GetNameCountryById(_person.NationalityCountryID);
            cmbCountry.SelectedIndex = cmbCountry.FindString(nameCountry);

        }

        private void frmAddUpdatePerson_Load(object sender, System.EventArgs e)
        {
            pickerBirth.MaxDate = DateTime.Now.AddYears(-18);
            cmbCountry.SelectedIndex = cmbCountry.FindString("Syria");
            _FillCmbCountry();
            _LoadData();
        }
        private void txtBoxLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtBoxNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only numbers and char
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] allowedChars = { '@', '.', '-', '_', '+' };
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !allowedChars.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void _FillDataPerson()
        {
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.ThirdName = txtThirdName.Text;
            _person.LastName = txtLastName.Text;
            _person.NationalNo = txtNationalNo.Text;
            _person.Address = txtAddress.Text;
            _person.Phone = txtPhone.Text;
            _person.Email = txtEmail.Text;
            _person.Gender = (byte)((radioBtnFemale.Checked) ? 1 : 0);
            _person.DateOfBirth = pickerBirth.Value;
            _person.NationalityCountryID = Person.GetIdCountryByName(cmbCountry.Text);
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (picError.Visible)
            {
                MessageBox.Show("You Can't Save It, By attention for entering data.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillDataPerson();
            if (_person.Save())
            {
                labPersonId.Text = _person.Id.ToString();
                MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Failed Saved ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void radioBtnFemale_CheckedChanged(object sender, System.EventArgs e)
        {
            // Convert the byte[] resource to an Image
            using (MemoryStream ms = new MemoryStream(Properties.Resources.Female_512))
            {
                picPerson.Image = Image.FromStream(ms);
            }
        }
        private void radioBtnMale_CheckedChanged(object sender, System.EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
            {
                picPerson.Image = Image.FromStream(ms);
            }
        }

        private void txtNationalNo_Leave(object sender, System.EventArgs e)
        {
            if (Person.ExistByNationalNo(Convert.ToInt32(txtNationalNo.Text)))
            {
                picError.Visible = true;
            }
            else
            {
                picError.Visible = false;
            }

        }
    }
}
