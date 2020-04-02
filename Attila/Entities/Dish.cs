using Attila.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class Dish : BaseAuditedEntity
    {
        [ForeignKey("DishCategory")]
        public int DishCategoryID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DishCategory DishCategory { get; set; }
        public ICollection<EventMenu> EventMenus { get; private set; } = new HashSet<EventMenu>();
        public ICollection<EventPackageDish> EventPackageDishes { get; private set; } = new HashSet<EventPackageDish>();
        public ICollection<Ingredient> Ingredients { get; private set; } = new HashSet<Ingredient>();
    }
}
