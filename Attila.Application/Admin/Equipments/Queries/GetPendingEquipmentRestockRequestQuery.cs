using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class GetPendingEquipmentRestockRequestQuery : IRequest<IEnumerable<EquipmentRequestVM>>
    {
        public class ViewPendingEquipmentRestockRequestQueryHandler : IRequestHandler<GetPendingEquipmentRestockRequestQuery, IEnumerable<EquipmentRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingEquipmentRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentRequestVM>> Handle(GetPendingEquipmentRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _listPendingRequest = new List<EquipmentRequestVM>();

                var _pendingRequest = dbContext.EquipmentRestockRequests
                    .Include(a => a.InventoryManager)
                    .Where(a => a.Status == Status.Processing);

                foreach (var item in _pendingRequest)
                {
                    var Equipments = new EquipmentRequestVM
                    {
                        ID = item.ID,
                        Quantity = item.Quantity,
                        DateTimeRequest = item.DateTimeRequest,
                        Status = item.Status,
                        User = item.InventoryManager
                    };

                    _listPendingRequest.Add(Equipments);
                }

                return _listPendingRequest;
                
            }
        }
    }
}
