using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class UpdateEquipmentStockCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        public class UpdateEquipmentStockCommandHandler : IRequestHandler<UpdateEquipmentStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentStockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEquipmentStockCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentStock = dbContext.EquipmentsInventory.Find(request.ID);

                if (_updatedEquipmentStock != null)
                {
                    _updatedEquipmentStock.Quantity = request.Quantity;
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

