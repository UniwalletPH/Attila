using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class SearchEventByKeywordQuery : IRequest<List<SearchEventVM>>
    {
        public string EventKeyword { get; set; }

        public class SearchEventByKeywordQueryHandler : IRequestHandler<SearchEventByKeywordQuery, List<SearchEventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<SearchEventVM>> Handle(SearchEventByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _search = new List<SearchEventVM>();

                var _searchedEvent = dbContext.EventDetails.Where
                    (a => a.EventName.Contains(request.EventKeyword)
                    || a.Description.Contains(request.EventKeyword)).ToList();

                if (_searchedEvent != null)
                {
                    foreach (var item in _searchedEvent)
                    {
                        var _result = new SearchEventVM
                        {
                            EventName = item.EventName,
                            Type = item.Type,
                            BookingDate = item.BookingDate,
                            Description = item.Description,
                            EventClientID = item.EventClientID,
                            EventDate = item.EventDate,
                            PackageDetailsID = item.PackageDetailsID,
                            Location = item.Location,
                            Remarks = item.Remarks,
                            UserID = item.UserID,
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
                        _search.Add(_result);
                    }
                    return _search;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }
            }
        }
    }
}
