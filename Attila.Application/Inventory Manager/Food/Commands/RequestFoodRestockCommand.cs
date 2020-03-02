using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Commands
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
                    FoodDetailsID = request.MyFoodRestockRequestVM.FoodDetailsID,
                    Status = request.MyFoodRestockRequestVM.Status,
                    UserID = request.MyFoodRestockRequestVM.UserID
                };

                dbContext.FoodRestockRequests.Add(_foodRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;

            }
        }
    }
}
