using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class TestData
    {
        public static int Add(int TestAppointmentId, bool Result, string Notes, int CreatedByUserId)
        {
            int newId = 0;
            string query = @"insert into Tests (TestAppointmentId,Result,Notes,CreatedByUserId) values (@TestAppointmentId,@Result,@Notes,@CreatedByUserId)
                    UPDATE TestAppointments SET IsLocked=1 where Id = @TestAppointmentId;
                      SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestAppointmentId", TestAppointmentId);
                    command.Parameters.AddWithValue("@Result", Result);
                    command.Parameters.AddWithValue("@Notes", !string.IsNullOrWhiteSpace(Notes) ? Notes : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);

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
        public static bool Update(int Id, int TestAppointmentId, bool Result, string Notes, int CreatedByUserId)
        {
            int RowsAffected = 0;
            string query = "update Tests set TestAppointmentId = @TestAppointmentId,Result = @Result,Notes = @Notes,CreatedByUserId = @CreatedByUserId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@TestAppointmentId", TestAppointmentId);
                    command.Parameters.AddWithValue("@Result", Result);
                    command.Parameters.AddWithValue("@Notes", !string.IsNullOrWhiteSpace(Notes) ? Notes : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);

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
        public static bool Get(int Id, ref int TestAppointmentId, ref bool Result, ref string Notes, ref int CreatedByUserId)
        {
            bool IsFound = false;
            string query = "select * from Tests  WHERE Id=@Id;";
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
                            TestAppointmentId = (int)reader["TestAppointmentId"];
                            Result = (bool)reader["Result"];
                            Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                            CreatedByUserId = (int)reader["CreatedByUserId"];


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
            return GenericData.All("select * from Tests");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete Tests where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from Tests where Id= @Id", "@Id", Id);
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
          (int PersonId, int LicenseClassId, int TestTypeId, ref int TestId,
            ref int TestAppointmentId, ref bool TestResult,
            ref string Notes, ref int CreatedByUserId)
        {
            bool isFound = false;
            string query = @"SELECT  top 1 Tests.Id as [Test Id], 
                Tests.TestAppointmentID, Tests.Result, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.Id as [app Id]
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentId = TestAppointments.Id ON LocalDrivingLicenseApplications.Id = TestAppointments.LocalDrivingLicenseApplicationsId INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.Id
                WHERE        (Applications.PersonId = @PersonId) 
                        AND (LocalDrivingLicenseApplications.LicenseClassesId = @LicenseClassId)
                        AND ( TestAppointments.TestTypeId=@TestTypeId)

                ORDER BY Tests.TestAppointmentID DESc
";


            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonId);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassId);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeId);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {

                            // The record was found
                            isFound = true;
                            TestId = (int)reader["Id"];
                            TestAppointmentId = (int)reader["TestAppointmentId"];
                            TestResult = (bool)reader["Result"];
                            Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : (string)reader["Notes"];
                            CreatedByUserId = (int)reader["CreatedByUserId"];
                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationId)
        {
            byte PassedTestCount = 0;

            string query = @"select PassedTestCount = count (Tests.Id) from Tests inner join TestAppointments on Tests.TestAppointmentId = TestAppointments.Id
				  where  TestAppointments.LocalDrivingLicenseApplicationsId=@LocalDrivingLicenseApplicationId
				  and Tests.Result=1";

            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationId", LocalDrivingLicenseApplicationId);
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                        {
                            PassedTestCount = ptCount;
                        }
                    }

                    catch (Exception ex)
                    {

                    }

                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return PassedTestCount;
        }

    }
}
