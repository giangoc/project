using AutoMapper;
using CafeManagement.Common;
using CafeManagement.Models;
using System.Collections.Generic;
using System.Text;

namespace CafeManagement.Dao
{
    public class MenuDao
    {      
        Dictionary<string, object> param;
        StringBuilder query;
        readonly ExcuteSQL excute = new ExcuteSQL();
        readonly dynamic mapper = new MapperConfiguration(cfg => { }).CreateMapper();

        public int Add(MenuModel model)
        {
            param = new Dictionary<string, object>();
            query = new StringBuilder();

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
            param.Add("IsActive", model.IsActive);

            return excute.ExcuteNonQuery(query.ToString(), param);
        }

        public string GetCode(string code)
        {
            param = new Dictionary<string, object>();
            query = new StringBuilder();

            query.Append("SELECT MAX(`Code`) FROM `menu` ");
            query.Append("  WHERE SUBSTRING(`Code`,1,1) = @Code");

            param.Add("Code", code);

            return excute.ExecuteScalar(query.ToString(), param).ToString();
        }

        public List<MenuModel> GetMenu()
        {
            List<MenuModel> listMenu = new List<MenuModel>();
            param = new Dictionary<string, object>();
            query = new StringBuilder();
            
            query.Append("SELECT * FROM `menu` ORDER BY `Code` ");
            List<CommonModel> listCommonModel = excute.ExecuteReader(query.ToString());

            for (int i = 0; i < listCommonModel.Count; i++)
            {
                MenuModel modelMenu = mapper.Map<MenuModel>(listCommonModel[i].Values);
                listMenu.Add(modelMenu);
            }          
            return listMenu;
        }
    }
}