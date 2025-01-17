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
            string query = "insert into LocalDrivingLicenseApplications (ApplicationLicenseClassesId) values (@ApplicationId,@LicenseClassesId) SELECT SCOPE_IDENTITY(); ";
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
            //Create view a tall query. 
            return GenericData.All("select * from LocalDrivingLicenseApplication_View");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete LocalDrivingLicenseApplications where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from LocalDrivingLicenseApplications where Id= @Id", "@Id", Id);
        }

        //Al of these in lesson 49
        //Does pass Test Type
        //Does Attend Test Type
        //Total Trials per test
        //IsThere An Active Schedule Test



    }
}
