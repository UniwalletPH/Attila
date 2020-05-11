using Attila.Application.Interfaces;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Attila.Application.Admin.Foods.Queries
{
    public class GetAllForApprovalFoodRequestQuery : IRequest<List<FoodRequestVM>>
    {
        public class GetAllForApprovalFoodRequestQueryHandler : IRequestHandler<GetAllForApprovalFoodRequestQuery, List<FoodRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllForApprovalFoodRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<FoodRequestVM>> Handle(GetAllForApprovalFoodRequestQuery request, CancellationToken cancellationToken)
            {
                var _qVal = await dbContext.FoodRestockRequests
                    .Include(a => a.InventoryManager)
                    .Where(a => a.Status == Status.ForApproval)
                    .Select(a => new FoodRequestVM
                    {
                        ID = a.ID,
                        DateTimeRequest = a.DateTimeRequest,
                        InventoryManager = a.InventoryManager,
                        Status = a.Status
                    }).ToListAsync();

                return _qVal;
            }
        }
    }
}
