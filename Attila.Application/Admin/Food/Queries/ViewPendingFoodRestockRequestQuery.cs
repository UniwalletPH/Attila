
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Food.Queries
{
    public class ViewPendingFoodRestockRequestQuery : IRequest<List<FoodRestockRequest>>
    {
        public class ViewPendingFoodRestockRequestQueryHandler : IRequestHandler<ViewPendingFoodRestockRequestQuery, List<FoodRestockRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingFoodRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async  Task<List<FoodRestockRequest>> Handle(ViewPendingFoodRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _pendingFoodRestock = dbContext.FoodRestockRequests                 
                    .Where(a => a.Status == Status.Pending);

                return _pendingFoodRestock.ToList();

            }
        }
    }
}
