using CafeManagement.Common;
using CafeManagement.Models;
using System.Collections.Generic;
using System.Text;

namespace CafeManagement.Dao
{
    public class MenuDao
    {
        ExcuteSQL excute = new ExcuteSQL();
        public int Add(MenuModel model)
        {
            Dictionary<string,object> param = new Dictionary<string, object>();
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO `menu` (");
            query.Append("  `Code`,");
            query.Append("  `Name`,");
            query.Append("  `Price`,");
            query.Append("  `Mark`,");
            query.Append("  `IsFood`,");
            query.Append("  `IsActive`");
            query.Append(")");
            query.Append("VALUES");
            query.Append("  (");
            query.Append("    @Code,");
            query.Append("    @Name,");
            query.Append("    @Price,");
            query.Append("    @Mark,");
            query.Append("    @IsFood,");
            query.Append("    @IsActive");
            query.Append("  )");

            param.Add("Code", model.Code);
            param.Add("Name", model.Name);
            param.Add("Price", model.Price);
            param.Add("Mark", model.Mark);
            param.Add("IsFood", model.IsFood);
            param.Add("IsActive", model.IsActiveString);

            return excute.ExcuteNonQuery(query.ToString(), param);
        }
    }
}