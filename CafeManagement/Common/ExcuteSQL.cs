using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CafeManagement.Common
{
    public class ExcuteSQL
    {
        public Params commonParam = new Params();
        public int ExcuteNonQuery(string query, Dictionary<string, object> param)
        {
            SqlConnection connection = new SqlConnection(commonParam.connect);
            connection.Open();
            SqlCommand command = new SqlCommand("", connection);
            SqlTransaction trans = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = trans;
            try
            {

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