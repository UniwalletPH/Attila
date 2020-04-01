using Attila.Domain.Entities.Base;

namespace Attila.Domain.Entities
{
    public class EventMenus : BaseAuditedEntity
    {
        public int DishID { get; set;}

        public int EventDetailsID { get; set; }

        public Event EventDetails { get; set; }
        
        public Dish Dish { get; set; }

    }
}
