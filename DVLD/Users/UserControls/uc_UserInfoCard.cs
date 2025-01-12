using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Users.UserControls
{
    public partial class uc_UserInfoCard : UserControl
    {
        private User _user;
        private int _userId;

        public uc_UserInfoCard()
        {
            InitializeComponent();
        }
        public User SelectedUser
        {
            get { return _user; }
        }
        public int UserId
        {
            get { return _userId; }
        }
        public void _LoadDataToUc()
        {
            uc_PersonInfoCard1.LoadPersonInfo(_user.PersonId);
            txtIsActive.Text = _user.IsActive ? "Yes" : "No";
            txtUserId.Text = _user.Id.ToString();
            txtUsername.Text = _user.Username;
        }
        public void LoadUserInfo(int userId)
        {
            _userId = userId;
            _user = User.Find(userId);
            if (_user == null)
            {
                MessageBox.Show($"There is no user with this Id {_userId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _LoadDataToUc();
        }


    }
}
