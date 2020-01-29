using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Commands
{
    public class AddAdditionalEquipmentRequestCommand : IRequest<bool>
    {
        private readonly PackageAdditionalEquipmentRequest additionalEquipment;
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
