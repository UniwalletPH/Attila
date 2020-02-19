﻿using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Queries
{
    public class GetFoodStockQuery : IRequest<IEnumerable<FoodInventoryVM>>
    {

        public class ViewFoodStockQueryHandler : IRequestHandler<GetFoodStockQuery, IEnumerable<FoodInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewFoodStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<FoodInventoryVM>> Handle(GetFoodStockQuery request, CancellationToken cancellationToken)
            {
                var _foodInventoryList = await dbContext.FoodsInventory.Select(a => new FoodInventoryVM 
                { 
                    ID = a.ID,
                    Quantity = a.Quantity,
                    ExpirationDate = a.ExpirationDate,
                    EncodingDate = a.EncodingDate,
                    ItemPrice = a.ItemPrice,
                    Remarks = a.Remarks,
                    UserID = a.UserID,
                    FoodDetailsID = a.FoodDetailsID,
                    FoodRestockID = a.FoodRestockID

                }).ToListAsync();

                return _foodInventoryList;
            }
        }
    }
}