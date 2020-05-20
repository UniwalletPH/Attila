using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class GetEventDetailsQuery : IRequest<EventDetailsVM>
    {
        public int EventDetailsID { get; set; }
        public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsVM>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEventDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventDetailsVM> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
            {
                var _getEventDetails = dbContext.Events.Find(request.EventDetailsID);

                EventDetailsVM _eventDetailsVM = new EventDetailsVM
                {
                    EventName = _getEventDetails.EventName,
                    EventStatus = _getEventDetails.EventStatus
                };

                return _eventDetailsVM;
            }
        }
    }
}
