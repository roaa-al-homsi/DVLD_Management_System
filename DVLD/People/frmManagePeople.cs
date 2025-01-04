using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            dgvAllPeople.DataSource = Person.All();
        }
        private void _FillFilterBy()
        {
            DataTable dt = Person.All();
            foreach (DataColumn column in dt.Columns)
            {
                cmbFilterBy.Items.Add(column);
            }
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshData();
            _FillFilterBy();
        }


    }
}
