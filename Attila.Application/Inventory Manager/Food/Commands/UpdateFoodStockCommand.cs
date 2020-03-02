using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Commands
{
    public class UpdateFoodStockCommand : IRequest<bool>
    {
        public FoodsInventoryVM MyFoodInventoryVM { get; set; }

        public class UpdateFoodStockInventoryCommandHandler : IRequestHandler<UpdateFoodStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodStockInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodStockCommand request, CancellationToken cancellationToken)
            {
                var _updatedFoodStock = dbContext.FoodsInventory.Find(request.MyFoodInventoryVM.ID);

                if (_updatedFoodStock != null)
                {
                    _updatedFoodStock.Quantity = request.MyFoodInventoryVM.Quantity;

                    await dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Food ID does not exist!");
                }
                
            }
        }
    }
}

