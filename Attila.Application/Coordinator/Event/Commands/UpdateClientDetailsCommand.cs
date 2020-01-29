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
    public class UpdateClientDetailsCommand : IRequest<bool>
    {
        public UpdateClientDetailsCommand()
        {

        }

        public class UpdateClientDetailsCommandHandler : IRequestHandler<UpdateClientDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<bool> Handle(UpdateClientDetailsCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
