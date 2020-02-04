using Attila.Application.Interfaces;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Equipment.Commands
{
    public class ApproveAdditionalEquipmentRequestCommand : IRequest<int>
    {
        public int RequestID { get; set; }

        public class ApproveAdditionalEquipmentRequestCommandHandler : IRequestHandler<ApproveAdditionalEquipmentRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;

            public ApproveAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {

                this.dbContext = dbContext;
            
            }

            public async  Task<int> Handle(ApproveAdditionalEquipmentRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToApprove = dbContext.EquipmentRestockRequests.Find(request.RequestID);
                _requestToApprove.Status = Status.Approved;
                await dbContext.SaveChangesAsync();

                return _requestToApprove.ID;


            }
        }
    }
}
