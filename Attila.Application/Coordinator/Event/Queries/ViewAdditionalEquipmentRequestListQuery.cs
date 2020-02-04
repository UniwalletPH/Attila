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
    public class ViewAdditionalEquipmentRequestListQuery : IRequest<List<PackageAdditionalEquipmentRequest>>
    {
        public PackageAdditionalEquipmentRequest EquipmentRequest;

        public class ViewAdditionalEquipmentRequestListQueryHandler : IRequestHandler<ViewAdditionalEquipmentRequestListQuery, List<PackageAdditionalEquipmentRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewAdditionalEquipmentRequestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<PackageAdditionalEquipmentRequest>> Handle(ViewAdditionalEquipmentRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalEquipment = await dbContext.PackageAdditionalEquipmentRequests.ToListAsync();

                return _viewAdditionalEquipment;
            }
        }
    }
}
