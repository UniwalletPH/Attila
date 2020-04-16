using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class GetAllDishCategoryQuery : IRequest<List<DishCategoryVM>>
    {
        public class GetAllDishCategoryQueryHandler : IRequestHandler<GetAllDishCategoryQuery, List<DishCategoryVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllDishCategoryQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<DishCategoryVM>> Handle(GetAllDishCategoryQuery request, CancellationToken cancellationToken)
            {
                var _qVal = await dbContext.DishCategories
                    .Select(a => new DishCategoryVM
                    {   
                        ID = a.ID,
                        Category = a.Category
                    
                    }).ToListAsync();

                return _qVal;
            }
        }
    }
}
