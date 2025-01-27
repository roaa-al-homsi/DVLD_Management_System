using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class ApplicationData
    {

        public static int Add(int PersonId, DateTime Date, int ApplicationTypeId, byte Status, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserId)
        {
            int newId = 0;
            string query = "insert into Applications (PersonId,Date,ApplicationTypeId,Status,LastStatusDate,PaidFees,CreatedByUserId) values (@PersonId,@Date,@ApplicationTypeId,@Status,@LastStatusDate,@PaidFees,@CreatedByUserId) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@ApplicationTypeId", ApplicationTypeId);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
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
        public static bool Update(int Id, int PersonId, DateTime Date, int ApplicationTypeId, byte Status, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserId)
        {
            int RowsAffected = 0;
            string query = "update Applications set PersonId = @PersonId,Date = @Date,ApplicationTypeId = @ApplicationTypeId,Status = @Status,LastStatusDate = @LastStatusDate,PaidFees = @PaidFees,CreatedByUserId = @CreatedByUserId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@ApplicationTypeId", ApplicationTypeId);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
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
        public static bool Get(int Id, ref int PersonId, ref DateTime Date, ref int ApplicationTypeId, ref byte Status, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserId)
        {
            bool IsFound = false;
            string query = "select * from Applications  WHERE Id=@Id;";
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
                            PersonId = (int)reader["PersonId"];
                            Date = (DateTime)reader["Date"];
                            ApplicationTypeId = (int)reader["ApplicationTypeId"];
                            Status = (byte)reader["Status"];
                            LastStatusDate = (DateTime)reader["LastStatusDate"];
                            PaidFees = (decimal)reader["PaidFees"];
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
            return GenericData.All("select * from Applications");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete Applications where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from Applications where Id= @Id", "@Id", Id);
        }
        //lesson 47
        //DoesPersonHaveActiveApplication
        //GetActiveApplicationId


        static public int GetActiveApplicationIdForLicenseClass(int personId, int applicationTypeId, int licenseClassId)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(SettingData.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.Id  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.Id = LocalDrivingLicenseApplications.ApplicationID
                            WHERE PersonId = @personId 
                            and ApplicationTypeId=@applicationTypeId
							and LocalDrivingLicenseApplications.LicenseClassesId = @licenseClassId
                            and Status=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personId", personId);
            command.Parameters.AddWithValue("@applicationTypeId", applicationTypeId);
            command.Parameters.AddWithValue("@licenseClassId", licenseClassId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }
        public static bool UpdateStatus(int Id, short NewStatus)
        {
            int RowsAffected = 0;
            string query = "update Applications set Status = @NewStatus,LastStatusDate = @LastStatusDate WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewStatus", NewStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Id", Id);

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



    }
}
