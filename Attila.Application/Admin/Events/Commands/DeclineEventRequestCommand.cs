using Attila.Application.Admin.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Events.Commands
{
    public class DeclineEventRequestCommand : IRequest<EventVM>
    {
        public int EventID { get; set; }
        public string AdminRemarks { get; set; }

        public class DeclineEventRequestCommandHandler : IRequestHandler<DeclineEventRequestCommand, EventVM>
        {
            private readonly IAttilaDbContext dbContext;
            public DeclineEventRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventVM> Handle(DeclineEventRequestCommand request, CancellationToken cancellationToken)
            {
                var _toDecline = dbContext.Events
                    .Where(a => a.ID == request.EventID)
                    .Include(a => a.Coordinator).SingleOrDefault();

                if (_toDecline != null)
                {
                    _toDecline.EventStatus = Status.Declined;
                    _toDecline.AdminRemarks = request.AdminRemarks;
                    await dbContext.SaveChangesAsync();

                    var _toReturn = new EventVM
                    {
                        ID = _toDecline.ID,
                        EventName = _toDecline.EventName,
                        Coordinator = _toDecline.Coordinator,
                        Result = true
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
