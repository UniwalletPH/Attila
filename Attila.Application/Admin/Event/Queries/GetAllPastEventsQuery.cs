using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetAllPastEventsQuery : IRequest<List<EventVM>>
    {
        public class GetAllPastEventsQueryHandler : IRequestHandler<GetAllPastEventsQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllPastEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventVM>> Handle(GetAllPastEventsQuery request, CancellationToken cancellationToken)
            {
                var _listPastEvents = new List<EventVM>();

                var _pastEvents = dbContext.EventsDetails
                    .Include(a => a.EventPackageDetails)
                    .Include(a => a.EventClient)
                    .Include(a => a.User)
                    .Where(a => a.EventDate < DateTime.Now);

                foreach (var item in _pastEvents)
                {
                    var Event = new EventVM
                    {
                        ID = item.ID,
                        Code = item.Code,
                        EventName = item.EventName,
                        Location = item.Location,
                        BookingDate = item.BookingDate,
                        EventDate = item.EventDate,
                        Description = item.Description,
                        Type = item.Type,
                        Package = item.EventPackageDetails,
                        Coordinator = item.User,
                        Client = item.EventClient,
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
