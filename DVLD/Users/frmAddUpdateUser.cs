using DVLD_Business;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private enum Mode { Add = 1, Update = 2 }
        private Mode _mode = Mode.Add;
        private User _user;
        private int _userId;
        public frmAddUpdateUser()
        {
            InitializeComponent();
        }
        public frmAddUpdateUser(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _mode = Mode.Update;

        }
        private void _LoadDataToForm()
        {
            if (_mode == Mode.Add)
            {
                this.Text = "Add A User";
                labTitleForm.Text = "Add A User";
                _user = new User();
                tabLoginInfo.Enabled = false;
                uc_PersonInfoCardWithFilter1.FilterFocus();
                return;
            }
            this.Text = "Update A User";
            labTitleForm.Text = "Update A User";
            _user = User.Find(_userId);
            if (_user == null)
            {
                MessageBox.Show($"There isn't user with this Id {_userId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            uc_PersonInfoCardWithFilter1.FilterEnable = false;
            uc_PersonInfoCardWithFilter1.LoadPersonInfo(_user.PersonId);
            labUserId.Text = _userId.ToString();
            txtPassword.Text = _user.Password;
            txtUserName.Text = _user.Username;
            chkIsActive.Checked = _user.IsActive;

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_mode == Mode.Update)
            {
                tabLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tabLoginInfo"];
                return;
            }
            if (uc_PersonInfoCardWithFilter1.PersonId != -1)
            {
                if (User.ExistByPersonId(uc_PersonInfoCardWithFilter1.PersonId))
                {
                    MessageBox.Show("Selected Person Aleardy A User ,Choose Another One..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uc_PersonInfoCardWithFilter1.FilterFocus();
                }

                else
                {
                    tabLoginInfo.Enabled = true;
                    btnSave.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tabLoginInfo"];
                    picUser.ImageLocation = uc_PersonInfoCardWithFilter1.SelectedPerson.ImagePath;
                }
            }
            else
            {
                MessageBox.Show("Please Select A Person", "Select A Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uc_PersonInfoCardWithFilter1.FilterFocus();

            }
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.Male_512))
            {
                picUser.Image = Image.FromStream(ms);
            }
            _LoadDataToForm();
        }

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation Doesn't Match Password!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This Field Is Required!!");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillUserWithData()
        {
            _user.Username = txtUserName.Text;
            _user.Password = txtPassword.Text;
            _user.IsActive = chkIsActive.Checked;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Field are not valid ,Put the mouse over the red icon!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserWithData();
            if (_user.Save())
            {
                labUserId.Text = _user.Id.ToString();
                _mode = Mode.Update;
                labTitleForm.Text = "Update A Person";
                this.Text = "Update A Person";
                MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Failed Saved ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
