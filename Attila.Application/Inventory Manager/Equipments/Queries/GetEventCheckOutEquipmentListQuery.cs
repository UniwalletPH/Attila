using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class GetEventCheckOutEquipmentListQuery : IRequest<List<EquipmentTrackingVM>>
    {
        public int EventDetailsID { get; set; }

        public class GetEventCheckOutEquipmentListQueryHandler : IRequestHandler<GetEventCheckOutEquipmentListQuery, List<EquipmentTrackingVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEventCheckOutEquipmentListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentTrackingVM>> Handle(GetEventCheckOutEquipmentListQuery request, CancellationToken cancellationToken)
            {
                List<EquipmentTrackingVM> _checkOutEquipmentList = new List<EquipmentTrackingVM>();

                var _getCheckOutList = dbContext.EquipmentTracking.Where(a => a.EventID == request.EventDetailsID && a.TrackingAction == EquipmentAction.CheckOut && a.Returned == false)
                                                                  .Include(a => a.Equipment)
                                                                  .Include(a => a.Event)
                                                                  .Include(a => a.InventoryManager);

                foreach (var item in _getCheckOutList)
                {
                    EquipmentTrackingVM _checkOutData = new EquipmentTrackingVM
                    {
                        ID = item.ID,
                        EventID = item.EventID,
                        EquipmentID = item.EquipmentID,
                        InventoryManagerID = item.InventoryManagerID,
                        Quantity = item.Quantity,
                        TrackingDate = item.TrackingDate,
                        TrackingAction = item.TrackingAction,
                        Remarks = item.Remarks,
                        Event = item.Event,
                        Equipment = item.Equipment,
                        InventoryManager = item.InventoryManager
                    };

                    _checkOutEquipmentList.Add(_checkOutData);
                }

                return _checkOutEquipmentList;
            }
        }
    }
}
