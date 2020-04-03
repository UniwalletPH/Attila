using Attila.Domain.Entities.Base;
using System.Collections.Generic;

namespace Attila.Domain.Entities
{
    public class Food : BaseAuditedEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public UnitType Unit { get; set; }
        public FoodType FoodType { get; set; }

        public ICollection<FoodInventory> FoodInventories { get; private set; } = new HashSet<FoodInventory>();
        public ICollection<Ingredient> Ingredients { get; private set; } = new HashSet<Ingredient>();

    }
}
