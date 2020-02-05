using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Food.Commands
{
    public class AddFoodInventoryCommand : IRequest<bool>
    {
        public FoodInventory MyFoodInventory { get; set; }

        public class AddFoodInventoryCommandHandler : IRequestHandler<AddFoodInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddFoodInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddFoodInventoryCommand request, CancellationToken cancellationToken)
            {
                FoodInventory _foodInventory = new FoodInventory
                {
                    Quantity = request.MyFoodInventory.Quantity,
                    ExpirationDate = request.MyFoodInventory.ExpirationDate,
                    EncodingDate = DateTime.Now,
                    ItemPrice = request.MyFoodInventory.ItemPrice,
                    Remarks = request.MyFoodInventory.Remarks,
                    UserID = request.MyFoodInventory.UserID,
                    FoodDetailsID = request.MyFoodInventory.FoodDetailsID
                };

                dbContext.FoodsInventory.Add(_foodInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
