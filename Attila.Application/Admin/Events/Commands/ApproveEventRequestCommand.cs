using Attila.Application.Admin.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Admin.Events.Commands
{
    public class ApproveEventRequestCommand : IRequest<EventVM>
    {
        public int EventID { get; set; }
       
        public class ApproveEventRequestCommandHandler : IRequestHandler<ApproveEventRequestCommand, EventVM>
        {
            private readonly IAttilaDbContext dbContext;
            public ApproveEventRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventVM> Handle(ApproveEventRequestCommand request, CancellationToken cancellationToken)
            {
                var _toApprove = dbContext.Events
                    .Where(a => a.ID == request.EventID)
                    .Include(a => a.Coordinator).SingleOrDefault();

                if (_toApprove != null)
                {
                    _toApprove.EventStatus = Status.Approved;
                    await dbContext.SaveChangesAsync();

                    var _toReturn = new EventVM { 
                    
                        ID = _toApprove.ID,
                        EventName = _toApprove.EventName,
                        Coordinator = _toApprove.Coordinator
                        
                    };
                    return _toReturn;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }          
            }
        }
    }    
}
