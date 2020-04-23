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
    public class ChangeEventStatusToCompletedCommand : IRequest<bool>
    {
        public int EventID { get; set; }
        public class ChangeEventStatusToCompletedCommandHandler : IRequestHandler<ChangeEventStatusToCompletedCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public ChangeEventStatusToCompletedCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(ChangeEventStatusToCompletedCommand request, CancellationToken cancellationToken)
            {
                var _qVal = dbContext.Events
                    .Where(a => a.ID == request.EventID)
                    .SingleOrDefault();

                if (_qVal != null)
                {
                    _qVal.EventStatus = Status.Completed;
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
