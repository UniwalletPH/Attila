using Atilla.Application.Interfaces;
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
        private readonly int EventID;
        public ApproveEventRequestCommand(int eventID)
        {
            this.EventID = eventID;
        }

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

                _toApprove.EventStatus = "Approved";

                await dbContext.SaveChangesAsync();

                return _toApprove.ID;
            }
        }

    }
    
}
