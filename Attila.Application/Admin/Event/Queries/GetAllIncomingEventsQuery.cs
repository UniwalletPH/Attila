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
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetAllIncomingEventsQuery : IRequest<List<EventVM>>
    {
        public class GetAllIncomingEventsQueryHandler : IRequestHandler<GetAllIncomingEventsQuery, List<EventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllIncomingEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventVM>> Handle(GetAllIncomingEventsQuery request, CancellationToken cancellationToken)
            {
                var _listIncomingEvents = new List<EventVM>();

                var _incomingEvents = dbContext.EventDetails
                    .Include(a => a.PackageDetails)
                    .Include(a => a.EventClient)
                    .Include(a => a.User)
                    .Where(a => a.EventStatus == Status.Approved && a.EventDate > DateTime.Now).ToList();

                foreach (var item in _incomingEvents)
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
                        Package = item.PackageDetails,
                        Coordinator = item.User,
                        Client = item.EventClient,
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
