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
    public class GetEquipmentRestockRequestDetailsQuery : IRequest<List<EquipmentCollectionVM>>
    {
        public int RequestID { get; set; }

        public class GetEquipmentRequestDetailsQueryHandler : IRequestHandler<GetEquipmentRestockRequestDetailsQuery, List<EquipmentCollectionVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEquipmentRequestDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<EquipmentCollectionVM>> Handle(GetEquipmentRestockRequestDetailsQuery request, CancellationToken cancellationToken)
            {
                
                var _collection = dbContext.EquipmentRequestCollections
                    .Where(a => a.EquipmentRestockRequestID == request.RequestID)
                    .Include(a => a.Equipment);

                var _equipmentRequests = new List<EquipmentCollectionVM>();

                foreach (var item in _collection)
                {
                    var EquipmentCollection = new EquipmentCollectionVM
                    {
                        ID = item.ID,
                        Equipment = item.Equipment,
                        Quantity = item.Quantity,
                        EstimatedPrice = item.EstimatedPrice,
                        TotalEstimatedPrice = item.Quantity*item.EstimatedPrice
                    };

                    _equipmentRequests.Add(EquipmentCollection);
                }

                return _equipmentRequests;

            }
        }
    }
}
