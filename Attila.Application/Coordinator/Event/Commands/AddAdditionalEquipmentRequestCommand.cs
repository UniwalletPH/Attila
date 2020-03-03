using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Status = Attila.Domain.Enums.Status;

namespace Attila.Application.Event.Commands
{

    public class AddAdditionalEquipmentRequestCommand : IRequest<bool>
    {
        public AdditionalEquipmentRequestListVM AdditionalEquipment { get; set; }
        public class AddAdditionalEquipmentRequestCommandHandler : IRequestHandler<AddAdditionalEquipmentRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalEquipmentRequestCommand request, CancellationToken cancellationToken)
            {
                var _additionalEquipment = new EventAdditionalEquipmentRequest
                {
                    EventDetailsID = request.AdditionalEquipment.EventDetailsID,
                    EquipmentDetailsID = request.AdditionalEquipment.EquipmentDetailsID,
                    Rate = request.AdditionalEquipment.Rate,
                    Quantity = request.AdditionalEquipment.Quantity,
                    Status = Status.Pending
                    
                };

                dbContext.EventAdditionalEquipmentRequests.Add(_additionalEquipment);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
