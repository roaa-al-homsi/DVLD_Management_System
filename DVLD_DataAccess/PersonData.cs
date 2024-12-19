using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class PersonData
    {
        public static int Add(string NationalNo, string FullName, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email, int NationalityCountryId, string ImagePath)
        {
            int newId = 0;
            string query = "insert into People (NationalNo,FullName,DateOfBirth,Gender,Address,Phone,Email,NationalityCountryImagePath) values (@NationalNo,@FullName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryId,@ImagePath) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FullName", FullName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryId", NationalityCountryId);
                    command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrWhiteSpace(ImagePath) ? ImagePath : (object)DBNull.Value);

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
        public static bool Update(int Id, string NationalNo, string FullName, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email, int NationalityCountryId, string ImagePath)
        {
            int RowsAffected = 0;
            string query = "update People set Id = @Id,NationalNo = @NationalNo,FullName = @FullName,DateOfBirth = @DateOfBirth,Gender = @Gender,Address = @Address,Phone = @Phone,Email = @Email,NationalityCountryId = @NationalityCountryId,ImagePath = @ImagePath  WHERE Id=@Id;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FullName", FullName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryId", NationalityCountryId);
                    command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrWhiteSpace(ImagePath) ? ImagePath : (object)DBNull.Value);

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
        public static bool Get(int Id, ref string NationalNo, ref string FullName, ref DateTime DateOfBirth, ref string Gender, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryId, ref string ImagePath)
        {
            bool IsFound = false;
            string query = "select * from People  WHERE Id=@Id;";
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
                            NationalNo = (string)reader["NationalNo"];
                            FullName = (string)reader["FullName"];
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Gender = (string)reader["Gender"];
                            Address = (string)reader["Address"];
                            Phone = (string)reader["Phone"];
                            Email = (string)reader["Email"];
                            NationalityCountryId = (int)reader["NationalityCountryId"];
                            ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : string.Empty;


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
            return GenericData.All("select * from People");
        }
        static public bool Delete(int Id)
        {
            return GenericData.Delete("delete People where Id = @Id", "@Id", Id);
        }
        static public bool Exist(int Id)
        {
            return GenericData.Exist("select Found=1 from People where Id= @Id", "@Id", Id);
        }



    }
}
