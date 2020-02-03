using Atilla.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Food.Commands
{
    public class ApproveFoodRestockRequestCommand : IRequest<int>
    {
        // TODO: a little changes, make public property for command and query except handler - see below - then remove assignment from constructor
        // public int RequestID { get; set; }
        private readonly int RequestID;
        public ApproveFoodRestockRequestCommand(int requestID)
        {
            this.RequestID = requestID;
        }

        public class ApproveFoodRestockRequestCommandHandler : IRequestHandler<ApproveFoodRestockRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public ApproveFoodRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(ApproveFoodRestockRequestCommand request, CancellationToken cancellationToken)
            {
                // UNDONE: logic?
                throw new NotImplementedException();

            }
        }
    }
}
