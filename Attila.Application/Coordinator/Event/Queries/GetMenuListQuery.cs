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


                var _listMenu = new List<MenuVM>();


                var _viewMenuList = dbContext.Menus
                    .Include(a => a.MenuCategory).ToList();



                foreach (var item in _viewMenuList)
                {
                    var _menuList = new MenuVM
                    {

                        MenuCategory = item.MenuCategory,
                        Name = item.Name,
                        Description  = item.Description
                    };


                    _listMenu.Add(_menuList);
                };


                return _listMenu;
            }
        }
    }
}
