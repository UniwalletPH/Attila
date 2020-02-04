using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class ViewAdditionalDurationRequestListQuery : IRequest<List<PackageAdditionalDurationRequest>>
    {
        public PackageAdditionalDurationRequest AdditionalPackage { get; set; }

        public class ViewAdditionalDurationReuestListQueryHandler : IRequestHandler<ViewAdditionalDurationRequestListQuery, List<PackageAdditionalDurationRequest>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewAdditionalDurationReuestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<PackageAdditionalDurationRequest>> Handle(ViewAdditionalDurationRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalDuration = await dbContext.PackageAdditionalDurationRequests.ToListAsync();

                return _viewAdditionalDuration;
            }
        }
    }
}
