using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class PersonData
    {
        public static int Add(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int newId = 0;
            string query = "insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,Address,Phone,Email,NationalityCountryID,ImagePath) values (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath) SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", !string.IsNullOrWhiteSpace(ThirdName) ? ThirdName : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", !string.IsNullOrWhiteSpace(Email) ? Email : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
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
        public static bool Update(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = 0;
            string query = "update People set NationalNo = @NationalNo,FirstName = @FirstName,SecondName = @SecondName,ThirdName = @ThirdName,LastName = @LastName,DateOfBirth = @DateOfBirth,Gender = @Gender,Address = @Address,Phone = @Phone,Email = @Email,NationalityCountryID = @NationalityCountryID,ImagePath = @ImagePath  WHERE Id=@PersonID;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", !string.IsNullOrWhiteSpace(ThirdName) ? ThirdName : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", !string.IsNullOrWhiteSpace(Email) ? Email : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
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
        public static bool Get(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            string query = "select * from People  WHERE Id=@PersonID;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonID = (int)reader["Id"];
                            NationalNo = (string)reader["NationalNo"];
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];
                            ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : string.Empty;
                            LastName = (string)reader["LastName"];
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Gender = (byte)reader["Gender"];
                            Address = (string)reader["Address"];
                            Phone = (string)reader["Phone"];
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty;
                            NationalityCountryID = (int)reader["NationalityCountryID"];
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
        public static bool Get(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            string query = "select * from People  WHERE NationalNo=@NationalNo;";
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonID = (int)reader["Id"];
                            NationalNo = (string)reader["NationalNo"];
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];
                            ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : string.Empty;
                            LastName = (string)reader["LastName"];
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Gender = (byte)reader["Gender"];
                            Address = (string)reader["Address"];
                            Phone = (string)reader["Phone"];
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty;
                            NationalityCountryID = (int)reader["NationalityCountryID"];
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
            return GenericData.All("select * from People_Info_view");
        }
        static public bool Delete(int personId)
        {
            return GenericData.Delete("delete People where Id = @personId", "@personId", personId);
        }
        static public bool Exist(int PersonID)
        {
            return GenericData.Exist("select Found=1 from People where Id= @PersonID", "@PersonID", PersonID);
        }
        static public bool ExistByNationalNo(string nationalNo)
        {
            return GenericData.Exist("select Found=1 from People where NationalNo= @nationalNo", "@nationalNo", nationalNo);

        }
        static public DataTable GetNamesCountries()
        {
            return GenericData.All("select * from Countries");
        }
        static public int GetIdCountryByName(string name)
        {
            return GenericData.GetIdByName("select Id from Countries where Name=@Name", "@Name", name);
        }
        static public string GetNameCountryById(int id)
        {
            return GenericData.GetNameById("select Name from Countries where Id=@Id", "@Id", id);
        }


    }
}
