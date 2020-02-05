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
    public class SearchEventByIdQuery : IRequest<EventDetails>
    {
        public int EventId { get; set; }

        public class SearchEventByIdQueryHandler : IRequestHandler<SearchEventByIdQuery, EventDetails>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventDetails> Handle(SearchEventByIdQuery request, CancellationToken cancellationToken)
            {
                var _searchedEvent = dbContext.EventsDetails.Find(request.EventId);

                if (_searchedEvent != null)
                {
                    return _searchedEvent;
                }
                else
                {
                    throw new Exception("Event ID does not exist!");
                }
            }
        }
    }
}
