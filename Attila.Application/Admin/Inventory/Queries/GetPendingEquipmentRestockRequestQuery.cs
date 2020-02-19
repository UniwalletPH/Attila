
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Enums;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Inventory.Queries
{
    public class GetPendingEquipmentRestockRequestQuery : IRequest<List<EquipmentRequestVM>>
    {
        public class ViewPendingEquipmentRestockRequestQueryHandler : IRequestHandler<GetPendingEquipmentRestockRequestQuery, List<EquipmentRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingEquipmentRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentRequestVM>> Handle(GetPendingEquipmentRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _listPendingRequest = new List<EquipmentRequestVM>();

                var _pendingRequest = dbContext.EquipmentRestockRequests
                    .Include(a => a.EquipmentDetails)
                    .Include(a => a.User)
                    .Where(a => a.Status == Status.Pending);

                foreach (var item in _pendingRequest)
                {
                    var Equipments = new EquipmentRequestVM
                    {
                        ID = item.ID,
                        EquipmentDetails = item.EquipmentDetails,
                        Quantity = item.Quantity,
                        DateTimeRequest = item.DateTimeRequest,
                        Status = item.Status,
                        User = item.User
                    };

                    _listPendingRequest.Add(Equipments);
                }

                return _listPendingRequest;
                
            }
        }
    }
}
