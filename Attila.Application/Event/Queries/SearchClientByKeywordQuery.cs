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
    public class SearchClientByKeywordQuery : IRequest<EventClient>
    {
        public SearchClientByKeywordQuery()
        { 
        
        }

        public class SearchClientByKeywordQueryHandler : IRequestHandler<SearchClientByKeywordQuery, EventClient>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchClientByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<EventClient> Handle(SearchClientByKeywordQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
