using Atilla.Application.Interfaces;
using Atilla.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Equipment.Commands
{
    public class RequestEquipmentDeliveryCommand : IRequest<bool>
    {
        private readonly EquipmentRestockRequest myEquipmentRestockRequest;
        public RequestEquipmentDeliveryCommand(EquipmentRestockRequest myEquipmentRestockRequest)
        {
            this.myEquipmentRestockRequest = myEquipmentRestockRequest;   
        }

        public class RequestEquipmentDeliveryCommandHandler : IRequestHandler<RequestEquipmentDeliveryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestEquipmentDeliveryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(RequestEquipmentDeliveryCommand request, CancellationToken cancellationToken)
            {
                EquipmentRestockRequest _equipmentRestockRequest = new EquipmentRestockRequest
                {
                    Quantity = request.myEquipmentRestockRequest.Quantity,
                    DateTimeRequest = DateTime.Now,
                    EquipmentDetailsID = request.myEquipmentRestockRequest.EquipmentDetailsID,
                    UserID = request.myEquipmentRestockRequest.UserID
                };

                dbContext.EquipmentRestockRequests.Add(_equipmentRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
