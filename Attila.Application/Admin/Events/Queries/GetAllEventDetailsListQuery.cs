using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Events.Queries
{
    public class GetAllEventDetailsListQuery : IRequest<List<EventVM>>
    {
       
        public class ViewAllEventDetailsListQueryHandler : IRequestHandler<GetAllEventDetailsListQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewAllEventDetailsListQueryHandler(IAttilaDbContext dbContext)
            {

                this.dbContext = dbContext;
            }

            public async Task<List<EventVM>> Handle(GetAllEventDetailsListQuery request, CancellationToken cancellationToken)
            {
                
                var _listIncomingEvents = new List<EventVM>();

                var _incomingEvents = dbContext.Events
                    .Include(a => a.EventPackage)
                    .Include(a => a.Client)
                    .Include(a => a.Coordinator).ToList();

                foreach (var item in _incomingEvents)
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

                    _listIncomingEvents.Add(Event);
                }
                return _listIncomingEvents;
            }
        }
    }
}
