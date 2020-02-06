using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetAdditionalDurationRequestListQuery : IRequest<List<PackageAdditionalDurationRequest>>
    {
        public PackageAdditionalDurationRequest AdditionalPackage { get; set; }

        public class GetAdditionalDurationReuestListQueryHandler : IRequestHandler<GetAdditionalDurationRequestListQuery, List<PackageAdditionalDurationRequest>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetAdditionalDurationReuestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<PackageAdditionalDurationRequest>> Handle(GetAdditionalDurationRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalDuration = await dbContext.PackageAdditionalDurationRequests.ToListAsync();

                return _viewAdditionalDuration;
            }
        }
    }
}
