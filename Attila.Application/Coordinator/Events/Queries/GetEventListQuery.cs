using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
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

                var _viewEventList = await dbContext.Events.Select(a => new SearchEventVM
                {
                    EventName = a.EventName,
                    Type = a.Type,
                    BookingDate = a.BookingDate,
                    Description = a.Description,
                    EventClientID = a.ClientID,
                    EventDate = a.EventDate,
                    PackageDetailsID = a.EventPackageID,
                    Location = a.Location,
                    Remarks = a.Remarks,
                    UserID = a.CoordinatorID,
                    EventStatus = a.EventStatus,
                    EntryTime = a.EntryTime,
                    NumberOfGuests = a.NumberOfGuests,
                    ProgramStart = a.ProgramStart,
                    ServingTime = a.ServingTime,
                    LocationType = a.LocationType,
                    ServingType = a.ServingType,
                    Theme = a.Theme,
                    VenueType = a.VenueType

                }).Include(a => a.EventClient.Name)
                .ToListAsync();

                return _viewEventList;
            }
        }

    }
}
