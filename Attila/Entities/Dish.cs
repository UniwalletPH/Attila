using Attila.Domain.Entities.Base;
using System.Collections.Generic;

namespace Attila.Domain.Entities
{
    public class Dish : BaseAuditedEntity
    {
        public int DishCategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DishCategory DishCategory { get; set; }

        public ICollection<EventMenus> EventMenus { get; set; }

      
    }
}
