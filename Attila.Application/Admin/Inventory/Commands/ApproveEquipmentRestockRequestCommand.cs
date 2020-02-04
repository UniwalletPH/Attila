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
    public class ApproveEquipmentRestockRequestCommand : IRequest<int>
    {
        public int RequestID { get; set; }

        public class ApproveAdditionalEquipmentRequestCommandHandler : IRequestHandler<ApproveEquipmentRestockRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;

            public ApproveAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {

                this.dbContext = dbContext;
            
            }

            public async  Task<int> Handle(ApproveEquipmentRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToApprove = dbContext.EquipmentRestockRequests.Find(request.RequestID);

                // TODO: Always put checking of object is null before accessing it

                // this might throw object reference is not set to an instance of an object if object is null

                _requestToApprove.Status = Status.Approved;
                await dbContext.SaveChangesAsync();

                return _requestToApprove.ID;


            }
        }
    }
}
