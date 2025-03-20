using DVLD_Business;
using Microsoft.Win32;
using System;
using System.Windows;
namespace DVLD.Global_Classes
{
    internal class Global
    {
        public static User CurrentUser;
        public const string path = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        public const string UsernameDVLD = "Username";
        public const string PasswordDVLD = "Password";
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            #region Save them to file
            //try
            //{
            //    //this will get the current project directory folder.
            //    string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            //    // Define the path to the text file where you want to save the data
            //    string filePath = currentDirectory + "\\data.txt";

            //    //encase the username is empty, delete the file
            //    if (Username == "" && File.Exists(filePath))
            //    {
            //        File.Delete(filePath);
            //        return true;

            //    }

            //    // concatenate username and password with  separator.
            //    string dataToSave = Username + "#//#" + Password;

            //    // Create a StreamWriter to write to the file
            //    using (StreamWriter writer = new StreamWriter(filePath))
            //    {
            //        // Write the data to the file
            //        writer.WriteLine(dataToSave);

            //        return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An error occurred: {ex.Message}");
            //    return false;
            //} 
            #endregion

            #region Save them to Registry file.

            try
            {
                //write to Registry file.
                Registry.SetValue(path, UsernameDVLD, Username, RegistryValueKind.String);
                Registry.SetValue(path, PasswordDVLD, Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
            #endregion
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found from file.
            #region Get from file.
            //try
            //{
            //    //gets the current project's directory
            //    string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            //    // Path for the file that contains the credential.
            //    string filePath = currentDirectory + "\\data.txt";

            //    // Check if the file exists before attempting to read it
            //    if (File.Exists(filePath))
            //    {
            //        // Create a StreamReader to read from the file
            //        using (StreamReader reader = new StreamReader(filePath))
            //        {
            //            // Read data line by line until the end of the file
            //            string line;
            //            while ((line = reader.ReadLine()) != null)
            //            {
            //                Console.WriteLine(line); // Output each line of data to the console
            //                string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

            //                Username = result[0];
            //                Password = result[1];
            //            }
            //            return true;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An error occurred: {ex.Message}");
            //    return false;
            //}
            #endregion

            #region Get from Registry file.
            try
            {
                Username = Registry.GetValue(path, UsernameDVLD, null) as string;
                Password = Registry.GetValue(path, PasswordDVLD, null) as string;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
            #endregion

        }
    }
}
