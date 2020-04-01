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

namespace Attila.Application.Event.Queries
{
    public class GetEventPackageQuery : IRequest<List<PackageMenuDetails>>
    {

        public class GetEventPackageQueryHandler : IRequestHandler<GetEventPackageQuery, List<PackageMenuDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEventPackageQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<PackageMenuDetails>> Handle(GetEventPackageQuery request, CancellationToken cancellationToken)
            {
                var _viewEventPackage = await dbContext.PackageMenuDetails.ToListAsync();

                return _viewEventPackage;
            }
        }
    }
}
