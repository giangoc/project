using System.Configuration;
using System.Data.SqlClient;

namespace CafeManagement.Common
{
    public class SqlConnect
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public void ConnectionOpen()
        {
            connect.Open();
        }

        public void ConnectionClose()
        {
            connect.Close();
        }
    }
}