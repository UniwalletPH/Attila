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
    public class GetEventMenuQuery : IRequest<List<EventMenuVM>>
    {
        public int EventId { get; set; }
        public class GetEventMenuQueryHandler : IRequestHandler<GetEventMenuQuery, List<EventMenuVM>>
        {
            public readonly IAttilaDbContext dbContext;
            public GetEventMenuQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventMenuVM>> Handle(GetEventMenuQuery request, CancellationToken cancellationToken)
            {
                var _eventMenuList = new List<EventMenuVM>();
                var _eventMenuDetails = await dbContext.EventMenus
                    .Include(a => a.Event)
                    .Include(a => a.Dish.DishCategory)
                    .Where(a => a.EventID == request.EventId)
                    .ToListAsync();

                foreach (var item in _eventMenuDetails)
                {
                    var EventMenuList = new EventMenuVM
                    {
                        Dish = item.Dish,
                        DishID = item.DishID,
                        Event = item.Event,
                        EventDetailsID = item.EventID,
                        ID = item.ID
                    };
                    _eventMenuList.Add(EventMenuList);
                }
                return _eventMenuList;
            }
        }
    }
}
