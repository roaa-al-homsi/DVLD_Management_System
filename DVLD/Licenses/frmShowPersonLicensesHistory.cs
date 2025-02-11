using System;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowPersonLicensesHistory : Form
    {
        private int _PersonId = -1;

        public frmShowPersonLicensesHistory()
        {
            InitializeComponent();
        }
        public frmShowPersonLicensesHistory(int personId)
        {
            InitializeComponent();
            _PersonId = personId;
        }
        private void uc_DriverLicenses1_Load(object sender, EventArgs e)
        {
            if (_PersonId != -1)
            {
                uc_PersonInfoCardWithFilter1.LoadPersonInfo(_PersonId);
                uc_DriverLicenses1.LoadLicensesHistoryByPersonId(_PersonId);
                uc_PersonInfoCardWithFilter1.FilterEnable = false;
            }
            else
            {
                uc_PersonInfoCardWithFilter1.FilterEnable = true;
                uc_PersonInfoCardWithFilter1.Focus();
            }

        }
        private void uc_PersonInfoCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonId = obj;
            if (_PersonId != -1)
            {
                uc_DriverLicenses1.LoadLicensesHistoryByPersonId(_PersonId);
            }
            else
            {
                uc_DriverLicenses1.Clear();
            }
        }
    }
}
