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
                var _getInventoryDeliveryList = await dbContext.DeliveryDetails.Select(a => new InventoriesDeliveryVM 
                {
                    ID = a.ID,
                    DeliveryDate = a.DeliveryDate,
                    ReceiptImage = a.ReceiptImage,
                    DeliveryPrice = a.DeliveryPrice,
                    SupplierDetailsID = a.SupplierID,
                    Remarks = a.Remarks

                }).ToListAsync();

                return _getInventoryDeliveryList;
            }
        }
    }
}
