using Attila.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Commands
{
    public class UpdateFoodStockCommand : IRequest<bool>
    {
        public int SearchedID { get; set; }
        public int NewFoodQuantity { get; set; }

        public class UpdateFoodStockInventoryCommandHandler : IRequestHandler<UpdateFoodStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodStockInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodStockCommand request, CancellationToken cancellationToken)
            {
                var _updatedFoodStock = dbContext.FoodsInventory.Find(request.SearchedID);

                _updatedFoodStock.Quantity = request.NewFoodQuantity;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}

