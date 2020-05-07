using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Foods.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class UpdateFoodStockCommand : IRequest<bool>
    {
        public FoodInventoryVM MyFoodInventoryVM { get; set; }

        public class UpdateFoodStockInventoryCommandHandler : IRequestHandler<UpdateFoodStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodStockInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodStockCommand request, CancellationToken cancellationToken)
            {
                bool response = new bool();

                var _updatedFoodStock = dbContext.FoodInventories.Find(request.MyFoodInventoryVM.FoodDetailsID);

                if (_updatedFoodStock != null)
                {
                    _updatedFoodStock.Quantity -= request.MyFoodInventoryVM.Quantity;

                    if (_updatedFoodStock.Quantity > 0)
                    {
                        await dbContext.SaveChangesAsync();
                        response = true;
                    }
                    else
                    {
                        response = false;
                    }

                    return response;
                }

                else
                {
                    throw new Exception("Food ID does not exist!");
                }
                
            }
        }
    }
}

