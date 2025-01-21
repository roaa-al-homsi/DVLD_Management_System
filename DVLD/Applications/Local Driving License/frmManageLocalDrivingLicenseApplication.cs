using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLicenseApplication : Form
    {
        private DataTable _dtLDLA;

        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _ChangeFormatDgvAllLDLA()
        {
            if (dgvAllLDLA.Rows.Count > 0)
            {
                dgvAllLDLA.Columns[0].Width = 100;
                dgvAllLDLA.Columns[1].Width = 250;
                dgvAllLDLA.Columns[2].Width = 150;
                dgvAllLDLA.Columns[3].Width = 200;
                dgvAllLDLA.Columns[4].Width = 150;
                dgvAllLDLA.Columns[5].Width = 100;
                dgvAllLDLA.Columns[6].Width = 150;
            }
        }
        private void _LoadDataToForm()
        {
            _dtLDLA = LocalDrivingLicenseApplication.All();
            dgvAllLDLA.DataSource = _dtLDLA;
            labCountRecords.Text = dgvAllLDLA.Rows.Count.ToString();
            _ChangeFormatDgvAllLDLA();
        }

        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
        }
    }
}
