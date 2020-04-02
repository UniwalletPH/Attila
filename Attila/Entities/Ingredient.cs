using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class Ingredient : BaseAuditedEntity
    {
        [ForeignKey("Dish")]
        public int DishID { get; set; }
        [ForeignKey("Food")]
        public int FoodID { get; set; }

        public string Name { get; set; }

        public Dish Dish { get; set; }
        public Food Food { get; set; }

    }
}
