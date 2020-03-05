using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class UpdateEquipmentStockCommand : IRequest<bool>
    {
        public EquipmentsInventoryVM MyEquipmentInventoryVM { get; set; }

        public class UpdateEquipmentStockCommandHandler : IRequestHandler<UpdateEquipmentStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentStockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEquipmentStockCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentStock = dbContext.EquipmentInventories.Find(request.MyEquipmentInventoryVM.ID);

                if (_updatedEquipmentStock != null)
                {
                    _updatedEquipmentStock.Quantity = request.MyEquipmentInventoryVM.Quantity;
                    await dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Equipment Stock ID does not exist!");
                }
            }
        }
    }
}

