using DVLD.People;
using System.Windows.Forms;
using Application = DVLD_Business.Application;

namespace DVLD.Applications
{
    public partial class uc_BasicApplicationInfo : UserControl
    {
        private int _applicationId = -1;
        private Application _application;
        public int ApplicationId
        {
            get { return _applicationId; }
        }

        public uc_BasicApplicationInfo()
        {
            InitializeComponent();
        }
        private void _LoadApplicationDataToForm()
        {
            labApplicationId.Text = _application.Id.ToString();
            labFees.Text = _application.PaidFees.ToString();
            labStatus.Text = _application.StatusText;
            labStatusDate.Text = _application.LastStatusDate.ToString();
            labDate.Text = _application.Date.ToString();
            labType.Text = _application.ApplicationType.Title;
            labFullNamePerson.Text = _application.FullNamePerson;
            labCreatedByUser.Text = _application.CreatedByUser.Username;
        }
        public void LoadApplicationInfo(int applicationId)
        {
            _application = Application.FindBaseApplication(applicationId);
            if (_application == null)
            {
                MessageBox.Show($"There is no application with this Id {applicationId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _applicationId = applicationId;
            _LoadApplicationDataToForm();
        }
        private void lnkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frmShowPerson = new frmShowPersonInfo(_application.PersonId);
            frmShowPerson.ShowDialog();
        }
    }
}
