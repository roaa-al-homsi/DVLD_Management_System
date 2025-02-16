using DVLD.Global_Classes;
using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        enum Mode { Add = 1, Update = 2 }

        private Mode _mode;

        private Person _person;
        private int _personId;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _mode = Mode.Add;
        }
        public frmAddUpdatePerson(int personId)
        {
            InitializeComponent();
            _personId = personId;
            _mode = Mode.Update;
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
            _person = Person.Find(_personId);
            if (_person == null)
            {
                MessageBox.Show($"There is no person with Id {_personId} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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
            dtpDateOfBirth.Value = _person.DateOfBirth;
            cmbCountry.SelectedIndex = cmbCountry.FindString(_person.CountryInfo.Name);

            if (_person.Gender == Person.enGender.Female)
            {
                radioBtnFemale.Checked = true;
            }
            else
            {
                radioBtnMale.Checked = true;
            }

            if (!string.IsNullOrEmpty(_person.ImagePath))
            {
                pbPersonImage.ImageLocation = _person.ImagePath;
            }

            linkLabRemoveImage.Visible = (!string.IsNullOrEmpty(_person.ImagePath));
        }
        private void _ResetDefaultValues()
        {
            _FillCmbCountry();
            if (_mode == Mode.Add)
            {
                _person = new Person();
                this.Text = "Add New a Person";
                labTitleForm.Text = "Add a Person";
            }
            else
            {
                this.Text = "Update a Person";
                labTitleForm.Text = "Update a Person";
            }
            if (radioBtnFemale.Checked)
            {
                using (MemoryStream ms = new MemoryStream(Properties.Resources.Female_512))
                {
                    pbPersonImage.Image = Image.FromStream(ms);
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
                {
                    pbPersonImage.Image = Image.FromStream(ms);
                }
            }
            linkLabRemoveImage.Visible = !string.IsNullOrEmpty(pbPersonImage.ImageLocation);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cmbCountry.SelectedIndex = cmbCountry.FindString("Syria");
            labPersonId.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSecondName.Text = string.Empty;
            txtThirdName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            dtpDateOfBirth.Text = string.Empty;
            radioBtnMale.Checked = true;
        }
        private void frmAddUpdatePerson_Load(object sender, System.EventArgs e)
        {
            _ResetDefaultValues();
            if (_mode == Mode.Update)
            {
                _LoadData();
            }
        }

        #region MyValidate
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

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] allowedChars = { '@', '.', '-', '_', '+' };
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !allowedChars.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
        private void _FillDataPerson()
        {
            _person.FirstName = txtFirstName.Text.Trim();
            _person.SecondName = txtSecondName.Text.Trim();
            _person.ThirdName = txtThirdName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.NationalNo = txtNationalNo.Text.Trim();
            _person.Address = txtAddress.Text.Trim();
            _person.Phone = txtPhone.Text.Trim();
            _person.Email = txtEmail.Text.Trim();
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Gender = ((radioBtnFemale.Checked) ? Person.enGender.Female : Person.enGender.Male);
            _person.NationalityCountryID = Person.GetIdCountryByName(cmbCountry.Text);
            _person.ImagePath = (string.IsNullOrEmpty(pbPersonImage.ImageLocation)) ? null : pbPersonImage.ImageLocation;

        }
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_person.ImagePath != string.Empty)
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (Util.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not validate ,but the mouse over red icon");
                return;
            }
            if (!_HandlePersonImage())
            {
                return;
            }
            _FillDataPerson();
            if (_person.Save())
            {
                labPersonId.Text = _person.Id.ToString();
                _mode = Mode.Update;
                labTitleForm.Text = "Update A Person";
                this.Text = "Update A Person";
                MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, _person.Id);
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
                pbPersonImage.Image = Image.FromStream(ms);
            }
        }
        private void radioBtnMale_CheckedChanged(object sender, System.EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
            {
                pbPersonImage.Image = Image.FromStream(ms);
            }
        }

        #region Validation
        private void _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(textBox, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                return;
            }

            if (!Validation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            if (txtNationalNo.Text.Trim() != _person.NationalNo && Person.ExistByNationalNo(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This national is used for another person");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        #endregion
        private void linkLabSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                pbPersonImage.ImageLocation = selectedFilePath;
                linkLabRemoveImage.Visible = true;
            }
        }
        private void linkLabRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (radioBtnFemale.Checked)
            {
                using (MemoryStream ms = new MemoryStream(Properties.Resources.Female_512))
                {
                    pbPersonImage.Image = Image.FromStream(ms);
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
                {
                    pbPersonImage.Image = Image.FromStream(ms);
                }
            }
            linkLabRemoveImage.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
