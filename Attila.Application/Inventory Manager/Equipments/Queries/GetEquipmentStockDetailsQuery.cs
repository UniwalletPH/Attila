using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class GetEquipmentStockDetailsQuery : IRequest<IEnumerable<EquipmentsInventoryVM>>
    {
        public class GetEquipmentStockDetailsQueryHandler : IRequestHandler<GetEquipmentStockDetailsQuery, IEnumerable<EquipmentsInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentStockDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentsInventoryVM>> Handle(GetEquipmentStockDetailsQuery request, CancellationToken cancellationToken)
            {
                List<EquipmentsInventoryVM> _equipmentStockDetailsList = new List<EquipmentsInventoryVM>();

                var _getFoodStockDetails = dbContext.EquipmentInventories.Include(a => a.Equipment);

                foreach (var item in _getFoodStockDetails)
                {
                    EquipmentsInventoryVM _equipmentStockDetails = new EquipmentsInventoryVM
                    {
                        ID = item.ID,
                        Quantity = item.Quantity,
                        EquipmentDetailsVM = item.Equipment
                    };

                    _equipmentStockDetailsList.Add(_equipmentStockDetails);
                }

                return _equipmentStockDetailsList;
            }
        }
    }
}
