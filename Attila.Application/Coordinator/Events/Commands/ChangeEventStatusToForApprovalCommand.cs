using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
{
    public class ChangeEventStatusToForApprovalCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class ChangeEventStatusCommandHandler : IRequestHandler<ChangeEventStatusToForApprovalCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public ChangeEventStatusCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(ChangeEventStatusToForApprovalCommand request, CancellationToken cancellationToken)
            {
                var _event = dbContext.Events.Find(request.ID);

                if (_event != null)
                {
                    _event.EventStatus = Status.ForApproval;
                    await dbContext.SaveChangesAsync();

                    return _event.ID;
                }

                else
                {
                    throw new Exception("Event doesnt exist");
                }
            }
        }
    }
}
