using DVLD.Local_Driving_License_App;
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
            frmAddUpdateLocalDrivingLicenseApplication frmNewLocalDrivingLicense = new frmAddUpdateLocalDrivingLicenseApplication();
            frmNewLocalDrivingLicense.ShowDialog();
        }
    }
}
