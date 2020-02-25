using CafeManagement.Common;
using CafeManagement.Models;
using System;
using System.Data.SqlClient;
using System.Text;

namespace CafeManagement.Dao
{  
    public class MenuManagementDao
    {
        Params param = new Params();
        public int Add(MenuModel model)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO `ms_menu` (");
            query.Append("  `Name`,");
            query.Append("  `Price`,");
            query.Append("  `Mark`,");
            query.Append("  `IsFood`,");
            query.Append("  `IsActive`");
            query.Append(")");
            query.Append("VALUES");
            query.Append("  (");
            query.Append("    @Name,");
            query.Append("    @Price,");
            query.Append("    @Mark,");
            query.Append("    @IsFood,");
            query.Append("    @IsActive");
            query.Append("  )");

            using (SqlConnection connection = new SqlConnection(param.connect))
            using (SqlTransaction transaction = connection.BeginTransaction())
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                connection.Open();                
                try {
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Price", model.Price);
                    command.Parameters.AddWithValue("@Mark", model.Mark);
                    command.Parameters.AddWithValue("@IsFood", model.IsFood == true ? 1 : 0);
                    command.Parameters.AddWithValue("@Name", model.Name);

                }
                catch (Exception) 
                {
                    transaction.Rollback();
                    return param.expCode;
                }
                finally 
                {
                    connection.Close();
                }
                              
            }           
                return param.successCode;
        }
    }
}