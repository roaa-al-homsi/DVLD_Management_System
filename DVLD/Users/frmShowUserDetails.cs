using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmShowUserDetails : Form
    {
        private int _Id;
        public frmShowUserDetails(int Id)
        {
            InitializeComponent();
            uc_UserInfoCard1.LoadUserInfo(Id);
        }


    }
}
