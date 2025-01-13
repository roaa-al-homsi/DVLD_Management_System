using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            _dtAllApplicationTypes = ApplicationType.All();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            labCountRecords.Text = dgvApplicationTypes.Rows.Count.ToString();
        }
        private void _ChangeFormatDgvAllApplicationTypes()
        {
            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].Width = 100;
                dgvApplicationTypes.Columns[1].Width = 300;
                dgvApplicationTypes.Columns[2].Width = 100;
            }
        }
        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshData();
            _ChangeFormatDgvAllApplicationTypes();
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frmUpdateApplication = new frmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frmUpdateApplication.ShowDialog();
            _RefreshData();
        }
    }
}
