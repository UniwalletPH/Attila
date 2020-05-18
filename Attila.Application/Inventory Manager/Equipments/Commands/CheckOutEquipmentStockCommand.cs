using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class CheckOutEquipmentStockCommand : IRequest<bool>
    {
        public EquipmentsInventoryVM MyEquipmentInventoryVM { get; set; }

        public class CheckOutEquipmentStockCommandHandler : IRequestHandler<CheckOutEquipmentStockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public CheckOutEquipmentStockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(CheckOutEquipmentStockCommand request, CancellationToken cancellationToken)
            {
                bool response = new bool();

                var _getEquipmentStockDetails = dbContext.EquipmentInventories.Find(request.MyEquipmentInventoryVM.EquipmentDetailsID);

                if (_getEquipmentStockDetails != null)
                {
                    _getEquipmentStockDetails.Quantity -= request.MyEquipmentInventoryVM.Quantity;

                    EquipmentTracking _checkOutRecord = new EquipmentTracking
                    {
                        EventID = request.MyEquipmentInventoryVM.EventDetailsID,
                        EquipmentID = request.MyEquipmentInventoryVM.EquipmentDetailsID,
                        InventoryManagerID = request.MyEquipmentInventoryVM.UserID,
                        Quantity = request.MyEquipmentInventoryVM.Quantity,
                        TrackingDate = DateTime.Now,
                        TrackingAction = EquipmentAction.CheckOut,
                        Remarks = request.MyEquipmentInventoryVM.Remarks
                    };

                    dbContext.EquipmentTracking.Add(_checkOutRecord);

                    if (_getEquipmentStockDetails.Quantity > 0)
                    {
                        await dbContext.SaveChangesAsync();
                        response = true;
                    }
                    else
                    {
                        response = false;
                    }

                    return response;
                }
                else
                {
                    throw new Exception("Equipment Stock ID does not exist!");
                }
            }
        }
    }
}
