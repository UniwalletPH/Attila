using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Queries
{
    public class ViewFoodStockQuery : IRequest<IEnumerable<FoodInventory>>
    {
        public ViewFoodStockQuery()
        {
        }

        public class ViewFoodStockQueryHandler : IRequestHandler<ViewFoodStockQuery, IEnumerable<FoodInventory>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewFoodStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<FoodInventory>> Handle(ViewFoodStockQuery request, CancellationToken cancellationToken)
            {
                var _foodInventoryList = await dbContext.FoodsInventory.ToListAsync();

                return _foodInventoryList;
            }
        }
    }
}
