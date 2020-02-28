using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class GetEquipmentDeliveryQuery : IRequest<IEnumerable<EquipmentRestockRequestVM>>
    {
        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }

        public class GetEquipmentDeliveryQueryHandler : IRequestHandler<GetEquipmentDeliveryQuery, IEnumerable<EquipmentRestockRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentDeliveryQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentRestockRequestVM>> Handle(GetEquipmentDeliveryQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDeliveryList = await dbContext.EquipmentsRestock.Select(a => new EquipmentRestockRequestVM
                {
                    ID = a.ID,
                    DeliveryDate = a.DeliveryDate,
                    DeliveryPrice = a.DeliveryPrice,
                    ReceiptImage = a.ReceiptImage,
                    Remarks = a.Remarks

                }).ToListAsync();

                return _equipmentDeliveryList;
            }
        }
    }
}
