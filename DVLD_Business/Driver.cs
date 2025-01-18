using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class Driver
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Driver()
        {
            this.Id = -1;
            this.PersonId = -1;
            this.CreatedByUserId = -1;
            this.CreatedDate = DateTime.MinValue;

            _mode = Mode.Add;
        }
        private Driver(int Id, int PersonId, int CreatedByUserId, DateTime CreatedDate)
        {
            this.Id = Id;
            this.PersonId = PersonId;
            this.CreatedByUserId = CreatedByUserId;
            this.CreatedDate = CreatedDate;


            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id =
                        DriverData.Add(this.PersonId, this.CreatedByUserId, this.CreatedDate);
            return (this.Id != -1);
        }
        private bool _Update()
        {
            return DriverData.Update(this.Id, this.PersonId, this.CreatedByUserId, this.CreatedDate);
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
            return DriverData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return DriverData.Delete(Id); }
        }
        public static DataTable All()
        {
            return DriverData.All();
        }
        public static Driver Find(int Id)
        {
            int PersonId = -1;
            int CreatedByUserId = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (DriverData.Get(Id, ref PersonId, ref CreatedByUserId, ref CreatedDate))
            {
                return new Driver(Id, PersonId, CreatedByUserId, CreatedDate);
            }
            return null;
        }
    }


}
