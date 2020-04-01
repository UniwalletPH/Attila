using Attila.Domain.Entities.Base;
using System;

namespace Attila.Domain.Entities
{
    public class EventAdditionalDurationRequest : BaseAuditedEntity
    {

        public TimeSpan Duration { get; set; }   

        public int EventDetailsID { get; set; }

        public Event EventDetails { get; set; }

    }
}
