using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Equipment.Commands
{
    public class UpdateEquipmentStockInventoryCommand : IRequest<bool>
    {
        private readonly EquipmentInventory myEquipmentInventory;

        public UpdateEquipmentStockInventoryCommand(EquipmentInventory myEquipmentInventory)
        {
            this.myEquipmentInventory = myEquipmentInventory;
        }

        public class UpdateEquipmentStockInventoryCommandHandler : IRequestHandler<UpdateEquipmentStockInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentStockInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateEquipmentStockInventoryCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentStock = dbContext.EquipmentsInventory.Find(request.myEquipmentInventory.ID);

                _updatedEquipmentStock.Quantity = request.myEquipmentInventory.Quantity;
                _updatedEquipmentStock.ItemPrice = request.myEquipmentInventory.ItemPrice;
                _updatedEquipmentStock.Remarks = request.myEquipmentInventory.Remarks;
                _updatedEquipmentStock.EquipmentDetailsID = request.myEquipmentInventory.EquipmentDetailsID;
                _updatedEquipmentStock.EquipmentDeliveryID = request.myEquipmentInventory.EquipmentDeliveryID;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}

