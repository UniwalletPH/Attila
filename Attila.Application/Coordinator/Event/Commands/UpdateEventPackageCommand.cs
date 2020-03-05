using Attila.Application.Coordinator.Event.Queries;
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
    public class UpdateEventPackageCommand : IRequest<bool>
    {
        public EventPackageVM UpdatePackage { get; set; }
        public class UpdateEventPackageCommandHandler : IRequestHandler<UpdateEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEventPackageCommand request, CancellationToken cancellationToken)
            {
                var _updatedEventPackage = dbContext.PackageMenuDetails.Find(request.UpdatePackage.ID);

                _updatedEventPackage.Description = request.UpdatePackage.Description;
                _updatedEventPackage.Duration = request.UpdatePackage.Duration;
                _updatedEventPackage.RatePerHead = request.UpdatePackage.Rate;
                _updatedEventPackage.Name = request.UpdatePackage.Name;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
