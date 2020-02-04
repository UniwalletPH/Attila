
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Inventory.Queries
{
    public class GetAllEquipmentRestockRequestQuery : IRequest<List<EquipmentRestockRequest>>

    {
        public class ViewAllEquipmentRestockRequestQueryHandler : IRequestHandler<GetAllEquipmentRestockRequestQuery, List<EquipmentRestockRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewAllEquipmentRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentRestockRequest>> Handle(GetAllEquipmentRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _allRequest = await dbContext.EquipmentRestockRequests.ToListAsync();

                return _allRequest;
            }
        }

    }
}
