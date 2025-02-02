using System;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmShowDriverLicenseInfo : Form
    {
        public frmShowDriverLicenseInfo(int licenseId)
        {
            InitializeComponent();
            uc_DriverLicense1.LoadDriverLicenseInfo(licenseId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
