using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetEventPackageQuery : IRequest<List<PackageDetails>>
    {

        public class GetEventPackageQueryHandler : IRequestHandler<GetEventPackageQuery, List<PackageDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEventPackageQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<PackageDetails>> Handle(GetEventPackageQuery request, CancellationToken cancellationToken)
            {
                var _viewEventPackage = await dbContext.EventsPackageDetails.ToListAsync();

                return _viewEventPackage;
            }
        }
    }
}
