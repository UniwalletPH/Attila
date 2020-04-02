using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class SearchClientByKeywordQuery : IRequest<List<SearchClientVM>>
    {
        public string Keyword { get; set; }

        public class SearchClientByKeywordQueryHandler : IRequestHandler<SearchClientByKeywordQuery, List<SearchClientVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchClientByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<SearchClientVM>> Handle(SearchClientByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _search = new List<SearchClientVM>();

                var _searchedClient = dbContext.Clients.Where
                    (a => a.Name.Contains(request.Keyword));

                if (_searchedClient != null)
                {
                    foreach (var item in _searchedClient)
                    {
                        var _result = new SearchClientVM
                        {
                            Address = item.Address,
                            Contact = item.Contact,
                            Email = item.Email,
                            Name = item.Name,
                        };
                        _search.Add(_result);
                    }
                    return _search;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }          
            }
        }
    }
}
