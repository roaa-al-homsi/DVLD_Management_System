using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class DetainedLicense
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public int LicenseId { get; set; }

        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserId { get; set; }
        public User CreatedByUserInfo { get; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserId { get; set; }
        public User ReleasedByUserInfo { get; }
        public int ReleaseApplicationId { get; set; }

        public DetainedLicense()
        {
            this.Id = -1;
            this.LicenseId = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = 0;
            this.CreatedByUserId = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserId = -1;
            this.ReleaseApplicationId = -1;

            _mode = Mode.Add;
        }
        private DetainedLicense(int Id, int LicenseId, DateTime DetainDate, decimal FineFees, int CreatedByUserId, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserId, int ReleaseApplicationId)
        {
            this.Id = Id;
            this.LicenseId = LicenseId;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserId = CreatedByUserId;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserId = ReleasedByUserId;
            this.ReleaseApplicationId = ReleaseApplicationId;
            this.CreatedByUserInfo = User.Find(CreatedByUserId);
            this.ReleasedByUserInfo = User.Find(ReleasedByUserId);
            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id =
                        DetainedLicenseData.Add(this.LicenseId, this.DetainDate, this.FineFees, this.CreatedByUserId, this.IsReleased, this.ReleaseDate, this.ReleasedByUserId, this.ReleaseApplicationId);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return DetainedLicenseData.Update(this.Id, this.LicenseId, this.DetainDate, this.FineFees, this.CreatedByUserId, this.IsReleased, this.ReleaseDate, this.ReleasedByUserId, this.ReleaseApplicationId);
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
                        return false;
                    }
                case Mode.Update: return _Update();
            }
            return false;
        }
        public static bool Exist(int Id)
        {
            return DetainedLicenseData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return DetainedLicenseData.Delete(Id); }
        }
        public static DataTable All()
        {
            return DetainedLicenseData.All();
        }
        public static DetainedLicense Find(int Id)
        {
            int LicenseId = -1;
            DateTime DetainDate = DateTime.MinValue;
            decimal FineFees = 0;
            int CreatedByUserId = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserId = -1;
            int ReleaseApplicationId = -1;

            if (DetainedLicenseData.Get(Id, ref LicenseId, ref DetainDate, ref FineFees, ref CreatedByUserId, ref IsReleased, ref ReleaseDate, ref ReleasedByUserId, ref ReleaseApplicationId))
            {
                return new DetainedLicense(Id, LicenseId, DetainDate, FineFees, CreatedByUserId, IsReleased, ReleaseDate, ReleasedByUserId, ReleaseApplicationId);
            }
            return null;
        }
        public static DetainedLicense FindByLicenseId(int licenseId)
        {
            int DetainId = -1;
            DateTime DetainDate = DateTime.MinValue;
            decimal FineFees = 0;
            int CreatedByUserId = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserId = -1;
            int ReleaseApplicationId = -1;

            if (DetainedLicenseData.GetByLicenseId(licenseId, ref DetainId, ref DetainDate, ref FineFees, ref CreatedByUserId, ref IsReleased, ref ReleaseDate, ref ReleasedByUserId, ref ReleaseApplicationId))
            {
                return new DetainedLicense(DetainId, licenseId, DetainDate, FineFees, CreatedByUserId, IsReleased, ReleaseDate, ReleasedByUserId, ReleaseApplicationId);
            }
            return null;
        }
        public static bool IsLicenseDetained(int licenseId)
        {
            return DetainedLicenseData.IsLicenseDetained(licenseId);
        }
        public bool ReleaseDetainedLicense(int releaseByUserId, int releaseApplicationId)
        {
            return DetainedLicenseData.ReleaseDetainedLicense(this.Id, releaseByUserId, releaseApplicationId);//id 7 8 
        }
    }


}
