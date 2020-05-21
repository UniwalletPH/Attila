using System;
using System.Linq;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Events.Queries
{
    public class GetAdditionalDishQuery : IRequest<IQueryable<AdditionalDishVM>>
    {
        #region Public members
        public int EventID { get; set; }
        #endregion

        #region Handler
        public class GetAdditionalDishQueryHandler : RequestHandler<GetAdditionalDishQuery, IQueryable<AdditionalDishVM>>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;

            public GetAdditionalDishQueryHandler(IMediator mediator, IAttilaDbContext dbContext)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
            }

            protected override IQueryable<AdditionalDishVM> Handle(GetAdditionalDishQuery request)
            {
                return dbContext.EventDishRequestCollection
                    .Where(a => a.EventAdditionalDishRequest.EventID == request.EventID)
                    .Include(a => a.Dish)
                    .Select(a => new AdditionalDishVM
                    {
                        ID = a.ID,
                        Dish = a.Dish,
                        Quantity = a.Quantity

                    });
            }
        }
        #endregion
    }
}