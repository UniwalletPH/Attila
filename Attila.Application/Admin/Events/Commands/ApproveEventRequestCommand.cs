using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Events.Commands
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
                var _toApprove = dbContext.EventDetails.Find(request.EventID);

                if (_toApprove != null)
                {
                    _toApprove.EventStatus = Status.Approved;
                    await dbContext.SaveChangesAsync();
                    return _toApprove.ID;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }          
            }
        }
    }    
}
