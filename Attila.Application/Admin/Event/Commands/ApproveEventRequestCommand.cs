using Atilla.Application.Interfaces;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Commands
{
    public class ApproveEventRequestCommand : IRequest<int>
    {
        public int EventID { get; set; }
       
        public class ApproveEventRequestCommandHandler : IRequestHandler<ApproveEventRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public ApproveEventRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(ApproveEventRequestCommand request, CancellationToken cancellationToken)
            {
                var _toApprove = dbContext.EventsDetails.Find(request.EventID);

                // TODO: Always put checking of object is null before accessing it
                // this might throw object reference is not set to an instance of an object if _toApprove is null
                _toApprove.EventStatus = Status.Approved;

                await dbContext.SaveChangesAsync();

                return _toApprove.ID;
            }
        }

    }
    
}
