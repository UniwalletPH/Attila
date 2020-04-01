using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class GetEventPackageQuery : IRequest<List<EventPackage>>
    {

        public class GetEventPackageQueryHandler : IRequestHandler<GetEventPackageQuery, List<EventPackage>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEventPackageQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventPackage>> Handle(GetEventPackageQuery request, CancellationToken cancellationToken)
            {
                var _viewEventPackage = await dbContext.EventPackages.ToListAsync();

                return _viewEventPackage;
            }
        }
    }
}
