using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class Country
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
            this.Id = -1;
            this.Name = string.Empty;

            _mode = Mode.Add;
        }
        private Country(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;


            _mode = Mode.Update;
        }

        public static DataTable All()
        {
            return CountryData.All();
        }
        public static Country Find(int Id)
        {
            string Name = string.Empty;

            if (CountryData.Get(Id, ref Name))
            {
                return new Country(Id, Name);
            }
            return null;
        }
        public static Country Find(string name)
        {
            int id = -1;

            if (CountryData.Get(name, ref id))
            {
                return new Country(id, name);
            }
            return null;
        }
    }


}
