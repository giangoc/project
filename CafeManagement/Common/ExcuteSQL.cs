using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CafeManagement.Common
{
    public class ExcuteSQL
    {
        public Params commonParam = new Params();
        public int ExcuteNonQuery(string query, Dictionary<string, object> param)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            connection.Open();
            MySqlCommand command = new MySqlCommand ();
            MySqlTransaction trans = connection.BeginTransaction();
            try
            {
                command.Connection = connection;
                command.Transaction = trans;
                command.CommandText = query;
                for (int i = 0; i < param.Count; i++)
                {
                    command.Parameters.AddWithValue(param.Keys.ElementAt(i), param[param.Keys.ElementAt(i)]);
                }
                command.ExecuteNonQuery();
                trans.Commit();
                return commonParam.success;
            }
            catch (Exception)
            {
                trans.Rollback();
                return commonParam.exception;
            }
            finally
            {
               connection.Close();
            }
        }
    }
}