using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class GetEquipmentStockQuery : IRequest<IEnumerable<EquipmentInventoryVM>>
    {
        public class ViewEquipmentStockQueryHandler : IRequestHandler<GetEquipmentStockQuery, IEnumerable<EquipmentInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewEquipmentStockQueryHandler(IAttilaDbContext dbContext)
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
