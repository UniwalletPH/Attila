using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class GetFoodStockQuery : IRequest<IEnumerable<FoodsInventoryVM>>
    {

        public class GetFoodStockQueryHandler : IRequestHandler<GetFoodStockQuery, IEnumerable<FoodsInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetFoodStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<FoodsInventoryVM>> Handle(GetFoodStockQuery request, CancellationToken cancellationToken)
            {
                var _foodInventoryList = await dbContext.FoodInventories.Select(a => new FoodsInventoryVM 
                { 
                    ID = a.ID,
                    Quantity = a.Quantity,
                    ExpirationDate = a.ExpirationDate,
                    EncodingDate = a.EncodingDate,
                    ItemPrice = a.ItemPrice,
                    Remarks = a.Remarks,
                    UserID = a.UserID,
                    FoodDetailsID = a.FoodDetailsID,
                    DeliveryDetailsID = a.FoodRestockID

                }).ToListAsync();

                return _foodInventoryList;
            }
        }
    }
}
