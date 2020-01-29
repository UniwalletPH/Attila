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
    public class SearchClientByIdQuery : IRequest<EventClient>
    {
        public SearchClientByIdQuery()
        { 
        
        }

        public class SearchClientByIdQueryHandler : IRequestHandler<SearchClientByIdQuery, EventClient>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchClientByIdQueryHandler(IAttilaDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public Task<EventClient> Handle(SearchClientByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
