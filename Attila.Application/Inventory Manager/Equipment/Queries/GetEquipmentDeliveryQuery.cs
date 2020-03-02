using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class GetEquipmentDeliveryQuery : IRequest<IEnumerable<EquipmentRestockVM>>
    {
        public class GetEquipmentDeliveryQueryHandler : IRequestHandler<GetEquipmentDeliveryQuery, IEnumerable<EquipmentRestockVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentDeliveryQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentRestockVM>> Handle(GetEquipmentDeliveryQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDeliveryList = await dbContext.EquipmentsRestock.Select(a => new EquipmentRestockVM
                {
                    ID = a.ID,
                    DeliveryDate = a.DeliveryDate,
                    ReceiptImage = a.ReceiptImage,
                    DeliveryPrice = a.DeliveryPrice,
                    Remarks = a.Remarks

                }).ToListAsync();

                return _equipmentDeliveryList;
            }
        }
    }
}
