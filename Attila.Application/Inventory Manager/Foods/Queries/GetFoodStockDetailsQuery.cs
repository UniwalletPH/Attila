using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class GetFoodStockDetailsQuery : IRequest<IEnumerable<FoodInventoryVM>>
    {
        public class GetFoodStockDetailsQueryHandler : IRequestHandler<GetFoodStockDetailsQuery, IEnumerable<FoodInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetFoodStockDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<FoodInventoryVM>> Handle(GetFoodStockDetailsQuery request, CancellationToken cancellationToken)
            {
                List<FoodInventoryVM> _foodStockDetailsList = new List<FoodInventoryVM>();

                var _getFoodStockDetails = dbContext.FoodInventories.Include(a => a.Food);

                foreach (var item in _getFoodStockDetails)
                {
                    FoodInventoryVM _foodStockDetails = new FoodInventoryVM
                    {
                        ID = item.ID,
                        Quantity = item.Quantity,
                        ExpirationDate = item.ExpirationDate,
                        FoodDetailsVM = item.Food
                    };

                    _foodStockDetailsList.Add(_foodStockDetails);
                }

                return _foodStockDetailsList;
            }
        }
    }
}
