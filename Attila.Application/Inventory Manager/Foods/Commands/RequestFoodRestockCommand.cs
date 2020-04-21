using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class RequestFoodRestockCommand : IRequest<int>
    {
        public FoodsRestockRequestVM MyFoodRestockRequestVM { get; set; }

        public class RequestFoodRestockCommandHandler : IRequestHandler<RequestFoodRestockCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestFoodRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            
            public async Task<int> Handle(RequestFoodRestockCommand request, CancellationToken cancellationToken)
            {
                FoodRestockRequest _foodRestockRequest = new FoodRestockRequest
                {
                    DateTimeRequest = DateTime.Now,
                    Status = Status.Processing,
                    InventoryManagerID = request.MyFoodRestockRequestVM.UserID
                };

                dbContext.FoodRestockRequests.Add(_foodRestockRequest);
                await dbContext.SaveChangesAsync();

                foreach (var item in request.MyFoodRestockRequestVM.FoodRequestCollection)
                {
                    FoodRequestCollection _foodRequestCollection = new FoodRequestCollection 
                    {
                        FoodID = item.FoodID,
                        FoodRestockRequestID = _foodRestockRequest.ID,
                        Quantity = item.Quantity
                    };

                    dbContext.FoodRequestCollections.Add(_foodRequestCollection);
                }


                await dbContext.SaveChangesAsync();
                return _foodRestockRequest.ID;
            }
        }
    }
}
