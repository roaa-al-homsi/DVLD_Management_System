using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class Test
    {
        private enum Mode { Add, Update }
        private Mode _mode;
        public int Id { get; set; }
        public int TestAppointmentId { get; set; }
        public TestAppointment TestAppointmentInfo { get; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserId { get; set; }

        public Test()
        {
            this.Id = -1;
            this.TestAppointmentId = -1;
            this.Result = false;
            this.Notes = string.Empty;
            this.CreatedByUserId = -1;

            _mode = Mode.Add;
        }
        private Test(int Id, int TestAppointmentId, bool Result, string Notes, int CreatedByUserId)
        {
            this.Id = Id;
            this.TestAppointmentId = TestAppointmentId;
            this.Result = Result;
            this.Notes = Notes;
            this.CreatedByUserId = CreatedByUserId;
            this.TestAppointmentInfo = TestAppointment.Find(TestAppointmentId);

            _mode = Mode.Update;
        }
        private bool _Add()
        {
            this.Id =
                        TestData.Add(this.TestAppointmentId, this.Result, this.Notes, this.CreatedByUserId);
            return (this.Id != -1);
        }

        private bool _Update()
        {
            return TestData.Update(this.Id, this.TestAppointmentId, this.Result, this.Notes, this.CreatedByUserId);
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
            return TestData.Exist(Id);
        }
        public static bool Delete(int Id)
        {
            if (!Exist(Id))
            {
                return false;
            }
            else { return TestData.Delete(Id); }
        }
        public static DataTable All()
        {
            return TestData.All();
        }
        public static Test Find(int Id)
        {
            int TestAppointmentId = -1;
            bool Result = false;
            string Notes = string.Empty;
            int CreatedByUserId = -1;

            if (TestData.Get(Id, ref TestAppointmentId, ref Result, ref Notes, ref CreatedByUserId))
            {
                return new Test(Id, TestAppointmentId, Result, Notes, CreatedByUserId);
            }
            return null;
        }

        public static Test FindLastTestPerPersonAndLicenseClass
    (int PersonID, int LicenseClassID, TestType.enTestTypes TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (TestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))
            {
                return new Test(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationId)
        {
            return TestData.GetPassedTestCount(LocalDrivingLicenseApplicationId);
        }
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationId)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationId) == 3;
        }
    }


}
