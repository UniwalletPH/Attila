using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Events.Queries
{
    public class GetAllCancelledEventsQuery : IRequest<List<EventVM>>
    {
        public class GetAllCancelledEventsQueryHandler : IRequestHandler<GetAllCancelledEventsQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllCancelledEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<EventVM>> Handle(GetAllCancelledEventsQuery request, CancellationToken cancellationToken)
            {
                var _events = dbContext.Events
                    .Include(a => a.Client)
                    .Include(a => a.Coordinator)
                    .Where(a => a.EventStatus == Status.Cancelled).ToList();

                var _listOfProcessingEvents = new List<EventVM>();

                foreach (var item in _events)
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
                        Coordinator = item.Coordinator,
                        Client = item.Client,
                        EventStatus = item.EventStatus,
                        Remarks = item.Remarks
                    };

                    _listOfProcessingEvents.Add(Event);
                }

                return _listOfProcessingEvents;
            }
        }
    }
}