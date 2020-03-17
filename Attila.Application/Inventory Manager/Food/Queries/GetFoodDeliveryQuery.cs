using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Application.Inventory_Manager.Shared.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Food.Queries
{
    public class GetFoodDeliveryQuery : IRequest<IEnumerable<InventoriesDeliveryVM>>
    {
        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }

        public class GetFoodDeliveryQueryHandler : IRequestHandler<GetFoodDeliveryQuery, IEnumerable<InventoriesDeliveryVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetFoodDeliveryQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<InventoriesDeliveryVM>> Handle(GetFoodDeliveryQuery request, CancellationToken cancellationToken)
            {
                var _foodDeliveryList = await dbContext.DeliveryDetails.Select(a => new InventoriesDeliveryVM
                {
                    ID = a.ID,
                    DeliveryDate = a.DeliveryDate,
                    DeliveryPrice = a.DeliveryPrice,
                    ReceiptImage = a.ReceiptImage,
                    Remarks = a.Remarks

                }).ToListAsync();

                return _foodDeliveryList;
            }
        }
    }
}
