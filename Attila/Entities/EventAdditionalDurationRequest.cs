using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    public class EventAdditionalDurationRequest
    {
        public int ID { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Rate { get; set; }

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }

    }
}
