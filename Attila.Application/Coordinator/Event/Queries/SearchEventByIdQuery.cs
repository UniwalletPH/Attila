using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Queries
{
    public class SearchEventByIdQuery : IRequest<EventDetails>
    {
        private readonly int EventID;
        public SearchEventByIdQuery(int eventID)
        {
            this.EventID = eventID;
        }

        public class SearchEventByIdQueryHandler : IRequestHandler<SearchEventByIdQuery, EventDetails>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventDetails> Handle(SearchEventByIdQuery request, CancellationToken cancellationToken)
            {
                var _searchedEvent = dbContext.EventsDetails.Find(request.EventID);

                if (_searchedEvent != null)
                {
                    return _searchedEvent;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }
            }
        }
    }
}
