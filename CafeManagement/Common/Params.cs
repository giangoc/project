using System.Configuration;

namespace CafeManagement.Common
{
    public class Params
    {
        public string connect = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public int success = 0;
        public int fail = 1;
        public int exception = -1;
    }
}