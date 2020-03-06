﻿using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
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
                var _viewEventList = await dbContext.EventDetails.Select(a => new SearchEventVM 
                {
                    EventName = a.EventName,
                    Type = a.Type,
                    BookingDate = a.BookingDate,
                    Theme = a.Theme,
                    Description = a.Description,
                    EventClientID = a.EventClientID,
                    EventDate = a.EventDate,
                    PackageDetailsID = a.PackageDetailsID,
                    Location = a.Location,
                    Remarks = a.Remarks,
                    UserID = a.UserID,
                    EventStatus = Status.Pending,
                    EntryTime = a.EntryTime,
                    NumberOfGuests = a.NumberOfGuests,
                    ProgramStart = a.ProgramStart,
                    ServingTime = a.ServingTime,
                    ServingType = a.ServingType,

                }).ToListAsync();

                return _viewEventList;
            }
        }

    }
}
