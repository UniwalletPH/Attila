using Attila.Application.Admin.Events.Queries;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class EventViewCVM
    {
        public List<EventVM> ProcessingEvent { get; set; }

        public List<EventVM> PendingEvent { get; set; }

        public List<EventVM> IncomingEvent { get; set; }

        public List<EventVM> CompletedEvent { get; set; }

        public List<EventVM> ClosedEvent { get; set; }

        public IEnumerable<EventVM> Events{get;set;}
    }
}
