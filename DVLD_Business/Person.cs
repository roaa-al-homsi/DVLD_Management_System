using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class Person
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public enum enGender { Male = 0, Female = 1 }
        public int Id { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                //return string.IsNullOrWhiteSpace(ThirdName) ? FirstName + " " + SecondName + " " + LastName : FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
                return string.IsNullOrWhiteSpace(ThirdName) ? $"{FirstName} {SecondName} {LastName}" : $"{FirstName} {SecondName} {ThirdName} {LastName}";
            }

        }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }//fK
        public string ImagePath { get; set; }

        public string GenderText
        {
            get
            {
                switch (Gender)
                {
                    case enGender.Male:
                        return "Male";
                    case enGender.Female:
                        return "Female";
                    default:
                        return "Male";
                }
            }
        }
        public Country CountryInfo { get; private set; } // or  private set, if you need to update its value only inside this class.. (most cases you don't need that)

        public Person()
        {
            this.Id = 0;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = enGender.Male;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityCountryID = 0;
            this.ImagePath = string.Empty;

            _mode = Mode.Add;
        }
        private Person(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, enGender Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.Id = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = Country.Find(NationalityCountryID);

            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id =
                        PersonData.Add(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, (byte)this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return PersonData.Update(this.Id, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, (byte)this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }
        public bool Save()
        {
            switch (_mode)
            {
                case Mode.Add:
                    {
                        if (_Add())
                        {
                            _mode = Mode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case Mode.Update: return _Update();
            }
            return false;
        }
        public static bool Exist(int personId)
        {
            return PersonData.Exist(personId);
        }
        public static bool Delete(int personId)
        {
            if (!Exist(personId))
            {
                return false;
            }
            else { return PersonData.Delete(personId); }
        }
        public static DataTable All()
        {
            return PersonData.All();
        }
        public static Person Find(int PersonID)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityCountryID = -1;
            string ImagePath = string.Empty;

            if (PersonData.Get(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new Person(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (enGender)Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            return null;
        }
        public static Person FindByNationalNo(string nationalNo)
        {
            int PersonId = -1;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityCountryID = -1;
            string ImagePath = string.Empty;

            if (PersonData.Get(nationalNo, ref PersonId, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new Person(PersonId, nationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (enGender)Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            return null;
        }
        public static DataTable GetNamesCountries()
        {
            return PersonData.GetNamesCountries();
        }
        public static int GetIdCountryByName(string name)
        {
            return PersonData.GetIdCountryByName(name);
        }
        public static string GetNameCountryById(int id)
        {
            return PersonData.GetNameCountryById(id);
        }
        public static bool ExistByNationalNo(string nationalNo)
        {
            return PersonData.ExistByNationalNo(nationalNo);

        }
    }








}
