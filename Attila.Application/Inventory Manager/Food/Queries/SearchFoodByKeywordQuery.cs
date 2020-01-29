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
    public class SearchFoodByKeywordQuery : IRequest<IEnumerable<FoodInventory>>
    {
        private readonly string searchedKeyword;
        public SearchFoodByKeywordQuery(string searchedKeyword)
        {
            this.searchedKeyword = searchedKeyword;
        }

        public class SearchFoodByKeywordQueryHandler : IRequestHandler<SearchFoodByKeywordQuery, IEnumerable<FoodInventory>>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchFoodByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<FoodInventory>> Handle(SearchFoodByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedKeyword = dbContext.FoodsInventory.Where(a => a.Remarks.Contains(request.searchedKeyword));

                return _searchedKeyword.ToList();
            }
        }
    }
}
