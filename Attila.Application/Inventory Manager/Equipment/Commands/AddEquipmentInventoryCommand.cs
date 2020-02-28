using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class AddEquipmentInventoryCommand : IRequest<bool>
    {
        public EquipmentInventoryVM EquipmentsInventoryVM { get; set; }

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
                    Quantity = request.EquipmentsInventoryVM.Quantity,
                    EncodingDate = request.EquipmentsInventoryVM.EncodingDate,
                    ItemPrice = request.EquipmentsInventoryVM.ItemPrice,
                    Remarks = request.EquipmentsInventoryVM.Remarks,
                    UserID = request.EquipmentsInventoryVM.UserID,
                    EquipmentDetailsID = request.EquipmentsInventoryVM.EquipmentDetailsID,
                    EquipmentDeliveryID = request.EquipmentsInventoryVM.EquipmentDeliveryID
                };

                dbContext.EquipmentsInventory.Add(_equipmentInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
