using Atilla.Application.Interfaces;
using Atilla.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Commands
{
    public class RequestFoodRestockCommand : IRequest<bool>
    {

        public FoodRestockRequest MyFoodRestockRequest { get; set; }

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
                    Quantity = request.MyFoodRestockRequest.Quantity,
                    DateTimeRequest = DateTime.Now,
                    FoodsDetailsID = request.MyFoodRestockRequest.FoodsDetailsID,
                    UserID = request.MyFoodRestockRequest.UserID
                };

                dbContext.FoodRestockRequests.Add(_foodRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
