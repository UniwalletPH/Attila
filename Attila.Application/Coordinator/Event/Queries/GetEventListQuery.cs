using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetEventListQuery : IRequest<IEnumerable<SearchEventVM>>
    {

        public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, IEnumerable<SearchEventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEventListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<SearchEventVM>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
            {
                var _viewEventList = await dbContext.EventsDetails.Select(a => new SearchEventVM 
                {
                    ID = a.ID,
                    Code = a.Code,
                    EventName = a.EventName,
                    Type = a.Type,
                    EventStatus = a.EventStatus,
                    BookingDate = a.BookingDate,
                    EventDate = a.EventDate,
                    Description = a.Description,
                    Location = a.Location,
                    Remarks = a.Remarks,
                    UserID = a.UserID,
                    EventPackageDetailsID = a.EventPackageDetailsID,
                    EventClientID = a.EventClientID

                }).ToListAsync();

                return _viewEventList;
            }
        }

    }
}
