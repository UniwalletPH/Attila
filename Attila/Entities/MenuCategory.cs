namespace Attila.Domain.Entities
{
    public class MenuCategory
    {
        public int ID { get; set; }

        public int PackageDetailsID { get; set; }

        public string Category { get; set; }

        public PackageMenuDetails PackageDetails { get; set; }

       
    }
}
