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
    public class DeleteEventPackageCommand : IRequest<bool>
    {
        public DeleteEventPackageCommand()
        {

        }

        public class DeleteEventPackageCommandHandler : IRequestHandler<DeleteEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public DeleteEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<bool> Handle(DeleteEventPackageCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
