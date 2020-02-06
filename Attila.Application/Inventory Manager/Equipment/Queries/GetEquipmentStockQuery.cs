using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class GetEquipmentStockQuery : IRequest<IEnumerable<EquipmentInventory>>
    {
        public GetEquipmentStockQuery()
        {
        }

        public class ViewEquipmentStockQueryHandler : IRequestHandler<GetEquipmentStockQuery, IEnumerable<EquipmentInventory>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewEquipmentStockQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<EquipmentInventory>> Handle(GetEquipmentStockQuery request, CancellationToken cancellationToken)
            {
                var _equipmentInventoryList = await dbContext.EquipmentsInventory.ToListAsync();

                return _equipmentInventoryList;
            }
        }
    }
}
