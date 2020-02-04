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
    public class UpdateEquipmentStockCommand : IRequest<bool>
    {
        public int SearchedID { get; set; }
        public int NewEquipmentQuantity { get; set; }

        public class UpdateEquipmentStockCommandHandler : IRequestHandler<UpdateEquipmentStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentStockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEquipmentStockCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentStock = dbContext.EquipmentsInventory.Find(request.SearchedID);

                _updatedEquipmentStock.Quantity = request.NewEquipmentQuantity;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}

