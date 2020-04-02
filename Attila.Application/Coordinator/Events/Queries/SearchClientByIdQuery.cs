using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class SearchClientByIdQuery : IRequest<SearchClientVM>
    {
        public int ClientId { get; set; }

        public class SearchClientByIdQueryHandler : IRequestHandler<SearchClientByIdQuery, SearchClientVM>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchClientByIdQueryHandler(IAttilaDbContext dbContext) 
            {
                this.dbContext = dbContext;
            }

            public async Task<SearchClientVM> Handle(SearchClientByIdQuery request, CancellationToken cancellationToken)
            {
                var _clientSearched = dbContext.Clients.Find(request.ClientId);

                if (_clientSearched != null)
                {
                    return new SearchClientVM
                    {
                        ID =  _clientSearched.ID,
                        Address = _clientSearched.Address,
                        Contact = _clientSearched.Contact,
                        Email = _clientSearched.Email,
                        Name = _clientSearched.Name,
                    };
                }
                else
                {
                    throw new Exception("Does not exist!");
                }
            }
        }
    }
}
