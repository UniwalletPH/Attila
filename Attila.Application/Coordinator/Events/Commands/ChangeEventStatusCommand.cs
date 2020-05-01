using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
{
    public class ChangeEventStatusCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class ChangeEventStatusCommandHandler : IRequestHandler<ChangeEventStatusCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public ChangeEventStatusCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(ChangeEventStatusCommand request, CancellationToken cancellationToken)
            {
                var _event = dbContext.Events.Find(request.ID);

                _event.EventStatus = Status.ForApproval;
                await dbContext.SaveChangesAsync();


                return _event.ID;

            }
        }
    }
}
