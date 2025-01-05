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

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson(-1);
            frmAddUpdatePerson.ShowDialog();
            _RefreshData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value);
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson(PersonId);
            frmAddUpdatePerson.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are you sure delete this person?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Person.Delete(personId))
                {
                    MessageBox.Show("Delete Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _RefreshData();
        }


    }
}
