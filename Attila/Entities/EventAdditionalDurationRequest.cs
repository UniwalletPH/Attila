using Attila.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class EventAdditionalDurationRequest : BaseAuditedEntity
    {
        [ForeignKey("Event")]
        public int EventID { get; set; }

        public TimeSpan Duration { get; set; }   
        public Status Status { get; set; }


        public Event Event { get; set; }
    }
}
