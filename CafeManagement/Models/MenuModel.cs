namespace CafeManagement.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Mark { get; set; }
        public int IsFood { get; set; }
        public int IsActive { get; set; }
    }
}