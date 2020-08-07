using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeManagement.Common
{
    public class ExcuteSQL
    {
        public Params commonParam = new Params();
        CommonModel model;
        List<CommonModel> listModel;
        public int ExcuteNonQuery(string query, Dictionary<string, object> param)
        {
            MySqlConnection connection = new MySqlConnection 
            {
                ConnectionString = commonParam.connectionString
            };
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

        public object ExecuteScalar(string query, Dictionary<string, object> param = null)
        {
            MySqlConnection connection = new MySqlConnection
            {
                ConnectionString = commonParam.connectionString
            };
            connection.Open();
            MySqlCommand command = new MySqlCommand
            {
                Connection = connection,
                CommandText = query
            };

            if (param != null)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    command.Parameters.AddWithValue(param.Keys.ElementAt(i), param[param.Keys.ElementAt(i)]);
                }
            }           
            object result = command.ExecuteScalar();
            connection.Close();
            return result;
        }

        public List<CommonModel> ExecuteReader(string query, Dictionary<string, object> param = null) 
        {
            model = new CommonModel();
            listModel = new List<CommonModel>();
            MySqlConnection connection = new MySqlConnection 
            {
                ConnectionString = commonParam.connectionString
            };
            connection.Open();
            MySqlCommand command = new MySqlCommand 
            {
                Connection = connection,
                CommandText = query
            };
            MySqlDataReader myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                for (int i = 0; i < myReader.FieldCount; i++)
                {
                    model.Add(myReader.GetName(i), myReader.GetValue(i));
                }
                listModel.Add(model);
                model = new CommonModel();
            }
            connection.Close();
            return listModel;
        }
    }
}