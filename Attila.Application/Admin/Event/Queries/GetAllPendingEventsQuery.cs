using Attila.Application.Interfaces;
using MediatR;
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

                var _pendingEvents = dbContext.EventDetails
                    .Include(a => a.PackageDetails)
                    .Include(a => a.User)
                    .Include(a => a.EventClient)
                    .Where(a => a.EventStatus == Status.ForApproval);

                foreach (var item in _pendingEvents)
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
                    Package = item.PackageDetails,
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
