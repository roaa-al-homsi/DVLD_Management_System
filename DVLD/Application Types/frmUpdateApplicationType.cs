using DVLD.Global_Classes;
using DVLD_Business;
using Guna.UI2.WinForms;
using System.ComponentModel;
using System.Windows.Forms;


namespace DVLD.ApplicationTypes
{
    public partial class frmUpdateApplicationType : Form
    {
        private int _applicationTypeId;
        private ApplicationType _applicationTypes;
        public frmUpdateApplicationType(int applicationTypeId)
        {
            InitializeComponent();
            _applicationTypeId = applicationTypeId;
        }

        private void _LoadDataToForm()
        {
            if (!ApplicationType.Exist(_applicationTypeId))
            {
                MessageBox.Show("This Type Doesn't Exist! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _applicationTypes = ApplicationType.Find(_applicationTypeId);
            if (_applicationTypes == null)
            {
                MessageBox.Show("This Type Doesn't Exist! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtId.Text = _applicationTypes.Id.ToString();
            txtFees.Text = _applicationTypes.Fees.ToString();
            txtTitle.Text = _applicationTypes.Title.ToString();

        }
        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "This Field Is Required!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, null);
            }
        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Reminder:: Adding if char is point in float case .
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!Validation.IsNumber(txtFees.Text))
            {
                e.Handled = true;
            }
        }
        private void frmUpdateApplicationType_Load(object sender, System.EventArgs e)
        {
            _LoadDataToForm();
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are not valid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _applicationTypes.Title = txtTitle.Text;
            _applicationTypes.Fees = decimal.Parse(txtFees.Text);
            if (_applicationTypes.Save())
            {
                MessageBox.Show("Updating Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Updating Failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

