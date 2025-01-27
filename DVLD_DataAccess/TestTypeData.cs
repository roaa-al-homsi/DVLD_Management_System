using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class TestTypeData
    {

        public static int Add(string Name, string Description, decimal Fees)
        {
            int newId = 0;
            string query = "insert into TestTypes (Name,Description,Fees) values (@Name,@Description,@Fees) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
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
        public static bool Update(int Id, string Name, string Description, decimal Fees)
        {
            int RowsAffected = 0;
            string query = "update TestTypes set Id = @Id,Name = @Name,Description = @Description,Fees = @Fees  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
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
        public static bool Get(int Id, ref string Name, ref string Description, ref decimal Fees)
        {
            bool IsFound = false;
            string query = "select * from TestTypes  WHERE Id=@Id;";
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
            return GenericData.All("select * from TestTypes");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete TestTypes where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from TestTypes where Id= @Id", "@Id", Id);
        }
        static public decimal GetFeesForSpecificTest(int Id)
        {
            decimal fees = 0;
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("select Fees from TestTypes where Id=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    try
                    {
                        connection.Open();
                        fees = (decimal)command.ExecuteScalar();
                    }
                    catch (Exception ex) { }
                }
            }
            return fees;
        }

    }
}
