using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class SearchEventByIdQuery : IRequest<SearchEventVM>
    {
        public int EventId { get; set; }

        public class SearchEventByIdQueryHandler : IRequestHandler<SearchEventByIdQuery, SearchEventVM>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<SearchEventVM> Handle(SearchEventByIdQuery request, CancellationToken cancellationToken)
            {
                var _searchedEvent = dbContext.EventDetails.Find(request.EventId);

                if (_searchedEvent != null)
                {
                    return new SearchEventVM {
                        EventName = _searchedEvent.EventName,
                        Type = _searchedEvent.Type,
                        BookingDate = _searchedEvent.BookingDate,
                        Description = _searchedEvent.Description,
                        EventClientID = _searchedEvent.EventClientID,
                        EventDate = _searchedEvent.EventDate,
                        PackageDetailsID = _searchedEvent.PackageDetailsID,
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
                }
                else
                {
                    throw new Exception("Event ID does not exist!");
                }
            }
        }
    }
}
