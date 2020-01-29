using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Equipment.Commands
{
    public class AddEquipmentStockInventoryCommand : IRequest<bool>
    {
        private readonly EquipmentInventory myEquipmentInventory;
        public AddEquipmentStockInventoryCommand(EquipmentInventory myEquipmentInventory)
        {
            this.myEquipmentInventory = myEquipmentInventory;
        }

        public class AddEquipmentStockInventoryCommandHandler : IRequestHandler<AddEquipmentStockInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddEquipmentStockInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEquipmentStockInventoryCommand request, CancellationToken cancellationToken)
            {
                EquipmentInventory _equipmentInventory = new EquipmentInventory
                {
                    Quantity = request.myEquipmentInventory.Quantity,
                    EncodingDate = request.myEquipmentInventory.EncodingDate,
                    ItemPrice = request.myEquipmentInventory.ItemPrice,
                    Remarks = request.myEquipmentInventory.Remarks,
                    UserID = request.myEquipmentInventory.UserID,
                };

                dbContext.EquipmentsInventory.Add(_equipmentInventory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
