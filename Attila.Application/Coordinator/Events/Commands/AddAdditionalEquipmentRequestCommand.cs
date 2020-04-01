using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
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
                var _additionalEquipment = new EventAdditionalEquipmentRequest
                {
                    EventDetailsID = request.AdditionalEquipment.EventDetailsID,
                    EquipmentDetailsID = request.AdditionalEquipment.EquipmentDetailsID,
                    Quantity = request.AdditionalEquipment.Quantity,
                    Status = Status.Processing               
                };

                dbContext.EventAdditionalEquipmentRequests.Add(_additionalEquipment);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
