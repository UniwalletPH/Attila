using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class RequestFoodRestockCommand : IRequest<bool>
    {
        public FoodsRestockRequestVM MyFoodRestockRequestVM { get; set; }

        public class RequestFoodRestockCommandHandler : IRequestHandler<RequestFoodRestockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestFoodRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            
            public async Task<bool> Handle(RequestFoodRestockCommand request, CancellationToken cancellationToken)
            {
                FoodRestockRequest _foodRestockRequest = new FoodRestockRequest
                {
                    Quantity = request.MyFoodRestockRequestVM.Quantity,
                    DateTimeRequest = DateTime.Now,
                    FoodID = request.MyFoodRestockRequestVM.FoodDetailsID,
                    Status = request.MyFoodRestockRequestVM.Status,
                    InventoryManagerID = request.MyFoodRestockRequestVM.UserID
                };

                dbContext.FoodRestockRequests.Add(_foodRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;

            }
        }
    }
}
