using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class LocalDrivingLicenseApplication : Application
    {
        public enum Mode { Add, Update }
        public Mode mode;
        public override int Id { get; set; }
        public int ApplicationId { get; set; }//fk
        public int LicenseClassId { get; set; }//fk
        public LicenseClass LicenseClass { get; }//Composition
        public string FullName
        {
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
            : base(applicationId, personId, date, applicationTypeId, status, lastStatusDate, paidFees, createByUserId)
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

                if (application == null) // or is haha
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
    }


}
