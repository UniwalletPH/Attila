namespace Attila.Domain.Entities
{
    public class Menu
    {
        public int ID { get; set; }

        public int MenuCategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MenuCategory MenuCategory { get; set; }
      
    }
}
