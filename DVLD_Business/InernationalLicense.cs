using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class InternationalLicense : Application
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int DriverId { get; set; }
        public Driver DriverInfo { get; set; }
        public int IssuedUsingLocalLicenseId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreateByUserId { get; set; }

        public InternationalLicense()
        {
            this.ApplicationTypeId = (int)Application.enApplicationType.NewInternationalLicense;
            this.Id = -1;
            this.ApplicationId = -1;
            this.DriverId = -1;
            this.IssuedUsingLocalLicenseId = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreateByUserId = -1;

            _mode = Mode.Add;
        }
        private InternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int Id, int DriverId, int IssuedUsingLocalLicenseId, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreateByUserId)
        {
            this.ApplicationId = ApplicationID;
            this.Date = ApplicationDate;
            this.IssueDate = ApplicationDate;
            this.Status = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserId = CreateByUserId;
            this.ApplicationTypeId = (int)Application.enApplicationType.NewInternationalLicense;

            //international 
            this.Id = Id;
            this.ApplicationId = ApplicationId;
            this.DriverId = DriverId;
            this.IssuedUsingLocalLicenseId = IssuedUsingLocalLicenseId;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreateByUserId = CreateByUserId;

            this.DriverInfo = Driver.Find(DriverId);
            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id =
                        InternationalLicenseData.Add(base.Id, this.DriverId, this.IssuedUsingLocalLicenseId, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreateByUserId);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return InternationalLicenseData.Update(this.Id, this.ApplicationId, this.DriverId, this.IssuedUsingLocalLicenseId, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreateByUserId);
        }
        public bool Save()
        {
            base.mode = (Application.Mode)_mode;
            if (!base.Save())
            {
                return false;
            }

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
            return InternationalLicenseData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return InternationalLicenseData.Delete(Id); }
        }
        public static DataTable All()
        {
            return InternationalLicenseData.All();
        }
        public static InternationalLicense Find(int Id)
        {
            int ApplicationId = -1;
            int DriverId = -1;
            int IssuedUsingLocalLicenseId = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreateByUserId = -1;

            if (InternationalLicenseData.Get(Id, ref ApplicationId, ref DriverId, ref IssuedUsingLocalLicenseId, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreateByUserId))
            {
                Application application = Application.FindBaseApplication(ApplicationId);
                if (application != null)
                {
                    return new InternationalLicense(ApplicationId, application.PersonId, application.Date, application.Status, application.LastStatusDate, application.PaidFees, Id, DriverId, IssuedUsingLocalLicenseId, IssueDate, ExpirationDate, IsActive, CreateByUserId);

                }
            }
            return null;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int driverId)
        {
            return InternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(driverId);
        }
        public static DataTable AllInternationalLicenses(int driverId)
        {
            return InternationalLicenseData.AllInternationalLicensesByDriverId(driverId);
        }

    }
}

