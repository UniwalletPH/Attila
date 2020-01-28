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
    public class AddEventCommand : IRequest<EventDetails>
    {
        public AddEventCommand()
        {

        }

        public class AddEventCommandHandler : IRequestHandler<AddEventCommand, EventDetails>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<EventDetails> Handle(AddEventCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
