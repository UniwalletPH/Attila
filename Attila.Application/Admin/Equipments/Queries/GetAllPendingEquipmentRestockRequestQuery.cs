using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class GetAllPendingEquipmentRestockRequestQuery : IRequest<List<EquipmentRequestVM>>
    {
        public class ViewPendingEquipmentRestockRequestQueryHandler : IRequestHandler<GetAllPendingEquipmentRestockRequestQuery, List<EquipmentRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingEquipmentRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentRequestVM>> Handle(GetAllPendingEquipmentRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _listPendingRequest = new List<EquipmentRequestVM>();

                var _pendingRequest = dbContext.EquipmentRestockRequests
                    .Include(a => a.InventoryManager)
                    .Where(a => a.Status == Status.Processing);

                foreach (var item in _pendingRequest)
                {
                    var EquipmentRestockRequestList = new EquipmentRequestVM
                    {
                        ID = item.ID,
                        DateTimeRequest = item.DateTimeRequest,
                        Status = item.Status,
                        InventoryManager = item.InventoryManager
                    };

                    _listPendingRequest.Add(EquipmentRestockRequestList);
                }

                return _listPendingRequest;
                
            }
        }
    }
}
