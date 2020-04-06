using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Events.Queries
{
    public class GetAdditionalEquipmentRequestListQuery : IRequest<List<EventAdditionalEquipmentRequest>>
    {
        public int EventID { get; set; }

        public class ViewAdditionalEquipmentRequestListQueryHandler : IRequestHandler<GetAdditionalEquipmentRequestListQuery, List<EventAdditionalEquipmentRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewAdditionalEquipmentRequestListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<EventAdditionalEquipmentRequest>> Handle(GetAdditionalEquipmentRequestListQuery request, CancellationToken cancellationToken)
            {
                var _additionalEquipments = dbContext.EventAdditionalEquipmentRequests        
                    .Where(a => a.EventID == request.EventID);

                return _additionalEquipments.ToList();
            }
        }
    }
}
