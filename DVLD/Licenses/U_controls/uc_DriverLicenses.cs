using DVLD_Business;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Licenses.U_controls
{
    public partial class uc_DriverLicenses : UserControl
    {
        private int _DriverId = -1;
        private Driver _Driver;
        private DataTable _dtLocalLicenses;
        private DataTable _dtInternationalLicenses;
        public uc_DriverLicenses()
        {
            InitializeComponent();
        }

        private void LoadLocalInfo()
        {
            _dtLocalLicenses = Driver.AllLocalLicenses(_DriverId);
            dgvLocalLicesnes.DataSource = _dtLocalLicenses;
            labCountRecords.Text = dgvLocalLicesnes.Rows.Count.ToString();
        }
        private void LoadInternationalInfo()
        {
            // _dtInternationalLicenses = Driver.AllInternationalLicenses(_DriverId);
            //  dgvLocalLicesnes.DataSource = _dtLocalLicenses;
            labCountRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }
        public void LoadLicensesHistory(int driverId)
        {
            _DriverId = driverId;
            _Driver = Driver.Find(driverId);
            if (_Driver == null)
            {
                MessageBox.Show($"There is no driver with this Id {driverId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadLocalInfo();
            LoadInternationalInfo();

        }
        public void LoadLicensesHistoryByPersonId(int personId)
        {
            _Driver = Driver.FindByPersonId(personId);
            if (_Driver == null)
            {
                MessageBox.Show($"There is no driver linked with this person Id {personId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverId = _Driver.Id;
            LoadLocalInfo();
            LoadInternationalInfo();
        }
        public void Clear()
        {
            _dtInternationalLicenses.Clear();
            _dtLocalLicenses.Clear();
        }

    }
}
