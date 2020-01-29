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
    public class AddClientDetailsCommand : IRequest<EventClient>
    {
        public AddClientDetailsCommand()
        {

        }

        public class AddClientDetailsCommandHandler : IRequestHandler<AddClientDetailsCommand, EventClient>
        {
            private readonly IAttilaDbContext dbContext;

            public AddClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<EventClient> Handle(AddClientDetailsCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
