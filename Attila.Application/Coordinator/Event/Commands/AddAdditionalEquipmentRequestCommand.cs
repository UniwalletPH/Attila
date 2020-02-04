using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Commands
{
    public class AddAdditionalEquipmentRequestCommand : IRequest<bool>
    {
        // TODO: use public property
        private readonly PackageAdditionalEquipmentRequest additionalEquipment;

        // TODO: remove constructor
        public AddAdditionalEquipmentRequestCommand(PackageAdditionalEquipmentRequest _additionalEquipment)
        {
            _additionalEquipment = additionalEquipment;
        }

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
                    EventDetailsID = request.additionalEquipment.EventDetailsID,
                    EventEquipmentsID = request.additionalEquipment.EventEquipmentsID,
                    Rate = request.additionalEquipment.Rate
                };

                dbContext.PackageAdditionalEquipmentRequests.Add(_additionalEquipment);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
