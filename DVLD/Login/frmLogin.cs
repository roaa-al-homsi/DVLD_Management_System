using DVLD.Global_Classes;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        //johndoe
        //password123
        public frmLogin()
        {
            InitializeComponent();
        }
        private static string _username = string.Empty;
        private static string _password = string.Empty;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Global.CurrentUser = User.FindByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            //if (Global.CurrentUser != null)
            //{
            //    if (chkRememberMe.Checked)
            //    {
            //        _username = txtUsername.Text;

            //        _password = txtPassword.Text;
            //    }
            //    this.Hide();
            //    frmMain frmMain = new frmMain();
            //    frmMain.Show();

            //}

            if (Global.CurrentUser != null)
            {

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    Global.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    Global.RememberUsernameAndPassword("", "");

                }

                //incase the user is not active
                if (!Global.CurrentUser.IsActive)
                {
                    txtUsername.Focus();
                }

                MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = string.Empty;
                txtUsername.Text = string.Empty;
                chkRememberMe.Checked = false;
                return;

                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtPassword.Text = _password;
            //txtUsername.Text = _username;
            //chkRememberMe.Checked = !string.IsNullOrEmpty(txtPassword.Text);
            string UserName = "", Password = "";

            if (Global.GetStoredCredential(ref UserName, ref Password))
            {
                txtUsername.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }
        }










    }


}
