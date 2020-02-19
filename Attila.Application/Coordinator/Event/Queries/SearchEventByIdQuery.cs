using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
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
                var _searchedEvent = dbContext.EventsDetails.Find(request.EventId);

                if (_searchedEvent != null)
                {
                    return new SearchEventVM {
                    ID = _searchedEvent.ID,
                    Address = _searchedEvent.Address,
                    BookingDate = _searchedEvent.BookingDate,
                    Code = _searchedEvent.Code,
                    Description = _searchedEvent.Description,
                    EventDate = _searchedEvent.EventDate,
                    EventName = _searchedEvent.EventName,
                    EventStatus = _searchedEvent.EventStatus,
                    Location = _searchedEvent.Location,
                    Remarks = _searchedEvent.Remarks,
                    Type = _searchedEvent.Type,
                    
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
