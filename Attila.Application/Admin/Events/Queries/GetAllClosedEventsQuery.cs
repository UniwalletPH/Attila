using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Attila.Application.Admin.Events.Queries
{
    public class GetAllClosedEventsQuery : IRequest<List<EventVM>>
    {
        public class GetAllPastEventsQueryHandler : IRequestHandler<GetAllClosedEventsQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllPastEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventVM>> Handle(GetAllClosedEventsQuery request, CancellationToken cancellationToken)
            {
                var _listPastEvents = new List<EventVM>();

                var _pastEvents = dbContext.Events
                    .Include(a => a.EventPackage)
                    .Include(a => a.Client)
                    .Include(a => a.Coordinator)
                    .Where(a => a.EventStatus == Status.Closed).ToList();

                foreach (var item in _pastEvents)
                {
                    var Event = new EventVM
                    {
                        ID = item.ID,
                        EventName = item.EventName,
                        Location = item.Location,
                        BookingDate = item.BookingDate,
                        EventDate = item.EventDate,
                        Description = item.Description,
                        Type = item.Type,
                        Package = item.EventPackage,
                        Coordinator = item.Coordinator,
                        Client = item.Client,
                        EventStatus = item.EventStatus,
                        Remarks = item.Remarks
                    };

                    _listPastEvents.Add(Event);
                }

                return _listPastEvents;
            }
        }
    }
}
