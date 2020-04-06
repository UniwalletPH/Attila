using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventAdditionalDishRequest : BaseAuditedEntity
    {
        [ForeignKey("Event")]
        public int EventID { get; set; }

        public int Quantity { get; set; }

        public Status Status { get; set; }


        public Event Event { get; set; }

    }
}
