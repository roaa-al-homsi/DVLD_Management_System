using System.Text.RegularExpressions;

namespace DVLD_Business
{
    public static class Validation
    {
        public static bool ValidateEmail(string email)
        {
            var pattern = "";
            var regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public static bool ValidateInteger(string number)
        {
            return true;
        }
        public static bool ValidateFloat(string number)
        {
            return true;
        }
        public static bool IsNumber(string number)
        {
            return true;
        }


    }
}
