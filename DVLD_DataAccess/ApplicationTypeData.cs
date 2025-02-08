using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class ApplicationTypeData
    {

        public static bool Update(int Id, string Title, decimal Fees)
        {
            int RowsAffected = 0;
            string query = "update ApplicationTypes set Id = @Id,Title = @Title,Fees = @Fees  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Title", Title);
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
        public static bool Get(int Id, ref string Title, ref decimal Fees)
        {
            bool IsFound = false;
            string query = "select * from ApplicationTypes  WHERE Id=@Id;";
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
                            Title = (string)reader["Title"];
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
            return GenericData.All("select * from ApplicationTypes");
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from ApplicationTypes where Id= @Id", "@Id", Id);
        }
        static public decimal GetFeesForSpecificApplication(byte Id)
        {
            decimal fees = 0;
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("select Fees from ApplicationTypes where Id=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        fees = (decimal)result;
                    }
                    catch (Exception ex) { }
                }
            }
            return fees;
        }


    }
}
