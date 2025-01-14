using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace DVLD.Test_Types
{
    public partial class frmUpdateTestTypes : Form
    {
        private TestType.enTestTypes _testTypeId = TestType.enTestTypes.VisionTest;
        private TestType _TestType;
        public frmUpdateTestTypes(TestType.enTestTypes testTypeId)
        {
            InitializeComponent();
            _testTypeId = testTypeId;
        }

        private void _LoadDataToForm()
        {
            if (!TestType.Exist((int)_testTypeId))
            {
                MessageBox.Show("This Type Of Test Doesn't Exist! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType = TestType.Find(_testTypeId);
            if (_TestType != null)
            {
                txtId.Text = _testTypeId.ToString();
                txtDescription.Text = _TestType.Description;
                txtTitle.Text = _TestType.Name;
                txtFees.Text = _TestType.Fees.ToString();
            }
        }
        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoadDataToForm();
        }
        private void _FillTestType()
        {
            _TestType.Name = txtTitle.Text;
            _TestType.Fees = decimal.Parse(txtFees.Text);
            _TestType.Description = txtDescription.Text;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid!!", "Error Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillTestType();
            if (_TestType.Save())
            {
                MessageBox.Show("Updating Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Updating Failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        }
    }
}
