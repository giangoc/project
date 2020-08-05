using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeManagement.Common
{
    public class ExcuteSQL
    {
        public Params commonParam = new Params();
        public int ExcuteNonQuery(string query, Dictionary<string, object> param)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = commonParam.connectionString;
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

        public void ExecuteScalar(string query, Dictionary<string, object> param = null)
        {



            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = commonParam.connectionString;
            connection.Open();
            MySqlCommand command = new MySqlCommand();

            command.Connection = connection;
            command.CommandText = query;
            if (param != null) 
            {
                for (int i = 0; i < param.Count; i++)
                {
                    command.Parameters.AddWithValue(param.Keys.ElementAt(i), param[param.Keys.ElementAt(i)]);
                }
            }
            MySqlDataReader myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                int idProject = Convert.ToInt32(myReader["Id"]);
                string name = Convert.ToString(myReader["Code"]);
            }
            //object result = command.ExecuteScalar();
            connection.Close();
        }

        public object ExecuteScalar(string query) 
        {
            MySqlConnection connection = new MySqlConnection();
            MySqlDataReader myReader;
            connection.ConnectionString = commonParam.connectionString;
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                int idProject = Convert.ToInt32(myReader["Id"]);
                string name = Convert.ToString(myReader["Code"]);
            }
            connection.Close();
            return myReader;
        }
    }
}