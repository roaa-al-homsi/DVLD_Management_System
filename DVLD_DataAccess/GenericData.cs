﻿using System;
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

    }
}
