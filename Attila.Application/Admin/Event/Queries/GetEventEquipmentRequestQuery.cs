using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetEventEquipmentRequestQuery : IRequest<List<EventEquipmentRequest>>
    {
        public int EventID { get; set; }
        public class ViewEventEquipmentRequestQueryHandler : IRequestHandler<GetEventEquipmentRequestQuery, List<EventEquipmentRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewEventEquipmentRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventEquipmentRequest>> Handle(GetEventEquipmentRequestQuery request, CancellationToken cancellationToken)
            {

                var _eventRequestRequirements = dbContext.EventEquipmentRequest
                    .Include(a => a.EquipmentDetails)
                    .Where(a => a.EventDetailsID == (request.EventID));

                return _eventRequestRequirements.ToList();

            }
        }
    }
}
