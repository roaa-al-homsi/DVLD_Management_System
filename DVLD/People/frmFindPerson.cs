using System;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmFindPerson : Form
    {
        //Define a delegate
        public delegate void DataBackEventHandler(object sender, int personId);

        //Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, uc_PersonInfoCardWithFilter1.PersonId);
        }
    }
}
