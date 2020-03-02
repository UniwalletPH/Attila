using Attila.Application.Admin.Event.Queries;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class EventViewVM
    {
        public List<EventVM> PendingEvent { get; set; }

        public List<EventVM> IncomingEvent { get; set; }

        public List<EventVM> PastEvent { get; set; }
    }
}
