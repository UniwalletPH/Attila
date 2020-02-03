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
    public class UpdateEventPackageCommand : IRequest<bool>
    {
        private readonly EventPackageDetails package;
        public UpdateEventPackageCommand(EventPackageDetails package)
        {
            this.package = package;
        }

        public class UpdateEventPackageCommandHandler : IRequestHandler<UpdateEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEventPackageCommand request, CancellationToken cancellationToken)
            {
                var _updatedEventPackage = dbContext.EventsPackageDetails.Find(request.package.ID);

                _updatedEventPackage.Description = request.package.Description;
                _updatedEventPackage.Duration = request.package.Duration;
                _updatedEventPackage.NumberOfGuest = request.package.NumberOfGuest;
                _updatedEventPackage.Rate = request.package.Rate;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
