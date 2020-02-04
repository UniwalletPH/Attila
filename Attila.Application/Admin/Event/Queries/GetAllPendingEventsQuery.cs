using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetAllPendingEventsQuery : IRequest<List<EventDetails>>
    {
        public class ViewAllPendingEventsQueryHandler : IRequestHandler<GetAllPendingEventsQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewAllPendingEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventDetails>> Handle(GetAllPendingEventsQuery request, CancellationToken cancellationToken)
            {
                var _pendingEvents = dbContext.EventsDetails
                    .Where(a => a.EventStatus == Status.Pending);

                return _pendingEvents.ToList();
            }
        }

    }
}
