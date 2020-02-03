using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Queries
{
    public class SearchFoodByKeywordQuery : IRequest<IEnumerable<FoodDetails>>
    {
        public string SearchedKeyword { get; set; }

        public class SearchFoodByKeywordQueryHandler : IRequestHandler<SearchFoodByKeywordQuery, IEnumerable<FoodDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchFoodByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<FoodDetails>> Handle(SearchFoodByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedKeyword = dbContext.FoodsDetails.Where(a => a.Name.Contains(request.SearchedKeyword) ||
                                                                         a.Code.Contains(request.SearchedKeyword) ||
                                                                         a.Specification.Contains(request.SearchedKeyword) ||
                                                                         a.Description.Contains(request.SearchedKeyword));

                return _searchedKeyword.ToList();
            }
        }
    }
}
