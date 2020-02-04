using Atilla.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Admin.Event.Queries
{
    public class ViewEventEquipmentRequestQuery : IRequest<List<EventEquipmentRequest>>
    {
        public int EventID { get; set; }
        public class ViewEventEquipmentRequestQueryHandler : IRequestHandler<ViewEventEquipmentRequestQuery, List<EventEquipmentRequest>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewEventEquipmentRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventEquipmentRequest>> Handle(ViewEventEquipmentRequestQuery request, CancellationToken cancellationToken)
            {

                var _eventRequestRequirements = dbContext.EventEquipmentRequest
                    .Include(a => a.EquipmentDetails)
                    .Where(a => a.EventDetailsID == (request.EventID));

                return _eventRequestRequirements.ToList();

            }
        }
    }
}
