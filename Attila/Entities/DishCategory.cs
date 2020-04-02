using Attila.Domain.Entities.Base;
using System.Collections;
using System.Collections.Generic;

namespace Attila.Domain.Entities
{
    public class DishCategory : BaseAuditedEntity
    {
        public string Category { get; set; }


        public ICollection<Dish> Collection { get; private set; } = new HashSet<Dish>();

    }
}
