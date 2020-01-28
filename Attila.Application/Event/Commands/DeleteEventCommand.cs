using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Commands
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public DeleteEventCommand()
        {

        }

        public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public DeleteEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
