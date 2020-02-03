using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class AddEquipmentInventoryCommand : IRequest<bool>
    {
        public EquipmentInventory MyEquipmentInventory { get; set; }

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
                    Quantity = request.MyEquipmentInventory.Quantity,
                    EncodingDate = DateTime.Now,
                    ItemPrice = request.MyEquipmentInventory.ItemPrice,
                    Remarks = request.MyEquipmentInventory.Remarks,
                    UserID = request.MyEquipmentInventory.UserID,
                    EquipmentDetailsID = request.MyEquipmentInventory.EquipmentDetailsID,
                    EquipmentDeliveryID = request.MyEquipmentInventory.EquipmentDeliveryID
                };

                dbContext.EquipmentsInventory.Add(_equipmentInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
