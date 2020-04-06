using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
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
                try
                {
                    FoodInventory _foodInventory = new FoodInventory
                    {
                        Quantity = request.MyFoodInventoryVM.Quantity,
                        ExpirationDate = request.MyFoodInventoryVM.ExpirationDate,
                        EncodingDate = DateTime.Now,
                        ItemPrice = request.MyFoodInventoryVM.ItemPrice,
                        Remarks = request.MyFoodInventoryVM.Remarks,
                        InventoryManagerID = request.MyFoodInventoryVM.UserID,
                        FoodID = request.MyFoodInventoryVM.FoodDetailsID,
                        DeliveryID = request.MyFoodInventoryVM.DeliveryDetailsID
                    };

                    dbContext.FoodInventories.Add(_foodInventory);
                    await dbContext.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
