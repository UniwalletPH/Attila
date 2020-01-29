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
    public class AddFoodStockInventoryCommand : IRequest<bool>
    {
        private readonly FoodInventory myFoodInventory;
        public AddFoodStockInventoryCommand(FoodInventory myFoodInventory)
        {
            this.myFoodInventory = myFoodInventory;
        }

        public class AddFoodStockInventoryCommandHandler : IRequestHandler<AddFoodStockInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddFoodStockInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddFoodStockInventoryCommand request, CancellationToken cancellationToken)
            {
                FoodInventory _foodInventory = new FoodInventory
                {
                    Quantity = request.myFoodInventory.Quantity,
                    ExpirationDate = request.myFoodInventory.ExpirationDate,
                    EncodingDate = request.myFoodInventory.EncodingDate,
                    ItemPrice = request.myFoodInventory.ItemPrice,
                    Remarks = request.myFoodInventory.Remarks,
                    UserID = request.myFoodInventory.UserID,
                };

                dbContext.FoodsInventory.Add(_foodInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
