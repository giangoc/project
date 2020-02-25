using System.Configuration;

namespace CafeManagement.Common
{
    public class Params
    {
        public string connect = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public int successCode = 0;
        public int failCode = 1;
        public int expCode = -1;
    }
}