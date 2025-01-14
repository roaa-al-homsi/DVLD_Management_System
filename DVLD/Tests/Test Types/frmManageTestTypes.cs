using DVLD.Test_Types;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            _dtAllTestTypes = TestType.All();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            labCountRecords.Text = dgvTestTypes.Rows.Count.ToString();
        }
        private void _ChangeFormatDgvTestTypes()
        {
            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].Width = 100;
                dgvTestTypes.Columns[1].Width = 180;
                dgvTestTypes.Columns[2].Width = 270;
                dgvTestTypes.Columns[3].Width = 90;
            }
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
            _ChangeFormatDgvTestTypes();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frmUpdateTest = new frmUpdateTestTypes((TestType.enTestTypes)dgvTestTypes.CurrentRow.Cells[0].Value);
            frmUpdateTest.ShowDialog();
            _Refresh();
        }
    }
}
