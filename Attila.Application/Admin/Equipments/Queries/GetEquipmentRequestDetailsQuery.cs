using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class GetEquipmentRequestDetailsQuery : IRequest<EquipmentRequestVM>
    {
        public int ID { get; set; }
        public class GetEquipmentRequestDetailsQueryHandler : IRequestHandler<GetEquipmentRequestDetailsQuery, EquipmentRequestVM>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEquipmentRequestDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EquipmentRequestVM> Handle(GetEquipmentRequestDetailsQuery request, CancellationToken cancellationToken)
            {
                var _qVal = dbContext.EquipmentRestockRequests
                    .Where(a => a.ID == request.ID)
                    .Include(a => a.InventoryManager)
                    .SingleOrDefault();

                var _requestDetails = new EquipmentRequestVM
                { 
                    ID = _qVal.ID,
                    DateTimeRequest = _qVal.DateTimeRequest,
                    InventoryManager = _qVal.InventoryManager,
                    Status = _qVal.Status,
                    Remarks = _qVal.Remarks
                };

                return _requestDetails;
            }
        }
    }
}
