using DVLD.Global_Classes;
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
        private static int _localDrivingLicenseId = -1;
        private int _SelectedPersonId = -1;
        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _mode = Mode.Add;
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
            _FillCmbLicenseClasses();
            if (_mode == Mode.Add)
            {
                this.Text = "New Local Driving License";
                labTitleForm.Text = "New Local Driving License";
                _localDrivingLicenseApplication = new LocalDrivingLicenseApplication();
                tabApplicationInfo.Enabled = false;
                cmbLicesneClasses.SelectedIndex = 2;
                txtApplicationFees.Text = ApplicationType.GetFeesForSpecificApplication(Application.enApplicationType.NewDrivingLicense).ToString();
                txtApplicationDate.Text = DateTime.Now.ToShortDateString().ToString();
                uc_PersonInfoCardWithFilter1.FilterFocus();
                txtCreatedBy.Text = Global.CurrentUser.Username;
            }
            else
            {
                this.Text = "Update Local Driving License";
                labTitleForm.Text = "Update Local Driving License";
                tabApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void _LoadData()
        {
            uc_PersonInfoCardWithFilter1.FilterEnable = false;
            //I can find LDLA by applicationId also.
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.Find(_localDrivingLicenseId);
            if (_localDrivingLicenseApplication != null)
            {
                uc_PersonInfoCardWithFilter1.LoadPersonInfo(_localDrivingLicenseApplication.PersonId);
                labLDLAId.Text = _localDrivingLicenseId.ToString();
                txtApplicationDate.Text = _localDrivingLicenseApplication.Date.ToString();
                txtApplicationFees.Text = _localDrivingLicenseApplication.PaidFees.ToString();
                txtCreatedBy.Text = _localDrivingLicenseApplication.CreatedByUser.Username;
                cmbLicesneClasses.SelectedIndex = cmbLicesneClasses.FindString(LicenseClass.GetNameById(_localDrivingLicenseApplication.LicenseClassId));
            }
            else
            {
                MessageBox.Show($"No Local Driving Application With This Id {_localDrivingLicenseId} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

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
            _ResetDefaultValues();
            if (_mode == Mode.Update)
            {
                _LoadData();
            }
        }
        private void _FillLocalDrivingLicenseApplicationBeforeSave()
        {
            _localDrivingLicenseApplication.PersonId = uc_PersonInfoCardWithFilter1.PersonId; ;
            _localDrivingLicenseApplication.Date = DateTime.Now;
            _localDrivingLicenseApplication.ApplicationTypeId = (int)Application.enApplicationType.NewDrivingLicense;
            _localDrivingLicenseApplication.Status = Application.enApplicationStatus.New;
            _localDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _localDrivingLicenseApplication.PaidFees = Convert.ToDecimal(txtApplicationFees.Text);
            _localDrivingLicenseApplication.CreatedByUserId = Global.CurrentUser.Id;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _localDrivingLicenseApplication.LicenseClassId = LicenseClass.GetIdByName(cmbLicesneClasses.Text);

            int activeApplicationId = Application.GetActiveApplicationIdForLicenseClass(uc_PersonInfoCardWithFilter1.PersonId, (int)Application.enApplicationType.NewDrivingLicense, _localDrivingLicenseApplication.LicenseClassId);
            if (activeApplicationId != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + activeApplicationId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLicesneClasses.Focus();
                return;
            }

            if (License.IsLicenseExistByPersonID(uc_PersonInfoCardWithFilter1.PersonId, _localDrivingLicenseApplication.LicenseClassId))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose different driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationBeforeSave();
            if (_localDrivingLicenseApplication.Save())
            {

                labLDLAId.Text = _localDrivingLicenseApplication.Id.ToString();
                _mode = Mode.Update;
                labTitleForm.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            uc_PersonInfoCardWithFilter1.FilterFocus();
        }

        private void uc_PersonInfoCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonId = obj;
        }
        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonId = PersonID;
            uc_PersonInfoCardWithFilter1.LoadPersonInfo(PersonID);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
