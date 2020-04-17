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
    public class GetAdditionalEquipmentCollectionQuery : IRequest<List<AdditionalEquipmentRequestListVM>>
    {
        public int EventAdditionalEquipmentRequestID { get; set; }

        public class GetAdditionalEquipmentRequestListQueryHandler : IRequestHandler<GetAdditionalEquipmentCollectionQuery, List<AdditionalEquipmentRequestListVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAdditionalEquipmentRequestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<AdditionalEquipmentRequestListVM>> Handle(GetAdditionalEquipmentCollectionQuery request, CancellationToken cancellationToken)
            {
                var _viewAdditionalEquipment = await dbContext.EventEquipmentRequestCollections
                    .Where(a => a.EventAdditionalEquipmentRequestID == request.EventAdditionalEquipmentRequestID)
                    .Include(a => a.Equipment)
                    .Select(a => new AdditionalEquipmentRequestListVM 
                {
                    ID = a.ID,
                    EquipmentDetails = a.Equipment,
                    Quantity = a.Quantity,  

                }).ToListAsync();

                return _viewAdditionalEquipment;
            }
        }
    }
}
