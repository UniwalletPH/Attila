using Attila.Application.Admin.Event.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EventViewVM
    {
        public List<EventVM> PendingEvent { get; set; }

        public List<EventVM> IncomingEvent { get; set; }

        public List<EventVM> PastEvent { get; set; }
    }
}
