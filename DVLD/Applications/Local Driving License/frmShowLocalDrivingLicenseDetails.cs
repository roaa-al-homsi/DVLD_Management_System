using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmShowLocalDrivingLicenseDetails : Form
    {

        public frmShowLocalDrivingLicenseDetails(int localDrivingLicenseId)
        {
            InitializeComponent();
            uc_LocalDrivingLicenseInfoCard1.LoadLocalDrivingLicenseInfoById(localDrivingLicenseId);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
