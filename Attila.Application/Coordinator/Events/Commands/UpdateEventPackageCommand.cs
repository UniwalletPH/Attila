﻿using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
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
                var _updatedEventPackage = dbContext.EventPackages.Find(request.UpdatePackage.ID);

                _updatedEventPackage.Description = request.UpdatePackage.Description;
                _updatedEventPackage.RatePerHead = request.UpdatePackage.RatePerHead;
                _updatedEventPackage.Name = request.UpdatePackage.Name;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
