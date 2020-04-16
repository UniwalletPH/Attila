using Attila.Application.Interfaces;
using Attila.Domain.Entities;
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
    public class GetAdditionalDishRequestListQuery : IRequest<List<AdditionalDishVM>>
    {
        public int EventID { get; set; }

        public class GetAdditionalDishRequestListQueryHandler : IRequestHandler<GetAdditionalDishRequestListQuery, List<AdditionalDishVM>>
        {
            public readonly IAttilaDbContext dbContext;

            public GetAdditionalDishRequestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<AdditionalDishVM>> Handle(GetAdditionalDishRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalDish = await dbContext.EventDishRequestCollection
                    .Where(a => a.AdditionalDishID == request.EventID)
                    .Include(a => a.Dish)                    
                    .Select(a => new AdditionalDishVM
                    {
                        ID = a.ID,
                        Dish = a.Dish,
                        Quantity = a.Quantity

                    })
                    .ToListAsync();

                return _viewAdditionalDish;
            }
        }
    }
}
