using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class Application
    {

        public enum Mode { Add, Update }
        public Mode mode = Mode.Add;
        public enum enApplicationType
        {
            NewDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public virtual int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string FullNamePerson
        {
            get
            {
                return Person.FullName;
            }
        }
        public DateTime Date { get; set; }
        public int ApplicationTypeId { get; set; }
        public ApplicationType ApplicationType { get; }
        public enApplicationStatus Status { get; set; }
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserId { get; set; }//fk
        public User CreatedByUser { get; }//composition // it is better to make it read only.. all composition, unless you have specific need to make it in write mode also

        public Application()
        {
            this.Id = -1;
            this.PersonId = -1;
            this.Date = DateTime.MinValue;
            this.ApplicationTypeId = -1;
            this.Status = enApplicationStatus.New;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserId = -1;

            mode = Mode.Add;
        }
        private Application(int Id, int PersonId, DateTime Date, int ApplicationTypeId, enApplicationStatus Status, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserId)
        {
            this.Id = Id;
            this.PersonId = PersonId;
            this.Person = Person.Find(PersonId);
            this.Date = Date;
            this.ApplicationTypeId = ApplicationTypeId;
            this.ApplicationType = ApplicationType.Find(ApplicationTypeId);
            this.Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserId = CreatedByUserId;
            this.CreatedByUser = User.Find(CreatedByUserId);


            mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id = ApplicationData.Add(this.PersonId, this.Date, this.ApplicationTypeId, (byte)this.Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserId);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return ApplicationData.Update(this.Id, this.PersonId, this.Date, this.ApplicationTypeId, (byte)this.Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserId);
        }
        public virtual bool Save()
        {

            switch (mode)
            {
                case Mode.Add:
                    {
                        if (_Add())
                        {
                            mode = Mode.Update;
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
        public static bool Exist(int Id)
        {
            return ApplicationData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return ApplicationData.Delete(Id); }
        }
        public static DataTable All()
        {
            return ApplicationData.All();
        }
        public static Application FindBaseApplication(int Id)
        {
            int PersonId = -1;
            DateTime Date = DateTime.MinValue;
            int ApplicationTypeId = -1;
            byte Status = 1;
            DateTime LastStatusDate = DateTime.MinValue;
            decimal PaidFees = 0;
            int CreatedByUserId = -1;

            if (ApplicationData.Get(Id, ref PersonId, ref Date, ref ApplicationTypeId, ref Status, ref LastStatusDate, ref PaidFees, ref CreatedByUserId))
            {
                return new Application(Id, PersonId, Date, ApplicationTypeId, (enApplicationStatus)Status, LastStatusDate, PaidFees, CreatedByUserId);
            }
            return null;
        }

        public bool Cancel()
        {
            return ApplicationData.UpdateStatus(Id, (byte)enApplicationStatus.Cancelled);
        }
        public bool Complete(int applicationId)
        {
            return ApplicationData.UpdateStatus(applicationId, (byte)enApplicationStatus.Completed);
        }
        public static int GetActiveApplicationIdForLicenseClass(int personId, int applicationTypeId, int licenseClassId)
        {
            return ApplicationData.GetActiveApplicationIdForLicenseClass(personId, applicationTypeId, licenseClassId);

        }

        //DoesPersonHaveActiveApplication(personId,applicationTypeId)
        //DoesPersonHaveActiveApplication(applicationTypeId)

        //GetActiveApplicationID



    }


}
