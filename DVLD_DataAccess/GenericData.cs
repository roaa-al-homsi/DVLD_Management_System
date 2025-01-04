using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class GenericData
    {
        static public DataTable All(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            dt.Load(Reader);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return dt;
        }
        static public bool Delete<T>(string query, string ParameterName, T DeleteBy)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ParameterName, DeleteBy);

                    try
                    {
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { return false; }
                }
            }

            return RowsAffected > 0;
        }
        static public bool Exist<T>(string query, string ParameterName, T ParameterValue)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ParameterName, ParameterValue);
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = command.ExecuteReader();
                        IsFound = Reader.HasRows;
                        Reader.Close();
                    }
                    catch (Exception ex) { }
                }
            }
            return IsFound;
        }
        static public int GetIdByName(string query, string ParameterName, string ParameterValue)
        {
            int Id = -1;
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ParameterName, ParameterValue);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            Id = insertedID;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return Id;
        }
        static public string GetNameById(string query, string ParameterName, int ParameterValue)
        {
            string name = string.Empty;
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ParameterName, ParameterValue);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            name = result.ToString();
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return name;
        }
        static public int GetSpecificIdById(string query, string ParameterName, int ParameterValue)
        {
            int Id = -1;
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ParameterName, ParameterValue);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            Id = insertedID;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return Id;
        }
    }
}
