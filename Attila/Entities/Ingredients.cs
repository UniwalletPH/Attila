using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class Ingredients : BaseAuditedEntity
    {
        public string Name { get; set; }

        public int DishID { get; set; }

        public int FoodID { get; set; }

        public Dish Dish { get; set; }

        public Food Food { get; set; }

    }
}
