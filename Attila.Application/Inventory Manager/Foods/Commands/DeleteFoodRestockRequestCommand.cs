using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class DeleteFoodRestockRequestCommand : IRequest<bool>
    {
        public int DeleteRequestID { get; set; }

        public class DeleteFoodRestockRequestCommandHandler : IRequestHandler<DeleteFoodRestockRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeleteFoodRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(DeleteFoodRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _getFoodRestockRequest = dbContext.FoodRestockRequests.Find(request.DeleteRequestID);

                if (_getFoodRestockRequest != null)
                {
                    var _getFoodRestockCollection = dbContext.FoodRequestCollections.Where(a => a.FoodRestockRequestID == request.DeleteRequestID).ToList();

                    dbContext.FoodRestockRequests.Remove(_getFoodRestockRequest);
                    dbContext.FoodRequestCollections.RemoveRange(_getFoodRestockCollection);

                }
                else
                {
                    throw new Exception("Request ID does not exist!");
                }

                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
