using DVLD.Applications.Local_Driving_License;
using DVLD.Local_Driving_License_App;
using DVLD.People;
using DVLD.Users;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmNewLocalDrivingLicense = new frmAddUpdateLocalDrivingLicenseApplication();
            frmNewLocalDrivingLicense.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManageLocalDrivingLicenseApplication frmManageLocalDrivingLicense = new frmManageLocalDrivingLicenseApplication();
            frmManageLocalDrivingLicense.ShowDialog();

        }

        private void peopleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManagePeople managePeople = new frmManagePeople();
            managePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmManageUsers manageUsers = new frmManageUsers();
            manageUsers.ShowDialog();
        }
    }
}
