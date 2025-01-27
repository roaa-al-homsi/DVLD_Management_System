using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.People.userControls
{
    public partial class uc_PersonInfoCardWithFilter : UserControl
    {
        //Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        //Create a protected method to raise the event with a parameters
        protected virtual void PersonSelected(int personId)
        {
            //Action<int> handler = OnPersonSelected;
            //if (handler != null)
            //{
            //    handler(personId);//Raise the event with the parameter
            //}
            OnPersonSelected?.Invoke(personId); // the same
        }


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            set
            {
                _ShowAddPerson = value;
                btnAdd.Visible = _ShowAddPerson;
            }
            get { return _ShowAddPerson; }
        }

        private bool _FilterEnable = true;

        public bool FilterEnable
        {
            set { _FilterEnable = value; gbFilter.Enabled = _FilterEnable; }
            get { return _FilterEnable; }
        }
        public int PersonId
        {
            // my way get { return uc_PersonInfoCard1.SelectedPersonInfo.Id; }
            get { return uc_PersonInfoCard1.PersonId; }
        }
        public Person SelectedPerson
        {
            get { return uc_PersonInfoCard1.SelectedPersonInfo; }
        }
        public uc_PersonInfoCardWithFilter()
        {
            InitializeComponent();
        }
        private void _FindNow()
        {
            switch (cmbFilterBy.Text)
            {
                case "Id":
                    if (!Person.Exist(int.Parse(txtFilterValue.Text)))
                    {
                        MessageBox.Show($"There is no person with this Id {txtFilterValue.Text}");
                        return;
                    }
                    uc_PersonInfoCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "National Number":
                    if (!Person.ExistByNationalNo(txtFilterValue.Text))
                    {
                        MessageBox.Show($"There is no person with this nationalNo {txtFilterValue.Text}");
                        return;
                    }
                    uc_PersonInfoCard1.LoadPersonInfo(txtFilterValue.Text);
                    break;
                default:
                    break;
            }
            if (FilterEnable)
            {
                //Raise the event with a parameter 
                OnPersonSelected?.Invoke(uc_PersonInfoCard1.PersonId);
            };
        }
        public void LoadPersonInfo(int personId)
        {
            cmbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = personId.ToString();
            _FindNow();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = string.Empty;
            txtFilterValue.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show($"Some fields are not validate!, put the mouse over the red icon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();

        }
        private void uc_PersonInfoCardWithFilter_Load(object sender, EventArgs e)
        {
            cmbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
        private void txtFilterValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // to do remove it
            //if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtFilterValue, "This field is required!");
            //}
            //else
            //{
            //    //e.Cancel = false;
            //    errorProvider1.SetError(txtFilterValue, null);
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.DataBack += _DataBackEvent;
            frmAddUpdatePerson.ShowDialog();
            FilterEnable = false;
        }
        private void _DataBackEvent(object sender, int personId)
        {    //handle the data received
            cmbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = personId.ToString();
            uc_PersonInfoCard1.LoadPersonInfo(personId);

        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformLayout();
                //mister uses bottom so the method is used is performClick();
            }
            if (cmbFilterBy.Text == "Id")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }


    }
}
