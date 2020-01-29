using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Queries
{
    public class SearchClientByIdQuery : IRequest<EventClient>
    {
        private readonly int ClientID;
        public SearchClientByIdQuery(int clientID)
        {
            this.ClientID = clientID;
        }

        public class SearchClientByIdQueryHandler : IRequestHandler<SearchClientByIdQuery, EventClient>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchClientByIdQueryHandler(IAttilaDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public async Task<EventClient> Handle(SearchClientByIdQuery request, CancellationToken cancellationToken)
            {
                var _clientSearched = dbContext.EventClients.Find(request.ClientID);

                if (_clientSearched != null)
                {
                    return _clientSearched;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }
            }
        }
    }
}
