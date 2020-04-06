using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventDishRequest : BaseAuditedEntity
    {
        [ForeignKey("EventAdditionalDishRequest")]
        public int AdditionalDishID { get; set; }

        [ForeignKey("Dish")]
        public int DishID { get; set; }

        public EventAdditionalDishRequest EventAdditionalDishRequest { get; set; }
        public Dish Dish { get; set; }
    }
}
