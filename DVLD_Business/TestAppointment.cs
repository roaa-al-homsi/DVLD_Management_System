using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class TestAppointment
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public TestType.enTestTypes TestTypeId { get; set; }
        public int LocalDrivingLicenseApplicationsId { get; set; }
        public DateTime Date { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserId { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationId { get; set; }
        public Application RetakeTestApplicationInfo { get; set; }

        public int TestID
        {
            get { return _GetTestID(); }

        }
        public TestAppointment()
        {
            this.Id = -1;
            this.TestTypeId = TestType.enTestTypes.VisionTest;
            this.LocalDrivingLicenseApplicationsId = -1;
            this.Date = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserId = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationId = -1;

            _mode = Mode.Add;
        }
        private TestAppointment(int Id, TestType.enTestTypes TestTypeId, int LocalDrivingLicenseApplicationsId, DateTime Date, decimal PaidFees, int CreatedByUserId, bool IsLocked, int RetakeTestApplicationId)
        {
            this.Id = Id;
            this.TestTypeId = TestTypeId;
            this.LocalDrivingLicenseApplicationsId = LocalDrivingLicenseApplicationsId;
            this.Date = Date;
            this.PaidFees = PaidFees;
            this.CreatedByUserId = CreatedByUserId;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationId = RetakeTestApplicationId;
            this.RetakeTestApplicationInfo = Application.FindBaseApplication(RetakeTestApplicationId);

            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id =
                        TestAppointmentData.Add((int)this.TestTypeId, this.LocalDrivingLicenseApplicationsId, this.Date, this.PaidFees, this.CreatedByUserId, this.IsLocked, this.RetakeTestApplicationId);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return TestAppointmentData.Update(this.Id, (int)this.TestTypeId, this.LocalDrivingLicenseApplicationsId, this.Date, this.PaidFees, this.CreatedByUserId, this.IsLocked, this.RetakeTestApplicationId);
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
            return TestAppointmentData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return TestAppointmentData.Delete(Id); }
        }
        public static DataTable All()
        {
            return TestAppointmentData.All();
        }
        public static TestAppointment Find(int Id)
        {
            int TestTypeId = -1;
            int LocalDrivingLicenseApplicationsId = -1;
            DateTime Date = DateTime.MinValue;
            decimal PaidFees = 0;
            int CreatedByUserId = -1;
            bool IsLocked = false;
            int RetakeTestApplicationId = -1;

            if (TestAppointmentData.Get(Id, ref TestTypeId, ref LocalDrivingLicenseApplicationsId, ref Date, ref PaidFees, ref CreatedByUserId, ref IsLocked, ref RetakeTestApplicationId))
            {
                return new TestAppointment(Id, (TestType.enTestTypes)TestTypeId, LocalDrivingLicenseApplicationsId, Date, PaidFees, CreatedByUserId, IsLocked, RetakeTestApplicationId);
            }
            return null;
        }
        public static TestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, TestType.enTestTypes TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (TestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new TestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }
        public DataTable GetApplicationTestAppointmentsPerTestType(TestType.enTestTypes TestTypeID)
        {
            return TestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationsId, (int)TestTypeID);

        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, TestType.enTestTypes TestTypeID)
        {
            return TestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }
        private int _GetTestID()
        {
            return TestAppointmentData.GetTestID(this.Id);
        }

    }


}
