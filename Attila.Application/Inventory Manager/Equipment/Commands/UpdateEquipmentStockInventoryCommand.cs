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
    public class UpdateEquipmentStockInventoryCommand : IRequest<bool>
    {
        private readonly int updateSearchedID;
        private readonly int newFoodStockQuantity;

        public UpdateEquipmentStockInventoryCommand(int updateSearchedID, int newFoodStockQuantity)
        {
            this.updateSearchedID = updateSearchedID;
            this.newFoodStockQuantity = newFoodStockQuantity;
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
                var _updatedEquipmentStock = dbContext.EquipmentsInventory.Find(request.updateSearchedID);

                _updatedEquipmentStock.Quantity = request.newFoodStockQuantity;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}

