using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Commands
{
    public class RequestFoodRestockCommand : IRequest<bool>
    {
        public int RequestFoodID { get; set; }
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
                var _searchRequestFoodId = dbContext.FoodsDetails.Find(request.RequestFoodID);

                if (_searchRequestFoodId != null)
                {
                    FoodRestockRequest _foodRestockRequest = new FoodRestockRequest
                    {
                        Quantity = request.MyFoodRestockRequest.Quantity,
                        DateTimeRequest = DateTime.Now,
                        FoodDetailsID = request.MyFoodRestockRequest.FoodDetailsID,
                        Status = 0,
                        UserID = request.MyFoodRestockRequest.UserID
                    };

                    dbContext.FoodRestockRequests.Add(_foodRestockRequest);
                    await dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Food Details ID does not exist!");
                }
                
            }
        }
    }
}
