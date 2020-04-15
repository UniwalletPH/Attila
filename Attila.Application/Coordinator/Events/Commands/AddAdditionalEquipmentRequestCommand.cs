using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
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
                var _additionalEquipment = new EventEquipmentRequestCollection
                {
                    EquipmentID = request.AdditionalEquipment.EquipmentDetailsID,
                    EventAdditionalEquipmentRequestID = request.AdditionalEquipment.RequestID,
                    Quantity = request.AdditionalEquipment.Quantity,
                    CreatedOn = DateTime.Now
                                
                };

                dbContext.EventEquipmentRequestCollections.Add(_additionalEquipment);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
