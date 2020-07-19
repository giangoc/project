using CafeManagement.Dao;
using System;

namespace CafeManagement.Logic
{
    public class MenuLogic
    {
        readonly MenuDao dao = new MenuDao();

        public string CreateCode(string isFood)
        {
            string code = isFood == "0" ? "F" : "D";
            string result = dao.GetCode(code);
            if (string.IsNullOrEmpty(result))
                code += "001";
            else
                code += (Convert.ToInt32(result.Substring(1, 3)) + 1).ToString("000");
            return code;
        }
    }
}