using DVLD_Business;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Licenses.U_controls
{
    public partial class uc_DriverLicenses : UserControl
    {
        // private int DriverId = -1;
        private DataTable _dtLocalLicenses;
        private DataTable _dtInternationalLicenses;
        public uc_DriverLicenses()
        {
            InitializeComponent();
        }

        private void LoadLocalInfo(int driverId)
        {
            _dtLocalLicenses = Driver.AllLocalLicenses(driverId);
        }
        private void LoadInternationalInfo()
        {

        }
        public void LoadLicensesHistory(int driverId)
        {
            LoadLocalInfo(driverId);
            LoadInternationalInfo();
        }


    }
}
