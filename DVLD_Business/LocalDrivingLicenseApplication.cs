using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class LocalDrivingLicenseApplication : Application
    {
        public enum Mode { Add, Update }
        public Mode mode;
        public new int Id { get; set; }

        public int ApplicationId { get; set; }
        public int LicenseClassId { get; set; }
        public LicenseClass LicenseClass { get; }
        public string FullName
        {
            //get
            //{
            //    return Person.Find(ApplicantPersonID).FullName;
            //}
            get
            {
                return base.Person.FullName;
            }
        }

        public LocalDrivingLicenseApplication()
        {
            this.Id = -1;
            this.ApplicationId = -1;
            this.LicenseClassId = -1;

            mode = Mode.Add;
        }
        private LocalDrivingLicenseApplication(int Id, int applicationId, int licenseClassId, DateTime date, int applicationTypeId,
            enApplicationStatus status, DateTime lastStatusDate, decimal paidFees, int createByUserId, int personId)
        {
            this.Id = Id;
            this.ApplicationId = applicationId;
            this.LicenseClassId = licenseClassId;
            this.Date = date;
            this.ApplicationTypeId = applicationTypeId;
            this.Status = status;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserId = createByUserId;
            this.PersonId = personId;
            this.LicenseClassId = licenseClassId;
            this.LicenseClass = LicenseClass.Find(licenseClassId);
            this.Person = Person.Find(personId);

            mode = Mode.Update;
        }
        private bool _Add()
        {
            this.ApplicationId = base.Id;
            this.Id = LocalDrivingLicenseApplicationData.Add(this.ApplicationId, this.LicenseClassId);
            return (this.Id != -1);
        }
        private bool _Update()
        {
            return LocalDrivingLicenseApplicationData.Update(this.Id, this.ApplicationId, this.LicenseClassId);
        }
        public override bool Save()
        {
            base.mode = (Application.Mode)mode;
            if (!base.Save())
            {
                return false;
            }

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
            return LocalDrivingLicenseApplicationData.Exist(Id);
        }
        public bool Delete()
        {
            if (!Exist(this.Id))
            {
                return false;
            }
            if (LocalDrivingLicenseApplicationData.Delete(Id))
            {
                return Application.Delete(this.ApplicationId);
            }
            return false;
        }
        public static DataTable All()
        {
            return LocalDrivingLicenseApplicationData.All();
        }
        public static LocalDrivingLicenseApplication Find(int Id)
        {
            int ApplicationId = -1;
            int LicenseClassesId = -1;

            if (LocalDrivingLicenseApplicationData.Get(Id, ref ApplicationId, ref LicenseClassesId))
            {
                Application application = Application.FindBaseApplication(ApplicationId);

                if (application is null)
                {
                    return null;
                }

                return new LocalDrivingLicenseApplication(Id, ApplicationId, LicenseClassesId, application.Date, application.ApplicationTypeId, application.Status, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserId, application.PersonId);
            }
            return null;
        }
        public static LocalDrivingLicenseApplication FindByApplicationId(int applicationId)
        {
            int Id = -1;
            int LicenseClassesId = -1;

            if (LocalDrivingLicenseApplicationData.GetByApplicationId(applicationId, ref Id, ref LicenseClassesId))
            {
                Application application = Application.FindBaseApplication(applicationId);
                if (application == null) // or is haha
                {
                    return null;
                }

                return new LocalDrivingLicenseApplication(applicationId, Id, LicenseClassesId, application.Date, application.ApplicationTypeId, application.Status, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserId, application.PersonId);
            }
            return null;
        }
        public bool DoesAttendTestType(TestType.enTestTypes testTypeId)
        {
            return LocalDrivingLicenseApplicationData.DoesAttendTestType(this.Id, (int)testTypeId);
        }
        public int TotalTrialsPerTest(TestType.enTestTypes testTypeId)
        {
            return LocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.Id, (int)testTypeId);
        }
        public bool IsThereAnActiveScheduledTest(TestType.enTestTypes testTypeId)
        {
            return LocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.Id, (int)testTypeId);
        }
        public bool DoesPassTestType(TestType.enTestTypes testTypeId)
        {
            return LocalDrivingLicenseApplicationData.DoesPassTestType(this.Id, (int)testTypeId);
        }
        //I'm not convinced...why we need person Id and license class Id 
        public Test GetLastTestPerTestType(TestType.enTestTypes testTypeId)
        {
            return Test.FindLastTestPerPersonAndLicenseClass(this.PersonId, this.LicenseClassId, testTypeId);
        }
        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }
        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return License.GetActiveLicenseIDByPersonID(this.PersonId, this.LicenseClassId);
        }
        public byte GetPassedTestCount()
        {
            return Test.GetPassedTestCount(this.Id);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return Test.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        public int IssueLicenseForTheFirstTime(string notes, int createdByUserID)
        {
            int driverId = -1;
            Driver driver = Driver.FindByPersonId(this.PersonId);
            if (driver == null)
            {
                driver = new Driver();
                driver.CreatedByUserId = this.CreatedByUserId;
                driver.PersonId = this.PersonId;
                driver.CreatedDate = DateTime.Now;
                if (driver.Save())
                {
                    driverId = driver.Id;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                driverId = driver.Id;
            }
            License license = new License();
            license.CreatedByUserId = createdByUserID;
            license.ApplicationId = this.ApplicationId;
            license.LicenseClassId = this.LicenseClassId;
            license.Notes = notes;
            license.DriverId = driverId;
            license.IsActive = true;
            license.IssueReason = License.enIssueReason.FirstTime;
            license.PaidFees = this.LicenseClass.Fees;
            license.ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength); ;
            license.IssueDate = DateTime.Now;
            if (license.Save())
            {
                this.Complete(this.ApplicationId);
                return license.Id;
            }
            else
            {
                return -1;
            }
        }
    }

}
