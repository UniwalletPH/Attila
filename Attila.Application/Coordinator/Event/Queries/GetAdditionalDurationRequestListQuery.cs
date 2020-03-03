using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetAdditionalDurationRequestListQuery : IRequest<IEnumerable<AdditionalDurationRequestListVM>>
    {
        public EventAdditionalDurationRequest AdditionalPackage { get; set; }

        public class GetAdditionalDurationReuestListQueryHandler : IRequestHandler<GetAdditionalDurationRequestListQuery, IEnumerable<AdditionalDurationRequestListVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetAdditionalDurationReuestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<AdditionalDurationRequestListVM>> Handle(GetAdditionalDurationRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalDuration = await dbContext.EventAdditionalDurationRequests.Select(a => new AdditionalDurationRequestListVM 
                {
                    ID = a.ID,
                    EventDetailsID = a.EventDetailsID,
                    Duration = a.Duration,
                    Rate = a.Rate
                    
                }).ToListAsync();

                return _viewAdditionalDuration;
            }
        }
    }
}
