using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class AddEquipmentInventoryCommand : IRequest<bool>
    {
        public EquipmentsInventoryVM MyEquipmentsInventoryVM { get; set; }

        public class AddEquipmentInventoryCommandHandler : IRequestHandler<AddEquipmentInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEquipmentInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEquipmentInventoryCommand request, CancellationToken cancellationToken)
            {
                EquipmentInventory _equipmentInventory = new EquipmentInventory
                {
                    Quantity = request.MyEquipmentsInventoryVM.Quantity,
                    EncodingDate = DateTime.Now,
                    ItemPrice = request.MyEquipmentsInventoryVM.ItemPrice,
                    Remarks = request.MyEquipmentsInventoryVM.Remarks,
                    UserID = request.MyEquipmentsInventoryVM.UserID,
                    EquipmentDetailsID = request.MyEquipmentsInventoryVM.EquipmentDetailsID,
                    EquipmentRestockID = request.MyEquipmentsInventoryVM.DeliveryDetailsID
                };

                dbContext.EquipmentInventories.Add(_equipmentInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
