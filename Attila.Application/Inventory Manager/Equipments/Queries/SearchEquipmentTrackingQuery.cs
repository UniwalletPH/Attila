using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
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
                var _getEquipmentTracking = dbContext.EquipmentTracking.Find(request.EquipmentTrackingID);

                EquipmentTrackingVM _equipmentTracking = new EquipmentTrackingVM
                {
                    ID = _getEquipmentTracking.ID,
                    EventID = _getEquipmentTracking.EventID,
                    EquipmentID = _getEquipmentTracking.EquipmentID
                };

                return _equipmentTracking;
            }
        }
    }
}
