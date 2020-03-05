﻿using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
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
                    EncodingDate = request.MyEquipmentsInventoryVM.EncodingDate,
                    ItemPrice = request.MyEquipmentsInventoryVM.ItemPrice,
                    Remarks = request.MyEquipmentsInventoryVM.Remarks,
                    UserID = request.MyEquipmentsInventoryVM.UserID,
                    EquipmentDetailsID = request.MyEquipmentsInventoryVM.EquipmentDetailsID,
                    EquipmentRestockID = request.MyEquipmentsInventoryVM.EquipmentDeliveryID
                };

                dbContext.EquipmentInventories.Add(_equipmentInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
