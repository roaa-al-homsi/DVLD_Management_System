using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class User
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public int PersonId { get; set; }//fk
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public Person PersonInfo { get; set; }
        public User()
        {
            this.Id = -1;
            this.PersonId = -1;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;

            _mode = Mode.Add;
        }
        private User(int Id, int PersonId, string Username, string Password, bool IsActive)
        {
            this.Id = Id;
            this.PersonId = PersonId;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = Person.Find(PersonId);

            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id = UserData.Add(this.PersonId, this.Username, this.Password, this.IsActive);
            return (this.Id != -1);
        }
        private bool _Update()
        {
            return UserData.Update(this.Id, this.PersonId, this.Username, this.Password, this.IsActive);
        }
        public bool Save()
        {
            switch (_mode)
            {
                case Mode.Add:
                    if (_Add())
                    {
                        _mode = Mode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case Mode.Update: return _Update();
            }
            return false;
        }
        public static bool Exist(int Id)
        {
            return UserData.Exist(Id);
        }
        public static bool ExistByPersonId(int personId)
        {
            return UserData.ExistByPersonId(personId);
        }
        public static bool ExistByUsername(string username)
        {
            return UserData.ExistByUsername(username);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return UserData.Delete(Id); }
        }
        public static DataTable All()
        {
            return UserData.All();
        }
        public static User Find(int Id)
        {
            int PersonId = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (UserData.Get(Id, ref PersonId, ref Username, ref Password, ref IsActive))
            {
                return new User(Id, PersonId, Username, Password, IsActive);
            }
            return null;
        }
        public static User FindByUsernameAndPassword(string username, string password)
        {
            int Id = -1;
            int personId = -1;
            bool IsActive = false;

            if (UserData.GetByUsernameAndPassword(username, password, ref Id, ref personId, ref IsActive))
            {
                return new User(Id, personId, username, password, IsActive);
            }
            return null;
        }
        public bool ChangePassword()
        {
            return UserData.ChangePassword(this.Id, this.Password);
        }

    }


}
