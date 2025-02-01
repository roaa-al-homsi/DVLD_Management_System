using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class LocalDrivingLicenseApplicationData
    {

        public static int Add(int ApplicationId, int LicenseClassesId)
        {
            int newId = 0;
            string query = "insert into LocalDrivingLicenseApplications (ApplicationId,LicenseClassesId) values (@ApplicationId,@LicenseClassesId) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                    command.Parameters.AddWithValue("@LicenseClassesId", LicenseClassesId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            newId = insertedID;
                        }

                    }
                    catch (Exception ex) { }
                }
            }

            return newId;
        }
        public static bool Update(int Id, int ApplicationId, int LicenseClassesId)
        {
            int RowsAffected = 0;
            string query = "update LocalDrivingLicenseApplications set ApplicationId = @ApplicationId,LicenseClassesId = @LicenseClassesId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                    command.Parameters.AddWithValue("@LicenseClassesId", LicenseClassesId);

                    try
                    {
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }

            return RowsAffected > 0;
        }
        public static bool Get(int Id, ref int ApplicationId, ref int LicenseClassesId)
        {
            bool IsFound = false;
            string query = "select * from LocalDrivingLicenseApplications  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            Id = (int)reader["Id"];
                            ApplicationId = (int)reader["ApplicationId"];
                            LicenseClassesId = (int)reader["LicenseClassesId"];


                        }
                        else
                        {
                            IsFound = false;
                        }
                    }
                    catch (Exception ex) { }
                }
            }

            return IsFound;
        }
        public static bool GetByApplicationId(int ApplicationId, ref int Id, ref int LicenseClassesId)
        {
            bool IsFound = false;
            string query = "select * from LocalDrivingLicenseApplications  WHERE ApplicationId=@ApplicationId;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            Id = (int)reader["Id"];
                            ApplicationId = (int)reader["ApplicationId"];
                            LicenseClassesId = (int)reader["LicenseClassesId"];


                        }
                        else
                        {
                            IsFound = false;
                        }
                    }
                    catch (Exception ex) { }
                }
            }

            return IsFound;
        }
        static public DataTable All()
        {
            return GenericData.All("select * from LocalDrivingLicenseApplication_View");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete LocalDrivingLicenseApplications where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select top 1 Found=1 from LocalDrivingLicenseApplications where Id= @Id", "@Id", Id);
        }

        //static public bool IsHaveLocalDrivingActive()
        //{

        //    return GenericData.Exist("select Found=1 from LocalDrivingLicenseApplications where Id= @Id", "@Id", Id);

        //}


        //Al of these in lesson 49
        //Does pass Test Type
        //Does Attend Test Type               done .
        //Total Trials per test 
        //IsThere An Active Schedule Test
        static public bool DoesAttendTestType(int localDrivingLicenseId, int testTypeId)
        {
            bool IsFound = false;
            string query = "select found = 1 from TestAppointments where LocalDrivingLicenseApplicationsId=@localDrivingLicenseId and TestTypeId =@testTypeId";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@testTypeId", testTypeId);
                    command.Parameters.AddWithValue("@localDrivingLicenseId", localDrivingLicenseId);
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = command.ExecuteReader();
                        IsFound = Reader.HasRows;
                        Reader.Close();
                    }
                    catch (Exception ex) { }
                }
            }
            return IsFound;
        }
        static public int TotalTrialsPerTest(int localDrivingLicenseId, int testTypeId)
        {
            int TotalTests = 0;
            string query = @"SELECT TotalTrialsPerTest = count(Tests.Id)from Tests inner join TestAppointments on Tests.TestAppointmentId = TestAppointments.Id
            where TestAppointments.TestTypeId = @testTypeId and TestAppointments.LocalDrivingLicenseApplicationsId = @localDrivingLicenseId ";

            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@localDrivingLicenseId", localDrivingLicenseId);
                    command.Parameters.AddWithValue("@testTypeId", testTypeId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            TotalTests = insertedID;
                        }

                    }
                    catch (Exception ex) { }
                }
            }

            return testTypeId;
        }
        public static bool IsThereAnActiveScheduledTest(int localDrivingLicenseId, int testTypeId)
        {
            bool IsFound = false;
            string query = "select top 1 found =1 from TestAppointments where TestTypeId=@testTypeId and LocalDrivingLicenseApplicationsId=@localDrivingLicenseId and IsLocked=0";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@testTypeId", testTypeId);
                    command.Parameters.AddWithValue("@localDrivingLicenseId", localDrivingLicenseId);
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = command.ExecuteReader();
                        IsFound = Reader.HasRows;
                        Reader.Close();
                    }
                    catch (Exception ex) { }
                }
            }
            return IsFound;
        }
        public static bool DoesPassTestType(int localDrivingLicenseId, int testTypeId)
        {
            bool IsFound = false;
            string query = @" select top 1 Result from Tests inner join TestAppointments 
                              on Tests.TestAppointmentId =TestAppointments.Id 
                              where (TestAppointments.LocalDrivingLicenseApplicationsId=@localDrivingLicenseId and TestAppointments.TestTypeId=@testTypeId and Tests.Result=1)";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@testTypeId", testTypeId);
                    command.Parameters.AddWithValue("@localDrivingLicenseId", localDrivingLicenseId);
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = command.ExecuteReader();
                        IsFound = Reader.HasRows;
                        Reader.Close();
                    }
                    catch (Exception ex) { }
                }
            }
            return IsFound;
        }
    }
}
