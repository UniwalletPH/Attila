using Attila.Application.Interfaces;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// TODO why the namespace is different? I think it should be Atilla.Application.Admin.Commands
namespace Atilla.Application.Admin.Equipment.Commands
{
    public class DeclineAdditionalEquipmentRequestCommand : IRequest<int>
    {
        public int RequestID { get; set; }

        public class DeclineAdditionalEquipmentRequestCommandHandler : IRequestHandler<DeclineAdditionalEquipmentRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public DeclineAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(DeclineAdditionalEquipmentRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToDecline = dbContext.EquipmentRestockRequests.Find(request.RequestID);


                // TODO: Always put checking of object is null before accessing it
                // this might throw object reference is not set to an instance of an object if _toApprove is null
                _requestToDecline.Status = Status.Declined;

                await dbContext.SaveChangesAsync();

                return _requestToDecline.ID;

            }
        }
    }
}
