using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Event.Queries
{
    public class AdditionalDurationRequestListVM
    {
        public int ID { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Rate { get; set; }

        public int EventDetailsID { get; set; }
    }
}
