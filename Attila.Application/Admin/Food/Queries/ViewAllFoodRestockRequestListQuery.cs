using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Food.Queries
{
    public class ViewAllFoodRestockRequestListQuery : IRequest<List<FoodRestockRequest>>
    {
        public class ViewAllFoodRestockRequestListHandler : IRequestHandler<ViewAllFoodRestockRequestListQuery, List<FoodRestockRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewAllFoodRestockRequestListHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            // TODO: put async and await
            public  Task<List<FoodRestockRequest>> Handle(ViewAllFoodRestockRequestListQuery request, CancellationToken cancellationToken)
            {
                var _foodRestockRequests = dbContext.FoodRestockRequests.ToListAsync();

                return _foodRestockRequests;
            }
        }
    }
}
