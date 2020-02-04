using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Inventory.Queries
{
    public class ViewPendingEquipmentRestockRequestQuery : IRequest<List<EquipmentRestockRequest>>
    {
        public class ViewPendingEquipmentRestockRequestQueryHandler : IRequestHandler<ViewPendingEquipmentRestockRequestQuery, List<EquipmentRestockRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingEquipmentRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentRestockRequest>> Handle(ViewPendingEquipmentRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _pendingRequest = dbContext.EquipmentRestockRequests
                    // TODO: dont use .Equals, compare enum with enum
                    .Where(a => a.Status.Equals(0));

                return _pendingRequest.ToList();
            }
        }
    }
}
