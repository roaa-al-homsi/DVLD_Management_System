using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class TestAppointmentData
    {
        public static int Add(int TestTypeId, int LocalDrivingLicenseApplicationsId, DateTime Date, decimal PaidFees, int CreatedByUserId, bool IsLocked, int RetakeTestApplicationId)
        {
            int newId = 0;
            string query = "insert into TestAppointments (TestTypeLocalDrivingLicenseApplicationsDate,PaidFees,CreatedByUserIsLocked,RetakeTestApplicationId) values (@TestTypeId,@LocalDrivingLicenseApplicationsId,@Date,@PaidFees,@CreatedByUserId,@IsLocked,@RetakeTestApplicationId) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestTypeId", TestTypeId);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationsId", LocalDrivingLicenseApplicationsId);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    command.Parameters.AddWithValue("@RetakeTestApplicationId", (RetakeTestApplicationId == -1) ? DBNull.Value : (object)RetakeTestApplicationId);

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
        public static bool Update(int Id, int TestTypeId, int LocalDrivingLicenseApplicationsId, DateTime Date, decimal PaidFees, int CreatedByUserId, bool IsLocked, int RetakeTestApplicationId)
        {
            int RowsAffected = 0;
            string query = "update TestAppointments set TestTypeId = @TestTypeId,LocalDrivingLicenseApplicationsId = @LocalDrivingLicenseApplicationsId,Date = @Date,PaidFees = @PaidFees,CreatedByUserId = @CreatedByUserId,IsLocked = @IsLocked,RetakeTestApplicationId = @RetakeTestApplicationId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@TestTypeId", TestTypeId);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationsId", LocalDrivingLicenseApplicationsId);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    command.Parameters.AddWithValue("@RetakeTestApplicationId", (RetakeTestApplicationId == -1) ? DBNull.Value : (object)RetakeTestApplicationId);

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
        public static bool Get(int Id, ref int TestTypeId, ref int LocalDrivingLicenseApplicationsId, ref DateTime Date, ref decimal PaidFees, ref int CreatedByUserId, ref bool IsLocked, ref int RetakeTestApplicationId)
        {
            bool IsFound = false;
            string query = "select * from TestAppointments  WHERE Id=@Id;";
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
                            TestTypeId = (int)reader["TestTypeId"];
                            LocalDrivingLicenseApplicationsId = (int)reader["LocalDrivingLicenseApplicationsId"];
                            Date = (DateTime)reader["Date"];
                            PaidFees = (decimal)reader["PaidFees"];
                            CreatedByUserId = (int)reader["CreatedByUserId"];
                            IsLocked = (bool)reader["IsLocked"];
                            RetakeTestApplicationId = reader["RetakeTestApplicationId"] != DBNull.Value ? (int)reader["RetakeTestApplicationId"] : -1;


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
            return GenericData.All("select * from TestAppointments");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete TestAppointments where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from TestAppointments where Id= @Id", "@Id", Id);
        }

    }
}
