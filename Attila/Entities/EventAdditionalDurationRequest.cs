using System;

namespace Attila.Domain.Entities
{
    public class EventAdditionalDurationRequest
    {
        public int ID { get; set; }

        public TimeSpan Duration { get; set; }   

        public int EventDetailsID { get; set; }

        public Event EventDetails { get; set; }

    }
}
