using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Attila.Domain.Enums;

namespace Attila.Application.Event.Commands
{
    public class RequestEventRequirementsCommand : IRequest<bool>
    {
        public EventEquipmentRequest EventRequirementRequest { get; set; }

        public class RequestEventRequirementsCommandHandler : IRequestHandler<RequestEventRequirementsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestEventRequirementsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(RequestEventRequirementsCommand request, CancellationToken cancellationToken)
            {
                    var _eventRequirementRequest = new EventEquipmentRequest
                    {
                        EventDetailsID = request.EventRequirementRequest.EventDetailsID,
                        EquipmentDetailsID = request.EventRequirementRequest.EquipmentDetailsID,
                        Quantity = request.EventRequirementRequest.Quantity,
                        Status = Status.Pending
                    };

                    dbContext.EventEquipmentRequest.Add(_eventRequirementRequest);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
