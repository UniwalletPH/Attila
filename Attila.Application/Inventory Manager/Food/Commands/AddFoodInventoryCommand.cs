using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Food.Commands
{
    public class AddFoodInventoryCommand : IRequest<bool>
    {
        public FoodInventoryVM MyFoodInventoryVM { get; set; }

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
                    Quantity = request.MyFoodInventoryVM.Quantity,
                    ExpirationDate = request.MyFoodInventoryVM.ExpirationDate,
                    EncodingDate = request.MyFoodInventoryVM.EncodingDate,
                    ItemPrice = request.MyFoodInventoryVM.ItemPrice,
                    Remarks = request.MyFoodInventoryVM.Remarks,
                    UserID = request.MyFoodInventoryVM.UserID,
                    FoodDetailsID = request.MyFoodInventoryVM.FoodDetailsID,
                    FoodRestockID = request.MyFoodInventoryVM.FoodRestockID
                };

                dbContext.FoodsInventory.Add(_foodInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
