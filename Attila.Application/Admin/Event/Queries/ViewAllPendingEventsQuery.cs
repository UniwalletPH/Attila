using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Event.Queries
{
    public class ViewAllPendingEventsQuery : IRequest<List<EventDetails>>
    {
        public class ViewAllPendingEventsQueryHandler : IRequestHandler<ViewAllPendingEventsQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewAllPendingEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventDetails>> Handle(ViewAllPendingEventsQuery request, CancellationToken cancellationToken)
            {
                var _pendingEvents = dbContext.EventsDetails
                    .Where(a => a.EventStatus == Status.Pending);

                return _pendingEvents.ToList();
            }
        }

    }
}
