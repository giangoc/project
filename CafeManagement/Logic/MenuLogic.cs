using CafeManagement.Dao;
using System;

namespace CafeManagement.Logic
{
    public class MenuLogic
    {
        readonly MenuDao dao = new MenuDao();

        public string CreateCode(string isFood)
        {
            string result = string.Empty;
            string code = isFood == "0" ? "F" : "D";
            result = dao.GetCode(code);
            if (String.IsNullOrEmpty(result))
                code += "001";
            else
                code += (Convert.ToInt32(result.Substring(1, 3)) + 1).ToString("000");
            return code;
        }
    }
}