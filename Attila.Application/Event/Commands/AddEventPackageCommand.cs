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
    public class AddEventPackageCommand : IRequest<EventPackageDetails>
    {
        public AddEventPackageCommand()
        {

        }

        public class AddEventPackageCommandHandler : IRequestHandler<AddEventPackageCommand, EventPackageDetails>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<EventPackageDetails> Handle(AddEventPackageCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
