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
    public class SearchClientByKeywordQuery : IRequest<EventClient>
    {
        private readonly string Keyword;
        public SearchClientByKeywordQuery(string keyword)
        {
            this.Keyword = keyword;
        }

        public class SearchClientByKeywordQueryHandler : IRequestHandler<SearchClientByKeywordQuery, EventClient>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchClientByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventClient> Handle(SearchClientByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedClient = dbContext.EventClients.Where
                    (a => a.Firstname.Contains(request.Keyword)
                    || a.Lastname.Contains(request.Keyword));

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
