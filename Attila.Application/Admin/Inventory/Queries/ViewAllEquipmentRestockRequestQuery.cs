using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Inventory.Queries
{
    public class ViewAllEquipmentRestockRequestQuery : IRequest<List<EquipmentRestockRequest>>

    {
        public class ViewAllEquipmentRestockRequestQueryHandler : IRequestHandler<ViewAllEquipmentRestockRequestQuery, List<EquipmentRestockRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewAllEquipmentRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            // TODO: put async await
            public Task<List<EquipmentRestockRequest>> Handle(ViewAllEquipmentRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _allRequest = dbContext.EquipmentRestockRequests.ToListAsync();

                return _allRequest;
            }
        }

    }
}
