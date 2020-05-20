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
                var _getEquipmentCheckOut = dbContext.EquipmentTracking.Find(request.MyEquipmentInventoryVM.CheckOutEquipmentID);

                if (_getEquipmentStockDetails != null)
                {
                    _getEquipmentStockDetails.Quantity += request.MyEquipmentInventoryVM.Quantity;
                    
                    EquipmentTracking _checkInRecord = new EquipmentTracking
                    {
                        EventID = request.MyEquipmentInventoryVM.EventDetailsID,
                        EquipmentID = request.MyEquipmentInventoryVM.EquipmentDetailsID,
                        InventoryManagerID = request.MyEquipmentInventoryVM.UserID,
                        Quantity = request.MyEquipmentInventoryVM.Quantity,
                        TrackingDate = DateTime.Now,
                        TrackingAction = EquipmentAction.CheckIn,
                        Remarks = request.MyEquipmentInventoryVM.Remarks,
                        CreatedOn = DateTime.Now,
                        Returned = true
                    };

                    dbContext.EquipmentTracking.Add(_checkInRecord);
                }
                else
                {
                    throw new Exception("Equipment Stock ID does not exist!");
                }

                if (_getEquipmentCheckOut != null)
                {
                    _getEquipmentCheckOut.Returned = true;
                }
                else
                {
                    throw new Exception("Check Out ID does not exist!");
                }


                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
