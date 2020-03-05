using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class GetEquipmentDeliveryQuery : IRequest<IEnumerable<EquipmentsRestockVM>>
    {
        public class GetEquipmentDeliveryQueryHandler : IRequestHandler<GetEquipmentDeliveryQuery, IEnumerable<EquipmentsRestockVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentDeliveryQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentsRestockVM>> Handle(GetEquipmentDeliveryQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDeliveryList = await dbContext.DeliveryDetails.Select(a => new EquipmentsRestockVM
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
