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
    public class GetEquipmentTrackingCheckOutQuery : IRequest<List<EquipmentTrackingVM>>
    {
        public class GetEquipmentTrackingCheckOutQueryHandler : IRequestHandler<GetEquipmentTrackingCheckOutQuery, List<EquipmentTrackingVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentTrackingCheckOutQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentTrackingVM>> Handle(GetEquipmentTrackingCheckOutQuery request, CancellationToken cancellationToken)
            {
                List<EquipmentTrackingVM> _equipmentTrackingCheckOutList = new List<EquipmentTrackingVM>();

                var _getEquipmentTrackingCheckOutList = dbContext.EquipmentTracking.Where(a => a.TrackingAction == EquipmentAction.CheckOut)
                                                                                  .Include(a => a.Event)
                                                                                  .Include(a => a.Equipment);

                foreach (var item in _getEquipmentTrackingCheckOutList)
                {
                    EquipmentTrackingVM _equipmentTracking = new EquipmentTrackingVM
                    {
                        ID = item.ID,
                        EventID = item.EventID,
                        EquipmentID = item.EquipmentID,
                        Quantity = item.Quantity,
                        TrackingDate = item.TrackingDate,
                        TrackingAction = item.TrackingAction,
                        Remarks = item.Remarks,
                        Event = item.Event,
                        Equipment = item.Equipment
                    };

                    _equipmentTrackingCheckOutList.Add(_equipmentTracking);
                }

                return _equipmentTrackingCheckOutList;
            }
        }
    }
}
