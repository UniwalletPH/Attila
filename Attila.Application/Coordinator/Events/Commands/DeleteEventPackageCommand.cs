using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class DeleteEventPackageCommand : IRequest<bool>
    {
       public int PackageId { get; set; }

        public class DeleteEventPackageCommandHandler : IRequestHandler<DeleteEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public DeleteEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(DeleteEventPackageCommand request, CancellationToken cancellationToken)
            {
                var _packageToDelete = dbContext.PackageMenuDetails.Find(request.PackageId);
                dbContext.PackageMenuDetails.Remove(_packageToDelete);
                await dbContext.SaveChangesAsync();

                return true;

            }
        }
    }
}
