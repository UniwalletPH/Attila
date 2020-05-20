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
    public class GetEquipmentTrackingCheckInQuery : IRequest<List<EquipmentTrackingVM>>
    {
        public class GetEquipmentTrackingCheckInQueryHandler : IRequestHandler<GetEquipmentTrackingCheckInQuery, List<EquipmentTrackingVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentTrackingCheckInQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EquipmentTrackingVM>> Handle(GetEquipmentTrackingCheckInQuery request, CancellationToken cancellationToken)
            {
                List<EquipmentTrackingVM> _equipmentTrackingCheckInList = new List<EquipmentTrackingVM>();

                var _getEquipmentTrackingCheckInList = dbContext.EquipmentTracking.Where(a => a.TrackingAction == EquipmentAction.CheckIn)
                                                                                  .Include(a => a.Event)
                                                                                  .Include(a => a.Equipment);

                foreach (var item in _getEquipmentTrackingCheckInList)
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

                    _equipmentTrackingCheckInList.Add(_equipmentTracking);
                }

                return _equipmentTrackingCheckInList;
            }
        }
    }
}
