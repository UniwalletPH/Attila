using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetAllPendingEventsQuery : IRequest<List<EventVM>>
    {
        public class ViewAllPendingEventsQueryHandler : IRequestHandler<GetAllPendingEventsQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewAllPendingEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventVM>> Handle(GetAllPendingEventsQuery request, CancellationToken cancellationToken)
            {

                var _listOfPendingEvents = new List<EventVM>();

                var _pendingEvents = dbContext.EventsDetails
                    .Include(a => a.EventPackageDetails)
                    .Include(a => a.User)
                    .Include(a => a.EventClient)
                    .Where(a => a.EventStatus == Status.Pending);

                foreach (var item in _pendingEvents)
                {
                    var Event = new EventVM
                    { 
                    ID = item.ID,
                    Code = item.Code,
                    EventName = item.EventName,
                    Address = item.Address,
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

                    _listOfPendingEvents.Add(Event);
                }

                return _listOfPendingEvents;
               

            }
        }

    }
}
