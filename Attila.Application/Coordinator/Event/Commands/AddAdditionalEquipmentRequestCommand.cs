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
        // TODO: use public property
        public PackageAdditionalEquipmentRequest AdditionalEquipment { get; set; }

        // TODO: remove constructor
        public class AddAdditionalEquipmentRequestCommandHandler : IRequestHandler<AddAdditionalEquipmentRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalEquipmentRequestCommand request, CancellationToken cancellationToken)
            {
                // TODO: can't build, check first before check in.
                var _additionalEquipment = new PackageAdditionalEquipmentRequest
                {
                    EventDetailsID = request.AdditionalEquipment.EventDetailsID,
                    EventEquipmentsID = request.AdditionalEquipment.EventEquipmentsID,
                    Rate = request.AdditionalEquipment.Rate,
                    Status = Status.Pending
                    
                };

                dbContext.PackageAdditionalEquipmentRequests.Add(_additionalEquipment);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
