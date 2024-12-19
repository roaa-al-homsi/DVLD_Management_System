using DVLD_DataAccess;
using System;

namespace DVLD_Business
{
    public class Person
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryId { get; set; }
        public string ImagePath { get; set; }

        public Person()
        {
            this.Id = -1;
            this.NationalNo = string.Empty;
            this.FullName = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityCountryId = -1;
            this.ImagePath = string.Empty;

            _mode = Mode.Add;
        }
        private Person(int Id, string NationalNo, string FullName, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email, int NationalityCountryId, string ImagePath)
        {
            this.Id = Id;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryId = NationalityCountryId;
            this.ImagePath = ImagePath;


            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id =
                        PersonData.Add(this.NationalNo, this.FullName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryId, this.ImagePath);
            return (this.Id != -1);
        }
        private bool _Update()
        {
            return PersonData.Update(this.Id, this.NationalNo, this.FullName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryId, this.ImagePath);
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
            return PersonData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return PersonData.Delete(Id); }
        }
        public Person Find(int Id)
        {
            string NationalNo = string.Empty;
            string FullName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            string Gender = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityCountryId = -1;
            string ImagePath = string.Empty;

            if (PersonData.Get(Id, ref NationalNo, ref FullName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryId, ref ImagePath))
            {
                return new Person(Id, NationalNo, FullName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryId, ImagePath);
            }
            return null;
        }
    }




}
