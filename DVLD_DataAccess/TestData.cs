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
            string query = "insert into Tests (TestAppointmentResult,Notes,CreatedByUserId) values (@TestAppointmentId,@Result,@Notes,@CreatedByUserId) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestAppointmentId", TestAppointmentId);
                    command.Parameters.AddWithValue("@Result", Result);
                    command.Parameters.AddWithValue("@Notes", Notes);
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
                    command.Parameters.AddWithValue("@Notes", Notes);
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
                            Notes = (string)reader["Notes"];
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

    }
}
