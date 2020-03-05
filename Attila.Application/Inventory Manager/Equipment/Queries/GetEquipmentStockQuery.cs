using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class GetEquipmentStockQuery : IRequest<IEnumerable<EquipmentsInventoryVM>>
    {
        public class GetEquipmentStockQueryHandler : IRequestHandler<GetEquipmentStockQuery, IEnumerable<EquipmentsInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<EquipmentsInventoryVM>> Handle(GetEquipmentStockQuery request, CancellationToken cancellationToken)
            {
                var _equipmentInventoryList = await dbContext.EquipmentInventories.Select(a => new EquipmentsInventoryVM
                { 
                    ID = a.ID,
                    Quantity = a.Quantity,
                    EncodingDate = a.EncodingDate,
                    ItemPrice = a.ItemPrice,
                    Remarks = a.Remarks,
                    UserID = a.UserID,
                    EquipmentDetailsID = a.EquipmentDetailsID,
                    EquipmentDeliveryID = a.EquipmentRestockID

                }).ToListAsync();

                return _equipmentInventoryList;
            }
        }
    }
}
