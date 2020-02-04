using Attila.Application.Interfaces;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Commands
{
    public class DeclineEventRequestCommand : IRequest<int>
    {
       public int EventID { get; set; }

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


                _toDecline.EventStatus = Status.Declined;

                await dbContext.SaveChangesAsync();

                return _toDecline.ID;
            }
        }
    }
}
