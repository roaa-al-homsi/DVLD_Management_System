using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int personId)
        {
            InitializeComponent();
            uc_PersonInfoCard1.LoadPersonInfo(personId);
        }
        public frmShowPersonInfo(string nationalNo)
        {
            InitializeComponent();
            uc_PersonInfoCard1.LoadPersonInfo(nationalNo);
        }

    }
}
