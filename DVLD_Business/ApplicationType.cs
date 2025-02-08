using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class ApplicationType
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public ApplicationType()
        {
            this.Id = -1;
            this.Title = string.Empty;
            this.Fees = 0;
        }
        private ApplicationType(int Id, string Title, decimal Fees)
        {
            this.Id = Id;
            this.Title = Title;
            this.Fees = Fees;
        }

        private bool _Update()
        {
            return ApplicationTypeData.Update(this.Id, this.Title, this.Fees);
        }
        public bool Save()
        {
            return _Update();
        }
        public static bool Exist(int Id)
        {
            return ApplicationTypeData.Exist(Id);
        }
        public static DataTable All()
        {
            return ApplicationTypeData.All();
        }
        public static ApplicationType Find(int Id)
        {
            string Title = string.Empty;
            decimal Fees = 0;

            if (ApplicationTypeData.Get(Id, ref Title, ref Fees))
            {
                return new ApplicationType(Id, Title, Fees);
            }
            return null;
        }

        public static decimal GetFeesForSpecificApplication(Application.enApplicationType applicationType)
        {
            return ApplicationTypeData.GetFeesForSpecificApplication((byte)applicationType);
        }
    }


}
