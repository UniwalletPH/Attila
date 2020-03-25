using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Food.Commands
{
    public class AddFoodInventoryCommand : IRequest<bool>
    {
        public FoodsInventoryVM MyFoodInventoryVM { get; set; }

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
                    EncodingDate = DateTime.Now,
                    ItemPrice = request.MyFoodInventoryVM.ItemPrice,
                    Remarks = request.MyFoodInventoryVM.Remarks,
                    UserID = request.MyFoodInventoryVM.UserID,
                    FoodDetailsID = request.MyFoodInventoryVM.FoodDetailsID,
                    FoodRestockID = request.MyFoodInventoryVM.DeliveryDetailsID
                };

                dbContext.FoodInventories.Add(_foodInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
