using Attila.Application.Admin.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Queries
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

                var _incomingEvents = dbContext.EventDetails
                    .Include(a => a.PackageDetails)
                    .Include(a => a.EventClient)
                    .Include(a => a.User).ToList();

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
