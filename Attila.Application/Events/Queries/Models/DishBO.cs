using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Events.Queries.Models
{
    public class DishBO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
    }
}
