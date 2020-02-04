using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Commands
{
    public class UpdateFoodStockInventoryCommand : IRequest<bool>
    {
        private readonly FoodInventory myFoodInventory;

        public UpdateFoodStockInventoryCommand(FoodInventory myFoodInventory)
        {
            this.myFoodInventory = myFoodInventory;
        }

        public class UpdateFoodStockInventoryCommandHandler : IRequestHandler<UpdateFoodStockInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodStockInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodStockInventoryCommand request, CancellationToken cancellationToken)
            {
                var _updatedFoodStock = dbContext.FoodsInventory.Find(request.myFoodInventory.ID);

                _updatedFoodStock.Quantity = request.myFoodInventory.Quantity;
                _updatedFoodStock.ExpirationDate = request.myFoodInventory.ExpirationDate;
                _updatedFoodStock.ItemPrice = request.myFoodInventory.ItemPrice;
                _updatedFoodStock.Remarks = request.myFoodInventory.Remarks;
                _updatedFoodStock.FoodDetailsID = request.myFoodInventory.FoodDetailsID;
                _updatedFoodStock.FoodRestockID = request.myFoodInventory.FoodRestockID;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}

