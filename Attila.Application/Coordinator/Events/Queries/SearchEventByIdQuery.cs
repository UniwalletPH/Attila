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
    public class SearchEventByIdQuery : IRequest<EventDetailsVM>
    {
        public int EventId { get; set; }

        public class SearchEventByIdQueryHandler : IRequestHandler<SearchEventByIdQuery, EventDetailsVM>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventDetailsVM> Handle(SearchEventByIdQuery request, CancellationToken cancellationToken)
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
                    .Where(a => a.ID == request.EventId).SingleOrDefault();

                var Events = new EventDetailsVM
                {
                    ID = _searchedEvent.ID,
                    EventName = _searchedEvent.EventName,
                    Type = _searchedEvent.Type,
                    BookingDate = _searchedEvent.BookingDate,
                    Description = _searchedEvent.Description,
                    EventClientID = _searchedEvent.ClientID,
                    Client = _searchedEvent.Client,
                    EventDate = _searchedEvent.EventDate,
                    PackageDetailsID = _searchedEvent.EventPackageID,
                    Package = _searchedEvent.EventPackage,
                    Location = _searchedEvent.Location,
                    Remarks = _searchedEvent.Remarks,
                    UserID = _searchedEvent.CoordinatorID,
                    EventStatus = _searchedEvent.EventStatus,
                    EntryTime = _searchedEvent.EntryTime,
                    NumberOfGuests = _searchedEvent.NumberOfGuests,
                    ProgramStart = _searchedEvent.ProgramStart,
                    ServingTime = _searchedEvent.ServingTime,
                    LocationType = _searchedEvent.LocationType,
                    ServingType = _searchedEvent.ServingType,
                    Theme = _searchedEvent.Theme,
                    VenueType = _searchedEvent.VenueType
                };

                return Events;
            }
        }
    }
}
