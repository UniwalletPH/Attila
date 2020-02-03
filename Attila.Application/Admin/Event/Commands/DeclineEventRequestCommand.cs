using Atilla.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Commands
{
    public class DeclineEventRequestCommand : IRequest<int>
    {
        private readonly int EventID;
        public DeclineEventRequestCommand(int eventID)
        {
            this.EventID = eventID;
        }

        public class DeclineEventRequestCommandHandler : IRequestHandler<DeclineEventRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public DeclineEventRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(DeclineEventRequestCommand request, CancellationToken cancellationToken)
            {
                var _toDecline = dbContext.EventsDetails.Find(request.EventID);
                _toDecline.EventStatus = "Declined";

                await dbContext.SaveChangesAsync();

                return _toDecline.ID;
            }
        }
    }
}
