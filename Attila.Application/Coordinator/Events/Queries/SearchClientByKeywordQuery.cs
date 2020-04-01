using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                var _searchedClient = dbContext.ClientDetails.Where
                    (a => a.Firstname.Contains(request.Keyword)
                    || a.Lastname.Contains(request.Keyword));

                if (_searchedClient != null)
                {
                    foreach (var item in _searchedClient)
                    {
                        var _result = new SearchClientVM
                        {
                            Address = item.Address,
                            Contact = item.Contact,
                            Email = item.Email,
                            Firstname = item.Firstname,
                            Lastname = item.Lastname
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
