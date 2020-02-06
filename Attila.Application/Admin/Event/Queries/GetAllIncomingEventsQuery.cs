using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetAllIncomingEventsQuery : IRequest<List<EventDetails>>
    {
        public class GetAllIncomingEventsQueryHandler : IRequestHandler<GetAllIncomingEventsQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllIncomingEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventDetails>> Handle(GetAllIncomingEventsQuery request, CancellationToken cancellationToken)
            {
                var _incomingEvents =  dbContext.EventsDetails
                    .Where(a => a.EventStatus == Status.Approved && a.EventDate > DateTime.Now);

                return _incomingEvents.ToList();
            }
        }
    }
}
