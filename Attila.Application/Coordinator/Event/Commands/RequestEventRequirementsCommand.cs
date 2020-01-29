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
    public class RequestEventRequirementsCommand : IRequest<bool>
    {
        public RequestEventRequirementsCommand()
        {

        }

        public class RequestEventRequirementsCommandHandler : IRequestHandler<RequestEventRequirementsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public RequestEventRequirementsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<bool> Handle(RequestEventRequirementsCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
