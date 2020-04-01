using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
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
                    EquipmentDetails = a.EquipmentDetails,
                    EquipmentDetailsID = a.EquipmentDetailsID,
                    EventDetailsID = a.EventDetailsID,
                    Quantity = a.Quantity,                 
                    Status = a.Status

                }).ToListAsync();

                return _viewAdditionalEquipment;
            }
        }
    }
}
