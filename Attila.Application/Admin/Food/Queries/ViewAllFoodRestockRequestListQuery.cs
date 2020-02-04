
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

            public async  Task<List<FoodRestockRequest>> Handle(ViewAllFoodRestockRequestListQuery request, CancellationToken cancellationToken)
            {
                var _foodRestockRequests = await dbContext.FoodRestockRequests.ToListAsync();

                return _foodRestockRequests;
            }
        }
    }
}
