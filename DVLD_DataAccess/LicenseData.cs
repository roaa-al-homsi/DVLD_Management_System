using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class LicenseData
    {
        public static int Add(int ApplicationId, int DriverId, int LicenseClassId, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserId)
        {
            int newId = 0;
            string query = "insert into Licenses (ApplicationId,DriverId,LicenseClassId,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserId) values (@ApplicationId,@DriverId,@LicenseClassId,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserId) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                    command.Parameters.AddWithValue("@DriverId", DriverId);
                    command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
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
        public static bool Update(int Id, int ApplicationId, int DriverId, int LicenseClassId, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserId)
        {
            int RowsAffected = 0;
            string query = "update Licenses set ApplicationId = @ApplicationId,DriverId = @DriverId,LicenseClassId = @LicenseClassId,IssueDate = @IssueDate,ExpirationDate = @ExpirationDate,Notes = @Notes,PaidFees = @PaidFees,IsActive = @IsActive,IssueReason = @IssueReason,CreatedByUserId = @CreatedByUserId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                    command.Parameters.AddWithValue("@DriverId", DriverId);
                    command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
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
        public static bool Get(int Id, ref int ApplicationId, ref int DriverId, ref int LicenseClassId, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserId)
        {
            bool IsFound = false;
            string query = "select * from Licenses  WHERE Id=@Id;";
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
                            DriverId = (int)reader["DriverId"];
                            LicenseClassId = (int)reader["LicenseClassId"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpirationDate = (DateTime)reader["ExpirationDate"];
                            Notes = (string)reader["Notes"];
                            PaidFees = (decimal)reader["PaidFees"];
                            IsActive = (bool)reader["IsActive"];
                            IssueReason = (byte)reader["IssueReason"];
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
            return GenericData.All("select * from Licenses");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete Licenses where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from Licenses where Id= @Id", "@Id", Id);
        }
        public static int GetActiveLicenseIDByPersonID(int PersonId, int LicenseClassId)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(SettingData.ConnectionString);

            string query = @"SELECT Licenses.Id
                            FROM Licenses INNER JOIN
                            Drivers ON Licenses.DriverId = Drivers.Id
                            WHERE  
                             Licenses.LicenseClassId =@LicenseClassId
                              AND Drivers.PersonId = @PersonId
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }
            return LicenseID;
        }

        public static bool DeactivateCurrentLicense(int licenseId)
        {
            int rowsAffected = 0;
            string query = "update Licenses set IsActive=0 where Id=@licenseId; ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@licenseId", licenseId);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            return rowsAffected > 0;
        }

        public static DataTable GetDriverLicenses(int driverId)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Licenses.Id as [Lic.Id], Licenses.ApplicationId as [App.Id], LicenseClasses.Name , Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
                           FROM     Licenses inner JOIN  LicenseClasses on Licenses.LicenseClassId=LicenseClasses.Id 
                           inner join Drivers on Drivers.Id=Licenses.DriverId where DriverId=@driverId";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@driverId", driverId);
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            dt.Load(Reader);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return dt;
        }

    }
}
