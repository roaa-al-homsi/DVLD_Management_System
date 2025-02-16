using System;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_Licenses.U_Controls
{
    public partial class uc_DriverLicenseWithFilter : UserControl
    {  // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }
        private int _licenseID = -1;
        private bool _filterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _filterEnabled;
            }
            set
            {
                _filterEnabled = value;
                gbFilter.Enabled = _filterEnabled;
            }
        }
        public int LicenseID
        {
            get { return uc_DriverLicense1.LicenseID; }
        }
        public DVLD_Business.License SelectedLicenseInfo
        { get { return uc_DriverLicense1.SelectedLicenseInfo; } }
        public uc_DriverLicenseWithFilter()
        {
            InitializeComponent();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformLayout();
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtFilterValue.Text = LicenseID.ToString();
            uc_DriverLicense1.LoadDriverLicenseInfo(LicenseID);
            _licenseID = uc_DriverLicense1.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnLicenseSelected(_licenseID);
            }
        }

        public void txtLicenseIDFocus()
        {
            txtFilterValue.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilterValue.Focus();
                return;

            }
            _licenseID = int.Parse(txtFilterValue.Text);
            LoadLicenseInfo(_licenseID);

        }
    }
}
