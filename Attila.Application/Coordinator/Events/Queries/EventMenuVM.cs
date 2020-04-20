using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class EventMenuVM
    {
        public int ID { get; set; }

        public int DishID { get; set; }

        public int EventDetailsID { get; set; }

        public Dish Dish { get; set; }
        public Event Event { get; set; }
    }
}
