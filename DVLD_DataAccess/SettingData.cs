using System.Configuration;

namespace DVLD_DataAccess
{
    public static class SettingData
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }


}
