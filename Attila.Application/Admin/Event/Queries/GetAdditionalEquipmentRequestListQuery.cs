using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Equipment.Queries
{
    public class GetAdditionalEquipmentRequestListQuery : IRequest<List<PackageAdditionalEquipmentRequest>>
    {
        public int EventID { get; set; }

        public class ViewAdditionalEquipmentRequestListQueryHandler : IRequestHandler<GetAdditionalEquipmentRequestListQuery, List<PackageAdditionalEquipmentRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewAdditionalEquipmentRequestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<PackageAdditionalEquipmentRequest>> Handle(GetAdditionalEquipmentRequestListQuery request, CancellationToken cancellationToken)
            {
                var _additionalEquipments = dbContext.PackageAdditionalEquipmentRequests
                    .Include(a => a.EquipmentDetails)          
                    .Where(a => a.EventDetailsID == request.EventID);

                return _additionalEquipments.ToList();
            }
        }
    }
}
