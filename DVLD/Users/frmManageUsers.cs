using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {

        private static DataTable _dtAllUsers;


        public frmManageUsers()
        {
            InitializeComponent();
        }
        private void _FillComboBoxFilterBy()
        {
            foreach (DataColumn column in _dtAllUsers.Columns)
            {
                cmbFilterBy.Items.Add(column.ColumnName);
            }
        }
        private void _ChangeFormatDgvAllUsers()
        {
            if (dgvAllUsers.Rows.Count > 0)
            {
                dgvAllUsers.Columns[0].Width = 100;
                dgvAllUsers.Columns[1].Width = 100;
                dgvAllUsers.Columns[2].Width = 100;
                dgvAllUsers.Columns[3].Width = 200;
                dgvAllUsers.Columns[4].Width = 100;
            }
        }
        private void _RefreshUserData()
        {
            _dtAllUsers = User.All();
            dgvAllUsers.DataSource = _dtAllUsers;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {

            _RefreshUserData();
            _ChangeFormatDgvAllUsers();
            _FillComboBoxFilterBy();
            cmbFilterBy.SelectedIndex = 0;
            cmbIsActive.Visible = false;
            labCountRecords.Text = dgvAllUsers.Rows.Count.ToString();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cmbFilterBy.Text != "None" && cmbFilterBy.Text != "Is Active");
            cmbIsActive.Visible = (cmbFilterBy.Text == "Is Active");
            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = string.Empty;
                txtFilterBy.Focus();
            }
            if (cmbIsActive.Visible)
            {
                cmbIsActive.SelectedIndex = 0;
                cmbIsActive.Focus();
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.Text == "Id" || cmbFilterBy.Text == "Person Id")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.Text == "None" || string.IsNullOrEmpty(txtFilterBy.Text))
            {
                _dtAllUsers.DefaultView.RowFilter = string.Empty;
                labCountRecords.Text = dgvAllUsers.Rows.Count.ToString();
                return;

            }
            switch (cmbFilterBy.Text)
            {
                case "Id":
                case "Person Id":
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}", cmbFilterBy.Text, txtFilterBy.Text.Trim());
                    break;
                default:
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]Like '{1}%'", cmbFilterBy.Text, txtFilterBy.Text.Trim());
                    break;
            }
            labCountRecords.Text = dgvAllUsers.Rows.Count.ToString();
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = string.Empty;
            switch (cmbIsActive.Text)
            {
                case "Yes":
                    FilterValue = "1";
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}", "Is Active", FilterValue);
                    break;
                case "No":
                    FilterValue = "0";
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}", "Is Active", FilterValue);
                    break;
                default:
                    _dtAllUsers.DefaultView.RowFilter = string.Empty;
                    break;
            }

            labCountRecords.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addUpdateUser = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            addUpdateUser.ShowDialog();
            //Refresh dgvUsers
            frmManageUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frmShowUser = new frmShowUserDetails((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frmShowUser.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addUpdateUser = new frmAddUpdateUser();
            addUpdateUser.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
        }
    }
}
