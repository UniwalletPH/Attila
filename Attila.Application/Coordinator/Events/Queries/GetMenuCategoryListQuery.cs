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
    public class GetMenuCategoryListQuery :IRequest<IEnumerable<MenuCategoryVM>>
    {
        public class GetMenuCategoryListQueryHandler : IRequestHandler<GetMenuCategoryListQuery, IEnumerable<MenuCategoryVM>>
        {
            public readonly IAttilaDbContext dbContext;
            public GetMenuCategoryListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<MenuCategoryVM>> Handle(GetMenuCategoryListQuery request, CancellationToken cancellationToken)
            {
                var _viewMenuCategoryList = await dbContext.DishCategories.Select(a => new MenuCategoryVM
                {
                    Category = a.Category,
                    ID = a.ID

                }).ToListAsync();

                return _viewMenuCategoryList;
            }
        }
    }
}
