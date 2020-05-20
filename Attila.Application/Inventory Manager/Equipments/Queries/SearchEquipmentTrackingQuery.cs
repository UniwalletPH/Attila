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
    public class SearchEquipmentTrackingQuery : IRequest<EquipmentTrackingVM>
    {
        public int EquipmentTrackingID { get; set; }
        public class SearchEquipmentTrackingQueryHandler : IRequestHandler<SearchEquipmentTrackingQuery, EquipmentTrackingVM>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchEquipmentTrackingQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EquipmentTrackingVM> Handle(SearchEquipmentTrackingQuery request, CancellationToken cancellationToken)
            {
                var _getEquipmentTracking = dbContext.EquipmentTracking.Where(a => a.ID == request.EquipmentTrackingID)
                                                                       .Include(a => a.Event)
                                                                       .Include(a => a.Equipment)
                                                                       .SingleOrDefault();

                EquipmentTrackingVM _equipmentTracking = new EquipmentTrackingVM
                {
                    ID = _getEquipmentTracking.ID,
                    EventID = _getEquipmentTracking.EventID,
                    EquipmentID = _getEquipmentTracking.EquipmentID,
                    Event = _getEquipmentTracking.Event,
                    Equipment = _getEquipmentTracking.Equipment
                };

                return _equipmentTracking;
            }
        }
    }
}
