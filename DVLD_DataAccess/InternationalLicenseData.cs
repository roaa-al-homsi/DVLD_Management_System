using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class InternationalLicenseData
    {
        public static int Add(int ApplicationId, int DriverId, int IssuedUsingLocalLicenseId, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreateByUserId)
        {
            int newId = 0;
            string query = "insert into InternationalLicenses (ApplicationId,DriverId,IssuedUsingLocalLicenseId,IssueDate,ExpirationDate,IsActive,CreateByUserId) values (@ApplicationId,@DriverId,@IssuedUsingLocalLicenseId,@IssueDate,@ExpirationDate,@IsActive,@CreateByUserId) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                    command.Parameters.AddWithValue("@DriverId", DriverId);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseId", IssuedUsingLocalLicenseId);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreateByUserId", CreateByUserId);

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
        public static bool Update(int Id, int ApplicationId, int DriverId, int IssuedUsingLocalLicenseId, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreateByUserId)
        {
            int RowsAffected = 0;
            string query = "update InternationalLicenses set ApplicationId = @ApplicationId,DriverId = @DriverId,IssuedUsingLocalLicenseId = @IssuedUsingLocalLicenseId,IssueDate = @IssueDate,ExpirationDate = @ExpirationDate,IsActive = @IsActive,CreateByUserId = @CreateByUserId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                    command.Parameters.AddWithValue("@DriverId", DriverId);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseId", IssuedUsingLocalLicenseId);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreateByUserId", CreateByUserId);

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
        public static bool Get(int Id, ref int ApplicationId, ref int DriverId, ref int IssuedUsingLocalLicenseId, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreateByUserId)
        {
            bool IsFound = false;
            string query = "select * from InternationalLicenses  WHERE Id=@Id;";
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
                            IssuedUsingLocalLicenseId = (int)reader["IssuedUsingLocalLicenseId"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpirationDate = (DateTime)reader["ExpirationDate"];
                            IsActive = (bool)reader["IsActive"];
                            CreateByUserId = (int)reader["CreateByUserId"];


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
            return GenericData.All("select * from InternationalLicenses");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete InternationalLicenses where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from InternationalLicenses where Id= @Id", "@Id", Id);
        }
        static public int GetActiveInternationalLicenseIDByDriverID(int driverId)
        {
            return GenericData.GetSpecificIdById("select Id from InternationalLicenses where DriverId=@driverId", "driverId", driverId);
        }
        static public DataTable AllInternationalLicensesByDriverId(int driverId)
        {
            DataTable dt = new DataTable();
            string query = @"select * from InternationalLicenses where DriverId=@driverId";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("driverId", driverId);
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
