using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Commands
{
    public class RequestFoodRestockCommand : IRequest<bool>
    {
        private readonly FoodRestockRequest myFoodRestockRequest;
        public RequestFoodRestockCommand(FoodRestockRequest myFoodRestockRequest)
        {
            this.myFoodRestockRequest = myFoodRestockRequest;
        }

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
                    Quantity = request.myFoodRestockRequest.Quantity,
                    DateTimeRequest = DateTime.Now,
                    FoodsDetailsID = request.myFoodRestockRequest.FoodsDetailsID,
                    UserID = request.myFoodRestockRequest.UserID
                };

                dbContext.FoodsRestockRequests.Add(_foodRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
