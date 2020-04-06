using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class EventDishRequestVM
    {
        public int AdditionalDishID { get; set; }
        public int DishID { get; set; }


        public EventAdditionalDishRequest EventAdditionalDishRequest { get; set; }
        public Dish Dish { get; set; }
    }
}
