using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        private int _userId;
        public frmChangePassword(int userId)
        {
            InitializeComponent();
            uc_UserInfoCard1.LoadUserInfo(userId);
            _userId = userId;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text != uc_UserInfoCard1.SelectedUser.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password Is Wrong!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, null);
            }

        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This Password Doesn't Match With New Password!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            uc_UserInfoCard1.SelectedUser.Password = txtNewPassword.Text;
            if (uc_UserInfoCard1.SelectedUser.ChangePassword())
            {
                MessageBox.Show("Password Changed Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Doesn't Changed..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

