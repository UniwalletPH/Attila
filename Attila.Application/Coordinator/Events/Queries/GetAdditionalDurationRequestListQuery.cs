using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class GetAdditionalDurationRequestListQuery : IRequest<IEnumerable<AdditionalDurationRequestListVM>>
    {
        public int EventID { get; set; }

        public class GetAdditionalDurationReuestListQueryHandler : IRequestHandler<GetAdditionalDurationRequestListQuery, IEnumerable<AdditionalDurationRequestListVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetAdditionalDurationReuestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<AdditionalDurationRequestListVM>> Handle(GetAdditionalDurationRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalDuration = await dbContext.EventAdditionalDurationRequests
                    .Where(a => a.EventID == request.EventID)
                    .Include(a => a.Event)
                    .Select(a => new AdditionalDurationRequestListVM 
                {
                    ID = a.ID,
                    EventDetailsID = a.EventID,
                    Duration = a.Duration,
                    
                }).ToListAsync();

                return _viewAdditionalDuration;
            }
        }
    }
}
