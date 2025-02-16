using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class License
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public Application ApplicationInfo { get; }
        public int DriverId { get; set; }
        public Driver DriverInfo { get; }
        public int LicenseClassId { get; set; }
        public LicenseClass LicenseClass { get; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserId { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public bool IsDetained
        {
            get
            {
                return DetainedLicense.IsLicenseDetained(this.Id);
            }
        }
        public DetainedLicense DetainInfo { get; set; }
        public License()
        {
            this.Id = -1;
            this.ApplicationId = -1;
            this.DriverId = -1;
            this.LicenseClassId = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Notes = string.Empty;
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserId = -1;

            _mode = Mode.Add;
        }
        private License(int Id, int ApplicationId, int DriverId, int LicenseClassId, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserId)
        {
            this.Id = Id;
            this.ApplicationId = ApplicationId;
            this.DriverId = DriverId;
            this.LicenseClassId = LicenseClassId;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserId = CreatedByUserId;
            this.DriverInfo = Driver.Find(DriverId);
            this.ApplicationInfo = Application.FindBaseApplication(ApplicationId);
            this.LicenseClass = LicenseClass.Find(LicenseClassId);
            this.DetainInfo = DetainedLicense.FindByLicenseId(Id);

            _mode = Mode.Update;
        }
        public static string GetIssueReasonText(enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.LostReplacement:
                    return "Lost Replacement";
                case enIssueReason.DamagedReplacement:
                    return "Damaged Replacement";
                case enIssueReason.Renew:
                    return "Renew";
                default:
                    return "First Time";
            }
        }
        private bool _Add()
        {
            this.Id =
                        LicenseData.Add(this.ApplicationId, this.DriverId, this.LicenseClassId, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserId);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return LicenseData.Update(this.Id, this.ApplicationId, this.DriverId, this.LicenseClassId, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserId);
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
            return LicenseData.Exist(Id);
        }

        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return LicenseData.Delete(Id); }
        }
        public static DataTable All()
        {
            return LicenseData.All();
        }
        public static License Find(int Id)
        {
            int ApplicationId = -1;
            int DriverId = -1;
            int LicenseClassId = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 1;
            int CreatedByUserId = -1;

            if (LicenseData.Get(Id, ref ApplicationId, ref DriverId, ref LicenseClassId, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserId))
            {
                return new License(Id, ApplicationId, DriverId, LicenseClassId, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserId);
            }
            else
            {
                return null;
            }
        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return LicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }
        public bool IsLicenseExpired()
        {
            return (DateTime.Now > this.ExpirationDate);
        }
        public bool DeactivateCurrentLicense()
        {
            return (LicenseData.DeactivateCurrentLicense(this.Id));
        }

        public License RenewLicense(string notes, int createByUserId)
        {
            Application application = new Application();
            application.CreatedByUserId = createByUserId;
            application.ApplicationTypeId = (byte)Application.enApplicationType.RenewDrivingLicense;
            application.Date = DateTime.Now;
            application.Status = Application.enApplicationStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PersonId = this.DriverInfo.PersonId;
            application.PaidFees = ApplicationType.GetFeesForSpecificApplication(Application.enApplicationType.RenewDrivingLicense);

            if (!application.Save())
            {
                return null;
            }
            License license = new License();
            license.Notes = notes;
            license.ApplicationId = application.Id;
            license.DriverId = this.DriverId;
            license.CreatedByUserId = createByUserId;
            license.IsActive = true;
            license.ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength);
            license.IssueDate = DateTime.Now;
            license.IssueReason = License.enIssueReason.Renew;
            license.IsActive = true;
            license.LicenseClassId = this.LicenseClassId;

            if (!license.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();
            return license;
        }
        public License Replace(enIssueReason IssueReason, int createdByUserId)
        {
            Application application = new Application();
            application.CreatedByUserId = createdByUserId;
            application.ApplicationTypeId = IssueReason == enIssueReason.LostReplacement ? (int)Application.enApplicationType.ReplaceLostDrivingLicense : (int)Application.enApplicationType.ReplaceDamagedDrivingLicense;
            application.Date = DateTime.Now;
            application.Status = Application.enApplicationStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = ApplicationType.GetFeesForSpecificApplication((Application.enApplicationType)application.ApplicationTypeId);
            application.PersonId = this.DriverInfo.PersonId;

            if (!application.Save())
            {
                return null;
            }

            License license = new License();
            license.LicenseClassId = this.LicenseClassId;
            license.ApplicationId = application.Id;
            license.DriverId = this.DriverId;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = this.ExpirationDate;
            license.Notes = this.Notes;
            license.PaidFees = 0;// no fees for the license because it's a replacement.
            license.IsActive = true;
            license.IssueReason = IssueReason;
            license.CreatedByUserId = createdByUserId;

            if (!license.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();

            return license;
        }
        public int Detain(decimal fineFees, int createdByUserId)
        {
            DetainedLicense detainedLicense = new DetainedLicense();
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = fineFees;
            detainedLicense.CreatedByUserId = createdByUserId;
            detainedLicense.LicenseId = this.Id;
            if (!detainedLicense.Save())
            {
                return -1;
            }
            return detainedLicense.Id;
        }
        public bool Release(int releasedByUserId)
        {
            Application application = new Application();
            application.CreatedByUserId = releasedByUserId;
            application.Date = DateTime.Now;
            application.ApplicationTypeId = (int)Application.enApplicationType.ReleaseDetainedDrivingLicense;
            application.LastStatusDate = DateTime.Now;
            application.PersonId = this.DriverInfo.PersonId;
            application.Status = Application.enApplicationStatus.Completed;
            application.PaidFees = ApplicationType.GetFeesForSpecificApplication(Application.enApplicationType.ReleaseDetainedDrivingLicense);
            if (!application.Save())
            {
                return false;
            }
            return (this.DetainInfo.ReleaseDetainedLicense(releasedByUserId, application.Id));
        }

        public static DataTable GetDriverLicenses(int driverId)
        {
            return LicenseData.GetDriverLicenses(driverId);
        }





    }


}
