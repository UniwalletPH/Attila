using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Queries
{
    public class SearchFoodByIdQuery : IRequest<FoodInventory>
    {
        public int SearchedID { get; set; }

        public class SearchFoodByIdQueryHandler : IRequestHandler<SearchFoodByIdQuery, FoodInventory>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchFoodByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<FoodInventory> Handle(SearchFoodByIdQuery request, CancellationToken cancellationToken)
            {
                FoodInventory _searchedFoodInventory = dbContext.FoodsInventory.Find(request.SearchedID);

                return _searchedFoodInventory;
            }
        }
    }
}
