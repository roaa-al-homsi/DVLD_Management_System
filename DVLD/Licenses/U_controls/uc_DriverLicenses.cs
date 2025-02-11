using DVLD.Licenses.Local_Licenses;
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
        private void ChangeFormatDgvLocal()
        {
            if (dgvLocalLicesnes.Rows.Count > 0)
            {
                dgvLocalLicesnes.Columns[0].Width = 110;
                dgvLocalLicesnes.Columns[1].Width = 110;
                dgvLocalLicesnes.Columns[2].Width = 250;
                dgvLocalLicesnes.Columns[3].Width = 170;
                dgvLocalLicesnes.Columns[4].Width = 170;
                dgvLocalLicesnes.Columns[5].Width = 110;
            }
        }
        private void LoadLocalInfo()
        {
            _dtLocalLicenses = Driver.AllLocalLicenses(_DriverId);
            dgvLocalLicesnes.DataSource = _dtLocalLicenses;
            labCountRecordsLocal.Text = dgvLocalLicesnes.RowCount.ToString();
        }
        private void LoadInternationalInfo()
        {
            // _dtInternationalLicenses = Driver.AllInternationalLicenses(_DriverId);
            //    dgvInternationalLicenses.DataSource = _dtLocalLicenses;
            labCountRecordInternational.Text = dgvInternationalLicenses.RowCount.ToString();
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
            ChangeFormatDgvLocal();
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
            ChangeFormatDgvLocal();
        }
        public void Clear()
        {
            _dtInternationalLicenses.Clear();
            _dtLocalLicenses.Clear();
        }

        private void showLocalInfoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowDriverLicenseInfo frmShowDriverLicenseInfo = new frmShowDriverLicenseInfo(_DriverId);
            frmShowDriverLicenseInfo.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            //show international info 
        }
    }
}
