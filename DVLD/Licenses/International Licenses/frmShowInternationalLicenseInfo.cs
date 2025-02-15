using System.Windows.Forms;

namespace DVLD.Licenses.International_Licenses
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        public frmShowInternationalLicenseInfo(int internationalLicenseId)
        {
            InitializeComponent();
            uc_InternationalLicenseInfo1.LoadDriverLicenseInfo(internationalLicenseId);
        }
    }
}
