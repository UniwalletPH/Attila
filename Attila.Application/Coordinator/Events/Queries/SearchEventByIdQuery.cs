using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class SearchEventByIdQuery : IRequest<List<EventDetailsVM>>
    {
        public int EventId { get; set; }

        public class SearchEventByIdQueryHandler : IRequestHandler<SearchEventByIdQuery, List<EventDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventDetailsVM>> Handle(SearchEventByIdQuery request, CancellationToken cancellationToken)
            {
                //var _searchedEvent = dbContext.Events.Find(request.EventId);

                var _searchEventList = new List<EventDetailsVM>();

                var _searchedEvent = dbContext.Events
                    .Include(a => a.EventMenus)
                    .Include(a => a.EventPackage)
                    .Include(a => a.Client)
                    .Include(a => a.EventAdditionalDurationRequests)
                    .Include(a => a.EventAdditionalEquipmentRequests)
                    .Include(a => a.EventAdditionalDishRequests)
                    .Where(a => a.ID == request.EventId);

                foreach (var item in _searchedEvent)
                {
                    var Events = new EventDetailsVM
                    {
                        ID = item.ID,
                        EventName = item.EventName,
                        Type = item.Type,
                        BookingDate = item.BookingDate,
                        Description = item.Description,
                        EventClientID = item.ClientID,
                        Client = item.Client,
                        EventDate = item.EventDate,
                        PackageDetailsID = item.EventPackageID,
                        Package = item.EventPackage,
                        Location = item.Location,
                        Remarks = item.Remarks,
                        UserID = item.CoordinatorID,
                        EventStatus = item.EventStatus,
                        EntryTime = item.EntryTime,
                        NumberOfGuests = item.NumberOfGuests,
                        ProgramStart = item.ProgramStart,
                        ServingTime = item.ServingTime,
                        LocationType = item.LocationType,
                        ServingType = item.ServingType,
                        Theme = item.Theme,
                        VenueType = item.VenueType
                    };
                    _searchEventList.Add(Events);
                }
                

                return _searchEventList;
            }
        }
    }
}
