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
    public class GetAllCompletedEventsQuery : IRequest<List<EventVM>>
    {
        public class GetAllCompletedEventsQueryHandler : IRequestHandler<GetAllCompletedEventsQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllCompletedEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventVM>> Handle(GetAllCompletedEventsQuery request, CancellationToken cancellationToken)
            {
                var _listCompletedEvents = new List<EventVM>();

                var _completedEvents = dbContext.Events
                    .Include(a => a.EventPackage)
                    .Include(a => a.Client)
                    .Include(a => a.Coordinator)
                    .Where(a => a.EventStatus == Status.Completed || a.EventStatus == Status.Approved && a.EventDate < DateTime.Now).ToList();

                foreach (var item in _completedEvents)
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

                    _listCompletedEvents.Add(Event);
                }

                return _listCompletedEvents;
            }
        }
    }
}
