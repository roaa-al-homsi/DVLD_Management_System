using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class LocalDrivingLicenseApplication : Application
    {
        public enum Mode { Add, Update }
        public Mode mode;
        public int Id { get; set; }
        public int ApplicationId { get; set; }//fk
        public int LicenseClassId { get; set; }//fk
        public LicenseClass LicenseClass { get; set; }//Composition
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
            this.Id = LocalDrivingLicenseApplicationData.Add(this.ApplicationId, this.LicenseClassId);
            return (this.Id != -1);
        }
        private bool _Update()
        {
            return LocalDrivingLicenseApplicationData.Update(this.Id, this.ApplicationId, this.LicenseClassId);
        }
        public bool Save()
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
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return LocalDrivingLicenseApplicationData.Delete(Id); }
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
                return new LocalDrivingLicenseApplication(applicationId, Id, LicenseClassesId, application.Date, application.ApplicationTypeId, application.Status, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserId, application.PersonId);
            }
            return null;
        }



    }


}
