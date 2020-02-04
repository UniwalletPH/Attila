using Atilla.Application.Interfaces;
using Atilla.Domain.Entities;
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
                    // TODO: dont use .Equals
                    // TODO: Status is an Enum, compare with Enum
                    .Where(a => a.Status.Equals(0));

                return _pendingFoodRestock.ToList();

            }
        }
    }
}
