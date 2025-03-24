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

        //alexbrown
        //password789

        //emilyjohnson
        //password012

        //michaelwilliams
        //password345
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Global.CurrentUser = User.FindByUsernameAndPassword(txtUsername.Text.Trim(), User.ComputeHash(txtPassword.Text.Trim()));


            if (Global.CurrentUser != null)
            {

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    Global.RememberUsernameAndPassword(txtUsername.Text.Trim(), User.ComputeHash(txtPassword.Text.Trim()));

                }
                else
                {
                    //store empty username and password
                    Global.RememberUsernameAndPassword("", "");
                }

                //encase the user is not active
                if (!Global.CurrentUser.IsActive)
                {
                    txtUsername.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
