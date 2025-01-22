using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class UserData
    {
        public static int Add(int PersonId, string Username, string Password, bool IsActive)
        {
            int newId = 0;
            string query = "insert into Users (PersonId,Username,Password,IsActive) values (@PersonId,@Username,@Password,@IsActive) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

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
        public static bool Update(int Id, int PersonId, string Username, string Password, bool IsActive)
        {
            int RowsAffected = 0;
            string query = "update Users set Id = @Id,PersonId = @PersonId,Username = @Username,Password = @Password,IsActive = @IsActive  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

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
        public static bool Get(int Id, ref int PersonId, ref string Username, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            string query = "select * from Users  WHERE Id=@Id;";
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
                            Username = (string)reader["Username"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];


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
        public static bool GetByPersonId(int PersonId, ref int Id, ref string Username, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            string query = "select * from Users  WHERE PersonId=@PersonId;";
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
                            Username = (string)reader["Username"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];


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
        public static bool GetByUsernameAndPassword(string Username, string Password, ref int PersonId, ref int Id, ref bool IsActive)
        {
            bool IsFound = false;
            string query = "select * from Users  WHERE Username=@Username and Password=@Password;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Username", Username);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            Id = (int)reader["Id"];
                            PersonId = (int)reader["PersonId"];
                            Username = (string)reader["Username"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];


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
            return GenericData.All("select * from User_Info_view");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete Users where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from Users where Id= @Id", "@Id", Id);
        }
        static public bool ExistByPersonId(int personId)
        {
            return GenericData.Exist("select Found=1 from Users where personId= @personId", "@personId", personId);
        }
        static public bool ExistByUsername(string username)
        {
            return GenericData.Exist("select Found=1 from Users where Username= @username", "@username", username);
        }
        //method change password
        static public bool ChangePassword(int id, string newPassword)
        {
            int RowsAffected = 0;
            string query = "update Users set Password=@newPassword WHERE Id=@id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@newPassword", newPassword);

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
