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
        private readonly int PackageID;
        public DeleteEventPackageCommand(int packageID)
        {
            this.PackageID = packageID;
        }

        public class DeleteEventPackageCommandHandler : IRequestHandler<DeleteEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public DeleteEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(DeleteEventPackageCommand request, CancellationToken cancellationToken)
            {
                var _packageToDelete = dbContext.EventsPackageDetails.Find(request.PackageID);
                dbContext.EventsPackageDetails.Remove(_packageToDelete);
                await dbContext.SaveChangesAsync();

                return true;

            }
        }
    }
}
