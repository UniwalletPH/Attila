using Atilla.Application.Interfaces;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                _requestToDecline.Status = Status.Declined;
                await dbContext.SaveChangesAsync();

                return _requestToDecline.ID;

            }
        }
    }
}
