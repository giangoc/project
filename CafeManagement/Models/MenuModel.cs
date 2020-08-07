using System.Security.Policy;

namespace CafeManagement.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Mark { get; set; }
        public string IsFood { get; set; }
        public bool IsActiveBool { get; set; }
        public string PriceString { get; set; }
        public string IsActive { get; set; }
    }
}