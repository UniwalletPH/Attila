using Attila.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class EventMenu : BaseAuditedEntity
    {
        [ForeignKey("Dish")]
        public int DishID { get; set;}

        [ForeignKey("Event")]
        public int EventID { get; set; }


        public Event Event { get; set; }
        public Dish Dish { get; set; }
    }
}
