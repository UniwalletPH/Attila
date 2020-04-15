using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class AdditionalEquipmentRequestVM
    {
        public int RequestID { get; set; }

        public int EventID { get; set; }

        public Status Status { get; set; }

        public Event Event { get; set; }

    }
}
