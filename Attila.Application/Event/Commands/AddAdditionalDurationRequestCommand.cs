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
    public class AddAdditionalDurationRequestCommand : IRequest<PackageAdditionalDurationRequest>
    {
        public AddAdditionalDurationRequestCommand()
        {

        }

        public class AddAdditionalDurationRequestCommandHandler : IRequestHandler<AddAdditionalDurationRequestCommand, PackageAdditionalDurationRequest>
        {
            private readonly IAttilaDbContext dbContext;

            public AddAdditionalDurationRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<PackageAdditionalDurationRequest> Handle(AddAdditionalDurationRequestCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
