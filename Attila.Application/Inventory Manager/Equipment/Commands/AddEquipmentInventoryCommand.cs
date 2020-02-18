using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class AddEquipmentInventoryCommand : IRequest<bool>
    {
        public int Quantity { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public int EquipmentDeliveryID { get; set; }

        public class AddEquipmentInventorycommandHandler : IRequestHandler<AddEquipmentInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEquipmentInventorycommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEquipmentInventoryCommand request, CancellationToken cancellationToken)
            {
                EquipmentInventory _equipmentInventory = new EquipmentInventory
                {
                    Quantity = request.Quantity,
                    EncodingDate = DateTime.Now,
                    ItemPrice = request.ItemPrice,
                    Remarks = request.Remarks,
                    UserID = request.UserID,
                    EquipmentDetailsID = request.EquipmentDetailsID,
                    EquipmentDeliveryID = request.EquipmentDeliveryID
                };

                dbContext.EquipmentsInventory.Add(_equipmentInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
