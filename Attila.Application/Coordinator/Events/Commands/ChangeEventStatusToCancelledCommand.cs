using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
{
    public class ChangeEventStatusToCancelledCommand : IRequest<bool>
    {
        public int EventID { get; set; }
        public class ChangeEventStatusToCancelledCommandHandler : IRequestHandler<ChangeEventStatusToCancelledCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public ChangeEventStatusToCancelledCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(ChangeEventStatusToCancelledCommand request, CancellationToken cancellationToken)
            {
                var _qVal = dbContext.Events
                    .Where(a => a.ID == request.EventID)
                    .SingleOrDefault();

                if (_qVal != null)
                {
                    _qVal.EventStatus = Status.Cancelled;
                    await dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Event doesnt exist");
                }

            }
        }
    }
}
