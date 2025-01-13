using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class TestType
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public TestType()
        {
            this.Id = -1;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Fees = 0;


        }
        private TestType(int Id, string Name, string Description, decimal Fees)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Fees = Fees;



        }

        private bool _Update()
        {
            return TestTypeData.Update(this.Id, this.Name, this.Description, this.Fees);
        }
        public bool Save()
        {
            return _Update();
        }
        public static bool Exist(int Id)
        {
            return TestTypeData.Exist(Id);
        }
        public static DataTable All()
        {
            return TestTypeData.All();
        }
        public static TestType Find(int Id)
        {
            string Name = string.Empty;
            string Description = string.Empty;
            decimal Fees = 0;

            if (TestTypeData.Get(Id, ref Name, ref Description, ref Fees))
            {
                return new TestType(Id, Name, Description, Fees);
            }
            return null;
        }
    }


}
