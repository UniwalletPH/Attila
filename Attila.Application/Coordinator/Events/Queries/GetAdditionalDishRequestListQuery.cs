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
    public class GetAdditionalDishRequestListQuery : IRequest<IEnumerable<AdditionalDishVM>>
    {
        public EventAdditionalDishRequest AdditionalDish { get; set; }

        public class GetAdditionalDishRequestListQueryHandler : IRequestHandler<GetAdditionalDishRequestListQuery, IEnumerable<AdditionalDishVM>>
        {
            public readonly IAttilaDbContext dbContext;

            public GetAdditionalDishRequestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<AdditionalDishVM>> Handle(GetAdditionalDishRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalDish = await dbContext.EventAdditionalDishRequests.Select(a => new AdditionalDishVM
                {
                    ID = a.ID,
                    EventID = a.EventID,
                    Status = a.Status

                }).Include(a => a.Event.EventName)
                    .ToListAsync();

                return _viewAdditionalDish;
            }
        }
    }
}
