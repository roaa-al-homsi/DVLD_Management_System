using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    static public class DriverData
    {
        public static int Add(int PersonId, int CreatedByUserId, DateTime CreatedDate)
        {
            int newId = 0;
            string query = "insert into Drivers (PersonId,CreatedByUserId,CreatedDate) values (@PersonId,@CreatedByUserId,@CreatedDate) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

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
        public static bool Update(int Id, int PersonId, int CreatedByUserId)
        {
            int RowsAffected = 0;
            string query = "update Drivers set PersonId = @PersonId,CreatedByUserId = @CreatedByUserId  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@PersonId", PersonId);
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
        public static bool Get(int Id, ref int PersonId, ref int CreatedByUserId, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            string query = "select * from Drivers  WHERE Id=@Id;";
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
                            CreatedByUserId = (int)reader["CreatedByUserId"];
                            CreatedDate = (DateTime)reader["CreatedDate"];


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
        public static bool GetByPersonId(int PersonId, ref int Id, ref int CreatedByUserId, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            string query = "select * from Drivers  WHERE PersonId=@PersonId;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            Id = (int)reader["Id"];
                            PersonId = (int)reader["PersonId"];
                            CreatedByUserId = (int)reader["CreatedByUserId"];
                            CreatedDate = (DateTime)reader["CreatedDate"];


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
            return GenericData.All("select * from Driver_Info_View");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete Drivers where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from Drivers where Id= @Id", "@Id", Id);
        }

    }
}
