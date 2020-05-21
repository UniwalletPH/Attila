using System;
using System.Linq;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Events.Queries.Models;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Events.Queries
{
    public class GetEventMenuDishQuery : IRequest<IQueryable<DishBO>>
    {
        #region Public members
        public int EventID { get; set; }
        #endregion

        #region Handler
        public class GetEventMenuDishQueryHandler : RequestHandler<GetEventMenuDishQuery, IQueryable<DishBO>>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;

            public GetEventMenuDishQueryHandler(IMediator mediator, IAttilaDbContext dbContext)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
            }

            protected override IQueryable<DishBO> Handle(GetEventMenuDishQuery request)
            {
                return dbContext.EventMenus
                    .Include(a => a.Dish.DishCategory)
                    .Where(a => a.EventID == request.EventID)
                    .Select(a => new DishBO
                    {
                        ID = a.DishID,
                        Name = a.Dish.Name,
                        Description = a.Dish.Description,
                        Category = a.Dish.DishCategory.Category
                    });
            }
        }
        #endregion
    }
}