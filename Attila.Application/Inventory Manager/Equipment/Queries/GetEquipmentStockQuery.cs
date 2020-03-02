using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class GetEquipmentStockQuery : IRequest<IEnumerable<EquipmentInventoryVM>>
    {
        public class GetEquipmentStockQueryHandler : IRequestHandler<GetEquipmentStockQuery, IEnumerable<EquipmentInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<EquipmentInventoryVM>> Handle(GetEquipmentStockQuery request, CancellationToken cancellationToken)
            {
                var _equipmentInventoryList = await dbContext.EquipmentsInventory.Select(a => new EquipmentInventoryVM
                { 
                    ID = a.ID,
                    Quantity = a.Quantity,
                    EncodingDate = a.EncodingDate,
                    ItemPrice = a.ItemPrice,
                    Remarks = a.Remarks,
                    UserID = a.UserID,
                    EquipmentDetailsID = a.EquipmentDetailsID,
                    EquipmentDeliveryID = a.EquipmentDeliveryID

                }).ToListAsync();

                return _equipmentInventoryList;
            }
        }
    }
}
