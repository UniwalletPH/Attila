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
    public class GetAllAdminPendingEventsQuery : IRequest<List<EventVM>>
    {
        public class GetAllAdminPendingEventsQueryHandler : IRequestHandler<GetAllAdminPendingEventsQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetAllAdminPendingEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventVM>> Handle(GetAllAdminPendingEventsQuery request, CancellationToken cancellationToken)
            {

                var _listOfPendingEvents = new List<EventVM>();

                var _pendingEvents = dbContext.Events
                    .Include(a => a.EventPackage)
                    .Include(a => a.Coordinator)
                    .Include(a => a.Client)
                    .Where(a => a.EventStatus == Status.ForApproval).ToList();

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
                        Package = item.EventPackage,
                        Coordinator = item.Coordinator,
                        Client = item.Client,
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
