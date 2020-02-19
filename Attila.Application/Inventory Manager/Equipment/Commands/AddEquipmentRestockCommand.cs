using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class AddEquipmentRestockCommand : IRequest<bool>
    {
        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }

        public class AddEquipmentRestockCommandHandler : IRequestHandler<AddEquipmentRestockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEquipmentRestockCommandHandler (IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEquipmentRestockCommand request, CancellationToken cancellationToken)
            {
                EquipmentRestock _equipmentRestock = new EquipmentRestock
                {
                    DeliveryDate = request.DeliveryDate,
                    ReceiptImage = request.ReceiptImage,
                    DeliveryPrice = request.DeliveryPrice,
                    Remarks = request.Remarks
                };

                dbContext.EquipmentsRestock.Add(_equipmentRestock);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
