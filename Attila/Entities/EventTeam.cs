using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventTeam
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int EventDetailsID { get; set; }
    }
}
