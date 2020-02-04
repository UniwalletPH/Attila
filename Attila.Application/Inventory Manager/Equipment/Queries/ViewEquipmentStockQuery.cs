using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class ViewEquipmentStockQuery : IRequest<IEnumerable<EquipmentInventory>>
    {
        public ViewEquipmentStockQuery()
        {
        }

        public class ViewEquipmentStockQueryHandler : IRequestHandler<ViewEquipmentStockQuery, IEnumerable<EquipmentInventory>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewEquipmentStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<EquipmentInventory>> Handle(ViewEquipmentStockQuery request, CancellationToken cancellationToken)
            {
                var _equipmentInventoryList = await dbContext.EquipmentsInventory.ToListAsync();

                return _equipmentInventoryList;
            }
        }
    }
}
