using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Event.Queries
{
    public class GetClientIdQuery : IRequest<EventClient>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public class GetClientIdQueryHandler : IRequestHandler<GetClientIdQuery, EventClient>
        {
            private readonly IAttilaDbContext dbContext;

            public GetClientIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EventClient> Handle(GetClientIdQuery request, CancellationToken cancellationToken)
            {
                var _searchedClient = dbContext.EventClients.Where
                    (a => a.Firstname.Contains(request.FirstName)
                    && a.Lastname.Contains(request.LastName));

                if (_searchedClient != null)
                {
                    return _searchedClient.SingleOrDefault();
                }
                else
                {
                    throw new Exception("Does not exist!");
                }
            }
        }
    }
}
