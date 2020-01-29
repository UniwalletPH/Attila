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
    public class SearchEventByKeywordQuery : IRequest<EventDetails>
    {
        public SearchEventByKeywordQuery()
        {

        }

        public class SearchEventByKeywordQueryHandler : IRequestHandler<SearchEventByKeywordQuery, EventDetails>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEventByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<EventDetails> Handle(SearchEventByKeywordQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
