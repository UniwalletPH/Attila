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
    public class GetAdditionalDurationRequestListQuery : IRequest<List<AdditionalDurationRequestVM>>
    {
        public int EventID { get; set; }

        public class GetAdditionalDurationReuestListQueryHandler : IRequestHandler<GetAdditionalDurationRequestListQuery, List<AdditionalDurationRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetAdditionalDurationReuestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<AdditionalDurationRequestVM>> Handle(GetAdditionalDurationRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalDuration = await dbContext.EventAdditionalDurationRequests
                    .Where(a => a.EventID == request.EventID)
                    .Include(a => a.Event)
                    .Select(a => new AdditionalDurationRequestVM 
                {
                    ID = a.ID,
                    EventDetailsID = a.EventID,
                    Duration = a.Duration,
                    
                }).ToListAsync();

                if (_viewAdditionalDuration != null)
                {
                    return _viewAdditionalDuration;
                }
                else
                {
                    return null;
                }
                
            }
        }
    }
}
