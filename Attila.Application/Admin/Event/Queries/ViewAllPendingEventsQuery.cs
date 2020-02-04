using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    // TODO: dont use .Equals to compare object, use == instead
                    // TODO: EventStatus is an Enum, compare it with  enum values also
                    .Where(a => a.EventStatus.Equals(0)) ;

                return _pendingEvents.ToList();
            }
        }

    }
}
