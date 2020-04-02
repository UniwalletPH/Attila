using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class GetInventoryDeliveryQuery : IRequest<IEnumerable<InventoriesDeliveryVM>>
    {
        public class GetInventoryDeliveryQueryHandler : IRequestHandler<GetInventoryDeliveryQuery, IEnumerable<InventoriesDeliveryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetInventoryDeliveryQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<InventoriesDeliveryVM>> Handle(GetInventoryDeliveryQuery request, CancellationToken cancellationToken)
            {
                List<InventoriesDeliveryVM> _inventoryList = new List<InventoriesDeliveryVM>();


                var _getInventoryDeliveryList =  dbContext.Deliveries.Include(a => a.Supplier);

                foreach (var item in _getInventoryDeliveryList)
                {
                    InventoriesDeliveryVM _inventory = new InventoriesDeliveryVM
                    {
                        ID = item.ID,
                        DeliveryDate = item.DeliveryDate,
                        ReceiptImage = item.ReceiptImage,
                        DeliveryPrice = item.DeliveryPrice,
                        SupplierID = item.SupplierID,
                        Remarks = item.Remarks,
                        Supplier = item.Supplier
                    };

                    _inventoryList.Add(_inventory);
                }

                return _inventoryList;
            }
        }
    }
}
