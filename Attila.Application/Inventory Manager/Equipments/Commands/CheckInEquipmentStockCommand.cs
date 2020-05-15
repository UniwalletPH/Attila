using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class CheckInEquipmentStockCommand : IRequest<bool>
    {
        public EquipmentsInventoryVM MyEquipmentInventoryVM { get; set; }

        public class CheckInEquipmentStockCommandHandler : IRequestHandler<CheckInEquipmentStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public CheckInEquipmentStockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(CheckInEquipmentStockCommand request, CancellationToken cancellationToken)
            {
                var _getEquipmentStockDetails = dbContext.EquipmentInventories.Find(request.MyEquipmentInventoryVM.EquipmentDetailsID);

                if (_getEquipmentStockDetails != null)
                {
                    _getEquipmentStockDetails.Quantity += request.MyEquipmentInventoryVM.Quantity;
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
