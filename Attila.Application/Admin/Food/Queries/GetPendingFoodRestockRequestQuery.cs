using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Enums;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Food.Queries
{
    public class GetPendingFoodRestockRequestQuery : IRequest<List<FoodRestockRequest>>
    {
        public class ViewPendingFoodRestockRequestQueryHandler : IRequestHandler<GetPendingFoodRestockRequestQuery, List<FoodRestockRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingFoodRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async  Task<List<FoodRestockRequest>> Handle(GetPendingFoodRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _pendingFoodRestock = dbContext.FoodRestockRequests
                    .Include(a => a.FoodDetails)
                    .Where(a => a.Status == Status.Pending);

                return _pendingFoodRestock.ToList();

            }
        }
    }
}
