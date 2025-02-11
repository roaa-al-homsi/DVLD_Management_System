using DVLD.Licenses;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {

        private static DataTable _dtAllPeople;//method all returns a view , I coded.
        private DataTable _dtPeople;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            //This is my solution using view in db.
            //dgvAllPeople.DataSource = Person.All();
            _dtAllPeople = Person.All();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "Id", "NationalNo", "First Name", "Second Name", "Third Name", "Last Name", "Gender", "Date Of Birth", "Nationality", "Phone", "Email");

            dgvAllPeople.DataSource = _dtPeople;
            labCountRecords.Text = dgvAllPeople.Rows.Count.ToString();
        }
        private void _FillComboFilterBy()
        {
            DataTable dt = Person.All();
            foreach (DataColumn column in dt.Columns)
            {
                cmbFilterBy.Items.Add(column);
            }
        }
        private void _ChangeFormatDgvAllPeople()
        {
            if (dgvAllPeople.Rows.Count > 0)
            {
                dgvAllPeople.Columns[0].HeaderText = "Person Id";
                dgvAllPeople.Columns[0].Width = 110;

                dgvAllPeople.Columns[1].HeaderText = "National No";
                dgvAllPeople.Columns[1].Width = 120;

                // dgvAllPeople.Columns[2].HeaderText = "First Name";
                dgvAllPeople.Columns[2].Width = 120;

                // dgvAllPeople.Columns[3].HeaderText = "Second Name";
                dgvAllPeople.Columns[3].Width = 140;

                // dgvAllPeople.Columns[4].HeaderText = "Third Name";
                dgvAllPeople.Columns[4].Width = 120;

                // dgvAllPeople.Columns[5].HeaderText = "Last Name";
                dgvAllPeople.Columns[5].Width = 120;

                // dgvAllPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvAllPeople.Columns[7].Width = 120;
                //width phone
                dgvAllPeople.Columns[9].Width = 120;
                //width Email
                dgvAllPeople.Columns[10].Width = 180;
            }
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshData();
            cmbFilterBy.SelectedIndex = 0;
            dgvAllPeople.DataSource = _dtPeople;
            labCountRecords.Text = dgvAllPeople.Rows.Count.ToString();

            _ChangeFormatDgvAllPeople();
            _FillComboFilterBy();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            _RefreshData();
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frmAddUpdatePerson.ShowDialog();
            _RefreshData();

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are you sure delete this person?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Person.Delete(personId))
                {
                    MessageBox.Show("Delete Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }
                else
                {
                    MessageBox.Show("Delete Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo showPersonInfo = new frmShowPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            showPersonInfo.ShowDialog();
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterBy.Text) || cmbFilterBy.Text == "None")
            {
                _dtPeople.DefaultView.RowFilter = string.Empty;
                labCountRecords.Text = dgvAllPeople.Rows.Count.ToString();
                return;
            }

            if (cmbFilterBy.Text == "Id")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]={1}", cmbFilterBy.Text, txtFilterBy.Text.Trim());
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]Like '{1}%'", cmbFilterBy.Text, txtFilterBy.Text.Trim());

            }
            labCountRecords.Text = dgvAllPeople.Rows.Count.ToString();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cmbFilterBy.Text != "None");
            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = string.Empty;
                txtFilterBy.Focus();
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {       //I Can enter only numbers when cmbFilter is Id.
            if (cmbFilterBy.Text == "Id")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }

        }

        private void showDriverLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frmShowPersonLicensesHistory.ShowDialog();

        }
    }
}
