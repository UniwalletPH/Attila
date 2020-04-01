using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Shared.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class GetEquipmentDeliveryQuery : IRequest<IEnumerable<InventoriesDeliveryVM>>
    {
        public class GetEquipmentDeliveryQueryHandler : IRequestHandler<GetEquipmentDeliveryQuery, IEnumerable<InventoriesDeliveryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentDeliveryQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<InventoriesDeliveryVM>> Handle(GetEquipmentDeliveryQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDeliveryList = await dbContext.DeliveryDetails.Select(a => new InventoriesDeliveryVM
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
