using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Attila.Application.Admin.Equipments.Commands;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class GetEquipmentRequestDetailsQuery : IRequest<EquipmentRequestVM>
    {
        public int RequestID { get; set; }
        public class GetEquipmentRequestDetailsQueryHandler : IRequestHandler<GetEquipmentRequestDetailsQuery, EquipmentRequestVM>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEquipmentRequestDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }


            public async Task<EquipmentRequestVM> Handle(GetEquipmentRequestDetailsQuery request, CancellationToken cancellationToken)
            {
                var _details = dbContext.EquipmentRestockRequests
                    .Where(a => a.ID == request.RequestID)
                    .Include(a => a.InventoryManager).SingleOrDefault();

                var _equipmentRequest = new EquipmentRequestVM
                {
                    ID = _details.ID,
                    Quantity = _details.Quantity,
                    DateTimeRequest = _details.DateTimeRequest,
                    Status = _details.Status,
                    User = _details.InventoryManager
                };

                return _equipmentRequest;


            }
        }
    }
}
