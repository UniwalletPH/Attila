using Attila.Application.Interfaces;
using Attila.Domain.Entities;
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
    public class GetClientIdQuery : IRequest<Client>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public class GetClientIdQueryHandler : IRequestHandler<GetClientIdQuery, Client>
        {
            private readonly IAttilaDbContext dbContext;

            public GetClientIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<Client> Handle(GetClientIdQuery request, CancellationToken cancellationToken)
            {
                var _searchedClient = dbContext.ClientDetails.Where
                    (a => a.Firstname.Contains(request.FirstName)
                    && a.Lastname.Contains(request.LastName));

                if (_searchedClient != null)
                {
                    return _searchedClient.SingleOrDefault();
                }
                else
                {
                    throw new Exception("Client ID does not exist!");
                }
            }
        }
    }
}
