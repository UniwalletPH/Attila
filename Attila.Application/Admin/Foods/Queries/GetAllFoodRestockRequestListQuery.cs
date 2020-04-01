using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Foods.Queries
{
    public class GetAllFoodRestockRequestListQuery : IRequest<List<FoodRestockRequest>>
    {
        public class ViewAllFoodRestockRequestListHandler : IRequestHandler<GetAllFoodRestockRequestListQuery, List<FoodRestockRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewAllFoodRestockRequestListHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async  Task<List<FoodRestockRequest>> Handle(GetAllFoodRestockRequestListQuery request, CancellationToken cancellationToken)
            {
                var _foodRestockRequests = await dbContext.FoodRestockRequests.ToListAsync();

                return _foodRestockRequests;
            }
        }
    }
}
