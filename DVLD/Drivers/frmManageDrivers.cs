using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmManageDrivers : Form
    {
        private DataTable _dtDrivers;

        public frmManageDrivers()
        {
            InitializeComponent();
        }
        private void _changeDesignDgvDrivers()
        {
            if (dgvAllDrivers.Rows.Count > 0)
            {
                dgvAllDrivers.Columns[0].Width = 100;
                dgvAllDrivers.Columns[1].Width = 100;
                dgvAllDrivers.Columns[2].Width = 150;
                dgvAllDrivers.Columns[3].Width = 200;
                dgvAllDrivers.Columns[4].Width = 175;
                dgvAllDrivers.Columns[5].Width = 150;
            }
        }
        private void _FillCmbFilterBy()
        {
            foreach (DataColumn dc in _dtDrivers.Columns)
            {
                if (dc.ColumnName.Equals("Created Date") || dc.ColumnName.Equals("Activate Licenses"))
                {
                    continue;
                }
                cmbFilterBy.Items.Add(dc.ColumnName);
            }
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _dtDrivers = Driver.All();
            dgvAllDrivers.DataSource = _dtDrivers;
            labCountRecords.Text = dgvAllDrivers.RowCount.ToString();
            _changeDesignDgvDrivers();
            _FillCmbFilterBy();

        }
    }
}
