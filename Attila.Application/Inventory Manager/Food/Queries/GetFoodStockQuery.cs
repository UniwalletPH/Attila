using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Queries
{
    public class GetFoodStockQuery : IRequest<IEnumerable<FoodInventory>>
    {

        public class ViewFoodStockQueryHandler : IRequestHandler<GetFoodStockQuery, IEnumerable<FoodInventory>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewFoodStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<FoodInventory>> Handle(GetFoodStockQuery request, CancellationToken cancellationToken)
            {
                var _foodInventoryList = await dbContext.FoodsInventory.ToListAsync();

                return _foodInventoryList;
            }
        }
    }
}
