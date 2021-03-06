﻿using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
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

                var _searchedEvent = dbContext.Events.Where
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
                            EventClientID = item.ClientID,
                            EventDate = item.EventDate,
                            PackageDetailsID = item.EventPackageID,
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
