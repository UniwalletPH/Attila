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
    public class SearchDeliveryByIdQuery : IRequest<InventoriesDeliveryVM>
    {
        public int DeliveryID { get; set; }

        public class SearchDeliveryByIdQueryHandler : IRequestHandler<SearchDeliveryByIdQuery, InventoriesDeliveryVM>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchDeliveryByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<InventoriesDeliveryVM> Handle(SearchDeliveryByIdQuery request, CancellationToken cancellationToken)
            {
                var _getSearchedDeliveryId = dbContext.Deliveries
                    .Include(a => a.Supplier)
                    .Where(a => a.ID == request.DeliveryID)
                    .SingleOrDefault();

                InventoriesDeliveryVM _deliveryDetails = new InventoriesDeliveryVM
                {
                    ID = _getSearchedDeliveryId.ID,
                    DeliveryDate = _getSearchedDeliveryId.DeliveryDate,
                    ReceiptImage = _getSearchedDeliveryId.ReceiptImage,
                    DeliveryPrice = _getSearchedDeliveryId.DeliveryPrice,
                    Remarks = _getSearchedDeliveryId.Remarks,
                    Supplier = _getSearchedDeliveryId.Supplier,
                   
                };

                return _deliveryDetails;
            }
        }
    }
}
