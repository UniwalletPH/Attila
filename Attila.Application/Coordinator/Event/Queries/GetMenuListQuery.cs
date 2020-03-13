using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Event.Queries
{
    public class GetMenuListQuery : IRequest<IEnumerable<MenuVM>>
    {
        public class GetMenuListQueryHandler : IRequestHandler<GetMenuListQuery, IEnumerable<MenuVM>>
        {
            public readonly IAttilaDbContext dbContext;
            public GetMenuListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<MenuVM>> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
            {
                var _viewMenuList= await dbContext.Menus.Select(a => new MenuVM
                {
                    Description = a.Description,
                    ID = a.ID,
                    MenuCategoryID = a.MenuCategoryID,
                    Name = a.Name

                }).ToListAsync();


                return _viewMenuList;
            }
        }
    }
}
