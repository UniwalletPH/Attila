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
    public class SearchEventByKeywordQuery : IRequest<EventDetails>
    {
        public string EventKeyword { get; set; }

        public class SearchEventByKeywordQueryHandler : IRequestHandler<SearchEventByKeywordQuery, EventDetails>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventDetails> Handle(SearchEventByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedEvent = dbContext.EventsDetails.Where
                    (a => a.EventName.Contains(request.EventKeyword)
                    || a.Description.Contains(request.EventKeyword));

                if (_searchedEvent != null)
                {
                    return _searchedEvent.SingleOrDefault();
                }
                else
                {
                    throw new Exception("Does not exist!");
                }
            }
        }
    }
}
