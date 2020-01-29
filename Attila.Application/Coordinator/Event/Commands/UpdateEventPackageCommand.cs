using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Commands
{
    public class UpdateEventPackageCommand : IRequest<bool>
    {
        public UpdateEventPackageCommand()
        {

        }

        public class UpdateEventPackageCommandHandler : IRequestHandler<UpdateEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<bool> Handle(UpdateEventPackageCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
