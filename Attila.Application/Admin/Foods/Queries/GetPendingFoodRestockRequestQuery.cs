using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Foods.Queries
{
    public class GetPendingFoodRestockRequestQuery : IRequest<List<FoodRequestVM>>
    {
        public class ViewPendingFoodRestockRequestQueryHandler : IRequestHandler<GetPendingFoodRestockRequestQuery, List<FoodRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingFoodRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<FoodRequestVM>> Handle(GetPendingFoodRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _listPendingRequest = new List<FoodRequestVM>();

                var _pendingFoodRestock = dbContext.FoodRestockRequests
                    .Include(a => a.InventoryManager)
                    .Where(a => a.Status == Status.Processing);

                foreach (var item in _pendingFoodRestock)
                {
                    var FoodRestockRequest = new FoodRequestVM
                    { 
                        ID = item.ID,
                        DateTimeRequest = item.DateTimeRequest,
                        Status = item.Status,
                        User = item.InventoryManager
                    };

                    _listPendingRequest.Add(FoodRestockRequest);
                }

                return _listPendingRequest;

            }
        }
    }
}
