using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class GetInventoryQuery : IRequest<IEnumerable<InventoriesVM>>
    {
        public class GetInventoryQueryHandler : IRequestHandler<GetInventoryQuery, IEnumerable<InventoriesVM>>
        {
            private readonly IAttilaDbContext dbContext;
            private readonly IMediator mediator;
            public GetInventoryQueryHandler(IAttilaDbContext dbContext, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }
            public async Task<IEnumerable<InventoriesVM>> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
            {
                var _inventoryDataList = new List<InventoriesVM>();

                var _getInventoryData = dbContext.EquipmentInventories.Include(a => a.EquipmentDetails);

                foreach (var item in _getInventoryData)
                {
                    var _inventoryAllDetails = new InventoriesVM
                    {
                        ID = item.ID,
                        Quantity = item.Quantity,
                        EncodingDate = item.EncodingDate,
                        ItemPrice = item.ItemPrice,
                        Remarks = item.Remarks,
                        UserID = item.UserID,
                        EquipmentDetails = item.EquipmentDetails
                    };

                    _inventoryDataList.Add(_inventoryAllDetails);
                }

                return _inventoryDataList;
            }
        }
    }
}
