using System.Configuration;

namespace CafeManagement.Common
{
    public class Params
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        public int success = 0;
        public int fail = 1;
        public int exception = -1;
    }
}