using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;
using Application = DVLD_Business.Application;

namespace DVLD.Local_Driving_License_App
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        private enum Mode { Add = 1, Update = 2 }
        private Mode _mode = Mode.Add;
        private LocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private int _localDrivingLicenseId = -1;
        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _mode = Mode.Add;
            _ResetDefaultValues();
        }
        public frmAddUpdateLocalDrivingLicenseApplication(int localDrivingLicenseId)
        {
            InitializeComponent();
            _localDrivingLicenseId = localDrivingLicenseId;
            _mode = Mode.Update;
        }
        private void _FillCmbLicenseClasses()
        {
            DataTable dt = LicenseClass.All();

            foreach (DataRow row in dt.Rows)
            {
                cmbLicesneClasses.Items.Add(row["Name"]);
            }
        }
        private void _ResetDefaultValues()
        {
            txtApplicationDate.Text = DateTime.Now.ToString();
            txtApplicationFees.Text = ApplicationType.GetFeesForSpecificApplication(1).ToString();
            //txtCreatedBy.Text=currentuser
            _FillCmbLicenseClasses();
        }
        private void _LoadData()
        {
            if (_mode == Mode.Add)
            {
                this.Text = "Add Local Driving License";
                labTitleForm.Text = "Add Local Driving License";
                _localDrivingLicenseApplication = new LocalDrivingLicenseApplication();
                return;
            }
            this.Text = "Update Local Driving License";
            labTitleForm.Text = "Update Local Driving License";
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(_localDrivingLicenseId);
            _localDrivingLicenseApplication.Person = uc_PersonInfoCardWithFilter1.SelectedPerson;
            uc_PersonInfoCardWithFilter1.LoadPersonInfo(_localDrivingLicenseApplication.PersonId);
            labLDLAId.Text = _localDrivingLicenseId.ToString();
            txtApplicationDate.Text = _localDrivingLicenseApplication.Date.ToString();
            txtApplicationFees.Text = ApplicationType.GetFeesForSpecificApplication(_localDrivingLicenseApplication.ApplicationTypeId).ToString();
            txtCreatedBy.Text = _localDrivingLicenseApplication.CreatedByUser.Username;

        }
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (_mode == Mode.Update)
            {
                btnSave.Enabled = true;
                tabApplicationInfo.Enabled = true;
                tcNewLocalDrivingLicenseApp.SelectedTab = tcNewLocalDrivingLicenseApp.TabPages[1];
                return;
            }
            if (uc_PersonInfoCardWithFilter1.PersonId != -1)
            {
                btnSave.Enabled = true;
                tabApplicationInfo.Enabled = true;
                tcNewLocalDrivingLicenseApp.SelectedTab = tcNewLocalDrivingLicenseApp.TabPages[1];

            }




        }

        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)

        {//I can use enum
            //_localDrivingLicenseApplication.LicenseClassId =
            _localDrivingLicenseApplication.ApplicationId = (int)Application.enApplicationType.NewDrivingLicense;



            if (_localDrivingLicenseApplication.Save())
            {
                labLDLAId.Text = _localDrivingLicenseApplication.Id.ToString();
                MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Failed Saved ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
