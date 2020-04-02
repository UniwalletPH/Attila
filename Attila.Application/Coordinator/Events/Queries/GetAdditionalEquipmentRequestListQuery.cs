using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class GetAdditionalEquipmentRequestListQuery : IRequest<IEnumerable<AdditionalEquipmentRequestListVM>>
    {
        public EventAdditionalEquipmentRequest EquipmentRequest;

        public class GetAdditionalEquipmentRequestListQueryHandler : IRequestHandler<GetAdditionalEquipmentRequestListQuery, IEnumerable<AdditionalEquipmentRequestListVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAdditionalEquipmentRequestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<AdditionalEquipmentRequestListVM>> Handle(GetAdditionalEquipmentRequestListQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalEquipment = await dbContext.EventAdditionalEquipmentRequests.Select(a => new AdditionalEquipmentRequestListVM 
                {
                    ID = a.ID,
                    EquipmentDetails = a.Equipment,
                    EquipmentDetailsID = a.EquipmentID,
                    EventDetailsID = a.EventID,
                    Quantity = a.Quantity,                 
                    Status = a.Status

                }).ToListAsync();

                return _viewAdditionalEquipment;
            }
        }
    }
}
