using Atilla.Application.Interfaces;
using Atilla.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

            public Task<List<EquipmentRestockRequest>> Handle(ViewAllEquipmentRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _allRequest = dbContext.EquipmentRestockRequests.ToListAsync();

                return _allRequest;
            }
        }

    }
}
