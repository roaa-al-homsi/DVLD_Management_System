using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class LicenseClassData
    {
        public static int Add(string Name, string Description, byte MinimumAllowedAge, byte DefaultValidityLength, decimal Fees)
        {
            int newId = 0;
            string query = "insert into LicenseClasses (Name,Description,MinimumAllowedAge,DefaultValidityLength,Fees) values (@Name,@Description,@MinimumAllowedAge,@DefaultValidityLength,@Fees) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@Fees", Fees);

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
        public static bool Update(int Id, string Name, string Description, byte MinimumAllowedAge, byte DefaultValidityLength, decimal Fees)
        {
            int RowsAffected = 0;
            string query = "update LicenseClasses set Name = @Name,Description = @Description,MinimumAllowedAge = @MinimumAllowedAge,DefaultValidityLength = @DefaultValidityLength,Fees = @Fees  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@Fees", Fees);

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
        public static bool Get(int Id, ref string Name, ref string Description, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal Fees)
        {
            bool IsFound = false;
            string query = "select * from LicenseClasses  WHERE Id=@Id;";
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
                            Name = (string)reader["Name"];
                            Description = (string)reader["Description"];
                            MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                            DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                            Fees = (decimal)reader["Fees"];


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
            return GenericData.All("select * from LicenseClasses");
        }
        static public DataTable AllNames()
        {
            return GenericData.All("select  Name  from LicenseClasses");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete LicenseClasses where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from LicenseClasses where Id= @Id", "@Id", Id);
        }
        static public string GetNameById(int Id)
        {
            return GenericData.GetNameById("select Name from LicenseClasses where Id=@Id", "@Id", Id);
        }
        static public int GetIdByName(string name)
        {
            return GenericData.GetIdByName("select Id from LicenseClasses where Name=@name", "@name", name);
        }
    }
}
