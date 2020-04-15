using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class DishVM
    {
        public int ID { get; set; }      
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
