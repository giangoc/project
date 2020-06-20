using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CafeManagement.Common
{
    public class ExcuteSQL
    {
        public Params commonParam = new Params();
        public int ExcuteNonQuery(string query, Dictionary<string,string> param)
        {
            using (SqlConnection connection = new SqlConnection(commonParam.connect))
            using (SqlCommand command = new SqlCommand("", connection))
            using (SqlTransaction trans = connection.BeginTransaction())
            {
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
            }
        }
    }
}