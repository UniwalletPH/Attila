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
    public class GetEventPackageListQuery : IRequest<IEnumerable<EventPackageVM>>
    {
        public class GetEventPackageListQueryHandler : IRequestHandler<GetEventPackageListQuery, IEnumerable<EventPackageVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEventPackageListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EventPackageVM>> Handle(GetEventPackageListQuery request, CancellationToken cancellationToken)
            {
                var _viewEventPackageList = await dbContext.PackageMenuDetails.Select(a => new EventPackageVM
                {
                   Code = a.Code,
                   Description = a.Description,
                   Name = a.Name,
                   RatePerHead = a.RatePerHead,
                   ID = a.ID
                   
                }).ToListAsync();

                return _viewEventPackageList;
            }
        }
    }
}
