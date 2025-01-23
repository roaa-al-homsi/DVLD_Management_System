using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class LicenseClass
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal Fees { get; set; }

        public LicenseClass()
        {
            this.Id = -1;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.Fees = 0;

            _mode = Mode.Add;
        }
        private LicenseClass(int Id, string Name, string Description, byte MinimumAllowedAge, byte DefaultValidityLength, decimal Fees)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.Fees = Fees;


            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id = LicenseClassData.Add(this.Name, this.Description, this.MinimumAllowedAge, this.DefaultValidityLength, this.Fees);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return LicenseClassData.Update(this.Id, this.Name, this.Description, this.MinimumAllowedAge, this.DefaultValidityLength, this.Fees);
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
            return LicenseClassData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return LicenseClassData.Delete(Id); }
        }
        public static DataTable All()
        {
            return LicenseClassData.All();
        }
        public static DataTable AllNames()
        {
            return LicenseClassData.AllNames();
        }
        public static string GetNameById(int Id)
        {
            return LicenseClassData.GetNameById(Id);
        }
        public static int GetIdByName(string name)
        {
            return LicenseClassData.GetIdByName(name);
        }
        public static LicenseClass Find(int Id)
        {
            string Name = string.Empty;
            string Description = string.Empty;
            byte MinimumAllowedAge = 18;
            byte DefaultValidityLength = 10;
            decimal Fees = 0;

            if (LicenseClassData.Get(Id, ref Name, ref Description, ref MinimumAllowedAge, ref DefaultValidityLength, ref Fees))
            {
                return new LicenseClass(Id, Name, Description, MinimumAllowedAge, DefaultValidityLength, Fees);
            }
            return null;
        }
    }


}
