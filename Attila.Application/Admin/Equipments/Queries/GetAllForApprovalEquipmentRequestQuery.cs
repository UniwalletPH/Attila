using Attila.Application.Interfaces;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class GetAllForApprovalEquipmentRequestQuery : IRequest<List<EquipmentRequestVM>>
    {
        public class GetAllForApprovalEquipmentRequestQueryHandler : IRequestHandler<GetAllForApprovalEquipmentRequestQuery, List<EquipmentRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllForApprovalEquipmentRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentRequestVM>> Handle(GetAllForApprovalEquipmentRequestQuery request, CancellationToken cancellationToken)
            {
                var _qVal = await dbContext.EquipmentRestockRequests
                    .Include(a => a.InventoryManager)
                    .Where(a => a.Status == Status.ForApproval)                   
                    .Select(a => new EquipmentRequestVM
                    {
                        ID = a.ID,
                        DateTimeRequest = a.DateTimeRequest,
                        InventoryManager = a.InventoryManager,
                        Status = a.Status

                    }).ToListAsync();

                return _qVal;
            }
        }

    }
}
