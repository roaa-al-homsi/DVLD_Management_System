using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class TestType
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public enum enTestTypes { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public TestType.enTestTypes Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public TestType()
        {
            this.Id = TestType.enTestTypes.VisionTest;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Fees = 0;

            _mode = Mode.Add;
        }
        private TestType(TestType.enTestTypes Id, string Name, string Description, decimal Fees)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Fees = Fees;


            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id = (TestType.enTestTypes)TestTypeData.Add(this.Name, this.Description, this.Fees);

            return (!string.IsNullOrEmpty(this.Name));
        }

        private bool _Update()
        {
            return TestTypeData.Update((int)this.Id, this.Name, this.Description, this.Fees);
        }
        public bool Save()
        {

            switch (_mode)
            {
                case Mode.Add:
                    {
                        _mode = Mode.Update;
                        return _Add();
                    }
                case Mode.Update: return _Update();
            }
            return false;
        }
        public static bool Exist(int Id)
        {
            return TestTypeData.Exist(Id);
        }
        public static DataTable All()
        {
            return TestTypeData.All();
        }
        public static TestType Find(TestType.enTestTypes Id)
        {
            string Name = string.Empty;
            string Description = string.Empty;
            decimal Fees = 0;

            if (TestTypeData.Get((int)Id, ref Name, ref Description, ref Fees))
            {
                return new TestType(Id, Name, Description, Fees);
            }
            return null;
        }
        public static decimal GetFeesForSpecificTest(TestType.enTestTypes Id)
        {
            return TestTypeData.GetFeesForSpecificTest((int)Id);
        }
    }




}
