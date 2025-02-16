using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class DetainedLicenseData
    {
        public static int Add(int LicenseId, DateTime DetainDate, decimal FineFees, int CreatedByUserId, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserId, int ReleaseApplicationId)
        {
            int newId = 0;
            string query = "insert into DetainedLicenses (LicenseId,DetainDate,FineFees,CreatedByUserId,IsReleased,ReleaseDate,ReleasedByUserId,ReleaseApplicationId) values (@LicenseId,@DetainDate,@FineFees,@CreatedByUserId,@IsReleased,@ReleaseDate,@ReleasedByUserId,@ReleaseApplicationId) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseId", LicenseId);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);
                    command.Parameters.AddWithValue("@ReleaseDate", (ReleaseDate == DateTime.MinValue) ? DBNull.Value : (object)ReleaseDate);
                    command.Parameters.AddWithValue("@ReleasedByUserId", (ReleasedByUserId == -1) ? DBNull.Value : (object)ReleasedByUserId);
                    command.Parameters.AddWithValue("@ReleaseApplicationId", (ReleaseApplicationId == -1) ? DBNull.Value : (object)ReleaseApplicationId);

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
        public static bool Update(int Id, int LicenseId, DateTime DetainDate, decimal FineFees, int CreatedByUserId, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserId, int ReleaseApplicationId)
        {
            int RowsAffected = 0;
            string query = "update DetainedLicenses set LicenseId = @LicenseId,DetainDate = @DetainDate,FineFees = @FineFees,CreatedByUserId = @CreatedByUserId,IsReleased = @IsReleased,ReleaseDate = @ReleaseDate,ReleasedByUserId = @ReleasedByUserId,ReleaseApplicationId = @ReleaseApplicationId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@LicenseId", LicenseId);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);
                    command.Parameters.AddWithValue("@ReleasedByUserId", (ReleasedByUserId == -1) ? DBNull.Value : (object)ReleasedByUserId);
                    command.Parameters.AddWithValue("@ReleaseApplicationId", (ReleaseApplicationId == -1) ? DBNull.Value : (object)ReleaseApplicationId);

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
        public static bool Get(int Id, ref int LicenseId, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserId, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserId, ref int ReleaseApplicationId)
        {
            bool IsFound = false;
            string query = "select * from DetainedLicenses  WHERE Id=@Id;";
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
                            LicenseId = (int)reader["LicenseId"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            FineFees = (decimal)reader["FineFees"];
                            CreatedByUserId = (int)reader["CreatedByUserId"];
                            IsReleased = (bool)reader["IsReleased"];

                            ReleasedByUserId = reader["ReleasedByUserId"] != DBNull.Value ? (int)reader["ReleasedByUserId"] : -1;
                            ReleaseApplicationId = reader["ReleaseApplicationId"] != DBNull.Value ? (int)reader["ReleaseApplicationId"] : -1;


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
        public static bool GetByLicenseId(int LicenseId, ref int Id, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserId, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserId, ref int ReleaseApplicationId)
        {
            bool IsFound = false;
            string query = "select * from DetainedLicenses  WHERE LicenseId=@LicenseId;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseId", LicenseId);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            Id = (int)reader["Id"];
                            LicenseId = (int)reader["LicenseId"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            FineFees = (decimal)reader["FineFees"];
                            CreatedByUserId = (int)reader["CreatedByUserId"];
                            IsReleased = (bool)reader["IsReleased"];
                            ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime)reader["ReleaseDate"] : DateTime.MinValue;
                            ReleasedByUserId = reader["ReleasedByUserId"] != DBNull.Value ? (int)reader["ReleasedByUserId"] : -1;
                            ReleaseApplicationId = reader["ReleaseApplicationId"] != DBNull.Value ? (int)reader["ReleaseApplicationId"] : -1;
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
            string query = @"  SELECT DetainedLicenses.Id [D.Id], DetainedLicenses.LicenseId [L.Id], DetainedLicenses.ReleaseApplicationId [R.App.Id], DetainedLicenses.DetainDate [Detain Date], DetainedLicenses.FineFees [Fine Fees], DetainedLicenses.IsReleased [Is Release], DetainedLicenses.ReleaseDate [Release Date], People.NationalNo [Na No], 
                     (People.FirstName +''+ People.SecondName+ISNULL(People.ThirdName,'' ) + ' '+ People.LastName) as [Full Name] 
                 FROM     DetainedLicenses INNER JOIN
                 
                  Licenses ON DetainedLicenses.LicenseId = Licenses.Id INNER JOIN
				   Drivers ON Licenses.DriverId = Drivers.Id INNER JOIN
                  People ON Drivers.PersonId = People.Id";
            return GenericData.All(query);
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete DetainedLicenses where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from DetainedLicenses where Id= @Id", "@Id", Id);
        }
        //Release Detained Licenses
        static public bool ReleaseDetainedLicense(int Id, int ReleasedByUserId, int ReleaseApplicationId)
        {
            int RowsAffected = 0;
            string query = "update DetainedLicenses set IsReleased = 1,ReleaseDate = @ReleaseDate,ReleasedByUserId = @ReleasedByUserId,ReleaseApplicationId = @ReleaseApplicationId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                    command.Parameters.AddWithValue("@ReleasedByUserId", ReleasedByUserId);
                    command.Parameters.AddWithValue("@ReleaseApplicationId", ReleaseApplicationId);
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
        static public bool IsLicenseDetained(int licenseId)
        {
            return GenericData.Exist("select IsDetained=1 from DetainedLicenses where LicenseId= @licenseId and IsReleased=0", "@licenseId", licenseId);
        }


    }
}
